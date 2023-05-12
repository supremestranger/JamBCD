using Components;
using Leopotam.Ecs;
using UnityComponents;

namespace JamBCD {
    public class PlayerGroundCheckSystem : IEcsRunSystem {
        private readonly EcsFilter<Player> _players = default;

        public void Run() {
            foreach (var i in _players) {
                ref var player = ref _players.Get1(i);

                if (player.PlayerView.IsGrounded()) {
                    _players.GetEntity(i).Get<Grounded>();
                    _players.GetEntity(i).Del<InAir>();
                }
                else {
                    _players.GetEntity(i).Get<InAir>();
                    _players.GetEntity(i).Del<Grounded>();
                }
            }
        }
    }
}