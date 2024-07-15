using Assets.CodeBase.GameLogic.PlayerLogic;
using Assets.CodeBase.GameLogic.Yes;
using Assets.Scripts.Infrastructure;
using Assets.Scripts.Infrastructure.States;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.CodeBase.GameLogic.Mutant
{
    public class MutantStateMachine : StateMachine, ITickable
    {
        public MutantStateMachine(Mutant mutant, Player player, PlayerTrigger fieldOfView, PlayerTrigger attackRange)
        {
            _states = new Dictionary<Type, IExitableState>()
            {
                [typeof(WaitPlayerState)] = new WaitPlayerState(fieldOfView, this),
                [typeof(MoveToPlayerState)] = new MoveToPlayerState(player, this, mutant, attackRange, fieldOfView),
                [typeof(AttackPlayerState)] = new AttackPlayerState(mutant, attackRange, player, this),
            };
        }

        public void Tick(float delta)
        {
            if (_currentState is ITickable)
            {
                var tickable = (ITickable)_currentState;
                tickable.Tick(delta);
            }
        }
    }
}
