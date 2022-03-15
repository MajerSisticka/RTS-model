using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
namespace LP.FDG.InputManager
{
    public class ChangeToMenu : MonoBehaviour
    {
        private string levelToLoad = "MainMenu";
        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Debug.LogWarning("pøepnutí do sceny" + levelToLoad);
                SceneManager.LoadScene(levelToLoad);
            }
        }
    }
}

