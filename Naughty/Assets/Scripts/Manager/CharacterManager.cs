using Character;
using UnityEngine;
using Utilities;

namespace Manager
{
    public class CharacterManager : MonoSingleton<CharacterManager>
    {
        [HideInInspector] public Player PlayerSpawn;
        [HideInInspector] public Enemy[] EnemySpawn;

        public int PlayerHp { get; private set; } = 4;

        [SerializeField] private Player player;
        [SerializeField] private Enemy[] enemy;
        [SerializeField] private Salesperson salesperson;
        [SerializeField] private float playerMoveSpeed;

        private Salesperson salesPersonSpawn;

        private new void Awake()
        {
            Debug.Assert(player != null, "player cannot be null");
            Debug.Assert(enemy != null, "enemy cannot be null");
            Debug.Assert(salesperson != null, "salesperson cannot be null");
            Debug.Assert(PlayerHp > 0, "playerHp has to be more than zero");
            Debug.Assert(playerMoveSpeed > 0, "playerMoveSpeed has to be more than zero");

            GameManager.Instance.OnStarted += SpawnPlayer;
            GameManager.Instance.OnStarted += SpawnEnemy;
            GameManager.Instance.OnStarted += SpawnSalesperson;
        }

        private void SpawnPlayer()
        {
            PlayerSpawn = Instantiate(player);
            PlayerSpawn.Init(PlayerHp, playerMoveSpeed);

            PlayerSpawn.OnOpenShelfDessert += UIManager.Instance.OnOpenShelfDessertUI;
            PlayerSpawn.OnOpenShelfIceCream += UIManager.Instance.OnOpenShelfIceCreamUI;
            PlayerSpawn.OnOpenShelfMeat += UIManager.Instance.OnOpenShelfMeatUI;
            PlayerSpawn.OnOpenShelfMilk += UIManager.Instance.OnOpenShelfMilkUI;
            PlayerSpawn.OnOpenShelfSoda += UIManager.Instance.OnOpenShelfSodaUI;
            PlayerSpawn.OnClosShelfStore += UIManager.Instance.OnClosShelfStored;
            PlayerSpawn.OnOpenWinnerDialog += UIManager.Instance.OnOpenWinnerDialog;
        }

        private void SpawnEnemy()
        {
            EnemySpawn = new Enemy[enemy.Length];

            for (var i = 0; i < enemy.Length; i++)
            {
                EnemySpawn[i] = Instantiate(enemy[i]);
                EnemySpawn[i].Init();
            }
        }

        private void SpawnSalesperson()
        {
            salesPersonSpawn = Instantiate(salesperson);
        }
    }
}