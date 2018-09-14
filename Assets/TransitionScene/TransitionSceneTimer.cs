using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TransitionSceneTimer : MonoBehaviour {

    float m_Timedelta = 0;
    public Text m_Text;
    public Text m_SubTitle;
    public Image m_Panel;



    string m_TextSrc="正在开始系统检验\n记忆单元检测:正常\n" +
        "正在初始化战术记录\n正在加载地形数据\n体征检测:正常\n" +
        "剩余MP检测:100%\n黑匣子温度:正常\n黑匣子内部压力:正常\n" +
        "正在启动IFF\n正在启动FCS\n正在启动辅助机通讯连接\n" +
        "正在启动DBU配置\n正在启动惯性控制系统\n正在启动环境传感器\n装备认证:完成\n" +
        "装备状态检测:通过\n系统:完全就绪\n战斗准备完成\n";

    int m_TextIndex=0;
        // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        m_Timedelta += Time.deltaTime;
        //Debug.Log(timedelta);
        if (m_Timedelta > 0.01)
        { m_Timedelta = 0;


            if (m_TextIndex < m_TextSrc.Length)
            {
                m_Text.text += m_TextSrc.Substring(m_TextIndex, 1);
                m_TextIndex++;

            }
            if (m_TextIndex == m_TextSrc.Length)
            {
                SceneTransition st = SceneTransition.Instance;
                UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(st.m_NextSceneName);
            }

            ///////////////////////////////////////////
            string subtitle = "正在启动系统。";
            for(int i =0;i< (m_TextIndex/16)%4;i++ )
            {
                subtitle += "。";
            }
            m_SubTitle.text = subtitle;
            ////////////////////////////////////////

            float panelalpha = 0;
            if (m_TextIndex >= m_TextSrc.Length-18)
            {
                panelalpha= Mathf.Clamp(m_TextIndex - m_TextSrc.Length+18, 0, 16);
                panelalpha= Mathf.Clamp((float)(panelalpha/16.0), 0, 1);
                
                Color panelc = m_Panel.color;
                panelc.a = panelalpha;
                m_Panel.color = panelc;
            }
           

        }
    }
}
