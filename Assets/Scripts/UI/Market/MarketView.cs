using System.Collections;
using UnityEngine;

namespace Assets.Scripts.UI.Market
{
    public class MarketView
    {
        private GameObject _panel;
        private RectTransform _rectTransform;
        private MonoBehaviour _coroutineRunner;

        private Vector2 _shownPosition;
        private Vector2 _hiddenPosition;
        private float _animationDuration = 0.5f;

        private Coroutine _currentAnimation;

        public MarketView(GameObject panel, MonoBehaviour coroutineRunner)
        {
            _panel = panel;
            _rectTransform = panel.GetComponent<RectTransform>();
            _coroutineRunner = coroutineRunner;

            _shownPosition = Vector2.zero;
            _hiddenPosition = new Vector2(0, -_rectTransform.rect.height);

            _rectTransform.anchoredPosition = _hiddenPosition;
        }

        public void ShowPanel()
        {
            StartAnimation(_rectTransform.anchoredPosition, _shownPosition);
        }

        public void HidePanel()
        {
            StartAnimation(_rectTransform.anchoredPosition, _hiddenPosition);
        }

        private void StartAnimation(Vector2 start, Vector2 end)
        {
            if (_currentAnimation != null)
                _coroutineRunner.StopCoroutine(_currentAnimation);

            _currentAnimation = _coroutineRunner.StartCoroutine(AnimatePanel(start, end));
        }

        private IEnumerator AnimatePanel(Vector2 start, Vector2 end)
        {
            float elapsed = 0f;

            while (elapsed < _animationDuration)
            {
                elapsed += Time.deltaTime;
                float t = elapsed / _animationDuration;
                t = 1 - Mathf.Pow(1 - t, 3);

                _rectTransform.anchoredPosition = Vector2.Lerp(start, end, t);
                yield return null;
            }

            _rectTransform.anchoredPosition = end;

            _currentAnimation = null;
        }
    }
}