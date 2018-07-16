using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamMateralAutoChange : MonoBehaviour {

    public int Index; 

    public Material m_MAl, m_MCu, m_MFe;
	// Use this for initialization
	void Start () {

        MeshRenderer mr= GetComponent<MeshRenderer>();

        SystemGlobal sg = SystemGlobal.Instance;

        int []mt=new int[2];
        mt[0] = sg.m_Type / 3;
        mt[1] = sg.m_Type % 3;

        switch (mt[Index])
        {
            case 0:
                mr.material = m_MFe;
                break;
            case 1:
                mr.material = m_MCu;
                break;
            case 2:
                mr.material = m_MAl;
                break;



        }

	}
	
	// Update is called once per frame
	void Update () {



    }

}
