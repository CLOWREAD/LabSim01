using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class SystemGlobal
{
    public bool m_Enable3DInput = false;
    public int m_Type;
    public bool m_FrozeCamera=false;
    //public int m_Type;
    //  public struct DataPanelPlugPos
    //  {
    //      public bool []Initated;
    //      public int Count;
    //      public Vector2[] m_OriginalPos;
    //      public Vector2[] m_Offset;
    //
    //      public int[] Fastener;
    //  };
    //  public DataPanelPlugPos m_DataPanelPlugPos;//面板上插头的位置
    public System.DateTime m_StartDateTime;
    public System.DateTime m_SubmitDateTime;
    public int m_Score;

    public bool m_DataPanelOn=false;
    public int m_DataPanelPage = 0;//当前选择的显示页面
    public float m_ForceValue;//测力值
    public List<String> m_OpRecord;
    public bool m_DataPanelShowInfo=true;
    public bool m_MainShowInfo = true;

    private static volatile SystemGlobal _instance;
    private static object _lock = new object();

    public static SystemGlobal Instance
    {
        get
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                        _instance = new SystemGlobal();
                    Init(_instance);
                }
            }
            return _instance;
        }
    }

    static private void Init(SystemGlobal sg)
    {
        //int fcount = 24;
        //sg.m_DataPanelPlugPos.Count = fcount;
        //sg.m_DataPanelPlugPos.Initated = new bool[fcount];
        //sg.m_DataPanelPlugPos.Fastener = new int[fcount];
        //for(int i=0;i< fcount; i++)
        //{
        //    sg.m_DataPanelPlugPos.Initated[i] = false;
        //    sg.m_DataPanelPlugPos.Fastener[i] = 0;
        //}
        //sg.m_DataPanelPlugPos.m_OriginalPos = new Vector2[fcount];
        //sg.m_DataPanelPlugPos.m_Offset = new Vector2[fcount];

        sg.m_OpRecord = new List<string>();

    }
    private SystemGlobal() { }



}
