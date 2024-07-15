using UnityEngine;

namespace Assets.CodeBase.GameLogic.Inventory
{
    [CreateAssetMenu(fileName = "ItemData", menuName = "Inventory/ItemData", order = 51)]
    public class ItemData : ScriptableObject
    {
        public Sprite Sprite;
        public ItemType Type;
        public int Count;
    }
}
