using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExpReportEventHandler : MonoBehaviour {

    // Use this for initialization
    void Start()
    {

    }
        // Update is called once per frame
        void Update () {
		
	}
    public void OnBackButtonDown()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainScene");
    }
    public void OnSubmit()
    {
        for(int i=0;i<6;i++)
        {
            GameObject go = GameObject.Find("InputField0" + (i + 1));
            Text t = go.GetComponentInChildren<Text>();
            InputField infield = go.GetComponent<InputField>();
             SystemGlobal sg = SystemGlobal.Instance;

            float vo=0, va=0;
            float.TryParse(t.text,out vo);
            va= GetMuValue(i, sg.m_ForceValue, sg.m_Type);
           
                if (Mathf.Abs(vo - va) > 0.025)
                {
                    t.color = Color.red;
                }
                else
                {
                    t.color = Color.green;
                }
            infield.text = va.ToString("F2");
            
           


            go = GameObject.Find("InputField1" + (i + 1));
            t = go.GetComponentInChildren<Text>();
            infield = go.GetComponent<InputField>();
            vo = 0;
            float.TryParse(t.text, out vo);
            va = GetLEDValue(i, sg.m_ForceValue, sg.m_Type);
           
                if (Mathf.Abs(vo - va) > 0.025)
                {
                    t.color = Color.red;
                }
                else
                {
                    t.color = Color.green;
                }
            infield.text = va.ToString("F2");
           



        }
    }

    float GetLEDValue(int i, float p, int type)
    {
        int M1 = type / 3, M2 = type % 3;//////
        float[] Yi = { -0.013f, -0.007f, 0.007f, -0.007f, 0.007f, 0.013f };
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


        if (i <= 2)
        {
            return (epsilon * E[M1]);
        }
        else
        {
            return (epsilon * E[M2]);
        }

    }
    float GetMuValue(int i, float p, int type)
    {
        int M1 = type / 3, M2 = type % 3;//////
        float[] Yi = { -0.013f, -0.007f, 0.007f, -0.007f, 0.007f, 0.013f };
        float[] E = { 203, 104, 75 };
        float[] mu = { 0.26f, 0.4f, 0.31f };
        float l = 0.200f;////////
        float b = 0.016f, h = 0.026f;
        float lz = b * h * h * h / 12;
        float m = p * l / 2;
        float epsilon = (m * Yi[i]) / (lz * (E[M1] + E[M2]));
        epsilon /= 1000;
        
        epsilon *= 1;



        return (epsilon);


    }

}
