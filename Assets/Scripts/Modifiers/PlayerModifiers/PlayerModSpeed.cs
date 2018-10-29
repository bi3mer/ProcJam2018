using UnityEngine.Assertions;
using UnityEngine;

public class PlayerModSpeed : MonoBehaviour, IPlayerMovementMod
{
    public float SpeedAdd = 0f;

    public void ModifyPlayerMovement(PlayerMovementMod movement)
    {
        Assert.IsTrue(SpeedAdd >= 0);
        Assert.IsNotNull(movement);
        movement.MovementAdder += SpeedAdd;
    }
}
