using UnityEngine.Assertions;
using UnityEngine;

public class ShotDamageMod : MonoBehaviour, IShotMod
{
    public float DamageIncrease = -1;

    public void ModifyShot(Shot shot)
    {
        Assert.IsNotNull(shot);

        if (DamageIncrease < 0)
        {
            DamageIncrease = Random.Range(0f, 1f);
        }

        shot.Damage += DamageIncrease;
    }
}
