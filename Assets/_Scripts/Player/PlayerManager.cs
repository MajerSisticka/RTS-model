using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using LP.FDG.InputManager;

namespace LP.FDG.Player
{
    public class PlayerManager : MonoBehaviour
    {
        public static PlayerManager instance;

        public Transform playerUnits;
        public Transform enemyUnits;

        public Transform playerBuildings;
        public int PlayerUnitsList = 0;
        public int EnemyUnitsList = 0;
        public int PlayerBuildingsList = 0;


        private void Awake()
        {
            instance = this;
            SetBasicStats(playerUnits);
            SetBasicStats(enemyUnits);
            SetBasicStats(playerBuildings);
            GetBasicStats(playerUnits);
            GetBasicStats(enemyUnits);
            GetBasicStats(playerBuildings);
        }

        private void Update()
        {
            InputHandler.instance.HandleUnitMovement();
            GetBasicStats(playerUnits);
            GetBasicStats(enemyUnits);
            GetBasicStats(playerBuildings);

            if (PlayerUnitsList == 0 && PlayerBuildingsList == 0)
            {
                Debug.LogWarning("Defeat");
            }
            else if (EnemyUnitsList == 0)
            {
                Debug.LogWarning("Victory");
            }
        }

        public void SetBasicStats(Transform type)
        {
            foreach (Transform child in type)
            {
                foreach (Transform tf in child)
                {
                    string name = child.name.Substring(0, child.name.Length - 1).ToLower();
                    //var stats = Units.UnitHandler.instance.GetBasicUnitStats(unitName);

                    if (type == playerUnits)
                    {
                        Units.Player.PlayerUnit pU = tf.GetComponent<Units.Player.PlayerUnit>();
                        pU.baseStats = Units.UnitHandler.instance.GetBasicUnitStats(name);                        
                    }
                    else if (type == enemyUnits)
                    {
                        // set enemy stats
                        Units.Enemy.EnemyUnit eU = tf.GetComponent<Units.Enemy.EnemyUnit>();
                        eU.baseStats = Units.UnitHandler.instance.GetBasicUnitStats(name);                        
                    }
                    else if(type == playerBuildings)
                    {
                        Buildings.Player.PlayerBuilding pB = tf.GetComponent<Buildings.Player.PlayerBuilding>();
                        pB.baseStats = Buildings.BuildingHandler.instance.GetBasicBuildingStats(name);
                    }

                    // if we have any upgrades add them now
                    // add upgrages to unit stats
                }
            }
        }
        public void GetBasicStats(Transform type)
        {
            if (type == playerUnits)
            {
                PlayerUnitsList = 0;
            }
            else if (type == enemyUnits)
            {
                EnemyUnitsList = 0;
            }
            else if (type == playerBuildings)
            {
                PlayerBuildingsList = 0;
            }
            foreach (Transform child in type)
            {
                foreach (Transform tf in child)
                {                    

                    if (type == playerUnits)
                    {
                        PlayerUnitsList += 1;
                    }
                    else if (type == enemyUnits)
                    {
                        EnemyUnitsList += 1;
                    }
                    else if (type == playerBuildings)
                    {
                        PlayerBuildingsList += 1;
                    }
                }
            }
        }
    }
}

