using Assets.CodeBase.GameLogic.Inventory;
using Assets.CodeBase.GameLogic.Yes;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.CodeBase.GameLogic.PlayerLogic
{
    public class PlayerWeapon : ITickable
    {
        private readonly Button _fireButton;
        private readonly WeaponView _weaponView;
        private readonly ItemsDataContainer _itemsDataContainer;

        private WeaponData _currentWeaponData;
        private float _currentWeaponCooldown;

        public PlayerWeapon(Button fireButton, WeaponView weaponView, ItemsDataContainer itemsDataContainer)
        {
            _fireButton = fireButton;
            _weaponView = weaponView;
            _itemsDataContainer = itemsDataContainer;
            _fireButton.onClick.AddListener(Fire);
        }

        public void Tick(float delta) => 
            _currentWeaponCooldown -= delta;

        private void Fire()
        {
            if(_currentWeaponCooldown <= 0 && _currentWeaponData != null && _currentWeaponData.Count != 0 && _itemsDataContainer.GetItemCount(ItemType.Ammo545x39) != 0)
            {
                var bullet = GameObject.Instantiate(_currentWeaponData.Bullet, _weaponView.transform.position, Quaternion.identity);
                bullet.Initialize(_currentWeaponData.Damage);
                _currentWeaponCooldown = _currentWeaponData.FireSpeed;
                _itemsDataContainer.MinusItem(ItemType.Ammo545x39);
            }
        }

        public void Use(WeaponData weaponData)
        {
            _currentWeaponCooldown = 0;
            _currentWeaponData = weaponData;
            _weaponView.SetView(_currentWeaponData.Sprite);
        }
    }
}
