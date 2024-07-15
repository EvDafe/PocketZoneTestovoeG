using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Assets.CodeBase.GameLogic.Inventory
{
    public class InventoryCanvas : MonoBehaviour
    {
        [SerializeField] private InventoryCell _inventoryCellPrefab;
        [SerializeField] private Transform _root;

        private ItemsDataContainer _itemsDataContainer;
        private List<InventoryCell> _spawnedCells = new();

        [Inject]
        private void Construct(ItemsDataContainer itemsDataContainer) => 
            _itemsDataContainer = itemsDataContainer;

        private void Awake() => 
            Close();

        private void OnEnable() => 
            _itemsDataContainer.InventoryChanged += UpdateView;

        private void OnDisable() => 
            _itemsDataContainer.InventoryChanged -= UpdateView;

        public void Open()
        {
            gameObject.SetActive(true);
            UpdateView();
        }

        public void Close() => 
            gameObject.SetActive(false);

        private void UpdateView()
        {
            ClearView();
            for (int i = 0; i < _itemsDataContainer.GetItemsCount(); i++)
            {
                if (_itemsDataContainer.GetItemCount(_itemsDataContainer.ItemDatas[i].Type) == 0)
                    continue;
                var cell = Instantiate(_inventoryCellPrefab, _root);
                cell.Initialize(_itemsDataContainer.ItemDatas[i], _itemsDataContainer);
                _spawnedCells.Add(cell);
            }
        }

        private void ClearView()
        {
            _spawnedCells.ForEach(x => Destroy(x.gameObject));
            _spawnedCells.Clear();
        }
    }
}
