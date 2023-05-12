using JamBCD;
using Leopotam.Ecs;
using UnityEngine;

namespace UnityComponents
{
    public class PlayerDashingSystem : IEcsRunSystem
    {
        private EcsFilter<Player, Dashing> filter;
        
        public void Run()
        {
            foreach (var i in filter)
            {
                ref var player = ref filter.Get1(i);
                ref var dashing = ref filter.Get2(i);
                
                var horizontalVelocity = dashing.DashDir * player.DashSpeed;
                var verticalVelocity = player.CharacterVelocity.y;

                player.CharacterVelocity = horizontalVelocity + Vector3.up * verticalVelocity;
                
                dashing.DashingElapsed -= Time.deltaTime;
                
                if (dashing.DashingElapsed <= 0f)
                {
                    player.TargetFOV = 60f;
                    filter.GetEntity(i).Get<InputControl>();
                    filter.GetEntity(i).Del<Dashing>();
                }
            }
        }
    }
}