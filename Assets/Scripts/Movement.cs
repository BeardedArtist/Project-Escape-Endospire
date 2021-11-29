using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Variablews holding our movement speeds.
    [SerializeField] float MainThruster = 1000f;
    [SerializeField] float RotateThruster = 160f;

    // Variables holding audio clips
    [SerializeField] AudioClip mainEngineAudio;
    [SerializeField] AudioClip rightEngineAudio;
    [SerializeField] AudioClip leftEngineAudio;

    // Variables holding particle effects.
    [SerializeField] ParticleSystem mainEngineParticles;
    [SerializeField] ParticleSystem leftBoosterParticles;
    [SerializeField] ParticleSystem rightBoosterParticles;


    //Variables for caching
        Rigidbody rb;
        AudioSource audioSource;
        AudioSource rightEngineAudioSource;
        AudioSource leftEngineAudioSource;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ProcessThrust();
        ProcessRotation();

        if ((rb != null) && rb.IsSleeping()) 
        {
            rb.WakeUp();
        }
    }


    void ProcessThrust() 
    {
        if (Input.GetKey(KeyCode.Space)) 
        {
            StartBoosting();
        }
        
        else if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D)) 
        {
            StopBoosting();
        }
    }

    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            RotateLeft();
        }

        else if (Input.GetKey(KeyCode.D)) 
        {
            RotateRight();
        }

        else 
        {
            StopRotating();
        }
    }


    void StartBoosting() 
    {
        if (Input.GetKey(KeyCode.Space)) 
        {
            // Adding relative force upword so player can move relative to the object.
            rb.AddRelativeForce(Vector3.up * MainThruster * Time.deltaTime);
            //adding audio when button is played. !audioSource.isPlaying allows us to stop audio layering
            if (!audioSource.isPlaying) 
            {
                // audioSource.PlayOneShot() allows us to play multiple audio files. Here, mainEngineAudio will activate when space bar is pressed.
                audioSource.PlayOneShot(mainEngineAudio);
            }
            if (!mainEngineParticles.isEmitting) 
            {
                mainEngineParticles.Play(mainEngineParticles);
            }
        }
    }

    public void StopBoosting() 
    {
        audioSource.Stop();
        mainEngineParticles.Stop(mainEngineParticles);
    }

    void RotateLeft() 
    {
        ApplyRotation(RotateThruster);

        if (!audioSource.isPlaying) 
        {
            audioSource.PlayOneShot(rightEngineAudio);
        }

        if (!rightBoosterParticles.isEmitting) 
        {
            rightBoosterParticles.Play();
        }
    }

    void RotateRight() 
    {
        ApplyRotation(-RotateThruster);

        if(!audioSource.isPlaying) 
        {
            audioSource.PlayOneShot(leftEngineAudio);
        }
        
        if (!leftBoosterParticles.isEmitting) 
        {
            leftBoosterParticles.Play();
        }
    }

    void StopRotating() 
    {
        rightBoosterParticles.Stop();
        leftBoosterParticles.Stop();
        
        if(!Input.GetKey(KeyCode.Space)) 
        {
            audioSource.Stop();
        }
    }


    void ApplyRotation(float rotationThisFrame)
    {
        rb.freezeRotation = true; // freezing rotation so we can manually rotate. Fixing the bug when player hits obstacle
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        rb.freezeRotation = false; // unfreezing rotation so the physics system can take over
    }
}
