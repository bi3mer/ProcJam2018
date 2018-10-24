public interface IHealthUpdateListener
{
    void Init(int maxHealth, int health);
    void UpdateMaxHealth(int newMaxHealth, int newHealth);
    void UpdateHealth(int newHealth);
}
