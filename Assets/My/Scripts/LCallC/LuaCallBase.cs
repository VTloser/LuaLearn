using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Father
{
    public string Name;
    public void Talk()
    {
        Debug.Log("����˵��");
    }
    public virtual void Override()
    {
        Debug.Log("���Ǹ�����鷽��");
    }
}
public class Child:Father
{
    public override void Override()
    {
        Debug.Log("�����������д����");
    }
}


public class LuaCallBase : MonoBehaviour
{
    void Start()
    {
        xLuaEnv.Instance.Dostring("require('LCallC/LuaCallBase')");
    }

    private void OnDestroy()
    {
        xLuaEnv.Instance.Free();
    }
}
