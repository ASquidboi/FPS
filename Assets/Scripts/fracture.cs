using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fracture : MonoBehaviour
{
    public GameObject fractured;
    public GameObject self;
    public Vector3 loc;
    public AudioSource audio;
    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter()
    {
        Shatter();
    }
    public void Shatter()
    {
        audio.Play();
        Vector3 oldPos = transform.position;
        Instantiate(fractured, oldPos, Quaternion.identity);
        Destroy(gameObject);
    }
}
