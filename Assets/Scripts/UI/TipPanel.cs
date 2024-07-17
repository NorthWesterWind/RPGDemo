using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TipPanel : MonoBehaviour
{
    public static TipPanel Instance { get; private set; }

    private TextMeshProUGUI tips;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        tips = this.transform.Find("tips").GetComponent<TextMeshProUGUI>();
        Hide();
    }

    // Update is called once per frame
    void Update()
    {
        if (tips.enabled)
        {
            Color color = tips.color;
            float alpha = Mathf.Lerp(color.a, 0, Time.deltaTime);
            tips.color = new Color(color.r , color.g,color.b , alpha);
            if(alpha == 0)
            {
                tips.enabled = false;
            }
        }
    }

    public void Show(string str)
    {
        tips.enabled = true;
        tips.text =   str;  
        tips.color = Color.white;
    }

    public void Hide()
    {
        tips.enabled = false;
    }
}
