using UnityEngine.Assertions;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PhysicsEnemy : BaseEnemy
{
    protected Rigidbody2D rb;

    public Rigidbody2D Rb
    {
        get
        {
            return rb;
        }
    }

    public Transform Transform
    {
        get
        {
            return rb.transform;
        }
    }

    protected void PhysicsAwake()
    {
        rb = GetComponent<Rigidbody2D>();
        Assert.IsNotNull(rb);

        BaseEnemyAwake();
    }
}
