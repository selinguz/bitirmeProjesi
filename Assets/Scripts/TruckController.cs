using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TruckController : MonoBehaviour
{
    public float TurnSpeed = 45f;
    public float acceleration = 20f;
    public static int stop_index;
    private float leftRight = 0f;
    private float forward = 0f;
    private float speed = 20f;
    private Rigidbody rigidbody;

    public static bool isInStop = false;
    public float voiceFadingTime = 1.0f;

    private AudioSource vroomSound;
    private bool truckIsMoving = false;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        vroomSound = GetComponent<AudioSource>();

        StartVroomSound();
    }

    private void Update()
    {
        if (TruckIsMoving())
        {
            if (!truckIsMoving)
            {
                StartVroomSound();
                truckIsMoving = true;
            }
        }
        else
        {
            if (truckIsMoving)
            {
                StopVroomSound();
                truckIsMoving = false;
            }
        }
    }

    bool TruckIsMoving()
    {
        return Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D);
    }

    void StartVroomSound()
    {
        if (vroomSound != null && !vroomSound.isPlaying)
        {
            vroomSound.volume = 1.0f;
            vroomSound.Play();
        }
    }

    void StopVroomSound()
    {
        if (vroomSound != null && vroomSound.isPlaying)
        {
            StartCoroutine(FadeOutSesi());
        }
    }

    System.Collections.IEnumerator FadeOutSesi()
    {
        float soundLevel = vroomSound.volume;
        float passedTime = 0.0f;
            
        while (passedTime < voiceFadingTime)
        {
            vroomSound.volume = Mathf.Lerp(soundLevel, 0.0f, passedTime / voiceFadingTime);
            passedTime += Time.deltaTime;
            yield return null;
        }

        vroomSound.Stop();
    }

    void FixedUpdate()
    {
        leftRight = Input.GetAxis("Horizontal");

        forward = Input.GetAxis("Vertical");

        transform.Rotate(Vector3.up, leftRight * TurnSpeed * Time.deltaTime);
        if (forward != 0)
        {
            rigidbody.AddForce(transform.forward * speed * forward, ForceMode.Acceleration);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        string stopName = other.gameObject.tag;
        if (stopName.Equals("Stop"))
        {
            isInStop = true;
            stop_index = other.GetComponent<StopController>().stop_index;
            other.gameObject.SetActive(false);
        }
    }


}
