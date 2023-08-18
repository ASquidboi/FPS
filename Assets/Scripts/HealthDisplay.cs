using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthDisplay : MonoBehaviour
{
    public Health health; // Reference to the Health script

    private TMP_Text healthText;

    private void Start()
    {
        // Get the TMP_Text component attached to this object
        healthText = GetComponent<TMP_Text>();
    }

    private void Update()
    {
        // Update the ammo count text
        healthText.text = Health.health + "/100";
    }
}
