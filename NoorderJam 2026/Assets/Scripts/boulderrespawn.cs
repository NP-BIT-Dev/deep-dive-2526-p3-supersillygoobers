using UnityEngine;

public class boulderrespawn : MonoBehaviour
{
    public GameObject boulder;
    private Vector2 savedPosition;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        savedPosition = boulder.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("boulder"))
        {
            boulder.transform.position = savedPosition;
        }
    }
}
