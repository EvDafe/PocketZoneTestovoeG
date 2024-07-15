using UnityEngine;
using UnityEngine.UI;

namespace Assets.CodeBase.GameLogic.Mutant
{
    public class MutantHealthBar : MonoBehaviour
    {
        [SerializeField] private Image _image;
        [SerializeField] private Mutant _mutant;

        private MutantHealth _mutantHealth;

        private void Awake() => 
            _mutant.Initialized += OnInitialize;

        private void OnInitialize()
        {
            _mutantHealth = _mutant.Health;
            _mutantHealth.DamageTaken += UpdateBar;
        }

        private void UpdateBar() =>
            _image.fillAmount = _mutantHealth.CurrentHealth / _mutantHealth.MaxHealth;
    }
}
