using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Father
{
    public string Name;
    public void Talk()
    {
        Debug.Log("大声说话");
    }
    public virtual void Override()
    {
        Debug.Log("这是父类的虚方法");
    }
}
public class Child:Father
{
    public override void Override()
    {
        Debug.Log("这是子类的重写方法");
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
