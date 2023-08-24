using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class autoammodisplay : MonoBehaviour
{
    public AutomaticGun gun; //Reference to the shotgun script
    private TMP_Text ammoText;
    // Start is called before the first frame update
    void Start()
    {
        ammoText = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        ammoText.text = gun.ammo + "/" + gun.magsize;
    }
}
