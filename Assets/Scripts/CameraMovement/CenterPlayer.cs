using UnityEngine;

namespace CameraMovement
{
    public class CenterPlayer : MonoBehaviour
    {
        private void FixedUpdate()
        {
            transform.position = new Vector3(
                Player.instance.transform.position.x,
                Player.instance.transform.position.y, 
                transform.position.z);
        }
    }
}