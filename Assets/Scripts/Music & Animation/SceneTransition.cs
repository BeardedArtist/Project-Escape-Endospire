using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTransition : MonoBehaviour
{
    public Animator transitionAnim;

    public void LoadSceneAnimation()
    {
        StartCoroutine(LoadSceneAnim());
    }

    IEnumerator LoadSceneAnim()
    {
        transitionAnim.SetTrigger("End");
        yield return new WaitForSeconds(1.5f);
    }
}
