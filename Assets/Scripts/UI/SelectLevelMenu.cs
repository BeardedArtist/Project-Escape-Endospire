using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectLevelMenu : MonoBehaviour
{

    public void LevelSelect(string sceneName) 
    {
        SceneManager.LoadScene(sceneName);
    }


}
