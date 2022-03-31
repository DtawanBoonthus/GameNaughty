using UnityEngine;

namespace Character
{
    public class Enemy : BaseCharacter
    {
        public override void Hurl()
        {
            var bullet = Instantiate(defaultBullet, hurlPosition.position, Quaternion.identity);
            bullet.Init(targetBullet.position, hurlPosition.position);
        }

        public void Init()
        {
            base.Init(defaultBullet);
        }
    }
}