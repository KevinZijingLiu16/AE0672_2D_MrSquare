using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthManager : MonoBehaviour //Inheritance from MonoBehaviour
{
    public Image healthBar;
    public float maxHealth = 100f;
    public float health = 100f;
    public float trapDamage = 10f; 
    public float hopeRefill = 20f; 
    // the reason why we use public is because we want to expose the variable to Unity Inspector.

    [SerializeField] private AudioSource damageAudioSource;
    [SerializeField] private AudioSource healAudioSource;
    [SerializeField] private AudioSource deathAudioSource;
    // OOP: Encapsulation - private. use [SerializeField] to expose to Unity Inspector.
    void Start()
    {
        // Initialize the player's health to the maximum value.
        health = maxHealth;
        UpdateHealthBar();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            
            TakeDamage(trapDamage); // reduce health
            damageAudioSource.Play();
        }
        if (collision.gameObject.CompareTag("Cube"))
        {
            CollectHope(collision.gameObject);// add health
            healAudioSource.Play();
        }


    }

    void UpdateHealthBar()
    {
       
        float healthRatio = health / maxHealth;
        healthBar.fillAmount = healthRatio; //update the health bar
    }

    public void TakeDamage(float damageAmount)
    {
        
        health -= damageAmount;

        health = Mathf.Max(health, 0f);
        // ensure health doesn't go below zero.

        UpdateHealthBar();
        // Update the health bar.

        
        if (health <= 0f)// is the player health <= 0, call Die() method, play death sound
        {
            Die();
            deathAudioSource.Play();
        }
    }
    public void CollectHope(GameObject hope)
    {
        // destroy the health object.
        Destroy(hope);
        // add health
        health += hopeRefill;

        // ensure health doesn't go above the maximum value.
        health = Mathf.Clamp(health, 0f, maxHealth);

      
        UpdateHealthBar();

    }
    void Die()
    {
        // reload the current scene:
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

   

    void Update()
    {
       
    }
}
