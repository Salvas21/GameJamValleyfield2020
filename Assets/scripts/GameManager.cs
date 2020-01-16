using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Animator transitionAnim;
    public void PlayGame()
    {
        StartCoroutine(LoadScene());
    }
    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
    
    IEnumerator LoadScene()
    {
        transitionAnim.SetTrigger("end");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("SampleScene");
    }

    IEnumerator LoadEndScene()
    {
        transitionAnim.SetTrigger("end");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("MainMenu");
    }

    public void RestartGame()
    {
        StartCoroutine(LoadEndScene());
    }


}
    