using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene1_Manager : MonoBehaviour
{
    public Animator myTransition;

    public void Start()
    {
            ChangeTheScene(1);
    }

    public void ChangeTheScene(int sceneID)
    {
        // change the scene now
        Debug.Log("Change the scene to " + sceneID.ToString());
        // UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        StartCoroutine(LoadMyLevel(sceneID));
    }

    IEnumerator LoadMyLevel(int levelIindex)
    {
        yield return new WaitForSeconds(2f);

        // play anmiation
        myTransition.SetTrigger("Start");
        
        // Wait
        yield return new WaitForSeconds(2f);

        // load the scene
        UnityEngine.SceneManagement.SceneManager.LoadScene(levelIindex);
    }
}
