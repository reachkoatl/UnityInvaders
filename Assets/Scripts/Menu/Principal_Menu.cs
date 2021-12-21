using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Principal_Menu : MonoBehaviour
{
 

    public void Credits()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);  
    }

    public void StartGameNormal()
    { 
        PlayerPrefs.SetInt("difficult", 1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }

    public void StartGameHell()
    { 
        PlayerPrefs.SetInt("difficult", 2);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }

    public void StartGameFromEnd()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void MenuScreen()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        
    }

    public void MenuScreenFromEnd()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 3);
        
    }

    public void CloseGame()
    {
        Application.Quit();
    }
}
