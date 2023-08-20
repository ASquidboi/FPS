using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeEditor : MonoBehaviour
{
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        audioSource.volume = Sound.Volume;
    }
}
