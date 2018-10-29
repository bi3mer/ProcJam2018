using UnityEngine;

public class DropModOnDeath : MonoBehaviour, IDestructionListener
{
    [SerializeField]
    private bool triggerOnDamageDeath;
    [SerializeField]
    private bool triggerOnOtherDeath;

    [SerializeField]
    private GameObject lootToSpawn;

    void IDestructionListener.NotifyDestruction(bool causedByDamage)
    {
        bool spawn = false;

        spawn |= causedByDamage && triggerOnDamageDeath;
        spawn |= (causedByDamage == false) && triggerOnOtherDeath;

        if (spawn)
        {



            Instantiate(
                original: lootToSpawn,
                position: gameObject.transform.position,
                rotation: gameObject.transform.rotation,
                parent: null);
        }
    }
}
