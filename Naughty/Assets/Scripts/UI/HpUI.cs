using TMPro;
using UnityEngine;

namespace UI
{
    public class HpUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI hpText;

        private void Awake()
        {
            Debug.Assert(hpText != null, "hpText cannot be null");
        }

        public void SetText(int hp)
        {
            hpText.text = $"Hp: {hp}";
        }
    }
}