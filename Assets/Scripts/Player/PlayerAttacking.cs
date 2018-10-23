using UnityEngine.Assertions;
using UnityEngine;

// @todo: handle case for weapons switching
public class PlayerAttacking : MonoBehaviour
{
    [SerializeField]
    private Shot shotPrefab;

    private void Awake()
    {
        Assert.IsNotNull(shotPrefab);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            GameObject shot = Instantiate(
                shotPrefab.gameObject, 
                transform.position, 
                Quaternion.identity);
            shot.transform.LookAt(mousePosition);
        }
    }
}
