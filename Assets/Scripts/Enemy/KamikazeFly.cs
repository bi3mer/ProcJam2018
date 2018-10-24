using UnityEngine;
using System;

[RequireComponent(typeof(CircleCollider2D))]
public class KamikazeFly : PhysicsEnemy
{
    [SerializeField]
    private float explosionRadius = 3f;

    [SerializeField]
    private float explosionForce = 2.0f;

    [SerializeField]
    private int damage = 10;

    [SerializeField]
    private float speed = 2.0f;

    private void Awake()
    {
        PhysicsAwake();
    }

    private void FixedUpdate()
    {
        rb.transform.position = Vector2.MoveTowards(
            transform.position, 
            Player.Transform.position, 
            speed * Time.fixedDeltaTime);
    }

    // @todo: radius check for around the surface to try and deal damage to the player
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals(Tags.Enemy, StringComparison.Ordinal) == false)
        {
            if (collision.gameObject.tag.Equals(Tags.Player, StringComparison.Ordinal))
            {
                Debug.Log("Implement dealing damage to the player.");
            }

            Debug.Log("Implement adding explosive force around the area.");
            Destroy(gameObject);
        }
    }
}
