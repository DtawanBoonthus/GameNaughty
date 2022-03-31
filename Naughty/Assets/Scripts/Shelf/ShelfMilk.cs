using Character;
using UnityEngine;

namespace Shelf
{
    public class ShelfMilk : BaseShelf
    {
        protected override void OnTriggerStay(Collider other)
        {
            var target = other.gameObject.GetComponent<IOnOpenStoreMilk>();
            target?.OpenShelfMilk();
        }
    }
}