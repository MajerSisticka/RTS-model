using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LP.FDG.Buildings.build;

namespace LP.FDG.Interactables.Worker
{
    public class InreactablesWorker : MonoBehaviour
    {
        public bool isInteracting = false;
        public GameObject BuildingManager;
        public GameObject BuildingTypeSelectUI;
        
        public virtual void Start()
        {
           Debug.Log("zmaèkla si workera");
           BuildingManager.SetActive(false);
           BuildingTypeSelectUI.SetActive(false);            
        }
        public virtual void OnInteractEnter()
        {
            ShowUIMenu();
            isInteracting = true;
        }
        public virtual void OnInteractExit()
        {
            HideUIMenu();
            isInteracting = false;
        }
        public virtual void ShowUIMenu()
        {
            //BuildingManager.SetActive(true);
            //BuildingTypeSelectUI.SetActive(true);
            //activatebuilding();
            Debug.Log("zmaèkla si workera");
        }
        public virtual void HideUIMenu()
        {
            //DEactivatebuilding();
            //BuildingManager.SetActive(false);
            //BuildingTypeSelectUI.SetActive(false);
            //highlight.SetActive(false);
            Debug.Log("NEzmaèkla si workera");


        }
    }
}
