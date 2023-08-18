using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemUI : MonoBehaviour
{
    public GameObject UI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ItemPickup.InRange) {
            UI.SetActive(true);
        } else
        {
            UI.SetActive(false);
        }
    }
}
