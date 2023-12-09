using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using TMPro;

public class ItemCollect : MonoBehaviour
{
    private int goldCount = 0;
    // oop : encapsulation.
    public TextMeshProUGUI goldText;
    // reason to use public: to expose to Unity Inspector.
    [SerializeField] private AudioSource goldCollectSound;
    //declare a variable named goldCollectSound of type AudioSource. 

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
