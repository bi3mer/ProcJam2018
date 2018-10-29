using UnityEngine.Assertions;
using UnityEngine;

public class ShotDamageMod : MonoBehaviour, IShotMod
{
    public float DamageIncrease = -1;

    private void Start()
    {
        if (DamageIncrease < 0)
        {
            DamageIncrease = Random.Range(0f, 1f);
        }
    }

    public void ModifyShot(ShotDataStructure shot)
    {
        Assert.IsNotNull(shot);
        shot.Damage += DamageIncrease;
    }
}
