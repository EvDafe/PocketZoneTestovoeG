using Assets.CodeBase.GameLogic.PlayerLogic;
using System.Linq;
using UnityEngine;
using Zenject;

namespace Assets.CodeBase.GameLogic.Test
{
    public class TestPlayerDamager : MonoBehaviour
    {
        private Player _player;

        [Inject]
        private void Construct(Player player) =>
            _player = player;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
                _player.Health.TakeDamage(10);

            if (Input.GetKeyDown(KeyCode.M))
                FindObjectsByType<Mutant.Mutant>(0).ToList().ForEach(x => x.Health.TakeDamage(100000));

            if (Input.GetKeyDown(KeyCode.H))
                FindObjectsByType<Mutant.Mutant>(0).ToList().ForEach(x => x.Health.TakeDamage(10));
        }
    }
}
