using Leopotam.Ecs;
using UnityEngine;

namespace JamBCD {
    public class PlayerStandingMoveSystem : IEcsRunSystem {
        private EcsFilter<Player, InputControl, Grounded> filter;
        private Configuration _config;
        private Vector3 velocity;

        public void Run() {
            foreach (var i in filter) {
                ref var player = ref filter.Get1(i);

                if (player.WantDash && player.MoveDir != Vector3.zero) {
                    player.TargetFOV = 80f;
                    ref var dashing = ref filter.GetEntity(i).Get<Dashing>();
                    dashing.DashingElapsed = _config.DashDuration;
                    filter.GetEntity(i).Get<Dashing>().DashDir = player.MoveDir;
                    filter.GetEntity(i).Del<InputControl>();
                }

                 
                if (player.MoveDir == Vector3.zero) {
                    if ((Vector3.zero - player.CharacterVelocity).sqrMagnitude <= 0.01f) {
                        player.CharacterVelocity = Vector3.zero;
                        continue;
                    }
                    player.MoveDir = (Vector3.zero - player.CharacterVelocity).normalized;
                }
                player.CharacterVelocity += (player.GroundAcceleration * player.MoveDir - Vector3.up * 10f) * Time.deltaTime;
                player.CharacterVelocity = Vector3.ClampMagnitude(player.CharacterVelocity, player.CurrentMaxSpeedOnGround);

                player.TargetHeight = player.WantCrouch ? 1f : 2f;
            }
        }
    }
}