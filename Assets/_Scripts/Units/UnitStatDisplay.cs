using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using LP.FDG.InputManager;

namespace LP.FDG.Units
{
    public class UnitStatDisplay : MonoBehaviour
    {
        public float maxHealth, armor, currentHealth;

        [SerializeField] private Image healthBarAmount;

        public int pUnitList = 0;
        public int eUnitList = 0;

        private bool isPlayerUnit = false;

        /*
        private void Start()
        {
            try
            {
                maxHealth = gameObject.GetComponentInParent<Player.PlayerUnit>().baseStats.health;
                armor = gameObject.GetComponentInParent<Player.PlayerUnit>().baseStats.armor;
                isPlayerUnit = true;
            }
            catch(Exception)
            {
                Debug.Log("No player Unit. Trying Enemy Unit...");
                try
                {
                    maxHealth = gameObject.GetComponentInParent<Enemy.EnemyUnit>().baseStats.health;
                    armor = gameObject.GetComponentInParent<Enemy.EnemyUnit>().baseStats.armor;
                    isPlayerUnit = false;
                }
                catch(Exception)
                {
                    Debug.Log("No Unit Scripts found!");
                }
            }

            currentHealth = maxHealth;
        }*/
        private void Start()
        {
            if (isPlayerUnit)
            {
                pUnitList = pUnitList + 1;
            }
            else
            {
                eUnitList = eUnitList + 1;
            }
        }

        public void SetStatDisplayBasicUnit(UnitStatTypes.Base stats,bool isPlayer)
        {
            maxHealth = stats.health;
            armor = stats.armor;
            isPlayerUnit = isPlayer;
            currentHealth = maxHealth;
        }

        public void SetStatDisplayBasicBuilding (Buildings.BuildingStatTypes.Base stats, bool isPlayer)
        {
            maxHealth = stats.health;
            armor = stats.armor;
            isPlayerUnit = isPlayer;
            currentHealth = maxHealth;
        }

        private void Update()
        {
            HandleHealth();            
        }

        public void TakeDamage(float damage)
        {
            float totalDamage = damage - armor;
            currentHealth -= totalDamage;
        }

        private void HandleHealth()
        {
            Camera camera = Camera.main;
            gameObject.transform.LookAt(gameObject.transform.position +
                camera.transform.rotation * Vector3.forward, camera.transform.rotation * Vector3.up);

            healthBarAmount.fillAmount = currentHealth / maxHealth;

            if (currentHealth <= 0)
            {
                Die();
            }
        }

        private void Die()
        {
            if (isPlayerUnit)
            {
                InputManager.InputHandler.instance.selectedUnits.Remove(gameObject.transform.parent);
                Destroy(gameObject.transform.parent.gameObject);
            }
            else
            {
                Destroy(gameObject.transform.parent.gameObject);
            }
        }
    }
}

