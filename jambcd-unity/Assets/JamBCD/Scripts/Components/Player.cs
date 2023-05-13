using UnityEngine;

namespace JamBCD
{
    public struct Player
    {
        public float TargetFOV;
        public Vector3 MoveDir;
        public float CurrentMaxSpeedOnGround;
        public Vector3 CharacterVelocity;
        public float TargetHeight;
        public float CurrentMaxSpeedInAir;
        public float GravitationalAcceleration;
        public float GroundAcceleration;
        public float CurrentAirAcceleration;
        public float JumpHeight;
        public float DashSpeed;

        // Inputs.
        public bool WantDash;
        public Vector3 MoveInput;
        public bool WantCrouch;
        public bool FireInputDown;
        public bool WantJump;
        public float MouseX;
        public float MouseY;
        public bool WantDrink;
        
        public PlayerView PlayerView;
    }
}