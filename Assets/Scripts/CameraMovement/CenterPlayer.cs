using UnityEngine;

namespace CameraMovement
{
    public class CenterPlayer : MonoBehaviour
    {
        private void FixedUpdate()
        {
            transform.position = new Vector3(
                Player.Transform.position.x,
                Player.Transform.position.y, 
                transform.position.z);
        }
    }
}