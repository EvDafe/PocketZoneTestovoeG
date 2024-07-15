using Assets.CodeBase.GameLogic.Inventory;
using Assets.CodeBase.GameLogic.PlayerLogic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Assets.Scripts.Infrastructure
{
    public class GameSceneInstaller : MonoInstaller
    {
        [SerializeField] private Joystick _joystick;
        [SerializeField] private Player _player;
        [SerializeField] private ItemsDataContainer _itemsDataContainer;
        [SerializeField] private Button _fireButton;

        public override void InstallBindings()
        {
            Container.Bind<Joystick>().FromInstance(_joystick).NonLazy();
            Container.Bind<Button>().FromInstance(_fireButton).NonLazy();
            Container.Bind<Player>().FromInstance(_player).NonLazy();
            Container.Bind<ItemsDataContainer>().FromInstance(_itemsDataContainer).NonLazy();
        }
    }
}