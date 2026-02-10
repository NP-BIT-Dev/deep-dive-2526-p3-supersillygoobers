using UnityEngine;

public class boulder : MonoBehaviour
{
    public GameObject player;
    private Vector2 savedPosition;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        savedPosition = player.transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player.transform.position = savedPosition;
        }
    }
}
