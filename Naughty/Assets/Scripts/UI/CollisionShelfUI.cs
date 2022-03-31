using Character;
using UnityEngine;

namespace UI
{
    public class CollisionShelfUI : MonoBehaviour
    {
        private void OnTriggerStay(Collider other)
        {
            var target = other.gameObject.GetComponent<ICollision>();
            target?.TakeCollision();
        }

        private void OnTriggerExit(Collider other)
        {
            var target = other.gameObject.GetComponent<ICollision>();
            target?.NotTakeCollision();
        }
    }
}