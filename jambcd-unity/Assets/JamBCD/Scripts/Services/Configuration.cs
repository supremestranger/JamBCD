using UnityEngine;
using UnityEngine.Serialization;

namespace JamBCD
{
    [CreateAssetMenu(menuName = "Create Configuration", fileName = "Configuration", order = 0)]
    public class Configuration : ScriptableObject
    {
        public GameObject PlayerPrefab;
        public float DashDuration;
        public float BaseSpeedOnGround;
        public float CameraZRot;
        public float AirAcceleration; 
        public float DashSpeed;
        public float MaxSpeedInAir;
        public float SlideSpeed;
        public float GravitationalAcceleration;
        public float JumpHeight;
        public float GroundAcceleration;
        public float DashFOV;
        public float CameraFOVUpdateSpeed;
    }
}