using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMover : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameManager _gameManager;

    private Rigidbody2D rb2d;
  
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.linearVelocity = new Vector2(-1.5f, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("carpti");
            Variables.isLive = 1;
        }
    }
}
