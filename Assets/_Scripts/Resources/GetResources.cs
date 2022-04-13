using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LP.FDG.Buildings;
using UnityEngine.UI;
using LP.FDG.Buildings.build;
namespace LP.FDG.Resources
{
    public class GetResources : MonoBehaviour
    {
        public int Gold;     
        public int DelayAmount = 2; // Second count
        public Text GoldValueText;
        public Text PowerText;

        protected float Timer;
        private void Start()
        {
            Gold = 10;
        }
        void Update()
        {
            Debug.LogWarning
            (
            "DelayAmount :"
            +
            DelayAmount
            );
            Timer += Time.deltaTime;

            if (Timer >= DelayAmount)
            {
                Timer = 1f;
                Gold += 2;
                Debug.LogWarning
                (
                "Timer : "
                +
                Timer
                );                
            }
            Debug.LogWarning
            (
            "Poèet zlata : "
            +
            Gold
            );
            Debug.LogWarning("dìkuji za pozornost");
        }
    }
}

