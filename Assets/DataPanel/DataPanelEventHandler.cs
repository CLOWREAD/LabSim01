using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataPanelEventHandler : MonoBehaviour {
    bool m_DataPanelShowInfo=true;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void OnBackButtonDown()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainScene");
    }
    public void OnPowerSwitchDown()
    {
        SystemGlobal sg = SystemGlobal.Instance;
        sg.m_DataPanelOn = !sg.m_DataPanelOn;
        if(sg.m_DataPanelOn)
        {
            sg.m_OpRecord.Add("面板开关已打开");
        }
        else
        {
            sg.m_OpRecord.Add("面板开关已关闭");

        }

    }
    public void OnClearButtonDown()
    {
        SystemGlobal sg = SystemGlobal.Instance;
        sg.m_ForceValue = 0;
        sg.m_OpRecord.Add("已清零数据");
    }
    public void OnShowJointMap(GameObject go)
    {
        SystemGlobal sg = SystemGlobal.Instance;
       
        sg.m_DataPanelShowInfo = !sg.m_DataPanelShowInfo;

        //Text t = GetComponentInChildren<Text>();
        //if (m_DataPanelShowInfo)
        //{
        //    t.text = "关闭接线方式";
        //   
        //    go.SetActive(true);
        //}
        //else
        //{
        //    t.text = "打开接线方式";
        //   
        //    go.SetActive(false);
        //}


    }

    public void OnForceUp()
    {
        SystemGlobal sg = SystemGlobal.Instance;
        
        sg.m_ForceValue += 100;
        sg.m_ForceValue = Mathf.Clamp(sg.m_ForceValue, 0, 2000);
    }
    public void OnForceDown()
    {
        SystemGlobal sg = SystemGlobal.Instance;

        sg.m_ForceValue -= 100;
        sg.m_ForceValue = Mathf.Clamp(sg.m_ForceValue, 0, 2000);
    }
    public void SwitchPage(int page)
    {
        SystemGlobal sg = SystemGlobal.Instance;
        sg.m_DataPanelPage = page;
    }
}
