using LP.FDG.Buildings.Player;
using LP.FDG.InputManager;
using LP.FDG.Units.Player;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace LP.FDG.Units
{
    public class UnitStatUI : InputHandler
    {
        private List<Transform> selectedUnit = new List<Transform>();
        //private Transform selectedBuilding = null;

        //[SerializeField] private TextMeshProUGUI messageText;
        public UnityEvent onQuantityChange;
        private string text;
        [SerializeField] private GameObject StatsDisplayObject;
        private float nextActionTime;
        //[SerializeField] private TextMeshProUGUI countDown;
        private float cuttingPerSec = 1f;

        //[SerializeField] private TextMeshProUGUI hitPoints;
        [SerializeField] private TextMeshProUGUI currectHealth;
        [SerializeField] private TextMeshProUGUI Attack;
        [SerializeField] private TextMeshProUGUI Armor;
        [SerializeField] private TextMeshProUGUI Range;
        //[SerializeField] private TextMeshProUGUI Name;

        public void unitStatsDisplay()
        {
            selectedBuilding = instance.selectedBuilding;
            selectedUnit = instance.selectedUnits;
            if (selectedUnit.Count == 1)
            {
                StatsDisplayObject.gameObject.SetActive(true);
                PlayerUnit pU = selectedUnit[0].gameObject.GetComponent<PlayerUnit>();
                float hp = pU.baseStats.health;
                //    float currectHp = UnitStatDisplay.instance.currentHealth;

                currectHealth.text = pU.statDisplay.currentHealth.ToString();
                //hitPoints.text = hp.ToString();

                Attack.text = pU.baseStats.attack.ToString();
                Armor.text = pU.statDisplay.armor.ToString();
                Range.text = pU.baseStats.atkRange.ToString();
                //Name.text = pU.unitType.humanPrefab.name.ToString();
                if (pU.statDisplay.currentHealth <= 0)
                {
                    StatsDisplayObject.gameObject.SetActive(false);
                }
            }

            else
                 if (selectedBuilding)
            {
                StatsDisplayObject.gameObject.SetActive(true);
                PlayerBuilding pB = selectedBuilding.gameObject.GetComponent<PlayerBuilding>();
                //hitPoints.text = pB.baseStats.health.ToString();
                currectHealth.text = pB.statDisplay.currentHealth.ToString();
                Armor.text = pB.baseStats.armor.ToString();
                //Name.text = pB.buildingType.buildingPrefab.name.ToString();
            }
            else
                StatsDisplayObject.gameObject.SetActive(false);

        }
    }
}
