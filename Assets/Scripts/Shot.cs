using UnityEngine.Assertions;
using UnityEngine;

public class ShotDataStructure
{
    public float Speed = 0f;
    public float LifeTime = 0f;
    public float Damage = 0f;
    public float Size = 1f;
}

[RequireComponent(typeof(DamageCollider))]
[RequireComponent(typeof(Rigidbody2D))]
public class Shot : MonoBehaviour
{
    public float Speed = 25f;
    public float LifeTime = 5f;
    public float Damage = 5;
    public float Size = 1f;

    public ShotDataStructure SDS = new ShotDataStructure();

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
        //ShotDataStructure shot = new ShotDataStructure();
        //IShotMod[] shotMods = GetComponents<IShotMod>();
        //int count = shotMods.Length;

        //for (int i = 0; i < count; ++i)
        //{
        //    shotMods[i].ModifyShot(shot);
        //}

        //DamageCollider dmg = GetComponent<DamageCollider>();
        //Assert.IsNotNull(dmg);
        ApplySshotDataStructure();
    }

    private void FixedUpdate()
    {
        rb.AddForce(transform.forward * Speed);
    }

    private void ApplySshotDataStructure()
    {
        DamageCollider dmg = GetComponent<DamageCollider>();
        Assert.IsNotNull(dmg);
        dmg.Damage += Damage + SDS.Damage;

        Speed += SDS.Speed;
        LifeTime += SDS.LifeTime;
        Destroy(gameObject, LifeTime);
    }
}
