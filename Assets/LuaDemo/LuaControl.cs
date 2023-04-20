using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;

public delegate void Init();

[CSharpCallLua] //用于重新映射
public delegate void MoveControl(float a, float b);
public delegate void NewMoveControl();

[CSharpCallLua]
public delegate void MyTransSelfAndParams_PlayerInfo(LuaCore_PlayerInfo luaCore, int count);

[CSharpCallLua]
public delegate void MyTransSelfAndParams_PlayerInf(LuaTable luaCore, int count);

public class LuaControl : MonoBehaviour
{
    Init init;
    MoveControl moveControl;
    NewMoveControl newMoveControl;
    private void Awake()
    {
        xLuaEnv.Instance.Dostring("require('Hello')");
        xLuaEnv.Instance.Dostring("return require('LuaObject')");
        LuaTable g = xLuaEnv.Instance.Global;

        init = g.Get<Init>("Init");
        moveControl = g.Get<MoveControl>("MoveControl");
        newMoveControl = g.Get<NewMoveControl>("NewMoveControl");

        //UseLuaTable();
        UseStruct();
    }

    private void UseStruct()
    {
        LuaTable g = xLuaEnv.Instance.Global;

        LuaCore_Object structcore = g.Get<LuaCore_Object>("Object");
        Debug.Log($"ID:{structcore.ID}");
        structcore.ID = 997; //修改属性
        Debug.Log($"ID:{structcore.ID}");

        Debug.Log("----------------------------");
        LuaCore_PlayerInfo playerInfo = g.Get<LuaCore_PlayerInfo>("PlayerInfo");
        Debug.Log($"ID:{playerInfo.ID}");
        Debug.Log($"age:{playerInfo.age}");

        playerInfo.age = 888;
        Debug.Log($"age:{playerInfo.age}");

        playerInfo.ChangeAge(playerInfo,7777);
        Debug.Log($"age:{playerInfo.age}");

        playerInfo.Func1("Hello Unityyyy");

    }

    private void UseLuaTable()
    {
        LuaTable g = xLuaEnv.Instance.Global;

        //获取的是全局变量Core ,因为它在Lua中是表，所以取出来的是LuaTable
        LuaTable core = g.Get<LuaTable>("Object");

        //获取Name
        //参数: table中索引名
        //类型：索引对应值的类型
        Debug.Log(core.Get<int>("ID"));

        LuaTable core_PlayerInfo = g.Get<LuaTable>("PlayerInfo");
        Debug.Log(core_PlayerInfo.Get<int>("age"));
        Debug.Log(core_PlayerInfo.Get<string>("name"));

        MyTransSelfAndParams_PlayerInf playerInfo = core_PlayerInfo.Get<MyTransSelfAndParams_PlayerInf>("ChangeAge");
        Debug.Log(core_PlayerInfo.Get<int>("ID"));
        Debug.Log(core_PlayerInfo.Get<int>("age"));

        playerInfo.Invoke(core_PlayerInfo, 10);

        Debug.Log(core_PlayerInfo.Get<int>("age"));

        core_PlayerInfo.Set<string, int>("age", 789798789);
        Debug.Log(core_PlayerInfo.Get<int>("age"));

        OneStringParams oneString = core_PlayerInfo.Get<OneStringParams>("Func1");
        oneString.Invoke("ceshiceshiceshi");

    }

    void Start()
    {
        init?.Invoke();
    }

    void Update()
    {
        // moveControl?.Invoke(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        newMoveControl?.Invoke();
    }

    private void OnDestroy()
    {
        xLuaEnv.Instance.Free();
    }
}

//映射 Object
//性能更好
//将Lua表映射到C#的结构体
//[GCOptimize]  //不产生GC 会导致程序崩溃...
public class LuaCore_Object 
{
    public int ID;
}

public class LuaCore_PlayerInfo : LuaCore_Object
{

    public string name;
    public int age;

    public MyTransSelfAndParams_PlayerInfo ChangeAge;
    public OneStringParams Func1;

}
