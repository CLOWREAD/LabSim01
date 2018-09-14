using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectExperiment : MonoBehaviour {
    public int Type; 
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnButtonDownCuCu()
    {
        SystemGlobal sg = SystemGlobal.Instance;
        sg.m_Type = Type;

        sg.m_StartDateTime = System.DateTime.Now;
        sg.m_OpRecord.Add("\t"+sg.m_StartDateTime.ToLongDateString()+"/"+sg.m_StartDateTime.ToLongTimeString()+ "\t 进入主界面,实验类型代号:" +Type);

        SceneTransition st = SceneTransition.Instance;
        st.TransTo("MainScene");
        //UnityEngine.SceneManagement.SceneManager.LoadScene("MainScene");
    }
    public void OnExit()
    {
        Application.Quit();
        Debug.Log("#Hayasumi");
    }
}
