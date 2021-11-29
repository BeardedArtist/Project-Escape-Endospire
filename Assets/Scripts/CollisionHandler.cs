using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float delay = 2.8f;
    [SerializeField] AudioClip rocketExplosion;
    [SerializeField] AudioClip levelComplete;

    [SerializeField] ParticleSystem levelCompleteParticles;
    [SerializeField] ParticleSystem rocketExplosionParticles;

    Movement movement;
    AudioSource audioSource;
    bool isTransitioning = false;
    // this bool will be used to help set up logic that won't allow for other methods to play if one is activated
    bool collisionDisabled = false;

    private void Start() 
    {
        movement = GetComponent<Movement>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update() 
    {
        DebugKeysAction();
        
    }

    void DebugKeysAction() 
    {
        if (Input.GetKeyDown(KeyCode.L)) 
        {
            LoadNextLevel();
        }
        
        else if (Input.GetKeyDown(KeyCode.C)) 
        {
            collisionDisabled = !collisionDisabled; // toggle collision
        }

        else if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            SceneManager.LoadScene("Start Menu");
        }
    }

    private void OnCollisionEnter(Collision other) 
    {
        // if isTransitioning is true (when a method is initiated), other methods cannot initiate.
        if (isTransitioning || collisionDisabled) {return;}

        // the argument here is checking for what objects are being collided with (other) and .tag is 
        // checking for a specific tag.
        switch (other.gameObject.tag) 
        {
            // "Friendly" refers to the tag given to the landing pad.
            case "Friendly":
                break;

            case "Refull Station":
                break;

            // "Finish" refers to the tag given to the landing pad.
            case "Finish":
                StartGoalSequence();
                break;

            // default refers to the rest of the objects with no tags that will result in damage to the player

            default:
                StartCrashSequence();
                break;
        }
    }

    private void StartCrashSequence() 
    {
        // disabling the movement script from players.
        // Invoking a 1 second delay after player collides with object.
        isTransitioning = true;
        //audioSource.Stop() will stop the rocket noise and then the next line will activate the correct sound
        audioSource.Stop();
        audioSource.PlayOneShot(rocketExplosion);
        rocketExplosionParticles.Play(rocketExplosionParticles);
        movement.enabled = false;
        Invoke("ReloadLevel", delay);
    }

    private void StartGoalSequence() 
    {
            isTransitioning = true;
            audioSource.Stop();
            audioSource.PlayOneShot(levelComplete);
            levelCompleteParticles.Play(levelCompleteParticles);
            movement.enabled = false;
            Invoke("LoadNextLevel", delay);  
    }

    void ReloadLevel() 
    {
        // Using scene manager to load scene after player crashes.
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    private void LoadNextLevel() 
    {
        // currentSceneIndex gets current level index.
        // nextLevelIndex adds 1 to the currentSceneIndex to help compare next index.
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextLevelIndex = currentSceneIndex + 1;

        // if statement here checks to see if the nextLevelIndex is equal to the total number of levels in the game
        // This is done through SceneManager.sceneCountInBuildSettings
        if (nextLevelIndex == SceneManager.sceneCountInBuildSettings) 
        {
            nextLevelIndex = 0;
        }
        SceneManager.LoadScene(nextLevelIndex);
    }



}
