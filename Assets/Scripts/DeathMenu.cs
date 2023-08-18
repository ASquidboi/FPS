using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{
    public static bool GameIsPaused = false; 
    public GameObject deathMenuUI;
    public int CurrentScene = 2;
    void Update()
    {
        
    }
    public void Respawn()
    {
        SceneManager.LoadScene(CurrentScene);
        // deathMenuUI.SetActive(false);
        // Time.timeScale = 1f;
        // GameIsPaused = false;
        // Screen.lockCursor = true;
    }
    public void Die()
    {
        deathMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        Screen.lockCursor = false;
    }
    public void Options()
    {

    }
    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
