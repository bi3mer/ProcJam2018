using UnityEngine.Assertions;
using UnityEngine;

public class ShotLifeTimeMod : MonoBehaviour, IShotMod
{
    public float LifeTimeIncrease = -1;

    public void ModifyShot(Shot shot)
    {
        Assert.IsNotNull(shot);

        if (LifeTimeIncrease < 0)
        {
            LifeTimeIncrease = Random.Range(0f, 0.1f);
        }

        shot.LifeTime += LifeTimeIncrease;
    }
}
