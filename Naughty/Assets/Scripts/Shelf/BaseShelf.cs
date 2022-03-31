using System;
using UnityEngine;

namespace Shelf
{
    public abstract class BaseShelf : MonoBehaviour
    {
        public enum Shelf
        {
            ShelfDessert,
            ShelfIceCream,
            ShelfMeat,
            ShelfMilk,
            ShelfSoda
        }

        protected virtual void OnTriggerStay(Collider other)
        {
            throw new NotImplementedException();
        }
    }
}