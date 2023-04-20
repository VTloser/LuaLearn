using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using XLua;

public class Loader : MonoBehaviour
{
    //Lua是脚本语言 编写代码脚本是实现功能最重要的方式

    private void Start()
    {
        Myloader();

    }

    private void SystemLoader()
    {

        LuaEnv env = new LuaEnv();

        //内置加载器会扫描预制目录 查找是否存在test.lua
        env.DoString("require('Test')");

        env.Dispose();
    }

    public void Myloader()
    {
        LuaEnv env = new LuaEnv();

        env.AddLoader(ProjectLoader);

        env.DoString("require('Test1')");

        env.Dispose();

    }

    /// <summary>
    /// 自定义加载器
    /// 自定义加载器会先于系统内置加载器执行，当自定义加载器找到文件后，后续的加载器便必会继续执行
    /// 如果需要加载的文件不存在记得返回 null
    /// 当Lua代码执行require()函数时，自定义加载器会尝试获得文件的内容
    /// 参数：被加载Lua文件的路径
    /// </summary>
    /// <param name="filepath"></param>
    /// <returns></returns>
    public byte[] ProjectLoader(ref string filepath)
    {
        //filepath 来自Lua的require('文件名')
        string path = Application.dataPath;
        path = path.Substring(0, path.Length - 7) + "/DataPath/Lua/" + filepath + ".lua";

        //将Lua文件读取成为字节流
        //Xlua的解析环境，会执行我们自定义加载器返回的Lua代码
        if (File.Exists(path))
            return File.ReadAllBytes(path);
        else
            return null;
    }
}
