using UnityEngine;
using System.Collections;


public class AutomaticGun : MonoBehaviour
{
    //Various gun info
    public float damage = 40f;
    public float range = 100f;
    public float fireRate = 5f;
    //Camera for raycasting
    public Camera fpsCam;
    //Impact effects & muzzle flash
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;
    public float impactForce = 30f;
    //Weapon timing
    private float nextTimeToFire = 0f;
    //Animation stuff
    public Animator animator;
    public AudioSource firingSound;
    public float ammo = 25f;
    public float magsize = 25f;
    public fracture breakScript;
    public float ReloadTime = 3f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Fire1") && Time.time >= nextTimeToFire  && ammo > 0)
        {
            nextTimeToFire = Time.time + 1f/fireRate;
            Shoot();
        }
        if(Input.GetButtonDown("Reload"))
        {
            StartCoroutine(Reload());
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
                Button button = hit.transform.GetComponent<Button>();
                if(hit.rigidbody != null)
                {
                    hit.rigidbody.AddForce(-hit.normal * impactForce);
                }
                GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(impactGO, 0.25f);
                ammo -= 1;
            }
            firingSound.Play();
        }

        IEnumerator Reload()
        {
            animator.SetTrigger("Reload");
            yield return new WaitForSeconds(ReloadTime);
            ammo = magsize;
        }
        
    }
}
