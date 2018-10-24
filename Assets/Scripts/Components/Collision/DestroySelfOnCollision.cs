using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySelfOnCollision : GeneralCollider
{
    protected override void HandleCollision(GameObject other, EntityClassification classification)
    {
        foreach (IDestructionListener listener in gameObject.GetComponents<IDestructionListener>())
        {
            listener.NotifyDestruction(causedByDamage: false);
        }
        Destroy(gameObject);
    }
}
