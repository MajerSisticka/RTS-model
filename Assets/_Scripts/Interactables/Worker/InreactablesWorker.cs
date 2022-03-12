using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LP.FDG.Buildings.build;

namespace LP.FDG.Interactables.Worker
{
    public class InreactablesWorker : BuildingTypeGroup
    {
        public bool isInteracting = false;
        public GameObject highlight = null;
        public virtual void Awake()
        {
            highlight.SetActive(false);
            
        }
        public virtual void OnInteractEnter()
        {
            ShowHighlight();

            isInteracting = true;
        }
        public virtual void OnInteractExit()
        {
            HideHighlight();
            isInteracting = false;
        }
        public virtual void ShowHighlight()
        {
            highlight.SetActive(true);
            activatebuilding();
        }
        public virtual void HideHighlight()
        {
            DEactivatebuilding();
            highlight.SetActive(false);
        }
    }
}
