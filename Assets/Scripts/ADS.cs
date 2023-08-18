using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ADS : MonoBehaviour
{
    public Transform gun;
    public Vector3 adsPosition; // The position where the gun should move when aiming down sights
    public Vector3 adsRotation; // The rotation angles when aiming down sights
    public float adsSpeed = 10f; // Adjust this to control the speed of the transition
    public Animator animator;
    public Camera cam;
    public float DestFov = 80f;
    public float speed = 10f;
    

    private Vector3 originalPosition;
    private Vector3 originalRotation;

    void Start()
    {
        originalPosition = gun.localPosition;
        originalRotation = gun.localEulerAngles;
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            animator.SetTrigger("ADS");
            cam.fieldOfView = Mathf.MoveTowards(Camera.main.fieldOfView, DestFov, Time.deltaTime * speed);
            // Move the gun to the ADS position and rotate it accordingly
            // gun.localPosition = Vector3.Lerp(gun.localPosition, adsPosition, Time.deltaTime * adsSpeed);
            // gun.localEulerAngles = Vector3.Lerp(gun.localEulerAngles, adsRotation, Time.deltaTime * adsSpeed);
            
        }
        if (Input.GetButtonUp("Fire2"))
        {
            animator.SetTrigger("Idle");
            cam.fieldOfView = 60;
            // Reset the gun to its original position and rotation
            // gun.localPosition = Vector3.Lerp(gun.localPosition, originalPosition, Time.deltaTime * adsSpeed);
            // gun.localEulerAngles = Vector3.Lerp(gun.localEulerAngles, originalRotation, Time.deltaTime * adsSpeed);
        }
    }
}