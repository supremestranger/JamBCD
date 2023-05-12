using Components;
using Leopotam.Ecs;
using UnityEngine;

namespace JamBCD
{
    public class PlayerJumpSystem : IEcsRunSystem
    {
        private EcsFilter<Player, Grounded, InputControl, TryJump> filter;
        private EcsFilter<TryJump> timerFilter;
        private int _count;
        
        public void Run()
        {
            JumpTimer();
            Jumping();
        }

        private void Jumping()
        {
            foreach (var i in filter)
            {
                ref var player = ref filter.Get1(i);

                /*if (grounded.groundedTimer <= player.bunnyHoopInterval && player.moveDir != Vector3.zero)
                {
                    if (_count < 5)
                    {
                        player.currentMaxSpeedInAir += 2f;
                        //player.currentMaxSpeedInAir = Mathf.Clamp(player.currentMaxSpeedInAir, 0, player.maxPossibleSpeedInAir);
                        player.currentAirAcceleration += 2f;
                        player.currentMaxSpeedOnGround += 2f;
                        _count += 1;
                    }
                }
                else
                {
                    _count = 0;
                    player.currentMaxSpeedInAir = player.baseMaxSpeedInAir;
                    player.currentAirAcceleration = player.baseAirAcceleration;
                }*/

                player.CurrentAirAcceleration = (player.MoveDir != Vector3.zero)
                    ? player.CurrentAirAcceleration
                    : player.CurrentAirAcceleration * 0.5f;
                player.CharacterVelocity = new Vector3(player.CharacterVelocity.x, 0f, player.CharacterVelocity.z);
                player.CharacterVelocity +=
                    new Vector3(0f, Mathf.Sqrt(-2 * player.GravitationalAcceleration * player.JumpHeight), 0f);
            }
        }

        private void JumpTimer()
        {
            foreach (var i in timerFilter)
            {
                ref var wannaJump = ref timerFilter.Get1(i);
                wannaJump.Timer -= Time.deltaTime;

                if (wannaJump.Timer <= 0f)
                {
                    timerFilter.GetEntity(i).Del<TryJump>();
                }
            }
        }
    }
}