using System;
using UI;
using UnityEngine;
using Utilities;


namespace Manager
{
    public class GameManager : MonoSingleton<GameManager>
    {
        public event Action OnStarted;
        public event Action OnPlayGame;
        public event Action OnSetting;
        public event Action OnBack;
        public event Action OnCredit;
        public event Action OnAudio;
        public event Action OnControl;
        public event Action OnIncreaseVolume;
        public event Action OnDecreaseVolume;
        public event Action OnNextLevel;

        [SerializeField] private CollisionShelfUI[] shelfColliders;
        [SerializeField] private GameObject redLighting;

        public float CooldownBullet { get; private set; }
        public int CountEnemyNextLevel { get; private set; } = 3;
        public bool IsNextLevel { get; private set; } = false;

        private static float cooldownNextLevel = 30f;

        private float nextLevel = cooldownNextLevel;
        private float cooldownBulletNormalLevel = 3f;
        private float cooldownBulletNextLevel = 1f;
        private bool isPlayGame = false;

        private new void Awake()
        {
            Debug.Assert(shelfColliders.Length != 0, "shelfColliders has to be more than zero");
            Debug.Assert(redLighting != null, "redLighting cannot be null");

            for (var i = 0; i < shelfColliders.Length; i++)
            {
                Debug.Assert(shelfColliders[i] != null, $"shelfColliders Index {i} cannot be null");
            }

            CooldownBullet = cooldownBulletNormalLevel;

            Cursor.lockState = CursorLockMode.Confined;

            StartGame();

            SetActiveCharacter(false);

            UIManager.Instance.PlayButton.onClick.AddListener(PlayGame);
            UIManager.Instance.SettingButton.onClick.AddListener(OnClickSetting);
            UIManager.Instance.CreditButton.onClick.AddListener(OnClickCredit);
            UIManager.Instance.BackButton.onClick.AddListener(OnClickBack);
            UIManager.Instance.ExitButton.onClick.AddListener(EndGame);
            UIManager.Instance.AudioButton.onClick.AddListener(OnClickAudio);
            UIManager.Instance.ControlButton.onClick.AddListener(OnClickControl);
            UIManager.Instance.IncreaseVolumeButton.onClick.AddListener(OnClickIncreaseVolume);
            UIManager.Instance.DecreaseVolumeButton.onClick.AddListener(OnClickDecreaseVolume);

            UIManager.Instance.OnWinner += Winner;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                SoundManager.Instance.Play(SoundManager.Sound.Click);
            }

            if (isPlayGame)
            {
                nextLevel -= Time.deltaTime;
            }

            if (nextLevel <= 0)
            {
                NextLevel();
            }
        }

        private void StartGame()
        {
            SpawnShelfCollider();

            SetShelf();

            OnStarted?.Invoke();
        }

        private void SpawnShelfCollider()
        {
            var colliders = new CollisionShelfUI[shelfColliders.Length];

            for (var i = 0; i < shelfColliders.Length; i++)
            {
                colliders[i] = Instantiate(shelfColliders[i]);
            }
        }

        private void SetShelf()
        {
            StuffManager.Instance.SpawnStuff();
            UIManager.Instance.SetTextListDessertUI(StuffManager.Instance.CountDessert);
            UIManager.Instance.SetTextListIceCreamUI(StuffManager.Instance.CountIceCream);
            UIManager.Instance.SetTextListMeatUI(StuffManager.Instance.CountMeat);
            UIManager.Instance.SetTextListMilkUI(StuffManager.Instance.CountMilk);
            UIManager.Instance.SetTextListSodaUI(StuffManager.Instance.CountSoda);
        }

        private void PlayGame()
        {
            isPlayGame = true;
            IsNextLevel = false;

            CharacterManager.Instance.PlayerSpawn.transform.position = Vector3.zero;

            SetActiveCharacter(true);

            HideEnemyNextLevel(CountEnemyNextLevel, true);

            Cursor.visible = false;

            OnPlayGame?.Invoke();
        }

        private void SetActiveCharacter(bool set)
        {
            CharacterManager.Instance.PlayerSpawn.gameObject.SetActive(set);

            foreach (var enemy in CharacterManager.Instance.EnemySpawn)
            {
                enemy.gameObject.SetActive(set);
            }
        }

        private void Winner()
        {
            SetActiveCharacter(false);

            CooldownBullet = cooldownBulletNormalLevel;

            isPlayGame = false;
            IsNextLevel = false;
            redLighting.gameObject.SetActive(false);
            nextLevel = cooldownNextLevel;

            Cursor.visible = true;
        }

        private void NextLevel()
        {
            SetActiveCharacter(true);

            CooldownBullet = cooldownBulletNextLevel;

            redLighting.gameObject.SetActive(true);

            IsNextLevel = true;

            OnNextLevel?.Invoke();
        }

        private void HideEnemyNextLevel(int initialNumber, bool hide)
        {
            for (var i = initialNumber; i < CharacterManager.Instance.EnemySpawn.Length; i++)
            {
                CharacterManager.Instance.EnemySpawn[i].gameObject.SetActive(!hide);
            }
        }

        private void OnClickSetting()
        {
            OnSetting?.Invoke();
        }

        private void OnClickCredit()
        {
            OnCredit?.Invoke();
        }

        private void OnClickAudio()
        {
            OnAudio?.Invoke();
        }

        private void OnClickDecreaseVolume()
        {
            OnDecreaseVolume?.Invoke();
        }

        private void OnClickIncreaseVolume()
        {
            OnIncreaseVolume?.Invoke();
        }

        private void OnClickControl()
        {
            OnControl?.Invoke();
        }

        private void OnClickBack()
        {
            OnBack?.Invoke();
        }

        private void EndGame()
        {
            Application.Quit();
        }
    }
}