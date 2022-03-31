using UnityEngine;

namespace Character
{
    public class Salesperson : BaseCharacter
    {
        private void OnTriggerStay(Collider other)
        {
            var target = other.gameObject.GetComponent<ICollision>();
            target?.TakeCollision();
            target?.OpenWinnerDialog();
        }

        private void OnTriggerExit(Collider other)
        {
            var target = other.gameObject.GetComponent<ICollision>();
            target?.NotTakeCollision();
        }
    }
}