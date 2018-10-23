using UnityEngine.Assertions;
using UnityEngine;

namespace CameraMovement
{
    public class CenterPlayer : MonoBehaviour
    {
        [SerializeField]
        private Transform player;

        private void Awake()
        {
            Assert.IsNotNull(player);
        }

        private void FixedUpdate()
        {
            transform.position = new Vector3(
                player.position.x, 
                player.position.y, 
                transform.position.z);
        }
    }
}