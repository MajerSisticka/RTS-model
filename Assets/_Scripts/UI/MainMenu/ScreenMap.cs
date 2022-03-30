using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace LP.FDG.UI.MainMenu
{
    public class ScreenMap : MonoBehaviour
    {
        [SerializeField]
        private string LevelToLoad;
                
        public void SetLevel()
        {
            try
            {
                SceneManager.LoadScene(LevelToLoad);
            }
            catch (System.Exception)
            {

                Debug.LogWarning("Scéna nenalezena");
            }
            
        }
        
    }
}
