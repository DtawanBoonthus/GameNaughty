using Manager;
using TMPro;
using UnityEngine;
using Random = System.Random;

namespace UI
{
    public class BuyListUI : MonoBehaviour
    {
        public int CountNeedDessert { get; private set; }
        public int CountNeedIceCream { get; private set; }
        public int CountNeedMeat { get; private set; }
        public int CountNeedMilk { get; private set; }
        public int CountNeedSoda { get; private set; }

        [SerializeField] private TextMeshProUGUI[] listText;

        private int countNeedStuff = 5;
        private int resetCountNeed = 0;

        private void Awake()
        {
            for (var i = 0; i < listText.Length; i++)
            {
                Debug.Assert(listText[i] != null, $"listText Index {i} cannot be null");
            }

            SetNeedStuffList();

            GameManager.Instance.OnPlayGame += PlayerGame;
        }

        private void Update()
        {
            SetListText();
        }

        private void PlayerGame()
        {
            CountNeedDessert = resetCountNeed;
            CountNeedMeat = resetCountNeed;
            CountNeedMilk = resetCountNeed;
            CountNeedSoda = resetCountNeed;
            CountNeedIceCream = resetCountNeed;

            StuffManager.Instance.ResetCountHaveStuff();

            SetNeedStuffList();
        }

        private void SetListText()
        {
            SetListTextDessert(CountNeedDessert);
            SetListTextIceCream(CountNeedIceCream);
            SetListTextMeat(CountNeedMeat);
            SetListTextMilk(CountNeedMilk);
            SetListTextSoda(CountNeedSoda);

            listText[0].text =
                $"Need : {CountNeedDessert} Have : {StuffManager.Instance.HaveDessert}";
            listText[1].text =
                $"Need : {CountNeedIceCream} Have : {StuffManager.Instance.HaveIceCream}";
            listText[2].text = $"Need : {CountNeedMeat} Have : {StuffManager.Instance.HaveMeat}";
            listText[3].text = $"Need : {CountNeedMilk} Have : {StuffManager.Instance.HaveMilk}";
            listText[4].text = $"Need : {CountNeedSoda} Have : {StuffManager.Instance.HaveSoda}";
        }

        private void SetListTextDessert(int count)
        {
            if (count == 0)
            {
                listText[0].gameObject.SetActive(false);
            }
            else
            {
                listText[0].gameObject.SetActive(true);
            }
        }

        private void SetListTextIceCream(int count)
        {
            if (count == 0)
            {
                listText[1].gameObject.SetActive(false);
            }
            else
            {
                listText[1].gameObject.SetActive(true);
            }
        }

        private void SetListTextMeat(int count)
        {
            if (count == 0)
            {
                listText[2].gameObject.SetActive(false);
            }
            else
            {
                listText[2].gameObject.SetActive(true);
            }
        }

        private void SetListTextMilk(int count)
        {
            if (count == 0)
            {
                listText[3].gameObject.SetActive(false);
            }
            else
            {
                listText[3].gameObject.SetActive(true);
            }
        }

        private void SetListTextSoda(int count)
        {
            if (count == 0)
            {
                listText[4].gameObject.SetActive(false);
            }
            else
            {
                listText[4].gameObject.SetActive(true);
            }
        }

        private void SetNeedStuffList()
        {
            var random = new Random();

            for (var i = 0; i < countNeedStuff; i++)
            {
                SetStuffNeeds(random.Next(5));
            }
        }

        private void SetStuffNeeds(int random)
        {
            switch (random)
            {
                case 0:
                    ++CountNeedDessert;
                    break;
                case 1:
                    ++CountNeedIceCream;
                    break;
                case 2:
                    ++CountNeedMeat;
                    break;
                case 3:
                    ++CountNeedMilk;
                    break;
                case 4:
                    ++CountNeedSoda;
                    break;
            }
        }
    }
}