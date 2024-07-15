using Assets.Scripts.ServicesScripts;
using Assets.Scripts.ServicesScripts.Progress;
using System;

namespace Assets.CodeBase.GameLogic.Inventory
{
    public class InventoryService : IService
    {
        private readonly LoadProgressService _progress;

        public InventoryService(LoadProgressService progress) => 
             _progress = progress;


        public int GetItemCount(ItemType type) =>
            _progress.Progress.Items[type];

        public int GetItemsCount() =>
            _progress.Progress.Items.Count;

        public void SetItemCount(ItemType type, int count)
        {
            if (count < 0)
                throw new ArgumentException("Невозможно", nameof(count));
            _progress.Progress.Items[type] = count;
        }

        public void Save() => 
            _progress.Save();
    }
}
