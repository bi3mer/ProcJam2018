using UnityEngine.Assertions;
using UnityEngine;

[RequireComponent(typeof(DamageCollider))]
[RequireComponent(typeof(Rigidbody2D))]
public class Shot : MonoBehaviour
{
    public float Speed = 25f;
    public float LifeTime = 5f;
    public float Damage = 5;
    public float Size = 1f;

    private Rigidbody2D rb;
    private Vector2 forceVector;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        Assert.IsNotNull(rb);
        Assert.IsFalse(LifeTime <= 0);
    }

    private void Start()
    {
        IShotMod[] shotMods = GetComponents<IShotMod>();
        int count = shotMods.Length;

        for (int i = 0; i < count; ++i)
        {
            shotMods[i].ModifyShot(this);
        }

        DamageCollider dmg = GetComponent<DamageCollider>();
        Assert.IsNotNull(dmg);
        dmg.Damage = Damage;

        transform.localScale *= Size;
        Destroy(gameObject, LifeTime);
    }

    private void FixedUpdate()
    {
        rb.AddForce(transform.forward * Speed);
    }
}
