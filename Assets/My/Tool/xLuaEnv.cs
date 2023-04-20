using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using XLua;

public class xLuaEnv
{
    #region Singleton

    //public static string PATH =>  Application.dataPath.Replace("Assets", "") + "DataPath/Lua/" ;
    public static string PATH =>  Application.streamingAssetsPath+ "/Lua/" ;


    private static xLuaEnv _Instance;

    public static xLuaEnv Instance
    {
        get { if (_Instance == null) _Instance = new xLuaEnv(); return _Instance; }
    }
    #endregion


    #region Create LuaEnv

    private LuaEnv _Env;

    private xLuaEnv()
    {
        _Env = new LuaEnv();
        _Env.AddLoader(_ProjectLoade);

    }

    #endregion


    #region Loader
    /// <summary>
    /// 自定义加载器
    /// 自定义加载器会先于系统内置加载器执行，当自定义加载器找到文件后，后续的加载器便必会继续执行
    /// 如果需要加载的文件不存在记得返回 null
    /// 当Lua代码执行require()函数时，自定义加载器会尝试获得文件的内容
    /// 参数：被加载Lua文件的路径
    /// </summary>
    /// <param name="filepath"></param>
    /// <returns></returns>
    private byte[] _ProjectLoade(ref string filePath)
    {
        //filepath 来自Lua的require('文件名')
        string path = PATH + filePath + ".lua";

        //将Lua文件读取成为字节流
        //Xlua的解析环境，会执行我们自定义加载器返回的Lua代码
        if (File.Exists(path))
            return File.ReadAllBytes(path);
        else
        {
            Debug.LogError($"未找到文件，重新检查路径:{path}");
            return null;
        }
    }
    #endregion


    #region Free LuaEnv

    /// <summary>
    /// 释放单例
    /// </summary>
    public void Free()
    {
        _Env.Dispose();
        _Instance = null;
    }
    #endregion


    #region Run Lua


    public object[] Dostring(string code)
    {
        return _Env.DoString(code);
    }

    //返回Lua环境的全局变量
    public LuaTable Global => _Env.Global;



    #endregion

}
