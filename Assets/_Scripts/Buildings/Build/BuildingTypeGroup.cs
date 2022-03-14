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

        public GameObject BuildManagerDE;

        private List<Transform> buttons = new List<Transform>();

        private Dictionary<BasicBuilding, Transform> buildButtonDic;

        private void Start()
        {
            visualSelect();
        }
        private void Awake()
        {
            buildingManager = GameObject.Find("/BuildingManager").GetComponent<BuildingManager>();
            BuildManagerDE = GameObject.Find("/BuildingManager");
            SetButtonsBuilding();
            //DEactivatebuilding();
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
        private void SetButtonsBuilding()
        {
            Transform BuildingButtonTemplate = transform.Find("buildingButtonTemplate");
            BuildingButtonTemplate.gameObject.SetActive(false);
            buildButtonDic = new Dictionary<BasicBuilding, Transform>();
            int I = 0;
            foreach (BasicBuilding buildingType in buildingTypeList)
            {
                Transform buildingButtonTransform = Instantiate(BuildingButtonTemplate, transform);
                buttons.Add(buildingButtonTransform);
                buildingButtonTransform.gameObject.SetActive(true);
                buildingButtonTransform.GetComponent<RectTransform>().anchoredPosition += new Vector2(I * 60, 0);
                //buildingButtonTransform.Find("image").GetComponent<Image>().sprite = BasicBuilding.sprite;
                //buildingButtonTransform.Find("image").GetComponent<Sprite>() = Buildings.BasicBuilding.spr
                // pøidávání obrázku do buttonnu nutné pøidat do scriptible objetù Sprite Obrázky !!!!
                buildingButtonTransform.GetComponent<Button>().onClick.AddListener(() =>
                {
                    buildingManager.SetactiveBasicbuildings(buildingType);
                    visualSelect();
                });
                buildButtonDic[buildingType] = buildingButtonTransform;
                I++;
            }
            Debug.LogWarning("pocet tlacitek " + buttons.Count);
        }
        public void DEactivatebuilding()
        {
            DestroyButtonsBuilding();
            DestroyBuildManager();   
        }
        public void activatebuilding()
        {
            visualSelect();
            SetButtonsBuilding();
        }
        private void DestroyButtonsBuilding()
        {
            foreach (Transform btn in buttons)
            {
                Destroy(btn.gameObject);
            }
            buttons.Clear();
        }
        private void DestroyBuildManager()
        {
            BuildManagerDE.SetActive(false);
        }
    }
}

