using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LP.FDG.Buildings;
using UnityEngine.EventSystems;
namespace LP.FDG.Buildings.build
{
    public class BuildingManager : BuildingTypeGroup
    {
        [SerializeField] private BasicBuilding activeBuildingType;
        [SerializeField] private  GameObject prefab;
        //[SerializeField] private List<GameObject> prefabs;
        private Camera cam = null;
        public Camera camera;
        public bool a = false;
        private void Start()
        {
            cam = Camera.main;
        }
        private void Update()
        {
            SpawnBuilding();
            
        }
        private void SpawnBuilding()
        {
            Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            RaycastHit raycastHit;

            if (Physics.Raycast(mouse, Vector3.down, out raycastHit))
            {
                Debug.DrawRay(mouse, Vector3.down * raycastHit.distance, Color.yellow);
                //pozice myši
                Debug.Log(raycastHit.point); // pozice kde reycast hitnul zem
            }

            if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
            {
                if (Physics.Raycast(mouse, Vector3.down, out raycastHit))
                {
                    if (raycastHit.collider.gameObject.layer! < 1)
                    {
                        // jeden typ budovy
                        //Instantiate(prefab, raycastHit.point, Quaternion.identity);
                        // všechny typy
                        Debug.Log("stavíme budovu" + activeBuildingType.buildingPrefab);
                        //stavìní budovy
                        Instantiate(activeBuildingType.buildingPrefab, raycastHit.point, Quaternion.identity);
                        DEactivatebuilding(); // zajímavý efekt kdy se vypnebudova :)

                        //Player.PlayerBuilding basicBuilding = activeBuildingType.buildingPrefab.AddComponent<Buildings.Player.PlayerBuilding>();
                        //basicBuilding.transform.SetParent(GameObject.Find("Player " + basicBuilding.buildingType.type.ToString() + "s").transform);

                        //Units.Player.PlayerUnit pu = spawnedObject.GetComponent<Units.Player.PlayerUnit>();
                        //pu.transform.SetParent(GameObject.Find("Player " + pu.unitType.type.ToString() + "s").transform);
                    }
                }



                Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                if (a)
                {
                    if (Boolspawnbuilding(activeBuildingType, mouseWorldPosition))
                    {

                        Instantiate(activeBuildingType.buildingPrefab, raycastHit.point, Quaternion.identity);
                        Instantiate(prefab, raycastHit.point, Quaternion.identity);



                        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
                        RaycastHit hit;
                        Physics.Raycast(ray, out hit);
                        Debug.Log(ray);
                        Debug.Log(hit);
                        if (Physics.Raycast(ray, out hit))
                        {
                            activeBuildingType.buildingPrefab.transform.position = hit.point;
                        }


                        Instantiate(activeBuildingType.buildingPrefab, mouseWorldPosition, Quaternion.identity);
                    }
                }

                //Vector3 mouseWorldPositionX = GetMouseWorldPositionRX;
                //Vector3 mouseWorldPositionZ = GetMouseWorldPositionRZ;






            }
        }

        private void SpawnAtMousePosition()
        {
            Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            RaycastHit raycastHit;

            if (Physics.Raycast(mouse, Vector3.down, out raycastHit))
            {
                Debug.DrawRay(mouse, Vector3.down * raycastHit.distance, Color.yellow);
                Debug.Log(raycastHit.point); // pozice kde reycast hitnul zem
            }           
        }
        public void SetactiveBasicbuildings(BasicBuilding buildtype)
        {
            activeBuildingType = buildtype;
        }
        public BasicBuilding getActiveBasicBuilding()
        {
            return activeBuildingType;
        }
        private bool Boolspawnbuilding(BasicBuilding basicBuilding,Vector3 position)
        {
            BoxCollider buildingBoxcollier = basicBuilding.buildingPrefab.GetComponent<BoxCollider>();
            /* if(Physics.OverlapBox(position + (Vector3)buildingBoxcollier,buildingBoxcollier.size, 0) != null)
             {
                 return false;
             }
             else
             {
                 return true;
             }*/
            return false;
        }
        /// metody na zjištìní polohy myši
        public void SetActiveBuildingType(BasicBuilding buildingType)
        {
            activeBuildingType = buildingType;
        }


        ////////////////////////////////////////////////////////////////////////////////////////

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

