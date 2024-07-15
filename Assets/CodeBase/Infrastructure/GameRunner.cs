using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Infrastructure
{
    public class GameRunner : MonoBehaviour
    {
        private void Awake()
        {
            var bootstraper = FindObjectOfType<GlobalBootstrap>();
            if (bootstraper == null)
                SceneManager.LoadScene("BootstrapScene");
        }
    }
}
