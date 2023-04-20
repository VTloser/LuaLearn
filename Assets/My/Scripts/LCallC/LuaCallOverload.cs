using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestOverload
{

    public static void Test(int id)
    {
        Debug.Log("��������" + id);
    }

    public static void Test(string name)
    {
        Debug.Log("�ַ�������" + name);
    }

    public static void Test(int id ,string name)
    {
        Debug.Log("������ֵ" + id  +name);
    }
}

public class LuaCallOverload : MonoBehaviour
{
    void Start()
    {
        xLuaEnv.Instance.Dostring("require('LCallC/LuaCallOverload')");
        this.gameObject.AddComponent(typeof(BoxCollider));
    }

    private void OnDestroy()
    {
        xLuaEnv.Instance.Free();
    }
}
