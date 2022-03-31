using UnityEngine;

namespace Character
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private Rigidbody rigidbody;
        [SerializeField] private int damage;

        private float time = 1f;

        public void Init(Vector3 target, Vector3 origin)
        {
            Move(target, origin);
        }

        private void Awake()
        {
            Debug.Assert(rigidbody != null, "rigidbody cannot be null");
        }

        private void Move(Vector3 target, Vector3 origin)
        {
            rigidbody.velocity = CalculateProjectile(target, origin);
        }

        private Vector3 CalculateProjectile(Vector3 target, Vector3 origin)
        {
            var distance = target - origin;
            var distanceVectorX = distance;
            distanceVectorX.y = 0f;

            var distanceScalarX = distanceVectorX.magnitude;
            var distanceScalarY = distance.y;

            var velocityX = distanceScalarX / time;
            var velocityY = distanceScalarY / time + 0.5f * Mathf.Abs(Physics.gravity.y) * time;

            var result = distanceVectorX.normalized;
            result *= velocityX;
            result.y = velocityY;

            return result;
        }

        private void OnTriggerEnter(Collider other)
        {
            var target = other.gameObject.GetComponent<IDamageable>();
            target?.TakeHit(damage);
            Destroy(gameObject);
        }
    }
}