using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void PlayGame() 
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

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


    public void QuitGame() 
    {
        Debug.Log("Quit");
        Application.Quit();
    }


}
