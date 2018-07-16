using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.Sprites;

class PlugFastenGlobal
{
    private static volatile PlugFastenGlobal _instance;
    private static object _lock = new object();

    public Vector3[] m_FastenerPos;
    public Vector3[] m_PlugPos;
    public bool[] m_Inited;
    public int[] m_PlugStatus;
    public int[] m_PlugFastenNum;
    public bool m_PlugCorrect=false;
    public static PlugFastenGlobal Instance
    {
        get
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                        _instance = new PlugFastenGlobal();
                    Init(_instance);
                }
            }
            return _instance;
        }
    }
    static private void Init(PlugFastenGlobal sg)
    {

        sg.m_FastenerPos = new Vector3[36];
        String fname;
        for (int i = 0; i < sg.m_FastenerPos.Length; i++)
        {
            fname = i.ToString().PadLeft(2, '0');
            fname = "Fastener" + fname;
            GameObject go = GameObject.Find(fname);
            sg.m_FastenerPos[i] = go.transform.position;

            Debug.Log("@" + sg.m_FastenerPos[i].x + "&" + sg.m_FastenerPos[i].y);

        }



        sg.m_PlugPos = new Vector3[22];
        sg.m_Inited = new bool[22];
        sg.m_PlugStatus = new int[22];
        sg.m_PlugFastenNum = new int[8];
        for (int i = 0; i < sg.m_Inited.Length; i++)
        {
            sg.m_Inited[i] = false;
        }
        for (int i = 0; i < sg.m_PlugStatus.Length; i++)
        {
            sg.m_PlugStatus[i] = -1;
        }

    }
    public int GetFasternerNum(int plugNum)
    {
        if (plugNum < 0 || plugNum > m_PlugStatus.Length/2) return -1;

        int f1, f2;
        f1 = m_PlugStatus[plugNum * 2 + 0];
        f2 = m_PlugStatus[plugNum * 2 + 1];

        if(f1==-1 ||f2==-1)
        {
            return -1;
        }

        if (f1 == f2 )
        {
            return -1;
        }

        f1 = f1 / 2;
        f2 = f2 / 2;
        //Debug.Log(f1 + "@" + f2);

        if(f1==f2)
        {
            return f1 ;
        }



        return -1;



    }
    public Vector3 Dock(int index,Vector3 pos)
    {
        Vector3 res=pos;

        Vector3 dist ;

        float min_d = 10.0f;

        m_PlugStatus[index] = -1;
        for (int i = 0; i < m_FastenerPos.Length; i++)
        {
            dist = pos - m_FastenerPos[i];
            if(dist.magnitude<9.0)
            {
               // Debug.Log("@@Dock!");
                if(dist.magnitude<min_d)
                {
                    //Debug.Log("@@Dock!"+index +"@"+i);
                    m_PlugStatus[index] = i;
                    min_d = dist.magnitude;
                    res = m_FastenerPos[i];
                }

                
            }
        }



            return res;
    }

    public bool CheckPlug()
    {
        bool cflag = true;

        for(int i=0;i< 8;i++)
        {
            m_PlugFastenNum[i] = GetFasternerNum(i);
            if (m_PlugFastenNum[i]==-1)
            {
                //Debug.Log("@@##" + i);
                cflag = false;
            }
            if (m_PlugFastenNum[i] >= 16)
            {
                //Debug.Log("@@##" + i);
                cflag = false;
            }
        }
        for (int i = 0; i < 8; i++)
        {
            for (int j = i+1; j < 8; j++)
            {

                if(m_PlugFastenNum[i]== m_PlugFastenNum[j])
                {
                    cflag = false;
                }

            }



        }

        //0~3 4~8 plug must on the same row of fasterner
        bool sideflag = true;

        sideflag = m_PlugFastenNum[0] < 8;
        for (int i = 0; i < 4; i++)
        {
            bool b = m_PlugFastenNum[i] < 8;
            if (b != sideflag)
            {
                cflag = false;
            }

        }
        sideflag = m_PlugFastenNum[4] < 8;
        for (int i = 4; i < 8; i++)
        {
            bool b = m_PlugFastenNum[i] < 8;
            if (b != sideflag)
            {
                cflag = false;
            }

        }

        if(cflag)
        {
           cflag = CheckTemperaturePlug();
        }



        return cflag;

    }
    public bool CheckTemperaturePlug()
    {
        bool cflag = true;

        int[] FastArray = new int[3];
        FastArray[0] = GetFasternerNum(8);
        FastArray[1] = GetFasternerNum(9);
        FastArray[2] = GetFasternerNum(10);

        bool sf0 = GetFasternerNum(0)< 8;
        bool sf1 = GetFasternerNum(4) < 8;

        SystemGlobal sg = SystemGlobal.Instance;

        int m0 = sg.m_Type / 3;
        int m1 = sg.m_Type % 3;

        if( (m0!=m1) &&(sf0==sf1))

        {

            return false;
        }
        if ((m0 == m1) && (sf0 != sf1))

        {
            return false;
        }

        //Debug.Log("@" + sf0 + "@" + sf1);
        //Debug.Log("#" + sf0 + "#" + sf1);
        //
        //Debug.Log("#" + FastArray[0] + "#" + FastArray[1]+"#" + FastArray[2]);

        if (m0==0)
        {
            if(sf0==true)
            {
                if(FastArray[0]!=16)
                {
                    cflag = false;
                }


            }
            else
            {
                if (FastArray[0] != 17)
                {
                    cflag = false;
                }

            }



        }
        if (m0 == 1)
        {
            if (sf0 == true)
            {
                if (FastArray[1] != 16)
                {
                    cflag = false;
                }


            }
            else
            {
                if (FastArray[1] != 17)
                {
                    cflag = false;
                }

            }



        }
        if (m0 == 2)
        {
            if (sf0 == true)
            {
                if (FastArray[2] != 16)
                {
                    cflag = false;
                }


            }
            else
            {
                if (FastArray[2] != 17)
                {
                    cflag = false;
                }

            }



        }

        ///////////////////



        if (m1 == 0)
        {
            if (sf1 == true)
            {
                if (FastArray[0] != 16)
                {
                    cflag = false;
                }


            }
            else
            {
                if (FastArray[0] != 17)
                {
                    cflag = false;
                }

            }



        }
        if (m1 == 1)
        {
            if (sf1 == true)
            {
                if (FastArray[1] != 16)
                {
                    cflag = false;
                }


            }
            else
            {
                if (FastArray[1] != 17)
                {
                    cflag = false;
                }

            }



        }
        if (m1 == 2)
        {
            if (sf1 == true)
            {
                if (FastArray[2] != 16)
                {
                    cflag = false;
                }


            }
            else
            {
                if (FastArray[2] != 17)
                {
                    cflag = false;
                }

            }



        }
        ////////////////////////////////////////////
        if(! (m1 == 0 ||m0==0))
        {
            if(FastArray[0]!=-1)
            {
                cflag = false;
            }
        }
        if (!(m1 == 1 || m0 == 1))
        {
            if (FastArray[1] != -1)
            {
                cflag = false;
            }
        }
        if (!(m1 == 2 || m0 == 2))
        {
            if (FastArray[2] != -1)
            {
                cflag = false;
            }
        }



        return cflag;
    }

    private PlugFastenGlobal() { }


    }
    