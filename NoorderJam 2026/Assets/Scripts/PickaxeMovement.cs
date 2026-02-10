using System;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.InputSystem;

public class PickaxeMovement : MonoBehaviour
{
    float angle;
    Vector2 direction;
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Mathf.Abs(Camera.main.transform.position.z);
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        direction = (mousePos - transform.position);
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 45f));
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log(angle);
            if (angle > 0)
            {
                this.GetComponentInParent<Rigidbody2D>().linearVelocity = new Vector2(direction.x, direction.y).normalized * 5f;
            }
            if (angle < 0)
            {
                this.GetComponentInParent<Rigidbody2D>().linearVelocity = new Vector2(direction.x, direction.y).normalized * 5f;
            }
        }
    }
}