using Cinemachine;
using UnityEngine;

namespace JamBCD
{
    public class CameraService
    {
        public Camera MainCamera;
        public float CameraZRot;
        public CinemachineVirtualCamera VirtualCamera;
        public CinemachineBasicMultiChannelPerlin CinemachineNoise;

        public CameraService(Camera mainCamera)
        {
            MainCamera = mainCamera;
            VirtualCamera = GameObject.FindObjectOfType<CinemachineVirtualCamera>();
            CinemachineNoise = VirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        }
    }
}