using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using TMPro;

public class ItemCollect : MonoBehaviour
{
    private int goldCount = 0;
    public TextMeshProUGUI goldText;
    [SerializeField] private AudioSource goldCollectSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Gold"))
        {
            goldCollectSound.Play();
            goldCount++;
            goldText.text = "Gold: " + goldCount;

            Destroy(collision.gameObject);
        }
    }


}
