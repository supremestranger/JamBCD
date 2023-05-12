using Components;
using Leopotam.Ecs;
using UnityEngine;

namespace JamBCD
{
    public class PlayerChangeHeightSystem : IEcsRunSystem
    {
        private EcsFilter<Player> filter;
        
        public void Run()
        {
            /*foreach (var i in filter)
            {
                ref var player = ref filter.Get1(i);
                
                var targetHeight = player.targetHeight;

                if (targetHeight == 2f && Physics.Raycast(player.mainCamera.transform.position, Vector3.up * 2f,
                    out var hitInfo, 0.7f))
                {
                    continue;
                }
                
                player.playerView.characterController.height = Mathf.Lerp(player.playerView.characterController.height, targetHeight, 10f * Time.deltaTime);
                player.playerView.characterController.center = Vector3.Lerp(player.playerView.characterController.center, 
                    Vector3.up * (player.playerView.characterController.height * 0.5f), 10f * Time.deltaTime);
                player.playerView.headTransform.localPosition = Vector3.Lerp(player.playerView.headTransform.localPosition, 
                    player.playerView.characterController.height * 0.875f * Vector3.up, 10f * Time.deltaTime);
            }*/
        }
    }
}