using UnityEngine;

namespace JamBCD
{
    public class CameraService
    {
        public Camera MainCamera;
        public float CameraHorizontalAngle;
        public float CameraVerticalAngle;
        public float CameraZRot;
        
        public CameraService(Camera mainCamera)
        {
            MainCamera = mainCamera;
        }
    }
}