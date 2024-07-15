using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Infrastructure
{
    public class LoadingCurtain : MonoBehaviour
    {
        [SerializeField] private CanvasGroup _curtain;

        private void Awake()
        {
            DontDestroyOnLoad(this);
            Hide();
        }

        public void Show()
        {
            _curtain.gameObject.SetActive(true);
            _curtain.alpha = 1;
        }

        public void Hide() => 
            StartCoroutine(FadeIn());

        private IEnumerator FadeIn()
        {
            while(_curtain.alpha > 0)
            {
                yield return new WaitForSeconds(0.03f);
                _curtain.alpha -= 0.03f;
            }
            _curtain.gameObject.SetActive(false);
        }
    }
}
