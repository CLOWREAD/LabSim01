using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainSceneEnentHandler : MonoBehaviour {

    // Use this for initialization
    
    public GameObject m_ScrollView;
    public Text m_InfoButton;



	void Start () {
        SystemGlobal sg = SystemGlobal.Instance;
        sg.m_Enable3DInput = false;
    }
	
	// Update is called once per frame
	void Update () {

        if (m_InfoButton != null)
        {
            SystemGlobal sg = SystemGlobal.Instance;

            m_ScrollView.SetActive(sg.m_MainShowInfo);

            Text t = m_InfoButton.GetComponentInChildren<Text>();
            if (sg.m_MainShowInfo)
            {
                t.text = "关闭实验介绍";
                sg.m_Enable3DInput = false;
            }
            else
            {
                t.text = "打开实验介绍";
                sg.m_Enable3DInput = true;
            }
        }
    }
    public void OnExpReportButtonDown()
    {
        SystemGlobal sg = SystemGlobal.Instance;
        sg.m_OpRecord.Add("进入实验报告界面");
        UnityEngine.SceneManagement.SceneManager.LoadScene("ExpReport");
    }
    public void OnExpRecordButtonDown()
    {
        SystemGlobal sg = SystemGlobal.Instance;
        sg.m_OpRecord.Add("进入实验记录界面");
        UnityEngine.SceneManagement.SceneManager.LoadScene("ExpRecord");
    }
    public void OnReturnButtonDown()
    {
        SystemGlobal sg = SystemGlobal.Instance;
        sg.m_OpRecord.Add("进入初始界面");
        UnityEngine.SceneManagement.SceneManager.LoadScene("SelectExpType");
    }
    public void OnIntrButtonDown()
    {
        SystemGlobal sg = SystemGlobal.Instance;

        
        sg.m_MainShowInfo = !sg.m_MainShowInfo;
        sg.m_FrozeCamera = sg.m_MainShowInfo;
       

    }
}
