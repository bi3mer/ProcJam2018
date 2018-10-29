using UnityEngine;

public class DamageCollider : GeneralCollider
{
    public float Damage = 1;

    protected override void HandleCollision(GameObject other, EntityClassification classification)
    {
        Healthful healthComponent = other.GetComponent<Healthful>();
        if (healthComponent != null)
        {
            Debug.Log(Damage);
            healthComponent.Health -= Damage;
        }
    }
}
