using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;


public class TestExtend
{
    public void Output()
    {
        Debug.Log("类本身的方法");
    }
}

//注意 Unity版本 只支持到 2019
//类拓展需要给拓展方法编写静态类加[LuaCallCSharp],否则Lua无法调用到
[LuaCallCSharp]
public static class Extend
{
    public static void Shot(this TestExtend testExtend)
    { 
        Debug.Log("拓展方法实现");
    }
}

public class LuaCallExtend : MonoBehaviour
{
    void Start()
    {
        xLuaEnv.Instance.Dostring("require('LCallC/LuaCallExtend')");

    }

    private void OnDestroy()
    {
        xLuaEnv.Instance.Free();
    }
}
