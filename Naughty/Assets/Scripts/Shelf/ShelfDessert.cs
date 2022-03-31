using Character;
using UnityEngine;

namespace Shelf
{
    public class ShelfDessert : BaseShelf
    {
        protected override void OnTriggerStay(Collider other)
        {
            var target = other.gameObject.GetComponent<IOnOpenStoreDessert>();
            target?.OpenShelfDessert();
        }
    }
}