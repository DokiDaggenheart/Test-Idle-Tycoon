using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class LoadingCircle : MonoBehaviour
    {
        public float loadDuration = 2f;

        private Image _loadingImage;
        private float _timer;
        private bool _isLoading;

        private void Awake()
        {
            _loadingImage = GetComponentInChildren<Image>();
            _loadingImage.fillAmount = 0f;
        }

        public void StartLoading(float duration)
        {
            loadDuration = duration;
            _timer = 0f;
            _isLoading = true;
            if (_loadingImage != null)
                _loadingImage.fillAmount = 0f;
        }

        void Update()
        {
            if (_loadingImage == null || !_isLoading) return;

            if (_timer < loadDuration)
            {
                _timer += Time.deltaTime;
                float fill = Mathf.Clamp01(_timer / loadDuration);
                _loadingImage.fillAmount = fill;
                if (_loadingImage.fillAmount == 1f)
                    Reload();
            }
        }
        
        private void Reload()
        {
            _isLoading = false;
            _loadingImage.fillAmount = 0f;
        }
    }
}