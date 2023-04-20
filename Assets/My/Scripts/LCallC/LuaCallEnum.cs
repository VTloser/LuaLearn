using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TestEnum
{
    LoL = 0,
    Dota
}


public class LuaCallEnum : MonoBehaviour
{

    TestEnum a = TestEnum.Dota;
    void Start()
    {
        xLuaEnv.Instance.Dostring("require('LCallC/LuaCallEnum')");
        this.gameObject.AddComponent(typeof(BoxCollider));
    }

    private void OnDestroy()
    {
        xLuaEnv.Instance.Free();
    }
}
