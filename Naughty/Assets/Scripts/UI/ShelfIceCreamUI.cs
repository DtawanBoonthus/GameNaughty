using Shelf;
using TMPro;
using UnityEngine;

namespace UI
{
    public class ShelfIceCreamUI : BaseShelfUI
    {
        [SerializeField] private TextMeshProUGUI textShelfIceCream;
        [SerializeField] private TextMeshProUGUI textListIceCream;

        public override void SetTextList(int count)
        {
            textListIceCream.text = $"X {count}";
        }

        private void Awake()
        {
            Debug.Assert(textShelfIceCream != null, "textShelfIceCream cannot be null");
            Debug.Assert(textListIceCream != null, "textListIceCream cannot be null");

            SetTextShelf();
        }

        protected override void SetTextShelf()
        {
            textShelfIceCream.text = $"{BaseShelf.Shelf.ShelfIceCream}";
        }
    }
}