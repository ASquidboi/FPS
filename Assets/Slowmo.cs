using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slowmo : MonoBehaviour
{
    public float slowmospeed = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Slowmo"))
        {
            SlowMotion();
        }
        if(Input.GetButtonUp("Slowmo"))
        {
            StopSlowmo();
        }
    }
    
    void SlowMotion()
    {Time.timeScale = slowmospeed;
        
    }
    void StopSlowmo()
    {
        Time.timeScale = 1f;
    }
}
