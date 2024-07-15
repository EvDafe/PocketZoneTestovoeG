using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Infrastructure
{
    public class GameSceneBootstrap : MonoBehaviour
    {
        [SerializeField] private bool _desktopInput = false;
        [SerializeField] private Joystick _joystick;
        [SerializeField] private Button _interactiveButton;
        [SerializeField] private Button _jumpButton;


        private void Awake()
        {
            InitializeMovement();   
        }

        private void InitializeMovement()
        {
        }
    }
}
