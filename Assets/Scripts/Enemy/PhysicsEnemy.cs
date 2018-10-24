using UnityEngine.Assertions;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PhysicsEnemy : BaseEnemy
{
    public Rigidbody2D Rb { get; private set; }
    public Transform Transform { get; private set; }

    protected virtual void OnPhysicsEnemyAwake() { }
    protected virtual void OnPhysicsFixedUpdate() { }

    sealed protected override void OnEnemyAwake()
    {
        Rb = GetComponent<Rigidbody2D>();
        Transform = Rb.transform;
        Assert.IsNotNull(Rb);

        OnPhysicsEnemyAwake();
    }

    private void FixedUpdate()
    {
        OnPhysicsFixedUpdate();
    }
}
