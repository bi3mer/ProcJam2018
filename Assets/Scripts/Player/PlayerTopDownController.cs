using UnityEngine.Assertions;
using UnityEngine;

// https://stuartspixelgames.com/2018/06/24/simple-2d-top-down-movement-unity-c/
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerTopDownController : MonoBehaviour
{
    [SerializeField]
    private float speed = 3f;

    private Rigidbody2D rb;
    private float horizontal = 0f;
    private float vertical = 0f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        Assert.IsNotNull(rb);
    }

    private void Update()
    {
        horizontal = Input.GetAxis(UnityConstants.HorizontalInput);
        vertical = Input.GetAxis(UnityConstants.VerticalInput);
    }

    void FixedUpdate()
    {
        if (horizontal != 0 && vertical != 0)
        {
            rb.velocity = new Vector2((horizontal * speed), (vertical * speed));
        }
        else
        {
            rb.velocity = new Vector2(horizontal * speed, vertical * speed);
        }
    }
}
