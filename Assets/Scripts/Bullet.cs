using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the bullet collides with an object tagged as "Block"
        if (collision.CompareTag("Block"))
        {
            Destroy(collision.gameObject); // Destroy the block
            Destroy(gameObject); // Destroy the bullet
        }
    }
}
