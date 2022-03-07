using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LP.FDG.Buildings;
namespace LP.FDG.Buildings.build
{
    public class BuildingManager : MonoBehaviour
    {
        [SerializeField]
        private BasicBuilding activeBuildingType;
        private void Update()
        {

            if (Input.GetMouseButtonDown(0))
            {
                Vector3 mouseWorldPosition = GetMouseWorldPositionRZ();
                //Vector3 mouseWorldPositionX = GetMouseWorldPositionRX;
                //Vector3 mouseWorldPositionZ = GetMouseWorldPositionRZ;

                Instantiate(activeBuildingType.buildingPrefab, mouseWorldPosition, Quaternion.identity);
            }
        }

        public static Vector3 GetMouseWorldPositionRZ()
        {
            Vector3 vectorZ = GetMouseWorldPositionWithZ(Input.mousePosition, Camera.main);
            vectorZ.z = 0f;
            return (vectorZ);
        }
        public static Vector3 GetMouseWorldPositionRX()
        {
            Vector3 vectorX = GetMouseWorldPositionWithX(Input.mousePosition, Camera.main);
            vectorX.x = 0f;
            return (vectorX);
        }
        public static Vector3 GetMouseWorldPositionWithZ()
        {
            return GetMouseWorldPositionWithZ(Input.mousePosition, Camera.main);
        }
        public static Vector3 GetMouseWorldPositionWithZ(Camera worldCamera)
        {
            return GetMouseWorldPositionWithZ(Input.mousePosition, worldCamera);
        }
        public static Vector3 GetMouseWorldPositionWithZ(Vector3 screenPosition, Camera worldCamera)
        {
            Vector3 worldPosition = worldCamera.ScreenToWorldPoint(screenPosition);
            return worldPosition;
        }

        public static Vector3 GetMouseWorldPositionWithY()
        {
            return GetMouseWorldPositionWithY(Input.mousePosition, Camera.main);
        }
        public static Vector3 GetMouseWorldPositionWithY(Camera worldCamera)
        {
            return GetMouseWorldPositionWithY(Input.mousePosition, worldCamera);
        }
        public static Vector3 GetMouseWorldPositionWithY(Vector3 screenPosition, Camera worldCamera)
        {
            Vector3 worldPosition = worldCamera.ScreenToWorldPoint(screenPosition);
            return worldPosition;
        }

        public static Vector3 GetMouseWorldPositionWithX()
        {
            return GetMouseWorldPositionWithX(Input.mousePosition, Camera.main);
        }
        public static Vector3 GetMouseWorldPositionWithX(Camera worldCamera)
        {
            return GetMouseWorldPositionWithX(Input.mousePosition, worldCamera);
        }
        public static Vector3 GetMouseWorldPositionWithX(Vector3 screenPosition, Camera worldCamera)
        {
            Vector3 worldPosition = worldCamera.ScreenToWorldPoint(screenPosition);
            return worldPosition;
        }
    }

    
}

