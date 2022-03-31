using Shelf;
using TMPro;
using UnityEngine;

namespace UI
{
    public class ShelfMilkUI : BaseShelfUI
    {
        [SerializeField] private TextMeshProUGUI textShelfMilk;
        [SerializeField] private TextMeshProUGUI textListMilk;

        public override void SetTextList(int count)
        {
            textListMilk.text = $"X {count}";
        }

        private void Awake()
        {
            Debug.Assert(textShelfMilk != null, "textShelfMilk cannot be null");
            Debug.Assert(textListMilk != null, "textListMilk cannot be null");

            SetTextShelf();
        }

        protected override void SetTextShelf()
        {
            textShelfMilk.text = $"{BaseShelf.Shelf.ShelfMilk}";
        }
    }
}