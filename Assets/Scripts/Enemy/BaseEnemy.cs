using UnityEngine;

public abstract class BaseEnemy : BaseEntity
{
    protected virtual void DropLoot()
    {
        Debug.Log("@todo: implement DropLoot in BaseEnemy");
    }

    protected override void OnDeath()
    {
        DropLoot();
        base.OnDeath();
    }

    protected void BaseEnemyAwake()
    {
        BaseEntityAwake();
    }
}
