using Assets.CodeBase.GameLogic.Inventory;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Assets.CodeBase.GameLogic.PlayerLogic
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private float _maxHealth;
        [SerializeField] private float _speed;
        [SerializeField] private WeaponView _weaponView;

        private PlayerWeapon _weapon;
        private PlayerSuit _suit;
        private PlayerHealth _health;
        private PlayerMovement _playerMovement;
        private ItemUser _itemUser;

        private Joystick _joystick;
        private Button _fireButton;
        private ItemsDataContainer _itemsDataContainer;

        public PlayerHealth Health => _health;

        [Inject]
        private void Contruct(Joystick joystick, Button fireButton, ItemsDataContainer itemsDataContainer)
        {
            _fireButton = fireButton;
            _joystick = joystick;
            _itemsDataContainer = itemsDataContainer;
        }

        private void Awake()
        {
            _weapon = new(_fireButton, _weaponView, _itemsDataContainer);
            _suit = new();
            _itemUser = new(_weapon, _suit);
            _health = new(_maxHealth);
            _playerMovement = new(transform, _speed, _joystick);
            _health.Dead += Death;
            _itemsDataContainer.ItemUsed += UseItem;
        }

        private void Death() => 
            Destroy(gameObject);

        private void UseItem(ItemData data) =>
            _itemUser.Use(data);

        private void FixedUpdate()
        {
            _playerMovement.Tick(Time.fixedDeltaTime);
            _weapon.Tick(Time.fixedDeltaTime);
        }
    }
}
