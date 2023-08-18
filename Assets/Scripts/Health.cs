// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.SceneManagement;

// public class Health : MonoBehaviour
// {
//     public float health = 100f;
//     public int CurrentScene = 2;
//     public GameObject dmgEffect;
//     // Start is called before the first frame update
//     void Start()
//     {
        
//     }

//     // Update is called once per frame
//     void Update()
//     {
        
//     }
//     public void TakeDamage(int damage)
//     {
        
//         health -= damage;
//         if (health <= 0f)
//         {
//             Die();
//         }
//         dmgEffect.SetActive(true);
//     }
//     void Die()
//     {
//         Debug.Log("rip");
//         SceneManager.LoadScene(CurrentScene);
//     }
// }
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public static float health = 100f;
    public int CurrentScene = 2;
    public GameObject dmgEffect;
    public static float maxhealth = 100f;
    public float effectDuration = 1f; // Duration of the effect in seconds

    private void Start()
    {
        dmgEffect.SetActive(false); // Deactivate the effect initially
        health = 100f;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0f)
        {
            Die();
        }
        StartCoroutine(ShowAndHideEffect());
    }

    private IEnumerator ShowAndHideEffect()
    {
        dmgEffect.SetActive(true); // Show the effect

        yield return new WaitForSeconds(effectDuration); // Wait for the specified duration

        // Hide the effect gradually using a gradient or animation if desired
        // For now, let's just deactivate it
        dmgEffect.SetActive(false);
    }

    void Die()
    {
        Debug.Log("rip");
        SceneManager.LoadScene(CurrentScene);
    }
    public static void Regen(float amount)
    {
        health += amount;
        if(health > maxhealth)
        {
            health = maxhealth;
        }
    }
}

