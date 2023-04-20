using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void EventLua();

public class TestEvent
{

    public static event EventLua Static;

    public static void StaticFunc()
    {
        Debug.Log("静态函数");
    }

    public static void CallStatic()
    {
        Static?.Invoke();
    }


    public event EventLua Dynamic;

    public void DynamicFunc()
    {
        Debug.Log("成员函数");
    }

    public EventLua DD1 = () => { Debug.Log("匿名成员函数"); };


    public void CallDynamic()
    {
        Dynamic += DynamicFunc;
        Dynamic += DD1;
        Dynamic.Invoke();
    }

}


public class LuaCallEvent : MonoBehaviour
{
    void Start()
    {
        xLuaEnv.Instance.Dostring("require('LCallC/LuaCallEvent')");
        this.gameObject.AddComponent(typeof(BoxCollider));
    }

    private void OnDestroy()
    {
        xLuaEnv.Instance.Free();
    }
}
