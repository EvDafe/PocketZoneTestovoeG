using UnityEngine;

namespace Assets.CodeBase.GameLogic.Inventory
{
    [CreateAssetMenu(fileName = "WeaponData", menuName = "Inventory/WeaponData", order = 51)]
    public class WeaponData : ItemData
    {
        public float Damage;
        public float FireSpeed;
        public Bullet Bullet;
    }
}
