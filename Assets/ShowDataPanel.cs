using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowDataPanel : MonoBehaviour {

    bool m_OldMouse = false;
    bool m_Capture = false;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        bool mouse = Input.GetMouseButton(0);
        MeshRenderer mr = GetComponent<MeshRenderer>();
       
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit Hit;

        if (Physics.Raycast(camRay, out Hit))
        {
            if (Hit.collider.name == "LabSim_Model2")
            {

                
                if (mouse == true && m_OldMouse == false)
                {
                   m_Capture = true;

                }
            }

        }


        SystemGlobal sg = SystemGlobal.Instance;

        if (mouse == false)
        {
            m_Capture = false;


        }

        if (m_Capture == true)
        {
            sg.m_OpRecord.Add("进入面板界面 测力="+sg.m_ForceValue);
            UnityEngine.SceneManagement.SceneManager.LoadScene("DataPanel");
            
        }


        m_OldMouse = mouse;
    }
}
