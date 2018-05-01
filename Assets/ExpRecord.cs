using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExpRecord : MonoBehaviour {

    // Use this for initialization
    public GameObject m_Content;
    public Font m_Font;
    int Index=0;
    int Len;
    void Start()
    {
        UpdateContent();
        Index = 0;
        SystemGlobal sg = SystemGlobal.Instance;
        sg.m_OpRecord.ForEach(new System.Action<string>(AddRecord));
    }
     void UpdateContent()
    {
        SystemGlobal sg = SystemGlobal.Instance;
        Len = sg.m_OpRecord.Capacity;
        RectTransform rt = m_Content.GetComponent<RectTransform>();
        rt.sizeDelta = new Vector2(20, Len * 25 +25);
       // rt.position
    }
     void AddRecord(string str)
    {
        GameObject go = new GameObject();
        go.AddComponent<Text>();
        //go.transform.localScale
        Text t = go.GetComponent<Text>();
        t.text = Index+":"+str;
        t.font = m_Font;
        t.color = Color.black;
        t.alignment = TextAnchor.MiddleLeft;
        go.transform.SetParent(m_Content.transform);
        RectTransform rt= go.GetComponent<RectTransform>();
        //go.GetComponent<RectTransform>().sizeDelta = new Vector2(200, 100);
        rt.offsetMax = new Vector2(100,Index* 25+20);
        rt.offsetMin = new Vector2(-100, Index * 25-20);
        rt.anchoredPosition = new Vector2(0, (1+Index- (Len/2)) * -25);
        Index++;
    }


    // Update is called once per frame
    void Update () {
		
	}
}
