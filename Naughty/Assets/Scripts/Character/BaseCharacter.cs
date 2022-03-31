using UnityEngine;

namespace Character
{
    public abstract class BaseCharacter : MonoBehaviour
    {
        [SerializeField] protected Bullet defaultBullet;
        [SerializeField] protected Transform hurlPosition;
        [SerializeField] protected Transform targetBullet;

        public int Hp { get; protected set; }
        public float Speed { get; protected set; }
        public Bullet Bullet { get; private set; }

        protected virtual void Init(int hp, float speed, Bullet bullet)
        {
            Hp = hp;
            Speed = speed;
            Bullet = bullet;
        }

        protected virtual void Init(Bullet bullet)
        {
            Bullet = bullet;
        }

        public virtual void Hurl()
        {
            //TODO: Implement this later
        }
    }
}