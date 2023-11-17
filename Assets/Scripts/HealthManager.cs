using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthManager : MonoBehaviour
{
    public Image healthBar;
    public float maxHealth = 100f;
    public float health = 100f;
    public float trapDamage = 10f; // Adjust this value as needed for trap damage.
    public float hopeRefill = 20f; // Adjust this value as needed for hope amount.


    [SerializeField] private AudioSource damageAudioSource;
    [SerializeField] private AudioSource healAudioSource;
    [SerializeField] private AudioSource deathAudioSource;

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
            // The player has collided with a trap. Reduce health by the trap damage amount.
            TakeDamage(trapDamage);
            damageAudioSource.Play();
        }
        if (collision.gameObject.CompareTag("Cube"))
        {
            CollectHope(collision.gameObject);
            healAudioSource.Play();
        }


    }

    void UpdateHealthBar()
    {
        // Update the health bar based on the player's current health.
        float healthRatio = health / maxHealth;
        healthBar.fillAmount = healthRatio;
    }

    public void TakeDamage(float damageAmount)
    {
        // Reduce the player's health by the specified damage amount.
        health -= damageAmount;

        // Ensure health doesn't go below zero.
        health = Mathf.Max(health, 0f);

        // Update the health bar.
        UpdateHealthBar();

        // Check if the player's health has reached zero.
        if (health <= 0f)
        {
            Die();
            deathAudioSource.Play();
        }
    }
    public void CollectHope(GameObject hope)
    {
        // Destroy the hope object.
        Destroy(hope);
        // Increase the player's health by the hope amount.
        health += hopeRefill;

        // Ensure health doesn't go above the maximum value.
        health = Mathf.Clamp(health, 0f, maxHealth);

        // Update the health bar.
        UpdateHealthBar();

    }
    void Die()
    {
        // Handle the player's death (e.g., display a game over screen, respawn, or reload the scene).
        // For example, you can reload the current scene:
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Add a Heal method here if you want to implement healing.

    void Update()
    {
        // Additional logic can be added here if needed.
    }
}
