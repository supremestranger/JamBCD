using UnityEngine;

namespace Components
{
    public struct Projectile
    {
        public Vector3 direction;
        public Vector3 previousPos;
        public GameObject projectileGO;
        public float speed;
        public float radius;
        public float pushPower;
        public float pushTime;
        public Vector3 pushDir;
        public int damage;
    }
}