using TMPro;
using UnityEngine;


public class Player : MonoBehaviour
{
    [Header("References")]
    private Rigidbody2D rb2d;
    private Animator _animator;
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private TextMeshProUGUI scoreText;


    [Header("Settings")]
    [SerializeField] private float jumpForce = 5f;

    [HideInInspector] private bool isGrounded = false;
    [HideInInspector] private bool isGameStarted = false;
    private int score = 0;



    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _animator.updateMode = AnimatorUpdateMode.UnscaledTime;
        rb2d.gravityScale = 0f;
    }
    private void Start()
    {
    }
    private void Update()
    {
        if (!isGrounded)
        {
            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
            {
                if (!isGameStarted)
                {
                    isGameStarted = true;
                    rb2d.gravityScale = 1f;
                }

                rb2d.linearVelocityY = jumpForce;
                _animator.SetTrigger(Constraints.FlyingTrigger);
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")||Variables.isLive==1)
        {
            _animator.SetTrigger(Constraints.DeadTrigger);
            isGrounded = true;
            _gameManager.GameOver();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ScoreTrigger"))
        {
            score++;
            scoreText.text = score.ToString();
            Debug.Log("Score: " + score);
        }
    }
}
