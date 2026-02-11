using UnityEngine;

public class enemy : MonoBehaviour
{

    public GameObject player;
    private Vector2 savedPosition;
        public Transform[] targets;
        private SpriteRenderer spider;

    private int currentPointIndex = 0;

    public float speed = 2f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spider = GetComponent<SpriteRenderer>();
        savedPosition = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float move = Input.GetAxis("Horizontal");

        if (targets.Length == 0) return;
        Transform targetPoint = targets[currentPointIndex];
        transform.position = Vector2.MoveTowards(transform.position, targetPoint.position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, targetPoint.position) < 0.1f)
        {
            currentPointIndex++;
            if (currentPointIndex >= targets.Length)
            {
                currentPointIndex = 0;
            }
        }
        else if (transform.position.x > targetPoint.position.x)
        {
            spider.flipX = false;
        }
        else if (transform.position.x < targetPoint.position.x)
        {
            spider.flipX = true;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player.transform.position = savedPosition;
        }
    }
}
