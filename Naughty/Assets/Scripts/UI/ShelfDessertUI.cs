using Shelf;
using TMPro;
using UnityEngine;

namespace UI
{
    public class ShelfDessertUI : BaseShelfUI
    {
        [SerializeField] private TextMeshProUGUI textShelfDessert;
        [SerializeField] private TextMeshProUGUI textListDessert;

        public override void SetTextList(int count)
        {
            textListDessert.text = $"X {count}";
        }

        private void Awake()
        {
            Debug.Assert(textShelfDessert != null, "textShelfDessert cannot be null");
            Debug.Assert(textListDessert != null, "textListDessert cannot be null");

            SetTextShelf();
        }

        protected override void SetTextShelf()
        {
            textShelfDessert.text = $"{BaseShelf.Shelf.ShelfDessert}";
        }
    }
}