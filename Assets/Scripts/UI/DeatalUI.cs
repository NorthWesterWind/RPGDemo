using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeatalUI : MonoBehaviour
{
    public Image imgitem;
    public Text txtInfo;
    public GameObject Grid;
    public GameObject ImgDetal;

    private ItemSO itemSO;
    private ItemUI itemUI;

    // Start is called before the first frame update
    void Start()
    {
       this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InitInfo(ItemSO itemSO , ItemUI itemUI)
    {
        imgitem.sprite = itemSO.icon;
        txtInfo.text = itemSO.info;

        this.itemSO = itemSO;
        this.itemUI = itemUI;

        foreach(Transform child in Grid.transform)
        {
            if (child.gameObject.activeSelf)
            {
                Destroy(child.gameObject);
            }
        }

        foreach(Property itemProperty in itemSO.propertyList)
        {
            string str = "";
            switch(itemProperty.propertyType)
            {
                case E_PropertyType.HpValue:
                    str = "����ֵ: ";
                    break;
                case E_PropertyType.EneryValue:
                    str = "����ֵ: ";
                    break;
                case E_PropertyType.MentalValue:
                    str = "����ֵ: ";
                    break;
                case E_PropertyType.SpeedValue:
                    str = "�ٶ�ֵ: ";
                    break;
                case E_PropertyType.AttackValue:
                    str = "����ֵ: ";
                    break;
            }
            str += itemProperty.value;
            GameObject obj =  GameObject.Instantiate<GameObject>(ImgDetal, Grid.transform);
            obj.SetActive(true);
            obj.transform.Find("txtDetal").GetComponent<Text>().text = str;
        }

    }

    //ʹ�ð�ť�¼�
    public void BtnUse()
    {
        InventoryPanel.Instance.onItemUse(itemSO, itemUI);
        this.gameObject.SetActive(false);
    }
}
