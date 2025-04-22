using System.Collections;
using UnityEngine;

namespace Assets.Scripts.UI.Market
{
    public class MarketController : MonoBehaviour
    {
        private MarketModel _model;
        private MarketView _view;

        private bool _isOpen = false;

        private void Awake()
        {
            _model = new MarketModel();
            _view = new MarketView(gameObject, this);
        }

        public void ToggleMarket()
        {
            if (_isOpen)
                _view.HidePanel();
            else
                _view.ShowPanel();

            _isOpen = !_isOpen;
        }
    }
}