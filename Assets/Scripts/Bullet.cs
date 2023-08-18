using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public int damage = 40;
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.up * speed;
    }
    void OnTriggerEnter (Collider hitInfo) 
    {
        Debug.Log("oof");
        Health player =hitInfo.GetComponent<Health>();
        if (player != null)
        {
            Debug.Log("Hit");
            player.TakeDamage(damage);
        }
        Destroy(gameObject);
    }
}
