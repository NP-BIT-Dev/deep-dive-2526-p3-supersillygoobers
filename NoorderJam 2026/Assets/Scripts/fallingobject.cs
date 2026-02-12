using UnityEngine;
using UnityEngine.SceneManagement;

public class fallingobject : MonoBehaviour
{
    public GameObject player;

    Rigidbody2D rb;
    private Vector2 savedPosition;

    private Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        savedPosition = player.transform.position;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            rb.bodyType = RigidbodyType2D.Dynamic;
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player.transform.position = savedPosition;
            GameObject.Destroy(gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (collision.gameObject.CompareTag("ground"))
        {
            animator.Play("Stalactite_break");
            GameObject.Destroy(gameObject, 0.5f);
            Debug.Log("Collided with ground");
        }
    }
}
