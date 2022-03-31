using Character;
using UnityEngine;

namespace Shelf
{
    public class ShelfIceCream : BaseShelf
    {
        protected override void OnTriggerStay(Collider other)
        {
            var target = other.gameObject.GetComponent<IOnOpenStoreIceCream>();
            target?.OpenShelfIceCream();
        }
    }
}