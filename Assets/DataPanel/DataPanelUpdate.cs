using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataPanelUpdate : MonoBehaviour {

    // Use this for initialization
    public GameObject m_LEDPanel;
    public Text m_ForceValue;
    public Text m_StatusBar;
    public Sprite m_Fastener_C, m_Fastener_NC;
    public Text m_InfoButton;
    public GameObject m_InfoPanel;

    private bool m_OldFastenStatus;
	void Start () {
        m_OldFastenStatus = FastenCorrectly();

    }
	
	// Update is called once per frame
	void Update () {
        SystemGlobal sg = SystemGlobal.Instance;
        if(sg.m_DataPanelOn)
        {
            m_LEDPanel.SetActive(true);
            m_ForceValue.text = sg.m_ForceValue.ToString("F2");
        }
        else
        {
            m_LEDPanel.SetActive(false);
        }

        UpdateFastener();
        for(int i=0;i<6;i++)
        {
            UpDateLED(i);
        }

        UpdateStatusBar();
        UpdateInfoPanel();
    }
    void UpdateStatusBar()
    {
        SystemGlobal sg = SystemGlobal.Instance;

        PlugFastenGlobal pfg = PlugFastenGlobal.Instance;
        
        bool nf = pfg.m_PlugCorrect;
        if(nf!=m_OldFastenStatus)
        {
            if (nf)
            {
                sg.m_OpRecord.Add( "线路连接正确");
            }
            else
            {
                sg.m_OpRecord.Add("线路连接错误");
            }
        }
        if (nf)
        {
            m_StatusBar.text="线路连接正确";
        }
        else
        {
            m_StatusBar.text = "线路连接错误";
        }
        m_OldFastenStatus = nf;
    }
    void UpdateFastener()
    {

        PlugFastenGlobal pfg = PlugFastenGlobal.Instance;


        for (int i = 0; i < 36; i++)
        {
            string str = i.ToString().PadLeft(2, '0');
            str = "Fastener" + str;
            Image go = GameObject.Find(str).GetComponent<Image>();

            go.sprite = m_Fastener_NC;

        }

        for (int i=0;i<pfg.m_PlugStatus.Length;i++)
        {
            if(pfg.m_PlugStatus[i]==-1)
            {
                continue;
            }
            string str = pfg.m_PlugStatus[i].ToString().PadLeft(2, '0');
            str = "Fastener" + str;
        
            Image go = GameObject.Find(str).GetComponent<Image>();
            go.sprite = m_Fastener_C;
        }

    }

    

    void UpDateLED(int i)
    {
        SystemGlobal sg = SystemGlobal.Instance;

        int port = 0;
        port = 6 * sg.m_DataPanelPage + i;

        PlugFastenGlobal pfg = PlugFastenGlobal.Instance;

        int plugnum = -1;

        for(int pn=0;pn< pfg.m_PlugFastenNum.Length;pn++)
        {
            if(pfg.m_PlugFastenNum[pn]==port)
            {
                plugnum = pn;
                break;
            }
        }

       

        string str = (i+1).ToString().PadLeft(2, '0');
        str = "LED" + str;
        GameObject go = GameObject.Find(str);


        if (go != null)
        {
            Text tx = go.GetComponent<Text>();
        
            if (plugnum!=-1)
            {
                tx.text = GetLEDValue(plugnum, sg.m_ForceValue, sg.m_Type).ToString("F0") ;
                //tx.text = GetLEDValue(PortRemap(port), sg.m_ForceValue, sg.m_Type).ToString("F2");
            }
            else
            {
                tx.text = "0.00";
            }
        }
        str = (i + 1).ToString().PadLeft(2, '0');
        str = "LABEL" + str;
        go = GameObject.Find(str);
        if (go != null)
        {
            Text tx = go.GetComponent<Text>();
            
            tx.text =(port+1).ToString("F0");
        }


    }
    int PortRemap(int i)
    {
        int[] portremap = { 0, -1,1, 2,3, 4, -1, 5 };
        if(i<0 ||i>=8)
        {
            return -1;
        }
        return portremap[i];
    }

    float GetLEDValue(int i, float p, int type)
    {

        if (i == -1) return 0;

        int M1 = type/3, M2 = type%3;//////
        float[] Yi = { -0.013f, -0.007f, 0,0.007f, -0.007f, 0,0.007f, 0.013f };
        float[] E = { 203, 104, 75 };
        float[] mu = { 0.26f, 0.4f, 0.31f };
        float l = 0.200f;////////
        float b = 0.016f, h = 0.026f;
        float lz = b * h * h * h / 12;
        float m = p * l / 2;
        float epsilon = (m * Yi[i]) / (lz * (E[M1] + E[M2]));
        epsilon /= 1000;
        epsilon /= 1000;
        epsilon *= 1000;

       
        if (i <= 3)
        {
            return (epsilon );
        }
        else
        {
            return (epsilon );
        }

    }
    float GetMuValue(int i, float p, int type)
    {
        int M1 = type / 3, M2 = type % 3;//////
        float[] Yi = { -0.013f, -0.007f, 0.007f, -0.007f, 0.007f, 0.0013f };
        float[] E = { 203, 104, 75 };
        float[] mu = { 0.26f, 0.4f, 0.31f };
        float l = 0.200f;////////
        float b = 0.016f, h = 0.026f;
        float lz = b * h * h * h / 12;
        float m = p * l / 2;
        float epsilon = (m * Yi[i]) / (lz * (E[M1] + E[M2]));
        epsilon /= 1000;
        epsilon /= 1000;
        epsilon *= 1;


       
        return (epsilon);
        

    }
    bool FastenCorrectly()
    {
        PlugFastenGlobal pfg = PlugFastenGlobal.Instance;
        pfg.m_PlugCorrect = pfg.CheckPlug();
        return pfg.m_PlugCorrect;
    }

    public void UpdateInfoPanel()
    {
        SystemGlobal sg = SystemGlobal.Instance;

       

        Text t = m_InfoButton.GetComponentInChildren<Text>();
        if (sg.m_DataPanelShowInfo)
        {
            t.text = "关闭接线方式";

            m_InfoPanel.SetActive(true);
        }
        else
        {
            t.text = "打开接线方式";

            m_InfoPanel.SetActive(false);
        }


    }

}
