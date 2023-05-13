using Components;
using Leopotam.Ecs;
using UnityComponents;
using UnityEngine;

namespace JamBCD
{
    public class PlayerAirMoveSystem : IEcsRunSystem
    {
        private EcsFilter<Player, InAir> filter;
        private Configuration _config;

        public void Run()
        {
            foreach (var i in filter)
            {
                ref var player = ref filter.Get1(i);
                
                if (player.WantDash && player.MoveDir != Vector3.zero)
                {
                    player.TargetFOV= _config.DashFOV;
                    ref var dashing = ref filter.GetEntity(i).Get<Dashing>();
                    dashing.DashingElapsed = _config.DashDuration;
                    filter.GetEntity(i).Get<Dashing>().DashDir = player.MoveDir;
                    filter.GetEntity(i).Del<InputControl>();
                }

                player.CharacterVelocity = Vector3.Lerp(player.CharacterVelocity,
                    player.CurrentMaxSpeedInAir * player.MoveDir, 1f * Time.deltaTime);
                var verticalVelocity = player.CharacterVelocity.y;
                // if (Physics.CapsuleCast(transform.position + (transform.up * movable.MyController.radius), transform.position + (transform.up * (movable.MyController.height - movable.MyController.radius)), movable.MyController.radius, Vector3.up, 0.02f))
                // {
                //     verticalVelocity = -1 * Mathf.Abs(verticalVelocity);
                // }
                var horizontalVelocity = Vector3.ProjectOnPlane(player.CharacterVelocity, Vector3.up);
                if (filter.GetEntity(i).Has<InputControl>())
                {
                    horizontalVelocity = Vector3.ClampMagnitude(horizontalVelocity, player.CurrentMaxSpeedInAir);
                }
                player.CharacterVelocity = horizontalVelocity + (Vector3.up * verticalVelocity);
                player.CharacterVelocity += new Vector3(0f, player.GravitationalAcceleration * Time.deltaTime, 0f);
            }
        }
    }
}