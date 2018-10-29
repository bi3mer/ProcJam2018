using UnityEngine.Assertions;
using UnityEngine;

public class ShotDamageMod : MonoBehaviour, IShotMod
{
    public int DamageIncrease = 0;

    public void ModifyShot(Shot shot)
    {
        Assert.IsNotNull(shot);
        shot.Damage += DamageIncrease;
    }
}
