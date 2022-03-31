namespace Character
{
    public interface IDamageable
    {
        void TakeHit(int damage);
        void Die();
    }
}