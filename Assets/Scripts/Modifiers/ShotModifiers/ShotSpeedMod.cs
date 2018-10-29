using UnityEngine.Assertions;
using UnityEngine;

public class ShotSpeedMod : MonoBehaviour, IShotMod
{
    public float Speed = -1;

    public void ModifyShot(Shot shot)
    {
        Assert.IsNotNull(shot);

        if (Speed == -1)
        {
            Speed = 1 + Random.Range(0f, 0.5f);
        }

        shot.Speed += Speed;
    }
}
