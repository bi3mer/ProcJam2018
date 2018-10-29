using UnityEngine.Assertions;
using UnityEngine;

public class ShotLifeTimeMod : MonoBehaviour, IShotMod
{
    public int LifeTimeIncrease = 0;

    public void ModifyShot(Shot shot)
    {
        Assert.IsTrue(LifeTimeIncrease >= 0);
        Assert.IsNotNull(shot);
        shot.LifeTime += LifeTimeIncrease;
    }
}
