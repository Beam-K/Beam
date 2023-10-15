
using System;
using Project.InputDemo;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

public class CharacterController : MonoBehaviour
{
    public float jumpForce = 5f;
    public int moveSpeed ;
    private Rigidbody2D rb;
    private float rotation = 0f; 
    private SpriteRenderer spriteRenderer;
    private Animator _animator;
    public bool touchLeft;  
    public bool touchRight; 
    public int score;
    public Text scoreText;
   
    

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        InputManager.Instance.OnJump += Jump;
    }

    public void Jump()
    {
        rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
    }

    private void Update()
    {
        var direction = new Vector3(0, 0, 0);

        direction.x = InputManager.Instance.DirectionMove;
        
        transform.Translate(direction * (Time.deltaTime * moveSpeed));

        switch (direction.x)
        {
            case -1:
                spriteRenderer.flipX = true;
                break;
            case 1:
                spriteRenderer.flipX = false;
                break;
        }
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Pickup"))
        {
            score += 10;
            scoreText.text = score.ToString();
            Destroy(collision.gameObject);
            
        }
    }
}

