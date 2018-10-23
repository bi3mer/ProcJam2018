using UnityEngine.Assertions;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Shot : MonoBehaviour
{
    [SerializeField]
    private float speed;

    [SerializeField]
    private float lifeTime;

    private Rigidbody2D rb;
    private Vector2 forceVector;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        Assert.IsNotNull(rb);
        Assert.IsFalse(lifeTime <= 0);

        Destroy(gameObject, lifeTime);
    }

    private void FixedUpdate()
    {
        rb.AddForce(transform.forward * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        Debug.Log("do some damage or something worthwhile.");
    }
}
