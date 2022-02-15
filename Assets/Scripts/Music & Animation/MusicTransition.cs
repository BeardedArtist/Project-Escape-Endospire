using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicTransition : MonoBehaviour
{
    
    private static MusicTransition instance;

    void Awake() 
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);

            if (SceneManager.GetActiveScene().name == "WinScreen")
                {
                    Destroy(gameObject);
                }
        }
        else
        { 
        
            Destroy(gameObject);
        }
    }
}
