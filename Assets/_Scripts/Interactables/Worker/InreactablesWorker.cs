using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LP.FDG.Buildings.build;

namespace LP.FDG.Interactables.Worker
{
    public class InreactablesWorker : MonoBehaviour
    {       
        public GameObject BuildingManager = null;
        public GameObject BuildingTypeSelectUI = null;
        public virtual void Awake()
        {
           // BuildingManager.SetActive(false);
           // BuildingTypeSelectUI.SetActive(false);            
        }
        public virtual void OnInteractEnter()
        {
            ShowUIMenu();
            //isInteracting = true;
        }
        public virtual void OnInteractExit()
        {
            HideUIMenu();
            //isInteracting = false;
        }
        public virtual void ShowUIMenu()
        {
            BuildingManager.SetActive(true);
            BuildingTypeSelectUI.SetActive(true);
            //highlight.SetActive(true);
        }
        public virtual void HideUIMenu()
        {
            BuildingManager.SetActive(false);
            BuildingTypeSelectUI.SetActive(false);
            //highlight.SetActive(false);
        }
    }
}
