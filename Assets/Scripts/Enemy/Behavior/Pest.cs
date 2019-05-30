using UnityEngine;

public class Pest : PhysicsEnemy
{
    [SerializeField]
    private float speed = 4.0f;

    [SerializeField]
    private bool affectedByLevel = true;

    private void Start()
    {
        if (affectedByLevel)
        {
            float speedMult = GameManager.instance.Level * .2f;
            if (speedMult > 1)
            {
                speed *= speedMult;
            }
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
