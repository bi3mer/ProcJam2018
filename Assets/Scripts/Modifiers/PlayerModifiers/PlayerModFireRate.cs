using UnityEngine.Assertions;
using UnityEngine;

public class PlayerModFireRate : MonoBehaviour, IPlayerAttackMod
{
    public float FireRateMultiplier = 1f;

    public void ModAttack(PlayerAttackMod attack)
    {
        Assert.IsTrue(FireRateMultiplier > 0);
        Assert.IsNotNull(attack);

        attack.AttackRateMultiplier *= FireRateMultiplier;
    }
}
