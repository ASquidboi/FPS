using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropelShards : MonoBehaviour
{
    private Rigidbody rb;
    public float speed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.up * speed;
        Debug.Log("Done");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
