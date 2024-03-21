using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        // AudioSource bileşenini al
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySound()
    {
        // Ses dosyasını çal
        if (audioSource != null)
        {
            audioSource.Play();
        }
    }
}
