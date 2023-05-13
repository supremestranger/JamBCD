using Components;
using Leopotam.Ecs;
using UnityEngine;


namespace JamBCD
{
    public class CameraLookRotationSystem : IEcsRunSystem
    {
        private EcsFilter<Player> filter;
        private SceneData _sceneData;
        private CameraService _cameraService;
        private Configuration _config;

        public void Run()
        {
            foreach (var i in filter)
            {
                ref var player = ref filter.Get1(i);

                _cameraService.VirtualCamera.m_Lens.FieldOfView = Mathf.Lerp(_cameraService.MainCamera.fieldOfView, player.TargetFOV, _config.CameraFOVUpdateSpeed * Time.deltaTime); // todo remove hardcode
                
                var camForward = _cameraService.MainCamera.transform.forward;
                camForward.y = 0f;
                player.PlayerView.Transform.forward = camForward;
                var zRot = -player.MoveInput.x * _cameraService.CameraZRot;
                _cameraService.VirtualCamera.m_Lens.Dutch = Mathf.Lerp(_cameraService.VirtualCamera.m_Lens.Dutch, zRot,
                    12f * Time.deltaTime);
                //_cameraService.MainCamera.transform.position = GameObject.Find("CameraRoot").transform.position;
            }
        }
    }
}