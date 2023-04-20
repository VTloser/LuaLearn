using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct TestStruct
{
    public string Name;

    public string Output()
    {
        return Name;
    }

}


public class LuaCalStruct : MonoBehaviour
{
    void Start()
    {
        xLuaEnv.Instance.Dostring("require('LCallC/LuaCalStruct')");
        this.gameObject.AddComponent(typeof(BoxCollider));
    }

    private void OnDestroy()
    {
        xLuaEnv.Instance.Free();
    }
}
