using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Health health; // Reference to the Health script
    public Slider mainSlider;


    private void Start()
    {
        // Get the TMP_Text component attached to this object
        mainSlider.value = 100f;
    }

    private void Update()
    {
        // Update the ammo count text
        mainSlider.value = Health.health;
    }
}
