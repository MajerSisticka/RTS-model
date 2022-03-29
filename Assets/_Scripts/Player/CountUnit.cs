using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LP.FDG.Player
{
    public class CountUnit : MonoBehaviour
    {
        [SerializeField]
        public List<Transform> playerUnits;
        [SerializeField]
        public List<Transform> enemyUnits;
    }
}
