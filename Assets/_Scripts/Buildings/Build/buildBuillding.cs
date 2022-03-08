using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace LP.FDG.Buildings.build
{
    public class buildBuillding : MonoBehaviour
    {
        public GameObject buildingBlueprint;
        //pozdìji pøidìlat list
        public void spawn_building()
        {
            Instantiate(buildingBlueprint);
        }

        
    }
}

