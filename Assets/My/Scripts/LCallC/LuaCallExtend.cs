using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;


public class TestExtend
{
    public void Output()
    {
        Debug.Log("�౾��ķ���");
    }
}

//ע�� Unity�汾 ֻ֧�ֵ� 2019
//����չ��Ҫ����չ������д��̬���[LuaCallCSharp],����Lua�޷����õ�
[LuaCallCSharp]
public static class Extend
{
    public static void Shot(this TestExtend testExtend)
    { 
        Debug.Log("��չ����ʵ��");
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
