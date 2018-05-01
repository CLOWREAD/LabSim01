using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlugMoving : MonoBehaviour {

    public int Index;
    public GameObject Fastener0, Fastener1;
    Vector2 m_Offset,m_OldOffset, m_OriginalPos;

    float m_MouseOldX, m_MouseOldY;

    bool m_MouseDown = false;
    // Use this for initialization
    void Start () {
        
        SystemGlobal sg = SystemGlobal.Instance;
        SystemGlobal.DataPanelPlugPos dp= sg.m_DataPanelPlugPos;
        if (dp.Initated[Index] == false)
        {
            dp.m_OriginalPos[Index].x = transform.position.x;
            dp.m_OriginalPos[Index].y = transform.position.y;

            m_OriginalPos = dp.m_OriginalPos[Index];
            m_Offset.x = 0;
            m_Offset.y = 0;

           
            //transform.position = new Vector3(m_OriginalPos.x + m_Offset.x, m_OriginalPos.y + m_Offset.y, 0);
            dp.Initated[Index] = true;
        }
        else
        {
            m_OriginalPos=dp.m_OriginalPos[Index];
            m_Offset = dp.m_Offset[Index];
           
        }

            m_OldOffset = m_Offset;
            transform.position = new Vector3(m_OriginalPos.x + m_Offset.x, m_OriginalPos.y + m_Offset.y, 0);

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void FixedUpdate()
    {

        if (m_MouseDown == true)
        {
            float x = 0, y = 0;
            x = Input.mousePosition.x;
            y = Input.mousePosition.y;
            Vector2 v;
            v.x = x - m_MouseOldX;
            v.y = y - m_MouseOldY;

            m_Offset = m_OldOffset + v;

            SystemGlobal sg = SystemGlobal.Instance;
            SystemGlobal.DataPanelPlugPos dp = sg.m_DataPanelPlugPos;

             dp.m_Offset[Index]=m_Offset;
            transform.position=new Vector3(m_OriginalPos.x+m_Offset.x, m_OriginalPos.y + m_Offset.y,0);
        }



        Fasten();
    }

    public void OnMouseDown()
    {
        m_MouseOldY = Input.mousePosition.y;
        m_MouseOldX = Input.mousePosition.x;
        m_OldOffset = m_Offset;
       

        m_MouseDown = true;       
    }
    public void OnMouseUp()
    {
        m_MouseDown = false;
    }
    void Fasten()
    {

        SystemGlobal sg = SystemGlobal.Instance;

        Vector3 offset= new Vector3(-6.0f,0,0);
        Vector3 v0 = Fastener0.transform.position - transform.position+ offset;
        Vector3 v1 = Fastener1.transform.position - transform.position+ offset;
        float d0, d1;
        d0 = v0.magnitude;
        d1 = v1.magnitude;
        int fi = Index /2;
        fi *= 2;

        sg.m_DataPanelPlugPos.Fastener[Index] = -1;
        if (d0 < 5.5f )
        {
            sg.m_DataPanelPlugPos.Fastener[Index] = fi;
        }

        if (d1 < 5.5f)
        {
            sg.m_DataPanelPlugPos.Fastener[Index] = fi+1;
        }



    }
}
