using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;


public delegate void Empty();

public class Call_LifeCycle : MonoBehaviour
{
    LuaTable g;
    Empty awake;
    Empty start;
    Empty update;

    private void Awake()
    {
        xLuaEnv.Instance.Dostring("require('Unity_LifeCycle')");
        g = xLuaEnv.Instance.Global;

        awake = g.Get<Empty>("Awake");
        start = g.Get<Empty>("Start");
        update = g.Get<Empty>("Update");

        awake.Invoke();
    }


    void Start()
    {
        start.Invoke();
    }

    
    void Update()
    {
        update.Invoke();
    }


    private void OnDestroy()
    {
        xLuaEnv.Instance.Free();
    }
}
