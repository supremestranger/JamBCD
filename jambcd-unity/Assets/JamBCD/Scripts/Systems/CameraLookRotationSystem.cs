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

        public void Run()
        {
            foreach (var i in filter)
            {
                ref var player = ref filter.Get1(i);

                _cameraService.MainCamera.fieldOfView = Mathf.Lerp(_cameraService.MainCamera.fieldOfView, player.TargetFOV, 5f * Time.deltaTime); // todo remove hardcode
                
                _cameraService.CameraHorizontalAngle += player.MouseX * player.MouseSensitivity;
                
                player.PlayerView.transform.localRotation = Quaternion.Slerp(player.PlayerView.Transform.localRotation, 
                Quaternion.Euler(0f, _cameraService.CameraHorizontalAngle, 0f), 12 * Time.deltaTime);
                
                _cameraService.CameraVerticalAngle += -player.MouseY * player.MouseSensitivity;
                _cameraService.CameraVerticalAngle = Mathf.Clamp(_cameraService.CameraVerticalAngle, -80f, 80f);
                
                var zRot = -player.MoveInput.x * _cameraService.CameraZRot;
                _cameraService.MainCamera.transform.localRotation = Quaternion.Slerp(_cameraService.MainCamera.transform.localRotation, 
                    Quaternion.Euler(_cameraService.CameraVerticalAngle, 0f, zRot), 12f * Time.deltaTime);
                //_cameraService.MainCamera.transform.position = GameObject.Find("CameraRoot").transform.position;
            }
        }
    }
}