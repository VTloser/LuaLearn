using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSingleton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        xLuaEnv.Instance.Dostring("print('Hello Singleton')");
        xLuaEnv.Instance.Dostring("require('Test1')");
    }


    private void OnDestroy()
    {
        xLuaEnv.Instance.Free();
    }
}
