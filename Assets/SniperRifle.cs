using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperRifle : MonoBehaviour
{
        //Various gun info
    public float damage = 40f;
    public float range = 100f;
    public float fireRate = 15f;
    //Camera for raycasting
    public Camera fpsCam;
    //Impact effects & muzzle flash
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;
    public float impactForce = 30f;
    //Weapon timing
    public float nextTimeToFire = 0f;
    //Animation stuff
    public Animator animator;
    public Animator animator2;
    public AudioSource firingSound;
    public float ammo = 12f;
    public float magsize = 12f;

    private bool isScoped = false;
    public GameObject scopeOverlay;
    public GameObject weaponCamera;
    public float slowmo = 0.5f;
    public float FOV = 15f;
    public float normalFOV = 60f;
    public float ReloadTime = 5f;
    //Ammo

    //public float ammo = 25f;
    //public float magsize = 25f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1") && Time.time >= nextTimeToFire && ammo > 0)
        {
            nextTimeToFire = Time.time + 1f/fireRate;
            Shoot();
        }
        if(Input.GetButtonDown("Reload"))
        {
            Reload();
        }
        void Shoot() 
        {
            animator.SetTrigger("Shoot");
            muzzleFlash.Play();
            RaycastHit hit;
            if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
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
                ammo -= 1f;
            }
            firingSound.Play();
        }
        

        if (Input.GetButtonDown("Fire2"))
        {
            isScoped = !isScoped;
            animator2.SetBool("Scoped", isScoped);
            if (isScoped){
                StartCoroutine(OnScoped());
            } else {
                OnUnscoped();
            }
        }

        IEnumerator OnScoped()
        {
            yield return new WaitForSeconds(0.15f);

            scopeOverlay.SetActive(true);
            weaponCamera.SetActive(false );
            Time.timeScale = slowmo;
            normalFOV = fpsCam.fieldOfView;
            fpsCam.fieldOfView = FOV;
        }

        void OnUnscoped()
        {
            scopeOverlay.SetActive(false);
            weaponCamera.SetActive(true);
            Time.timeScale = 1f;
            fpsCam.fieldOfView = normalFOV;
        }
    }
    IEnumerator Reload()
    {
        animator.SetTrigger("Reload");
        yield return new WaitForSeconds(ReloadTime);
        ammo = magsize;
    }
}
