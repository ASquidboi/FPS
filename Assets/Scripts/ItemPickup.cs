using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public GameObject Weapon;
    public GameObject player;
    public static bool InRange = false;
    public GameObject fpsCam;
    public float range = 100f;
    public Transform Self;
    public GameObject Depot;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float minDist = 2;
        float dist = Vector3.Distance(player.transform.position, transform.position);
        if(dist < minDist)
        {
            
            RaycastHit hit;
            if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
            {
                ItemPickup item = hit.transform.GetComponent<ItemPickup>();
                if(item != null) 
                {
                    InRange = true;
                    if(Input.GetButtonDown("Interact") && dist < minDist)
                    {
                        Pickup();    
                    }
                }
                
            }
        } else
        {
            InRange = false;
        }
        
        
    }
    void Pickup()
    {
        Weapon.gameObject.SetActive(true);
        transform.position = Depot.transform.position;
    }
}
