using Shelf;
using TMPro;
using UnityEngine;

namespace UI
{
    public class ShelfMeatUI : BaseShelfUI
    {
        [SerializeField] private TextMeshProUGUI textShelfMeat;
        [SerializeField] private TextMeshProUGUI textListMeat;

        public override void SetTextList(int count)
        {
            textListMeat.text = $"X {count}";
        }

        private void Awake()
        {
            Debug.Assert(textShelfMeat != null, "textShelfMeat cannot be null");
            Debug.Assert(textListMeat != null, "textListMeat cannot be null");

            SetTextShelf();
        }

        protected override void SetTextShelf()
        {
            textShelfMeat.text = $"{BaseShelf.Shelf.ShelfMeat}";
        }
    }
}