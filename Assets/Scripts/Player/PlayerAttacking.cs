using UnityEngine.Assertions;
using UnityEngine;

// @todo: handle case for weapons switching
public class PlayerAttacking : MonoBehaviour
{
    [SerializeField]
    private Shot shotPrefab;

    // @note: may be temp so it can play well with mods that are dropped
    [SerializeField]
    private float attackSpeed = 0.5f;

    private float nextFire = 0f;

    //The player is a 1 unit diameter circle.  So he ends at 0.5 units away from center.
    //Adding 0.1 unit to spawn the shot just outside him.
    private const float shotSpawnDisplacement = 0.16f;//0.6f;

    private void Awake()
    {
        Assert.IsNotNull(shotPrefab);
    }

    private void Update()
    {
        if (Input.GetMouseButton(0) && Time.time > nextFire)
        {
            nextFire = Time.time + attackSpeed;
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = transform.position.z;

            Vector3 shotDirection = (mousePosition - transform.position).normalized;

            if (shotDirection.x == 0f && shotDirection.y == 0f)
            {
                //Edge case where they clicked right in the middle of the player
                shotDirection = Random.insideUnitCircle;
            }

            GameObject shot = Instantiate(
                shotPrefab.gameObject,
                transform.position + shotDirection * shotSpawnDisplacement,
                Quaternion.identity);
            shot.transform.forward = shotDirection;
        }
    }
}
