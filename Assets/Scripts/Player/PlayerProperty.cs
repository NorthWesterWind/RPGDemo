using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ��ɫ������
/// </summary>
public class PlayerProperty : MonoBehaviour
{
    public Dictionary<E_PropertyType, List<Property>> propertDic = new Dictionary<E_PropertyType, List<Property>>();
    public int hpvalue = 100;
    public int eneryvalue =100;
    public int mentalvalue = 50;

    public int Lev = 1;

    public int currentExp = 5;



    // Start is called before the first frame update
    void Awake()
    {
        propertDic.Add(E_PropertyType.AttackValue, new List<Property>());  
        propertDic.Add(E_PropertyType.SpeedValue, new List<Property>());

        Addproperty(E_PropertyType.AttackValue, 20);
        Addproperty(E_PropertyType.SpeedValue, 5);

        EventMgr.OnMonsterDied += OnMonsterDied;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Ϊ��ɫ�������
    /// </summary>
    /// <param name="pt"></param>
    /// <param name="value"></param>
    public void Addproperty(E_PropertyType pt , int value)
    {
        
        switch(pt)
        {
            case E_PropertyType.HpValue:    
                hpvalue += value;
                return;
            case E_PropertyType.EneryValue:
                eneryvalue += value;
                return;
            case E_PropertyType.MentalValue:
                mentalvalue += value;
                return;
        }

        List<Property> list;
        propertDic.TryGetValue(pt , out list);
        list.Add(new Property(pt , value));
    }

    public void RemoveProperty(E_PropertyType pt , int value)
    {

        switch (pt)
        {
            case E_PropertyType.HpValue:
                hpvalue -= value;
                return;
            case E_PropertyType.EneryValue:
                eneryvalue -= value;
                return;
            case E_PropertyType.MentalValue:
                mentalvalue -= value;
                return;
        }

        List<Property> list;
        propertDic.TryGetValue(pt, out list);
        list.Remove(list.Find(x => x.value == value));
    }
    /// <summary>
    /// ����Ʒʹ���߼�
    /// </summary>
    public void UseItem(ItemSO itemSO)
    {
        //��ѡ��ʹ�õ���Ʒ�е������б���б���
        foreach(Property property in itemSO.propertyList)
        {
            Addproperty(property.propertyType, property.value);
        }
    }
    private void OnDestroy()
    {
         EventMgr.OnMonsterDied -= OnMonsterDied;
    }

    public void OnMonsterDied(Monster monster)
    {
        this.currentExp += monster.exp;
        //����ֵ����  ��ɫ����
        if(currentExp >= Lev * 30)
        {
            currentExp -= Lev * 30;
            Lev += 1;

        }
        PropertyPanel.Instance.UpdateProperty();
    }
}
