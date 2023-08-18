using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediumHealthPack : MonoBehaviour
{
    public static float amount = 40f;
    public ParticleSystem HealEffect;
    public float accelx, accely, accelz = 0;

    void Update ()
    {
        // accelx = Input.acceleration.x;
        // accely = Input.acceleration.y;
        // accelz = Input.acceleration.z;
        transform.Rotate (accelx * Time.deltaTime, accely * Time.deltaTime, accelz * Time.deltaTime);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame  
    void OnTriggerEnter()
    {
        Health.Regen(amount);
        Destroy(gameObject);
        HealEffect.Play();
    }
}
