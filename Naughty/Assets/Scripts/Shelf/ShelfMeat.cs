using Character;
using UnityEngine;

namespace Shelf
{
    public class ShelfMeat : BaseShelf
    {
        protected override void OnTriggerStay(Collider other)
        {
            var target = other.gameObject.GetComponent<IOnOpenStoreMeat>();
            target?.OpenShelfMeat();
        }
    }
}