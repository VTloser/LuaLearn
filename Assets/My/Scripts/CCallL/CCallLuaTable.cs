using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;


public delegate void OneStringParams(string name);
public delegate void OneIntParams(int name);
public delegate void TransSelf(LuaTable luaTable);
[CSharpCallLua]
public delegate void TransSelfAndParams(LuaTable luaTable, int count);

[CSharpCallLua]
public delegate void MyTransSelf(LuaCore luaCore);
[CSharpCallLua]
public delegate void MyTransSelfAndParams(LuaCore luaCore, int count);

public class CCallLuaTable : MonoBehaviour
{
    void Start()
    {
        xLuaEnv.Instance.Dostring("return require('CCallL/CCallLuaTable')");


        //UseLuaTable();
        UseStruct();
    }

    /// <summary>
    /// 通过LuaTable获取
    /// </summary>
    void UseLuaTable()
    {

        LuaTable g = xLuaEnv.Instance.Global;

        //获取的是全局变量Core ,因为它在Lua中是表，所以取出来的是LuaTable
        LuaTable core = g.Get<LuaTable>("Core");
        //获取Name
        //参数: table中索引名
        //类型：索引对应值的类型
        Debug.Log(core.Get<string>("Name"));

        //修改参数
        core.Set<string, string>("Name", "admin");
        Debug.Log(core.Get<string>("Name"));

        OneStringParams osp = core.Get<OneStringParams>("Func1");
        osp?.Invoke("Fun Demo");

        OneIntParams oip = core.Get<OneIntParams>("Func1");
        oip?.Invoke(99);

        //相当于":"调用
        TransSelf ts = core.Get<TransSelf>("Func4");
        ts(core);


        //相当于":"调用
        TransSelfAndParams Tap = core.Get<TransSelfAndParams>("Func5");
        Tap(core, 7894);
    }

    /// <summary>
    /// 通过映射结构体调用
    /// </summary>
    void UseStruct()
    {
        LuaTable g = xLuaEnv.Instance.Global;

        LuaCore structcore = g.Get<LuaCore>("Core");

        Debug.Log($"{structcore.ID } { structcore.Name} {structcore.IsMan } ");

        structcore.Name = "root"; //修改属性
        structcore.Func1("小帅ABC");// += ()=> { };
        structcore.Func2(75123);
        structcore.Func4(structcore);
        structcore.Func5(structcore, 155);
    }



    private void OnDestroy()
    {
        xLuaEnv.Instance.Free();
    }
}



//性能更好
//将Lua表映射到C#的结构体
//[GCOptimize]  //不产生GC 会导致程序崩溃...
public struct LuaCore 
{
    public int ID;
    public string Name;
    public bool IsMan;

    public OneStringParams Func1;  //方法名要与Lua方法名一致
    public OneIntParams Func2;
    public MyTransSelf Func4;      //经过映射后从self填入的参数从LuaTable变成LuaCore
    public MyTransSelfAndParams Func5;
}