using UnityEngine.Assertions;
using System.Collections;
using UnityEngine;

/** @todo
 * Currently jumping doesn't follow a curve which makes it unsatisfing. Lerping between
 * Values will give a natural curve that should be more pleasing to use, but isn't 
 * important right now
 */


[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float speed = 3.0f;

    [SerializeField]
    private float gravityForce = -9.8f;

    [SerializeField]
    private float jumpForce = 10f;

    [SerializeField]
    private float jumpTime = 3f;

    private Rigidbody2D rb;
    private Vector2 gravity;
    private bool jumping = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        Assert.IsNotNull(rb);

        gravity = new Vector2(0f, gravityForce);
    }

    private void Update()
    {
        if (jumping == false)
        {
            if (Input.GetKeyUp(KeyCode.Space))
            {
                jumping = true;
                StartCoroutine(ResetJump());
            }
        }
    }

    private void FixedUpdate()
    {
        float xVelocity = Input.GetAxis(UnityConstants.HorizontalInput) * speed;
        float yVelocity = jumping == true ? jumpForce : 0f;
        
        rb.MovePosition(rb.position + (new Vector2(xVelocity, yVelocity) * speed * Time.fixedDeltaTime) + (gravity * Time.fixedDeltaTime));
    }

    private IEnumerator ResetJump()
    {
        yield return new WaitForSeconds(jumpTime);
        jumping = false;
    }
}
