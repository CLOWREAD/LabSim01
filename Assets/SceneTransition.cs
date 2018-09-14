using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

class SceneTransition
{



    public string m_NextSceneName;
    private static volatile SceneTransition _instance;
    private static object _lock = new object();

    public static SceneTransition Instance
    {
        get
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                        _instance = new SceneTransition();
                    Init(_instance);
                }
            }
            return _instance;
        }
    }

    static private void Init(SceneTransition sg)
    {

    }

    public void  TransTo(string scenename)
    {
        m_NextSceneName = scenename;
        UnityEngine.SceneManagement.SceneManager.LoadScene("TransitionScene");

    }

}
