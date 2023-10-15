using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Coint : MonoBehaviour
{
    public int count;
    private GameObject _player;
    public AudioClip audioClip;
    private AudioSource _audioSource;


    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _audioSource = _player.GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
           
            _audioSource.PlayOneShot(audioClip);
            Destroy(gameObject);
        }
    }
}
