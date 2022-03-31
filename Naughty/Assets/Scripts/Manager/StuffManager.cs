using UnityEngine;
using Utilities;

namespace Manager
{
    public class StuffManager : MonoSingleton<StuffManager>
    {
        public int CountDessert { get; private set; }
        public int CountIceCream { get; private set; }
        public int CountMeat { get; private set; }
        public int CountMilk { get; private set; }
        public int CountSoda { get; private set; }

        public int HaveDessert { get; private set; }
        public int HaveIceCream { get; private set; }
        public int HaveMeat { get; private set; }
        public int HaveMilk { get; private set; }
        public int HaveSoda { get; private set; }

        private float cooldown;
        private float cooldownMax = 6f;
        private int resetCount = 0;

        public void SpawnStuff()
        {
            SetCountStuff();
            SpawnDessert();
            SpawnIceCream();
            SpawnMeat();
            SpawnMilk();
            SpawnSoda();

            UIManager.Instance.OnClickDessertListButton += OnClickedDessertListButton;
            UIManager.Instance.OnClickIceCreamListButton += OnClickedIceCreamListButton;
            UIManager.Instance.OnClickMeatListButton += OnClickedMeatListButton;
            UIManager.Instance.OnClickMilkListButton += OnClickedMilkListButton;
            UIManager.Instance.OnClickSodaListButton += OnClickedSodaListButton;
        }

        public void ResetCountHaveStuff()
        {
            SetCountHaveStuffOnDied();
        }

        private void Start()
        {
            CharacterManager.Instance.PlayerSpawn.OnDied += ResetCountHaveStuff;
        }

        private void Update()
        {
            CooldownSpawnDessert();
            CooldownSpawnIceCream();
            CooldownSpawnMeat();
            CooldownSpawnMilk();
            CooldownSpawnSoda();
        }

        private void SetCountStuff()
        {
            CountDessert = resetCount;
            CountIceCream = resetCount;
            CountMeat = resetCount;
            CountMilk = resetCount;
            CountSoda = resetCount;
        }

        private void SetCountHaveStuffOnDied()
        {
            HaveDessert = resetCount;
            HaveIceCream = resetCount;
            HaveMeat = resetCount;
            HaveMilk = resetCount;
            HaveSoda = resetCount;
        }

        private void CooldownSpawnDessert()
        {
            if (CountDessert > 0)
            {
                return;
            }

            cooldown += Time.deltaTime;

            if (cooldown >= cooldownMax)
            {
                SpawnDessert();

                UIManager.Instance.SetTextListDessertUI(CountDessert);

                cooldown = 0;
            }
        }

        private void CooldownSpawnIceCream()
        {
            if (CountIceCream > 0)
            {
                return;
            }

            cooldown += Time.deltaTime;

            if (cooldown >= cooldownMax)
            {
                SpawnIceCream();

                UIManager.Instance.SetTextListIceCreamUI(CountIceCream);

                cooldown = 0;
            }
        }

        private void CooldownSpawnMeat()
        {
            if (CountMeat > 0)
            {
                return;
            }

            cooldown += Time.deltaTime;

            if (cooldown >= cooldownMax)
            {
                SpawnMeat();

                UIManager.Instance.SetTextListMeatUI(CountMeat);

                cooldown = 0;
            }
        }

        private void CooldownSpawnMilk()
        {
            if (CountMilk > 0)
            {
                return;
            }

            cooldown += Time.deltaTime;

            if (cooldown >= cooldownMax)
            {
                SpawnMilk();

                UIManager.Instance.SetTextListMilkUI(CountMilk);

                cooldown = 0;
            }
        }

        private void CooldownSpawnSoda()
        {
            if (CountSoda > 0)
            {
                return;
            }

            cooldown += Time.deltaTime;

            if (cooldown >= cooldownMax)
            {
                SpawnSoda();

                UIManager.Instance.SetTextListSodaUI(CountSoda);

                cooldown = 0;
            }
        }

        private void OnClickedDessertListButton()
        {
            if (CountDessert != 0)
            {
                CountDessert--;

                HaveDessert++;

                UIManager.Instance.SetTextListDessertUI(CountDessert);
            }
        }

        private void OnClickedIceCreamListButton()
        {
            if (CountIceCream != 0)
            {
                CountIceCream--;

                HaveIceCream++;

                UIManager.Instance.SetTextListIceCreamUI(CountIceCream);
            }
        }

        private void OnClickedMeatListButton()
        {
            if (CountMeat != 0)
            {
                CountMeat--;

                HaveMeat++;

                UIManager.Instance.SetTextListMeatUI(CountMeat);
            }
        }

        private void OnClickedMilkListButton()
        {
            if (CountMilk != 0)
            {
                CountMilk--;

                HaveMilk++;

                UIManager.Instance.SetTextListMilkUI(CountMilk);
            }
        }

        private void OnClickedSodaListButton()
        {
            if (CountSoda != 0)
            {
                CountSoda--;

                HaveSoda++;

                UIManager.Instance.SetTextListSodaUI(CountSoda);
            }
        }

        private void SpawnDessert()
        {
            CountDessert++;
        }

        private void SpawnIceCream()
        {
            CountIceCream++;
        }

        private void SpawnMeat()
        {
            CountMeat++;
        }

        private void SpawnMilk()
        {
            CountMilk++;
        }

        private void SpawnSoda()
        {
            CountSoda++;
        }
    }
}