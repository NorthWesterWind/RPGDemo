using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCObject : InteractObject
{
    public string Name;
    public List<string> infolist = new List<string>();
    

    protected override void Interact()
    {
        DialogPanel.Instance.InfoList = infolist;
        DialogPanel.Instance.ShowPanel(Name);
        
    }
}
