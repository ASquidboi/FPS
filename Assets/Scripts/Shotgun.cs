using System.Collections;
using System.Collections.Generic;
using Random = UnityEngine.Random;
using UnityEngine;

public class Shotgun : MonoBehaviour
{
    //Various gun info
    public float damage = 20f;
    public float range = 1f;
    public float fireRate = 5f;
    //Camera for raycasting
    public Transform fpsCam;
    //Impact effects & muzzle flash
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;
    public float impactForce = 30f;
    //Weapon timing
    private float nextTimeToFire = 0f;
    //Animation stuff
    public Animator animator;
    public AudioSource firingSound;
    //Ammo
    public float ammo = 5f;
    public float ammoLimit = 5f;
    public float Pellets = 8f;
    // Start is called before the first frame update
    // Start is called before the first frame update
    [SerializeField] private float spreadDistance;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetButtonDown("Fire1") && ammo > 0 && Time.time >= nextTimeToFire)
        {
            ammo -= 1f;
            for(int i = 0; i < Pellets; i++)
            {
                Shoot();
            }
            nextTimeToFire = Time.time + 1f/fireRate;
        }  
        if (Input.GetButtonDown("Reload"))
        {
            Reload();
        }
    }
    void Shoot()
    {
        Vector3 direction = fpsCam.transform.forward; // your initial aim.
        Vector3 spread = Vector3.zero;
        spread += fpsCam.transform.up * Random.Range(-spreadDistance, spreadDistance); // add random up or down (because random can get negative too)
        spread += fpsCam.transform.right * Random.Range(-spreadDistance, spreadDistance); // add random left or right
        Debug.Log(spread);
        //Debug.Log("Hello there");

        // Using random up and right values will lead to a square spray pattern. If we normalize this vector, we'll get the spread direction, but as a circle.
        // Since the radius is always 1 then (after normalization), we need another random call. 
        //direction += spread.normalized() * Random.Range(0f, 0.2f);
        animator.SetTrigger("Shoot");
        muzzleFlash.Play();
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward + spread, out hit, range))
        {
            Debug.Log(hit.transform.name);
            Target target = hit.transform.GetComponent<Target>();
            if(target != null) 
            {
                target.TakeDamage(damage);
            }
            fracture glass = hit.transform.GetComponent<fracture>();
                if(glass != null) 
                {
                    glass.Shatter();
                }
            if(hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }
            GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, 1f);
            
            Debug.DrawLine(fpsCam.transform.position, hit.point, Color.green, 1f);
            
        } else {
            Debug.DrawLine(fpsCam.transform.position, fpsCam.transform.position + direction * range, Color.red, 1f);
        }
        firingSound.Play();
        
            
    }
    void Reload()
        {
            animator.SetTrigger("Reload");
            ammo = ammoLimit;
        }
}
