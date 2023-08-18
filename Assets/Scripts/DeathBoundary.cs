using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathBoundary : MonoBehaviour
{
    public int CurrentScene = 2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision);
        SceneManager.LoadScene(CurrentScene);
        // DeathMenu.Die();
    }
}
