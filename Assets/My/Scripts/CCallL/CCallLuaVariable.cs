using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;

public class CCallLuaVariable : MonoBehaviour
{

    private void Start()
    {
        //通过这种方式获取的返回值会涉及拆装箱对性能不太友好
        object[] data = xLuaEnv.Instance.Dostring("return require('CCallL/CCallLuavariable')");
        foreach (var item in data)
        {
            Debug.Log(item);
        }

        //LuaEnv 中提供成员变量 Global，它用于C#获取Lua的全局变量
        //Global的数据类型是C#实现的LuaTable  
        //LuaTable是Xlua实现的C#和Lua中表对应的数据结构
        //Xlua会将Lua中的全局变量以Table的方式全部存储再Global中
        //LuaTable 是C#数据对象，用于和Lua中的全局变量存储的table对应

        LuaTable g = xLuaEnv.Instance.Global;

        //从Lua中提取变量

        Debug.Log(g.Get<int>("num"));
        Debug.Log(g.Get<float>("rate"));
        Debug.Log(g.Get<bool>("isMan"));
        Debug.Log(g.GetInPath<string>("name"));  //不清楚GetInPath

    }

    private void OnDestroy()
    {
        xLuaEnv.Instance.Free();
    }


}
