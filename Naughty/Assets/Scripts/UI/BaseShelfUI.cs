using System;
using UnityEngine;

namespace UI
{
    public abstract class BaseShelfUI : MonoBehaviour
    {
        public virtual void SetTextList(int count)
        {
            throw new NotImplementedException();
        }

        protected virtual void SetTextShelf()
        {
            throw new NotImplementedException();
        }
    }
}