using Shelf;
using TMPro;
using UnityEngine;

namespace UI
{
    public class ShelfSodaUI : BaseShelfUI
    {
        [SerializeField] private TextMeshProUGUI textShelfSoda;
        [SerializeField] private TextMeshProUGUI textListSoda;

        public override void SetTextList(int count)
        {
            textListSoda.text = $"X {count}";
        }

        private void Awake()
        {
            Debug.Assert(textShelfSoda != null, "textShelfSoda cannot be null");
            Debug.Assert(textListSoda != null, "textListSoda cannot be null");

            SetTextShelf();
        }

        protected override void SetTextShelf()
        {
            textShelfSoda.text = $"{BaseShelf.Shelf.ShelfSoda}";
        }
    }
}