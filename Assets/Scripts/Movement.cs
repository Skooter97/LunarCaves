using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float mainThrust = 10f;
    [SerializeField] float rotaionSpeed = 10f;
    [SerializeField] AudioClip mainEngine;

    [SerializeField] ParticleSystem mainThrustParticles;
    [SerializeField] ParticleSystem rightTurnThrustParticles;
    [SerializeField] ParticleSystem leftTurnThrustParticles;

    Rigidbody rb;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotaion();
    }

    void ProcessThrust()
    {
        ShipsThrustControl();
    }
    void ProcessRotaion()
    {
        ShipSteering();
    }

    void ShipsThrustControl()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
            if (!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(mainEngine);
            }
            if (!mainThrustParticles.isPlaying)
            {
                mainThrustParticles.Play();
            }
        }
        else
        {
            audioSource.Stop();
            mainThrustParticles.Stop();
        }
    }

    void ShipSteering()
    {
        if (Input.GetKey(KeyCode.A))
        {
            ApplyRotation(rotaionSpeed);
            if (!leftTurnThrustParticles.isPlaying)
            {
                leftTurnThrustParticles.Play();
            }
        }
        else if (Input.GetKey(KeyCode.D))
        {
            ApplyRotation(-rotaionSpeed);
            if (!rightTurnThrustParticles.isPlaying)
            {
                rightTurnThrustParticles.Play();
            }
        }
        else
        {
            rightTurnThrustParticles.Stop();
            leftTurnThrustParticles.Stop();
        }
    }

    private void ApplyRotation(float rotationThisFrame)
    {
        rb.freezeRotation = true; 
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        rb.freezeRotation = false;
    }
}
