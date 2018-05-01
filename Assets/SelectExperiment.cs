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
       
        sg.m_OpRecord.Add("进入主界面,实验类型代号:"+Type);
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainScene");
    }

}
