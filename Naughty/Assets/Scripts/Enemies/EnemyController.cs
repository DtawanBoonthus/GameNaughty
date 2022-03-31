using Manager;
using UnityEngine;

namespace Enemies
{
    public class EnemyController : MonoBehaviour
    {
        private float cooldowns;

        private void Awake()
        {
            cooldowns = GameManager.Instance.CooldownBullet;
        }

        private void Update()
        {
            cooldowns -= Time.deltaTime;

            if (GameManager.Instance.IsNextLevel)
            {
                if (cooldowns <= 0)
                {
                    for (var i = 0; i < CharacterManager.Instance.EnemySpawn.Length; i++)
                    {
                        CharacterManager.Instance.EnemySpawn[i].Hurl();
                    }

                    cooldowns = GameManager.Instance.CooldownBullet;
                }

                return;
            }

            if (cooldowns <= 0)
            {
                for (var i = 0; i < GameManager.Instance.CountEnemyNextLevel; i++)
                {
                    CharacterManager.Instance.EnemySpawn[i].Hurl();
                }

                cooldowns = GameManager.Instance.CooldownBullet;
            }
        }
    }
}