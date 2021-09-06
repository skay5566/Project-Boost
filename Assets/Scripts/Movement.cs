using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rb;
    AudioSource audioSource;
    [SerializeField] float mainThrust = 9001f;
    [SerializeField] float rotationThrust = 1f;
    [SerializeField] AudioClip  engineSound;
    [SerializeField] AudioClip  trustersSound;
    [SerializeField] ParticleSystem engineParticles;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();    
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(engineSound);
            }
            if (!engineParticles.isPlaying)
            {
                engineParticles.Play();
            }
            rb.AddRelativeForce(Vector3.up * Time.deltaTime * mainThrust);
        } else {
            audioSource.Stop();
            engineParticles.Stop();
        }
    }

    void ProcessRotation ()
    {
        if (Input.GetKey(KeyCode.A))
        {
            ApplyRotation(rotationThrust);
             if (!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(trustersSound);
            }
        }
        else if (Input.GetKey(KeyCode.D))
        {
            ApplyRotation(-rotationThrust);
             if (!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(trustersSound);
            }
        }
    }

    private void ApplyRotation(float rotationThisFrame)
    {
        rb.freezeRotation = true;
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        rb.freezeRotation = false;
    }
}
