using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;

public class LuaTest : MonoBehaviour
{
    /**
     * Lua ����������
     * Xlua������
     * ��������Lua����
     * �����ͷ�
     * **/

    void Start()
    {
        CSharpCodeCallLua();

        LuaCallCSharpCode();

        LuaReturnData();
    }

    /// <summary>
    /// C# ����Lua
    /// </summary>
    public void CSharpCodeCallLua()
    {
        //Xlua������
        LuaEnv env = new LuaEnv();

        //����������Lua����
        env.DoString(@"print('ABC')");

        //�������ͷ�
        env.Dispose();
    }

    /// <summary>
    /// Lua����C#
    /// </summary>
    public void LuaCallCSharpCode()
    {
        LuaEnv env = new LuaEnv();
        //Lua ����C#���� =>(CS.�����ռ�.����.������(����))
        env.DoString("CS.UnityEngine.Debug.Log('from Lua')");
        env.Dispose();
    }

    /// <summary>
    /// Lua����ֵ��C#
    /// </summary>
    public void LuaReturnData()
    {
        LuaEnv env = new LuaEnv();
        dynamic[] data = env.DoString("return 100,true");
        Debug.Log($"Lua ��һ����ֵ{data[0]}");
        Debug.Log($"Lua �ڶ�����ֵ{data[1]}");
        env.Dispose();
    }


}
