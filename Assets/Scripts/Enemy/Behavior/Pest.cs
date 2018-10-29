using UnityEngine;

public class Pest : PhysicsEnemy
{
    [SerializeField]
    private float speed = 4.0f;

    sealed protected override void OnPhysicsFixedUpdate()
    {
        Rb.transform.position = Vector2.MoveTowards(
            transform.position,
            Player.instance.transform.position,
            speed * Time.fixedDeltaTime);
    }
}
