using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    private Button jumpButton;
    private bool isGrounded;

    private Rigidbody2D rigidbody2D;
    private SpriteRenderer _spriteRenderer;

    private Animator _animator;
    public int score;
    public Text scoreText;

    public float timerScale;
    public float timerScaleMax;
    

    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();

        
    }

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }

        Vector3 pozition = transform.position;

        pozition.x += Input.GetAxis("Horizontal") * speed;

        transform.position = pozition;


        if (Input.GetAxis("Horizontal") != 0)
        {
            if (Input.GetAxis("Horizontal") > 0)
            {
                _spriteRenderer.flipX = false;
            }
            else if (Input.GetAxis("Horizontal") < 0)
            {
                _spriteRenderer.flipX = true;
            }

            _animator.SetInteger("State", 1);
        }
        else
        {
            _animator.SetInteger("State", 0);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
             SceneManager.LoadScene(0);
        }
       
        
    }


    private void Jump()
    {
        if (isGrounded)
        {
            isGrounded = false;
            rigidbody2D.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    public void AddCount(int count)
    {
        score += count;

        scoreText.text = score.ToString();
    }

    private void BonusCheck()
    {
        if (timerScale>0)
        {
            transform.localScale = new Vector3(2.5f, 2.5f, 1 );

            timerScale--;
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }
    public void ScaleBonus()
    {
        timerScale = timerScaleMax;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }
}