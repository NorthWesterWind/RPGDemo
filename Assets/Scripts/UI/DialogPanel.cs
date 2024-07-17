using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogPanel : MonoBehaviour
{
    public static DialogPanel Instance { get; private set; }


    public TextMeshProUGUI txtName;
    public TextMeshProUGUI txtinfo;
    public Button btnOk;

    public List<string> InfoList = new List<string>();
    private int Index;

    public Action actionDialog;
    private void Awake()
    {
        //判断场景中是否已有DialogPanel  
        if(Instance !=null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        //Ok按钮事件监听
        btnOk.onClick.AddListener(() =>
        {
            Index++;
            if (Index >= InfoList.Count)
            {
                HidePanel();
                Index = 0;
                actionDialog?.Invoke();
                return;
            }    
            txtinfo.text = InfoList[Index];
        });

        HidePanel();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //显示对话框UI
    public void ShowPanel(string name  ,Action action = null)
    {
        this.gameObject.SetActive(true);
        txtName.text = name;
        
        txtinfo.text = InfoList[0];      
        this.actionDialog = action;
    }

    //隐藏对话框UI
    public void HidePanel()
    {
        this.gameObject.SetActive(false);
    }
}
