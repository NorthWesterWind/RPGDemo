using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ��ɫ���������
/// </summary>
public class PropertyPanel : MonoBehaviour
{

    public static PropertyPanel Instance { get; private set; }

    private Image imgHp;
    private Image imgExp;
    private Text txtLev;
    private Text txtHp;

    private GameObject PropertyGrid;
    private GameObject Template;

    private Image weaponicon;

    private GameObject Ui;

    private GameObject obj;

    private PlayerProperty property;
    private Role role;
    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        Ui = this.transform.Find("Ui").gameObject;
        imgHp = this.transform.Find("Ui/Hp/ImgHp").GetComponent<Image>();
        imgExp = this.transform.Find("Ui/Lev/ImgExp").GetComponent<Image>();
        txtHp = this.transform.Find("Ui/Hp/txtHp").GetComponent<Text>();
        txtLev = this.transform.Find("Ui/Lev/txtLev").GetComponent<Text>();
        PropertyGrid = this.transform.Find("Ui/PropertyGrid").gameObject;
        Template = this.transform.Find("Ui/PropertyGrid/propertyTemplate").gameObject;
        Template.SetActive(false);
        weaponicon = this.transform.Find("Ui/Image").GetComponent<Image>();

        //ͨ����ǩ�ҵ���ҽ�ɫ
        obj = GameObject.Find("Role");
        property = obj.GetComponent<PlayerProperty>();
        role = obj.GetComponent<Role>();

        Hide();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.C))
        {
            if (Ui.activeSelf)
            {
                Hide();
            }
            else
            {
                Show();
            }
               
        }
    }

    /// <summary>
    /// ���½�ɫ����
    /// </summary>
    public void UpdateProperty( )
    {
        imgHp.fillAmount = property.hpvalue * 1.0f / 100;
        if(property.hpvalue > 100)
            property.hpvalue = 100;
        txtHp.text = "Ѫ���� " + property.hpvalue + "/100";
        imgExp.fillAmount = property.currentExp * 1.0f / (property.Lev * 30);
        txtLev.text = "�ȼ�: " + property.Lev;

        //���������崴����Ui���
        foreach (Transform child in PropertyGrid.transform)
        {
            if (child.gameObject.activeSelf)
            {
                Destroy(child.gameObject);
            }
        }
        
        AddProperty("����ֵ: " + property.eneryvalue);
        AddProperty("����ֵ: " + property.mentalvalue);

        foreach(var item in property.propertDic)
        {
            string str = "";
            switch (item.Key)
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
            int num = 0;
            foreach(var i in item.Value)
            {
                num += i.value;
            }

            //�����������
            AddProperty(str + num); 
        }

        if(role.Weapon != null)
        {
            weaponicon.sprite = role.weaponIcon;
        }
    }
    //�������ֵ��ʾ���
    private void AddProperty(string str)
    {
        GameObject obj = GameObject.Instantiate<GameObject>(Template, PropertyGrid.transform);
        obj.SetActive(true);
        obj.GetComponent<Text>().text = str;
    }

    //��ʾ���
    public void Show()
    {
        Ui.SetActive(true);

        UpdateProperty();
    }
    //�������
    public void Hide()
    {
        Ui.SetActive(false);
    }
}
