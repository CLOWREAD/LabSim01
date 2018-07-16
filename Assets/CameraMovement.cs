using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    public Transform target;
  
    float m_CameraHeight = 0, m_OldCameraHeight;
    float m_Rotation = 180.0f, m_OldRotation;
    bool m_OldMouseDown=false;

    float m_X, m_Y;
    float m_MouseOldX, m_MouseOldY;
    // Use this for initialization
    void Start () {

        SystemGlobal sg = SystemGlobal.Instance;

        sg.m_FrozeCamera = false;

        Vector3 offset;
        offset.x = 0f;
        offset.y = 0f;
        offset.z = -12.0f;
        this.transform.position = offset;
        this.transform.LookAt(target);

    }
	
	// Update is called once per frame
	void Update () {
		



	}
    void FixedUpdate()
    {

        CameraGlobal cg = CameraGlobal.Instance;

        SystemGlobal sg = SystemGlobal.Instance;
        if (sg.m_FrozeCamera == true) return;
        if (!sg.m_Enable3DInput) return;
        bool md = Input.GetMouseButton(0);
        float x=0, y=0;
        if(md==true && m_OldMouseDown==false)
        {
            m_MouseOldY = -Input.mousePosition.y;
            m_MouseOldX = Input.mousePosition.x;
            m_OldRotation = m_Rotation;
            m_OldCameraHeight = m_CameraHeight;
        }
        if (md == true && m_OldMouseDown == true)
        {
            y = -Input.mousePosition.y;
            x = Input.mousePosition.x;
            m_Rotation = m_OldRotation + (x - m_MouseOldX);
            m_CameraHeight = m_OldCameraHeight + (y - m_MouseOldY);
            m_CameraHeight = Mathf.Clamp(m_CameraHeight, 0, 256.0f);


            Quaternion q = Quaternion.Euler(0, m_Rotation, 0);
            Vector3 offset = q * Vector3.forward* cg.m_CameraDist;
            offset += target.position;
            offset *= Mathf.Cos(m_CameraHeight / 256.0f);
            offset.y = cg.m_CameraDist * Mathf.Sin(m_CameraHeight/256.0f);

            this.transform.position = offset;
            this.transform.LookAt(target);

        }
        if (md == false && m_OldMouseDown == true)
        {
            y = Input.mousePosition.y;
            x = Input.mousePosition.x;

        }


        m_OldMouseDown = md;
    }

}
