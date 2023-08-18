using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    public void BackToMenu()
    {
        Debug.Log("Returning to menu...");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        Screen.lockCursor = false;
    }
}
