using System;
using Manager;
using UnityEngine;

namespace Character
{
    public class Player : BaseCharacter, IDamageable, ICollision, IOnOpenStoreDessert, IOnOpenStoreIceCream,
        IOnOpenStoreMeat, IOnOpenStoreMilk, IOnOpenStoreSoda, IEffectorPhysics
    {
        public event Action OnOpenShelfDessert;
        public event Action OnOpenShelfIceCream;
        public event Action OnOpenShelfMeat;
        public event Action OnOpenShelfMilk;
        public event Action OnOpenShelfSoda;
        public event Action OnClosShelfStore;
        public event Action OnOpenWinnerDialog;
        public event Action OnDied;

        private int countBullet = 10;
        private int maxHp;
        private int maxBullet = 10;
        private bool isTakeCollision = false;
        private bool isOpenStore = false;

        public void Init(int hp, float speed)
        {
            base.Init(hp, speed, defaultBullet);

            UIManager.Instance.SetTextHpUI(Hp);
            UIManager.Instance.SetTextCountBulletUI(countBullet);
        }

        public void TakeCollision()
        {
            if (isOpenStore)
            {
                UIManager.Instance.HideFToStoreUI(true);
                return;
            }

            isTakeCollision = true;

            UIManager.Instance.HideFToStoreUI(false);
        }

        public void NotTakeCollision()
        {
            isTakeCollision = false;
            isOpenStore = false;

            UIManager.Instance.HideFToStoreUI(true);
            UIManager.Instance.HideStoreDialog(true);

            ClosShelfStoreUI();

            Cursor.visible = false;
        }

        public void OpenStore()
        {
            if (!isOpenStore && isTakeCollision)
            {
                isOpenStore = true;

                UIManager.Instance.HideStoreDialog(false);

                Cursor.visible = true;
            }
            else
            {
                UIManager.Instance.HideStoreDialog(true);

                isOpenStore = false;

                Cursor.visible = false;
            }
        }

        public void TakeHit(int damage)
        {
            Hp -= damage;

            UIManager.Instance.SetTextHpUI(Hp);

            if (Hp > 0)
            {
                return;
            }

            Die();
        }

        public override void Hurl()
        {
            if (countBullet == 0)
            {
                return;
            }

            SoundManager.Instance.Play(SoundManager.Sound.Throw);

            var bullet = Instantiate(defaultBullet, hurlPosition.position, Quaternion.identity);
            bullet.Init(targetBullet.position, hurlPosition.position);

            countBullet--;

            UIManager.Instance.SetTextCountBulletUI(countBullet);
        }

        public void OpenWinnerDialog()
        {
            if (UIManager.Instance.IsWinner())
            {
                OnOpenWinnerDialog?.Invoke();

                return;
            }

            UIManager.Instance.HideNotCompleteUI(false);

            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = false;
        }

        public void Die()
        {
            CharacterManager.Instance.PlayerSpawn.gameObject.SetActive(false);

            Hp = maxHp;

            countBullet = maxBullet;

            transform.position = Vector3.zero;

            UIManager.Instance.SetTextHpUI(Hp);
            UIManager.Instance.SetTextCountBulletUI(countBullet);

            CharacterManager.Instance.PlayerSpawn.gameObject.SetActive(true);

            OnDied?.Invoke();
        }

        public void TakePropeller()
        {
            Die();
        }

        public void OpenShelfDessert()
        {
            OnOpenShelfDessert?.Invoke();
        }

        public void OpenShelfIceCream()
        {
            OnOpenShelfIceCream?.Invoke();
        }

        public void OpenShelfMeat()
        {
            OnOpenShelfMeat?.Invoke();
        }

        public void OpenShelfMilk()
        {
            OnOpenShelfMilk?.Invoke();
        }

        public void OpenShelfSoda()
        {
            OnOpenShelfSoda?.Invoke();
        }

        private void Awake()
        {
            Debug.Assert(defaultBullet != null, "defaultWeapon cannot be null");
            Debug.Assert(hurlPosition != null, "hurlPosition cannot be null");
            Debug.Assert(targetBullet != null, "targetBullet cannot be null");

            maxHp = CharacterManager.Instance.PlayerHp;
        }

        private void ClosShelfStoreUI()
        {
            OnClosShelfStore?.Invoke();
        }
    }
}