using UnityEngine;

public class Player : MonoBehaviour
{
    private static Transform playerTransform;
    public static Transform Transform
    {
        get
        {
            return playerTransform;
        }
    }

    private void Awake()
    {
        playerTransform = transform;
    }
}
