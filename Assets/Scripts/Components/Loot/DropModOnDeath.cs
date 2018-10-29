using UnityEngine;

public class DropModOnDeath : MonoBehaviour, IDestructionListener
{
    public const string ModsLocation = "Mods/";

    void IDestructionListener.NotifyDestruction(bool causedByDamage)
    {
        if (causedByDamage)
        {
            GameObject[] mods = Resources.LoadAll<GameObject>(ModsLocation);

            Instantiate(
                original: mods[Random.Range(0, mods.Length)],
                position: gameObject.transform.position,
                rotation: gameObject.transform.rotation,
                parent: null);
        }
    }
}
