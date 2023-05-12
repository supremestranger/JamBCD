using UnityEngine;

namespace JamBCD
{
    public class PlayerView : MonoBehaviour
    {
        public CharacterController Controller;
        public Transform Transform;

        private void Awake()
        {
            Transform = transform;
            Controller = GetComponent<CharacterController>();
        }

        public bool IsGrounded()
        {
            return Controller.isGrounded;
        }
    }
}