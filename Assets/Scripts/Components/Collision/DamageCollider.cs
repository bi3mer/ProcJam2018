using UnityEngine;

public class DamageCollider : GeneralCollider
{
    public int Damage = 1;

    protected override void HandleCollision(GameObject other, EntityClassification classification)
    {
        Healthful healthComponent = other.GetComponent<Healthful>();
        if (healthComponent != null)
        {
            healthComponent.Health -= Damage;
        }
    }
}
