using Leopotam.Ecs;
using UnityEngine;

namespace JamBCD {
    public class PlayerAnalyzeInputSystem : IEcsRunSystem {
        private EcsFilter<Player> filter;
        private Vector3 _direction;
        private float _backSpeed;
        
        public void Run() {
            foreach (var i in filter) {
                ref var player = ref filter.Get1(i);

                player.MoveDir = (player.MoveInput.x * player.PlayerView.Transform.right +
                                  player.MoveInput.z * player.PlayerView.Transform.forward).normalized;
                //var transform = player.mainCamera.transform;
                //player.cameraDir = (playerInput.moveInput.x * transform.right +
                //                    playerInput.moveInput.z * transform.forward).normalized;

                if (player.WantJump) {
                    filter.GetEntity(i).Get<TryJump>().Timer = 0.2f;
                }
            }
        }
    }
}