using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleBonus : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.GetComponent<Player>().ScaleBonus();
            Destroy(gameObject);
        }
    }
}  