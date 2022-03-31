using Character;
using UnityEngine;

namespace EffectorPhysics
{
    public class InertiaTensor : MonoBehaviour
    {
        [SerializeField] private Rigidbody rigidbody;

        private void FixedUpdate()
        {
            rigidbody.angularVelocity = rigidbody.inertiaTensor;
        }

        private void OnTriggerEnter(Collider other)
        {
            var target = other.gameObject.GetComponent<IEffectorPhysics>();
            target?.TakePropeller();
        }
    }
}