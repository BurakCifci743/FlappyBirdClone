using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    private Rigidbody2D rb2d;
    [Header("Settings")]
    [SerializeField] private float scrollSpeed = -1.3f;
    private float width;
    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.linearVelocity = new Vector2(scrollSpeed, 0f);
        width = GetComponent<SpriteRenderer>().bounds.size.x;
    }
    private void Update()
    {
        if (transform.position.x < -width)
        {
            transform.position += new Vector3((width * 2f - 0.01f), 0f, 0f);
        }
    }
}
