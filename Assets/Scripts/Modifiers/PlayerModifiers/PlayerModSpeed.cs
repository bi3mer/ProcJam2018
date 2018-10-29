using UnityEngine.Assertions;
using UnityEngine;

public class PlayerModSpeed : MonoBehaviour, IPlayerMovementMod
{
    public float SpeedAdd = -1;

    private void Start()
    {
        if (SpeedAdd < 0)
        {
            SpeedAdd = Random.Range(0f, 0.05f);
        }
    }

    public void ModifyPlayerMovement(PlayerMovementMod movement)
    {
        Assert.IsNotNull(movement);
        movement.MovementAdder += SpeedAdd;
    }
}
