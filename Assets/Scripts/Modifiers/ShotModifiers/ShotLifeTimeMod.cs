using UnityEngine.Assertions;
using UnityEngine;

public class ShotLifeTimeMod : MonoBehaviour, IShotMod
{
    public float LifeTimeIncrease = -1;

    private void Start()
    {
        if (LifeTimeIncrease < 0)
        {
            LifeTimeIncrease = Random.Range(0f, 0.1f);
        }
    }

    public void ModifyShot(ShotDataStructure shot)
    {
        Assert.IsNotNull(shot);
        shot.LifeTime += LifeTimeIncrease;
    }
}
