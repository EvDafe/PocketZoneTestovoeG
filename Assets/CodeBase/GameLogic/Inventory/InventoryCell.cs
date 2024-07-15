using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.CodeBase.GameLogic.Inventory
{
    public class InventoryCell : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private TMP_Text _itemCountText;
        [SerializeField] private Button _useButton;
        [SerializeField] private Button _deleteButton;
        [SerializeField] private Image _itemIcon;

        private ItemData _itemData;
        private ItemsDataContainer _itemsDataContainer;

        public void Initialize(ItemData itemData, ItemsDataContainer itemsDataContainer)
        {
            _itemsDataContainer = itemsDataContainer;
            SetButtonsActive(true);
            _itemData = itemData;
            if (_itemData.Count == 0)
                _itemCountText.text = string.Empty;
            else 
                _itemCountText.text = _itemData.Count.ToString();

            _itemIcon.sprite = _itemData.Sprite;
            _useButton.onClick.AddListener(UseItem);
            _deleteButton.onClick.AddListener(DeleteItem);
            SetButtonsActive(false);
        }

        private void DeleteItem() => 
            _itemsDataContainer.DeleteItem(_itemData.Type);

        private void UseItem() => 
            _itemsDataContainer.UseItem(_itemData.Type);

        public void OnPointerClick(PointerEventData eventData) => 
            SetButtonsActive(true);

        private void SetButtonsActive(bool active)
        {
            _useButton.gameObject.SetActive(active);
            _deleteButton.gameObject.SetActive(active);
        }
    }
}
