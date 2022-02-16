using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefulShip : MonoBehaviour
{
    public AudioClip refuelShip;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionStay(Collision other) 
    {
        audioSource.PlayOneShot(refuelShip);
    }
}
