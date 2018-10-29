using UnityEngine.Assertions;
using UnityEngine;

public class ShotSpeedMod : MonoBehaviour, IShotMod
{
    public float Speed = -1;

    private void Start()
    {
        if(Speed == -1)
        {
            Speed = 1 + Random.Range(0f, 0.5f);
        }
    }

    public void ModifyShot(ShotDataStructure shot)
    {
        Assert.IsNotNull(shot);
        shot.Speed += Speed;
    }
}
