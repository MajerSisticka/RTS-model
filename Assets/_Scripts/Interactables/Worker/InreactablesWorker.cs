using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LP.FDG.Buildings.build;

namespace LP.FDG.Interactables.Worker
{
    public class InreactablesWorker : MonoBehaviour
    {       
        public GameObject BuildingManager;
        public GameObject BuildingTypeSelectUI;
        public bool active = true;
        public virtual void Start()
        {
           Debug.Log("zmaèkla si workera");
           BuildingManager.SetActive(false);
           BuildingTypeSelectUI.SetActive(false);            
        }
        public virtual void OnInteractEnter()
        {
            ShowUIMenu();
            active = true;
        }
        public virtual void OnInteractExit()
        {
            HideUIMenu();
            active = false;
        }
        public virtual void ShowUIMenu()
        {
            BuildingManager.SetActive(true);
            BuildingTypeSelectUI.SetActive(true);
            //highlight.SetActive(true);
            Debug.Log("zmaèkla si workera");
        }
        public virtual void HideUIMenu()
        {
            BuildingManager.SetActive(false);
            BuildingTypeSelectUI.SetActive(false);
            //highlight.SetActive(false);
            Debug.Log("NEzmaèkla si workera");


        }
    }
}
