using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace AE0672
{
    public class EndMenu : MonoBehaviour //Inheritance from MonoBehaviour
    {
        public void RestartGame()
        {
            // Load the first scene in the build settings
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }

        public void QuitGame()
        {
            // Quit the game
            Application.Quit();
        }
    } 
}
