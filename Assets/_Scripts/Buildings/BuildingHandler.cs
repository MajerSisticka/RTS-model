using UnityEngine;

namespace LP.FDG.Buildings
{
    public class BuildingHandler : MonoBehaviour
    {
        public static BuildingHandler instance;

        [SerializeField]
        private BasicBuilding barraks,basecamps,buildings;

        private void Awake()
        {
            instance = this;
        }

        public BuildingStatTypes.Base GetBasicBuildingStats(string type)
        {
            BasicBuilding building;
            switch (type)
            {
                case "barrak":
                    building = barraks;
                    break;
                case "basecamp":
                    building = basecamps;
                    break;
                case "building":
                    building = buildings;
                    break;
                default:
                    Debug.Log($"Unit Type: {type} could not be found or does not exist!");
                    return null;
            }
            return building.baseStats;
        }
    }
}

