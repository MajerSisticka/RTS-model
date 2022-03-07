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

        private void Awake()
        {
            Transform BuildingButtonTemplate = transform.Find("BuildingButtonTemplate");
            BuildingButtonTemplate.gameObject.SetActive(false);
            int I = 0;
            foreach (BasicBuilding buildingType in buildingTypeList)
            {
                Transform buildingButtonTransform = Instantiate(BuildingButtonTemplate, transform);
                buildingButtonTransform.gameObject.SetActive(true);
                buildingButtonTransform.GetComponent<RectTransform>().anchoredPosition += new Vector2(I * 60, 0);
                //buildingButtonTransform.Find("image").GetComponent<Image>().sprite = BasicBuilding.sprite;
                // p�id�v�n� obr�zku do buttonnu nutn� p�idat do scriptible objet� Sprite Obr�zky !!!!
                buildingButtonTransform.GetComponent<Button>().onClick.AddListener(() => { });
                I++;
            }
            
        }
    }
}

