using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

namespace LP.FDG.Units.Enemy
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class EnemyUnit : MonoBehaviour
    {
        private NavMeshAgent navAgent;

        public BasicUnit unitType;

        [HideInInspector]
        public UnitStatTypes.Base baseStats;

        public UnitStatDisplay statDisplay;

        private Collider[] rangeColliders;

        private Transform aggroTarget;

        private UnitStatDisplay aggroUnit;

        private bool hasAggro = false;

        private float distance;

        public float atkCooldown;

        private void Start()
        {
            baseStats = unitType.baseStats;
            statDisplay.SetStatDisplayBasicUnit(baseStats, false);
            navAgent = gameObject.GetComponent<NavMeshAgent>();
        }

        private void Update()
        {
            atkCooldown -= Time.deltaTime;

            if (!hasAggro)
            {
                CheckForEnemyTargets();
            }
            else
            {
                Attack();
                MoveToAggroTarget();
            }
        }

        private void CheckForEnemyTargets()
        {
            rangeColliders = Physics.OverlapSphere(transform.position, baseStats.aggroRange, UnitHandler.instance.pUnitLayer);
            Debug.LogWarning("hledání Range colliers");
            // rangeColliders = Physics.OverlapSphere(transform.position, baseStats.aggroRange, UnitHandler.instance.eUnitLayer);

            for (int i = 0; i < rangeColliders.Length;)
            {
                Debug.LogWarning("nastavení AggroTarger");
                aggroTarget = rangeColliders[i].gameObject.transform;
                Debug.LogWarning("nastavení AggroUnit");
                aggroUnit = aggroTarget.gameObject.GetComponentInChildren<UnitStatDisplay>();
                // vytvořit skript pro Enumíka s  aggroUnit = aggroTarget.gameObject.GetComponentInChildren<EnemyUnitStatDisplay>();
                hasAggro = true;
                break;
            }
        }

        private void Attack()
        {
            CheckForEnemyTargets();
            try
            {
                CheckForEnemyTargets();
                Debug.LogWarning("zautoc");
                if (atkCooldown <= 0 && distance <= baseStats.atkRange + 1)
                {
                    CheckForEnemyTargets();
                    Debug.LogWarning("JOJO");
                    aggroUnit.TakeDamage(baseStats.attack);
                    Debug.LogWarning("NENE");
                    atkCooldown = baseStats.atkSpeed;

                    Debug.LogWarning(aggroUnit);
                    CheckForEnemyTargets();
                    Debug.LogWarning(aggroUnit);
                }
            }
            catch (System.Exception)
            {

                Debug.LogWarning(aggroUnit);
                CheckForEnemyTargets();
                Debug.LogWarning(aggroUnit);

            }
            
        }

        private void MoveToAggroTarget()
        {
            if  (aggroTarget == null)
            {
                navAgent.SetDestination(transform.position);
                hasAggro = false;
            }
            else
            {
                distance = Vector3.Distance(aggroTarget.position, transform.position);
                navAgent.stoppingDistance = (baseStats.atkRange + 1);

                if (distance <= baseStats.aggroRange)
                {
                    navAgent.SetDestination(aggroTarget.position);
                }
            }
        }
    }
}

