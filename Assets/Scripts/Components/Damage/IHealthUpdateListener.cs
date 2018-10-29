public interface IHealthUpdateListener
{
    void Init(int maxHealth, float health);
    void UpdateMaxHealth(int newMaxHealth, float newHealth);
    void UpdateHealth(float newHealth);
}
