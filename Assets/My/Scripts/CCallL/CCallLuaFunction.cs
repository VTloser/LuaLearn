using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;

public delegate void Func1();
public delegate void Func2(string str);

[CSharpCallLua] //用于重新映射
public delegate void Func22(int num);   //参数不为string 需要添加标签CSharpCallLua 并重新生成xLua

public delegate string Func3();

[CSharpCallLua]  //注意重新生成xLua
public delegate string Func4(out int a, out float b);  //Lua函数为多返回值参数 C#对应参数变为Out关键字
//public delegate void Func4(out string str, out int a, out float b); //这样也可以 





public class CCallLuaFunction : MonoBehaviour
{

    private void Start()
    {
        xLuaEnv.Instance.Dostring("return require('CCallL/CCallLuaFunction')");


        LuaTable g = xLuaEnv.Instance.Global;


        //Lua的参数会 导出为C#的委托形式
        Func1 func1 = g.Get<Func1>("func1");
        func1?.Invoke();

        //向Lua传递数据  stirng类型不需要CSharpCallLua重新映射
        Func2 func2 = g.Get<Func2>("func2");  
        func2?.Invoke("AAA");

        //向Lua传递数据  需要CSharpCallLua重新映射
        Func22 func22 = g.Get<Func22>("func2");  
        func22?.Invoke(456);

        //接收Lua函数的返回值
        Func3 func3 = g.Get<Func3>("func3");
        Debug.Log(func3?.Invoke());

        //接收Lua函数多返回值，表现为C#的Out
        string str ="";
        int a = 0;
        float b = 0;
        Func4 func4 = g.Get<Func4>("func4");
        Debug.Log(func4?.Invoke(out a, out b));
        //func4?.Invoke(out str, out a, out b);
        Debug.Log(str);
        Debug.Log(a);       
        Debug.Log(b);

    }
    private void OnDestroy()
    {
        xLuaEnv.Instance.Free();
    }
}
