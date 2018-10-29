using System.Collections.Generic;
using UnityEngine.Assertions;
using UnityEngine;

public class PlayerAttackMod
{
    public float AttackRateMultiplier = 1f;
}

// @todo: handle case for weapons switching
public class PlayerAttacking : MonoBehaviour
{
    [SerializeField]
    private Shot shotPrefab;

    // @note: may be temp so it can play well with mods that are dropped
    public float AttackSpeed = 0.5f;

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
            PlayerAttackMod attackMod = new PlayerAttackMod();
            IPlayerAttackMod[] mods = GetComponents<IPlayerAttackMod>();
            int count = mods.Length;
            for (int i = 0; i < count; ++i)
            {
                mods[i].ModAttack(attackMod);
            }

            nextFire = Time.time + AttackSpeed * attackMod.AttackRateMultiplier;
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = transform.position.z;

            Vector3 shotDirection = (mousePosition - transform.position).normalized;

            if (shotDirection.x == 0f && shotDirection.y == 0f)
            {
                //Edge case where they clicked right in the middle of the player
                shotDirection = Random.insideUnitCircle;
            }

            Shot shot = Instantiate(
                shotPrefab,
                transform.position + shotDirection * shotSpawnDisplacement,
                Quaternion.identity);

            List<IShotMod> shotMods = Player.instance.ShotMods;
            count = shotMods.Count;
            for (int i = 0; i < count; ++i)
            {
                shotMods[i].ModifyShot(shot);
            }

            shot.transform.forward = shotDirection;
        }
    }
}
