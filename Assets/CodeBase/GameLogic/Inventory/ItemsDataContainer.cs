using Assets.Scripts.ServicesScripts;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.CodeBase.GameLogic.Inventory
{
    public class ItemsDataContainer : MonoBehaviour
    {
        [SerializeField] private List<ItemData> _itemDatas = new();

        private InventoryService _inventoryService;

        public List<ItemData> ItemDatas => _itemDatas;
        public event Action InventoryChanged;
        public event Action<ItemData> ItemUsed;

        private void Awake()
        {
            _inventoryService = Services.Container.Get<InventoryService>();
            if (_itemDatas.Count != GetItemsCount())
                throw new System.InvalidOperationException();
            InitializeDatas();
        }

        private void InitializeDatas()
        {
            foreach(var data in _itemDatas)
                data.Count = GetItemCount(data.Type);
        }

        public int GetItemCount(ItemType type) =>
            _inventoryService.GetItemCount(type);

        public int GetItemsCount() =>
            _inventoryService.GetItemsCount();

        public void DeleteItem(ItemType type)
        {
            Debug.Log("DeleteItem");
            _inventoryService.SetItemCount(type, 0);
            GetItemData(type).Count = 0;
            _inventoryService.Save();
            InventoryChanged?.Invoke();
        }

        public ItemData GetItemData(ItemType type) =>
            _itemDatas.Where(x => x.Type ==type).First();

        public void UseItem(ItemType type) =>
            ItemUsed?.Invoke(GetItemData(type));

        public void AddItem(ItemType itemType)
        {
            var count = _inventoryService.GetItemCount(itemType) + 1;
            _inventoryService.SetItemCount(itemType, count);
            GetItemData(itemType).Count = count;
            _inventoryService.Save();
            InventoryChanged?.Invoke();
        }

        public void MinusItem(ItemType itemType)
        {
            var count = _inventoryService.GetItemCount(itemType) - 1;
            _inventoryService.SetItemCount(itemType, count);
            GetItemData(itemType).Count = count;
            _inventoryService.Save();
            InventoryChanged?.Invoke();
        }
    }
}
