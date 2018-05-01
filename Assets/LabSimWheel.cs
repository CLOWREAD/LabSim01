using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LabSimWheel : MonoBehaviour {

    public Text m_Text;
    // Use this for initialization
    float m_RotateY = 0;
    bool m_OldMouse = false;
    bool m_Capture = false;
    Quaternion m_OriginalQuat;

    Material m_OldMat;
    public Material m_HLMat;

    void Start()
    {
        // this.tag = "HellElephantButton";
        SystemGlobal sg = SystemGlobal.Instance;

        
        m_OriginalQuat = transform.rotation;

        m_RotateY=sg.m_ForceValue ;
        m_Text.text = m_RotateY.ToString("F2");
        MeshRenderer mr = GetComponent<MeshRenderer>();
        m_OldMat = mr.material;


    }

    // Update is called once per frame
    void Update()
    {
        SystemGlobal sg = SystemGlobal.Instance;
        if (!sg.m_Enable3DInput) return;

        bool mouse = Input.GetMouseButton(0);
        MeshRenderer mr = GetComponent<MeshRenderer>();
        mr.material = m_OldMat;
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit Hit;

            if (Physics.Raycast(camRay, out Hit))
            {
                if (Hit.collider.name== "LabSim_Model1")
                {

                    mr.material = m_HLMat;
                    if (mouse == true && m_OldMouse == false)
                    {
                    m_Text.text =  m_RotateY.ToString();
                    m_Capture = true;
                    
                    }
                }

            }

        
        
      
        if (mouse == false && m_OldMouse==true)
        {
            m_Capture = false;

            sg.m_FrozeCamera = false;
           

        }

        if (m_Capture == true)
        {
            Rotate();
            sg.m_FrozeCamera = true;
            mr.material = m_HLMat;
        }


        m_OldMouse = mouse;
    }
    void Rotate()
    {
        float X = Input.GetAxis("Mouse X");
        m_RotateY += X;
        m_RotateY=Mathf.Clamp((m_RotateY * 1.0f), 0, 2000);
        transform.rotation = Quaternion.Euler(m_OriginalQuat.eulerAngles.x, m_OriginalQuat.eulerAngles.y, m_OriginalQuat.eulerAngles.z+m_RotateY);
        m_Text.text =  m_RotateY.ToString("F2");
        SystemGlobal sg = SystemGlobal.Instance;
        sg.m_ForceValue = m_RotateY;
    }
}
