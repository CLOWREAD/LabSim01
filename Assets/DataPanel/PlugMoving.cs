using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlugMoving : MonoBehaviour {

    public int Index;

    Vector2 m_Pos,m_OldPos, m_OriginalPos;

    float m_MouseOldX, m_MouseOldY;

    bool m_MouseDown = false;
    // Use this for initialization
    void Start () {
        
        SystemGlobal sg = SystemGlobal.Instance;

        PlugFastenGlobal pfg = PlugFastenGlobal.Instance;
        if (pfg.m_Inited[Index] == false)
        {
            pfg.m_PlugPos[Index] = transform.position;
            m_OriginalPos= transform.position;
            //m_OriginalPos = transform.position;
            m_OldPos = transform.position;


            //transform.position = new Vector3(m_OriginalPos.x + m_Offset.x, m_OriginalPos.y + m_Offset.y, 0);
            pfg.m_Inited[Index] = true;
        }
        else
        {
            m_OriginalPos= pfg.m_PlugPos[Index];
            m_OldPos = pfg.m_PlugPos[Index];
           
        }

        m_Pos = m_OldPos;

        transform.position = m_Pos;

       

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

            m_Pos = m_OldPos + v;
          



            PlugFastenGlobal pfg = PlugFastenGlobal.Instance;

            m_Pos.x += 6.5f;
            m_Pos = pfg.Dock(Index,m_Pos);
            m_Pos.x -= 6.5f;

            pfg.m_PlugPos[Index] = m_Pos;

            transform.position = m_Pos;
        }



        Fasten();
    }

    public void OnMouseDown()
    {
        m_MouseOldY = Input.mousePosition.y;
        m_MouseOldX = Input.mousePosition.x;
        m_OldPos = m_Pos;
       

        m_MouseDown = true;       
    }
    public void OnMouseUp()
    {
        m_MouseDown = false;
        PlugFastenGlobal pfg = PlugFastenGlobal.Instance;
        pfg.m_PlugCorrect=pfg.CheckPlug();
    }
    void Fasten()
    {

        SystemGlobal sg = SystemGlobal.Instance;

       //Vector3 offset= new Vector3(-6.0f,0,0);
       //Vector3 v0 = Fastener0.transform.position - transform.position+ offset;
       //Vector3 v1 = Fastener1.transform.position - transform.position+ offset;
       //float d0, d1;
       //d0 = v0.magnitude;
       //d1 = v1.magnitude;
       //int fi = Index /2;
       //fi *= 2;
       //
       //sg.m_DataPanelPlugPos.Fastener[Index] = -1;
       //if (d0 < 5.5f )
       //{
       //    sg.m_DataPanelPlugPos.Fastener[Index] = fi;
       //}
       //
       //if (d1 < 5.5f)
       //{
       //    sg.m_DataPanelPlugPos.Fastener[Index] = fi+1;
       //}



    }
}
