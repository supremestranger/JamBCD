using Leopotam.Ecs;
using UnityEngine;

namespace JamBCD
{
    public class PlayerApplyMoveSystem : IEcsRunSystem
    {
        private EcsFilter<Player> _players;
        
        public void Run()
        {
            foreach (var i in _players)
            {
                _players.Get1(i).PlayerView.Controller.Move(_players.Get1(i).CharacterVelocity * Time.deltaTime);
            }
        }
    }
}