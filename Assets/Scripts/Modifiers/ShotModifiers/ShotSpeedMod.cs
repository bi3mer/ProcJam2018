using UnityEngine.Assertions;
using UnityEngine;

public class ShotSpeedMod : MonoBehaviour, IShotMod
{
    public float Speed = 0f;

    public void ModifyShot(Shot shot)
    {
        Assert.IsTrue(Speed > 0);
        Assert.IsNotNull(shot);
        shot.Speed += Speed;
    }
}
