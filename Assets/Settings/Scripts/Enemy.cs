using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class Enemy : MonoBehaviour
{
    public float speed;
    public Vector3[] positions;

    private int _currentTarget;

    public void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, positions [_currentTarget], speed);

        if (transform.position == positions [_currentTarget])
        {
            if (_currentTarget < positions.Length -1)
            {
                _currentTarget++;
                
            }
            else
            {
                _currentTarget = 0;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}