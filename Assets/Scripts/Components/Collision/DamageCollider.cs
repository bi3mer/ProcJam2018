using UnityEngine;

public class DamageCollider : GeneralCollider
{
    [SerializeField]
    private int damage = 1;

    protected override void HandleCollision(GameObject other, EntityClassification classification)
    {
        Healthful healthComponent = other.GetComponent<Healthful>();
        if (healthComponent != null)
        {
            healthComponent.Health -= damage;
        }
    }
}
