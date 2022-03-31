using Character;
using UnityEngine;

namespace Shelf
{
    public class ShelfSoda : BaseShelf
    {
        protected override void OnTriggerStay(Collider other)
        {
            var target = other.gameObject.GetComponent<IOnOpenStoreSoda>();
            target?.OpenShelfSoda();
        }
    }
}