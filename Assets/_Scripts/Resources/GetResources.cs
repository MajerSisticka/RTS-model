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
        public int Gold = 0;
        [SerializeField]
        public int CountMinerMinesGeathers = 0;
        void Update()
        {
            Debug.LogWarning("Count Gold materials is : " + Gold);
            StartCoroutine(waitToMine());
            Gold = Gold + (CountMinerMinesGeathers * 2);            
        }
        private IEnumerator waitToMine()
        {
                yield return new WaitForSeconds(200000000000f);
        }
    }
}

