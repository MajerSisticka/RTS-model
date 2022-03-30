using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using LP.FDG.InputManager;
using UnityEngine.SceneManagement;

namespace LP.FDG.Player
{
    public class PlayerManager : MonoBehaviour
    {
        public static PlayerManager instance;

        public Transform playerUnits;
        public Transform enemyUnits;
        public Transform playerBuildings;

        [SerializeField]
        public string WinScene;
        [SerializeField]
        public string LostScene;

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

            // && PlayerBuildingsList == 0

            if (PlayerUnitsList == 0)
            {
                Debug.LogWarning("Defeat");
                try
                {
                    SceneManager.LoadScene(LostScene);
                }
                catch (System.Exception)
                {

                    Debug.LogWarning("Scéna nenalezena");
                }




                
            }
            else if (EnemyUnitsList == 0)
            {
                Debug.LogWarning("Victory");
                try
                {
                    SceneManager.LoadScene(WinScene);
                }
                catch (System.Exception)
                {

                    Debug.LogWarning("Scéna nenalezena");
                }
                
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

