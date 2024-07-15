using Assets.CodeBase.GameLogic.Inventory;

namespace Assets.CodeBase.GameLogic.PlayerLogic
{
    public class ItemUser
    {
        private readonly PlayerWeapon _weapon;
        private readonly PlayerSuit _suit;

        public ItemUser(PlayerWeapon weapon, PlayerSuit suit)
        {
            _weapon = weapon;
            _suit = suit;
        }

        public void Use(ItemData itemData)
        {
            if (itemData is WeaponData)
                _weapon.Use(itemData as WeaponData);
            else if (itemData is SuitData)
                _suit.Use(itemData as SuitData);
        }
    }
}
