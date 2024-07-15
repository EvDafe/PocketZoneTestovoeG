using Assets.Scripts.ServicesScripts.Progress;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.CodeBase.GameLogic.Mutant
{
    [RequireComponent(typeof(Mutant))]
    public class MutantDeathView : MonoBehaviour
    {
        [SerializeField] private Mutant _mutant;
        [SerializeField] private List<GameObject> _corpses = new();

        private void OnValidate() => 
            _mutant ??= GetComponent<Mutant>();

        private void Start() => 
            _mutant.Dead += SpawnCorpse;

        private void SpawnCorpse()
        {
            foreach(var corp in _corpses)
                Instantiate(corp, transform.position.AddRandomOffset(0.4f), Quaternion.identity);
        }
    }
}
