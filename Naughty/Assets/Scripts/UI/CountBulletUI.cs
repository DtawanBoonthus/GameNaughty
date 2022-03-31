using TMPro;
using UnityEngine;

namespace UI
{
    public class CountBulletUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI countBulletText;

        private void Awake()
        {
            Debug.Assert(countBulletText != null, "countBulletText cannot be null");
        }

        public void SetText(int countBullet)
        {
            countBulletText.text = $"{countBullet}";
        }
    }
}