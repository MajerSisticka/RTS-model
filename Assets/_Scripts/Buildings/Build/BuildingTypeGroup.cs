using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LP.FDG.Buildings;
using UnityEngine.UI;

namespace LP.FDG.Buildings.build
{
    public class BuildingTypeGroup : MonoBehaviour
    {
        [SerializeField]
        private List<BasicBuilding> buildingTypeList;
        [SerializeField]
        private BuildingManager buildingManager;

        private Dictionary<BasicBuilding, Transform> buildButtonDic;

        private void Start()
        {
            visualSelect();
        }
        private void Awake()
        {
            Transform BuildingButtonTemplate = transform.Find("buildingButtonTemplate");
            BuildingButtonTemplate.gameObject.SetActive(false);
            buildButtonDic = new Dictionary<BasicBuilding, Transform>();
            int I = 0;
            foreach (BasicBuilding buildingType in buildingTypeList)
            {
                Transform buildingButtonTransform = Instantiate(BuildingButtonTemplate, transform);
                buildingButtonTransform.gameObject.SetActive(true);
                buildingButtonTransform.GetComponent<RectTransform>().anchoredPosition += new Vector2(I * 60, 0);
                //buildingButtonTransform.Find("image").GetComponent<Image>().sprite = BasicBuilding.sprite;
                
                // pøidávání obrázku do buttonnu nutné pøidat do scriptible objetù Sprite Obrázky !!!!
                buildingButtonTransform.GetComponent<Button>().onClick.AddListener(() => 
                {
                    buildingManager.SetactiveBasicbuildings(buildingType);
                    visualSelect();
                });
                buildButtonDic[buildingType] = buildingButtonTransform;
                I++;
            }
            
        }
        private void visualSelect()
        {
            foreach (BasicBuilding buildingType in buildButtonDic.Keys)
            {
                buildButtonDic[buildingType].Find("selected").gameObject.SetActive(false);
            }
            BasicBuilding activeBuildingType = buildingManager.getActiveBasicBuilding();
            buildButtonDic[activeBuildingType].Find("selected").gameObject.SetActive(true);

        }
    }
}

