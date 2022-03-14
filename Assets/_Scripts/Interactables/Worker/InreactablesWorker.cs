using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LP.FDG.Buildings.build;

namespace LP.FDG.Interactables.Worker
{
    public class InreactablesWorker : MonoBehaviour
    {
        public bool isInteracting = false;
        public GameObject highlight = null;
        [SerializeField] private GameObject buildingManager = null;
        [SerializeField] private GameObject buildingTypeSelectUI = null;
        public virtual void Awake()
        {
            highlight.SetActive(false);
            //buildingManager.SetActive(false);
            buildingManager.GetComponent<BuildingManager>().enabled = false;
            //buildingTypeSelectUI.SetActive(false);
            buildingTypeSelectUI.GetComponent<CanvasGroup>().alpha = 0f;
            buildingTypeSelectUI.GetComponent<CanvasGroup>().interactable = false;
            buildingManager = GameObject.Find("/BuildingManager");
            buildingTypeSelectUI = GameObject.Find("BuildingTypeSelectUI");
        }
        public virtual void OnInteractEnter()
        {
            Debug.LogWarning("OnInteractEnter");
            ShowHighlight();

            isInteracting = true;
        }
        public virtual void OnInteractExit()
        {
            Debug.LogWarning("OnInteractExit");
            HideHighlight();
            isInteracting = false;
        }
        public virtual void ShowHighlight()
        {
            Debug.LogWarning("Show");
            buildingManager.GetComponent<BuildingManager>().enabled = true;
            //buildingManager.SetActive(true);
            buildingTypeSelectUI.GetComponent<CanvasGroup>().alpha = 1f;
            buildingTypeSelectUI.GetComponent<CanvasGroup>().interactable = true;
            //buildingTypeSelectUI.SetActive(true);
            highlight.SetActive(true);
            //activatebuilding();
            isInteracting = true;
        }
        public virtual void HideHighlight()
        {
            Debug.LogWarning("HIDE");
            //DEactivatebuilding();
            //buildingManager.SetActive(false);
            //buildingTypeSelectUI.SetActive(false);
            highlight.SetActive(false);
            isInteracting = false;
        }
    }
}
