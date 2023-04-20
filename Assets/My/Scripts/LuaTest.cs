using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;

public class LuaTest : MonoBehaviour
{
    /**
     * Lua 解释性语言
     * Xlua解析器
     * 析器运行Lua代码
     * 析器释放
     * **/

    void Start()
    {
        CSharpCodeCallLua();

        LuaCallCSharpCode();

        LuaReturnData();
    }

    /// <summary>
    /// C# 调用Lua
    /// </summary>
    public void CSharpCodeCallLua()
    {
        //Xlua解析器
        LuaEnv env = new LuaEnv();

        //解析器运行Lua代码
        env.DoString(@"print('ABC')");

        //解析器释放
        env.Dispose();
    }

    /// <summary>
    /// Lua调用C#
    /// </summary>
    public void LuaCallCSharpCode()
    {
        LuaEnv env = new LuaEnv();
        //Lua 调用C#代码 =>(CS.命名空间.类名.方法名(参数))
        env.DoString("CS.UnityEngine.Debug.Log('from Lua')");
        env.Dispose();
    }

    /// <summary>
    /// Lua返回值给C#
    /// </summary>
    public void LuaReturnData()
    {
        LuaEnv env = new LuaEnv();
        dynamic[] data = env.DoString("return 100,true");
        Debug.Log($"Lua 第一返回值{data[0]}");
        Debug.Log($"Lua 第二返回值{data[1]}");
        env.Dispose();
    }


}
