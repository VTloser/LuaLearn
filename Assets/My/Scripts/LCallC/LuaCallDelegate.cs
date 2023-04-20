using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;

public delegate void DelegateLua();


public class TestDelegate
{
    public static DelegateLua StaticDele;
    public DelegateLua Dynamic;

    public TestDelegate()
    {
        DDP2 = DynamicFunc;
    }

    public static void StaticFunc()
    {
        Debug.Log("C#静态成员函数");
    }

    public void DynamicFunc()
    {
        Debug.Log("C#成员函数");
    }

    public DelegateLua DDP1 = () => { Debug.Log("匿名成员函数"); };

    public DelegateLua DDP2;
   
    public void ADD(DelegateLua lua)
    {
        //lua?.Invoke();
        Dynamic += lua;
        Dynamic.Invoke();
    }
}


public class LuaCallDelegate : MonoBehaviour
{


    void Start()
    {
        xLuaEnv.Instance.Dostring("require('LCallC/LuaCallDelegate')");
        this.gameObject.AddComponent(typeof(BoxCollider));
    }

    private void OnDestroy()
    {
        xLuaEnv.Instance.Free();
    }

}
