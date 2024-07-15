using Assets.CodeBase.GameLogic.Inventory;
using Assets.CodeBase.GameLogic.PlayerLogic;
using Assets.Scripts.ServicesScripts.Progress;
using UnityEngine;
using Zenject;

namespace Assets.CodeBase.GameLogic.Mutant
{
    public class MutantSpawner : MonoBehaviour
    {
        [SerializeField] private Mutant _mutantPrefab;

        private Player _player;
        private ItemsDataContainer _itemsDataContainer;

        [Inject]
        private void Construct(Player player, ItemsDataContainer itemsDataContainer)
        {
            _itemsDataContainer = itemsDataContainer;
            _player = player;
        }

        private void Awake()
        {
            SpawnMutants();
        }

        private void SpawnMutants()
        {
            for(int i = 0; i < 3; i++)
            {
                var mutant = Instantiate(_mutantPrefab, Vector3.zero.AddRandomOffset(10), Quaternion.identity);
                mutant.Initialize(_player, _itemsDataContainer);
            }
        }
    }
}
