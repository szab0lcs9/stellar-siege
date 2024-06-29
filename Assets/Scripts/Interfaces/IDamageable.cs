public interface IDamageable
{
    float Health { get; set; }
    float Shield { get; set; }

    void TakeDamage(float damageTaken);
    void Die();
}
