using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class KamikazeFly : PhysicsEnemy
{
    [SerializeField]
    private float speed = 2.0f;

    private void Start()
    {
        float speedMult = GameManager.instance.Level * 0.2f;
        if (speedMult > 1)
        {
            speed *= speedMult;
        }
    }

    sealed protected override void OnPhysicsFixedUpdate()
    {
        Rb.transform.position = Vector2.MoveTowards(
            transform.position, 
            Player.instance.transform.position, 
            speed * Time.fixedDeltaTime);
    }
}
