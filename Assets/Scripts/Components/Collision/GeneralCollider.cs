using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(Collider2D))]
public abstract class GeneralCollider : MonoBehaviour
{
    [SerializeField]
    private bool hitEnemy = false;
    [SerializeField]
    private bool hitPlayer = false;
    [SerializeField]
    private bool hitEnvironment = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case Tags.Enemy:
                if (hitEnemy)
                {
                    HandleCollision(collision.gameObject, EntityClassification.Enemy);
                }
                break;
            case Tags.Player:
                if (hitPlayer)
                {
                    HandleCollision(collision.gameObject, EntityClassification.Player);
                }
                break;
            case Tags.Environment:
                if (hitEnvironment)
                {
                    HandleCollision(collision.gameObject, EntityClassification.Environment);
                }
                break;
            default:
                //Do nothing
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        switch (collider.gameObject.tag)
        {
            case Tags.Enemy:
                if (hitEnemy)
                {
                    HandleCollision(collider.gameObject, EntityClassification.Enemy);
                }
                break;
            case Tags.Player:
                if (hitPlayer)
                {
                    HandleCollision(collider.gameObject, EntityClassification.Player);
                }
                break;
            case Tags.Environment:
                if (hitEnvironment)
                {
                    HandleCollision(collider.gameObject, EntityClassification.Environment);
                }
                break;
            default:
                //Do nothing
                break;
        }
    }

    protected abstract void HandleCollision(GameObject other, EntityClassification classification);
}
