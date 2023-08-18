using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropWeapon : MonoBehaviour
{
    public GameObject itemDrop;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Drop"))
        {
            gameObject.SetActive(false);
            Instantiate(itemDrop, transform.position, transform.rotation);
        }
    }
}
