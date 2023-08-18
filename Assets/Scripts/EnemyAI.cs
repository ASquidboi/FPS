using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform player;
    private float nextTimeToFire = 0f;
    public float fireRate = 5f;
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float minDist = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // float minDist = 10;
        float dist = Vector3.Distance(player.transform.position, transform.position);
        if(dist < minDist)
        {
            Vector3 directionToPlayer = player.transform.position - transform.position;
            directionToPlayer.y = 0; // Set the y-component to 0 to ignore vertical rotation
            transform.rotation = Quaternion.LookRotation(directionToPlayer);
            if(Time.time >= nextTimeToFire)
            {
                nextTimeToFire = Time.time + 1f/fireRate;
                Shoot();
            }
        }
        

    }
    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
