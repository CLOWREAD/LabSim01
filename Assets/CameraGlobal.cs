using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class CameraGlobal
{
    public float m_CameraDist = 12.0f;

    private static volatile CameraGlobal _instance;
    private static object _lock = new object();

    public static CameraGlobal Instance
    {
        get
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                        _instance = new CameraGlobal();
                    Init(_instance);
                }
            }
            return _instance;
        }
    }

    static private void Init(CameraGlobal sg)
    {

    }
}
