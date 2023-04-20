using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void EventLua();

public class TestEvent
{

    public static event EventLua Static;

    public static void StaticFunc()
    {
        Debug.Log("��̬����");
    }

    public static void CallStatic()
    {
        Static?.Invoke();
    }


    public event EventLua Dynamic;

    public void DynamicFunc()
    {
        Debug.Log("��Ա����");
    }

    public EventLua DD1 = () => { Debug.Log("������Ա����"); };


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
