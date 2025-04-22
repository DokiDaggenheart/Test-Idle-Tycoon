using Assets.Scripts.Inventory;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.UI.Inventory
{
    public class InventoryView : MonoBehaviour
    {
        [SerializeField] private GameObject panel;
        [SerializeField] private Transform contentRoot;
        [SerializeField] private ItemSlotView itemViewPrefab;
        [SerializeField] private float animationDuration = 0.5f;

        private RectTransform _rectTransform;
        private Vector2 _shownPosition;
        private Vector2 _hiddenPosition;
        private Coroutine _currentAnimation;
        private bool _isVisible;
        private Action<ItemData> _onEquip;
        private Action<ItemData> _onCraft;

        public void Init(Action<ItemData> onEquip, Action<ItemData> onCraft)
        {
            _onEquip = onEquip;
            _onCraft = onCraft;

            _rectTransform = panel.GetComponent<RectTransform>();
            _shownPosition = Vector2.zero;
            _hiddenPosition = new Vector2(0, -_rectTransform.rect.height);

            _rectTransform.anchoredPosition = _hiddenPosition;
            _isVisible = false;
        }

        public void Toggle()
        {
            if (_isVisible)
                Hide();
            else
                Show();
        }

        private void Show()
        {
            if (_currentAnimation != null)
                StopCoroutine(_currentAnimation);

            _currentAnimation = StartCoroutine(AnimatePanel(_rectTransform.anchoredPosition, _shownPosition));
            _isVisible = true;
        }

        private void Hide()
        {
            if (_currentAnimation != null)
                StopCoroutine(_currentAnimation);

            _currentAnimation = StartCoroutine(AnimatePanel(_rectTransform.anchoredPosition, _hiddenPosition));
            _isVisible = false;
        }

        private IEnumerator AnimatePanel(Vector2 start, Vector2 end, Action onComplete = null)
        {
            float elapsed = 0f;

            while (elapsed < animationDuration)
            {
                elapsed += Time.deltaTime;
                float t = elapsed / animationDuration;
                t = 1 - Mathf.Pow(1 - t, 3);

                _rectTransform.anchoredPosition = Vector2.Lerp(start, end, t);
                yield return null;
            }

            _rectTransform.anchoredPosition = end;
            _currentAnimation = null;
            onComplete?.Invoke();
        }

        public void SetItems(List<ItemData> items)
        {
            foreach (Transform child in contentRoot)
                Destroy(child.gameObject);

            foreach (var item in items)
            {
                var view = Instantiate(itemViewPrefab, contentRoot);
                view.Setup(item, _onEquip, _onCraft);
            }
        }
    }
}