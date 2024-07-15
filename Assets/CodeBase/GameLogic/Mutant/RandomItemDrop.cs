using Assets.CodeBase.GameLogic.Inventory;
using Assets.CodeBase.GameLogic.PlayerLogic;
using UnityEngine;

namespace Assets.CodeBase.GameLogic.Mutant
{
    public class RandomItemDrop : MonoBehaviour
    {
        [SerializeField] private PlayerTrigger _trigger;

        private ItemsDataContainer _itemsDataContainer;

        internal void Initialize(ItemsDataContainer itemsDataContainer) => 
            _itemsDataContainer = itemsDataContainer;

        private void Awake() => 
            _trigger.PlayerEntered += OnPlayerEnter;

        private void OnPlayerEnter(Player obj)
        {
            _itemsDataContainer.AddItem((ItemType)Random.Range(0, _itemsDataContainer.ItemDatas.Count));
            Destroy(gameObject);
        }
    }
}
