using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestT
{
    public void OutPut<T>(T data)
    {
        Debug.Log("泛型方法:" + data.ToString());
    }

    //Lua并不支持泛型 所以需要将泛型全部实现
    public void OutPut(float data)
    {
        OutPut<float>(data);
    }
    public void OutPut(string data)
    {
        OutPut<string>(data);
    }
}




public class LuaCallT : MonoBehaviour
{

    void Start()
    {
        xLuaEnv.Instance.Dostring("require('LCallC/LuaCallT')");
    }

    private void OnDestroy()
    {
        xLuaEnv.Instance.Free();
    }
}
