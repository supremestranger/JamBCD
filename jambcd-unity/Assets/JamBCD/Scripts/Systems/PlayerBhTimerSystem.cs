using Components;
using Leopotam.Ecs;
using UnityEngine;

namespace JamBCD
{
    public class PlayerBhTimerSystem : IEcsRunSystem
    {
        private EcsFilter<Player, Grounded> filter;

        public void Run()
        {
            /*
            foreach (var i in filter)
            {
                ref var player = ref filter.Get1(i);
                ref var grounded = ref filter.Get2(i);

                grounded.groundedTimer += Time.deltaTime;

                if (grounded.groundedTimer >= player.bunnyHoopInterval)
                {
                    player.currentMaxSpeedOnGround = player.baseMaxSpeedOnGround;
                }
            }
            */
        }
    }
}