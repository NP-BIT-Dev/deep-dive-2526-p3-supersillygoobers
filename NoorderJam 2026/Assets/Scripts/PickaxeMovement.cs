using UnityEngine;
using UnityEngine.InputSystem;

public class PickaxeMovement : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Mathf.Abs(Camera.main.transform.position.z);
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        Vector2 direction = (mousePos - transform.position);
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 45f));
    }
}