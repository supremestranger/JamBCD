using UnityEngine;

namespace JamBCD
{
    public class PlayerView : MonoBehaviour
    {
        public CharacterController Controller;
        public Transform Transform;
        public Transform GroundCheckPoint;
        private Collider[] _results = new Collider[16];
        [SerializeField] private LayerMask _groundLayerMask;

        private void Awake()
        {
            Transform = transform;
            Controller = GetComponent<CharacterController>();
        }

        public bool IsGrounded()
        {
            return Physics.OverlapSphereNonAlloc(GroundCheckPoint.position, 0.25f, _results, _groundLayerMask) != 0;
        }
    }
}