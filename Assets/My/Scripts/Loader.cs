using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using XLua;

public class Loader : MonoBehaviour
{
    //Lua�ǽű����� ��д����ű���ʵ�ֹ�������Ҫ�ķ�ʽ

    private void Start()
    {
        Myloader();

    }

    private void SystemLoader()
    {

        LuaEnv env = new LuaEnv();

        //���ü�������ɨ��Ԥ��Ŀ¼ �����Ƿ����test.lua
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
    /// �Զ��������
    /// �Զ��������������ϵͳ���ü�����ִ�У����Զ���������ҵ��ļ��󣬺����ļ�������ػ����ִ��
    /// �����Ҫ���ص��ļ������ڼǵ÷��� null
    /// ��Lua����ִ��require()����ʱ���Զ���������᳢�Ի���ļ�������
    /// ������������Lua�ļ���·��
    /// </summary>
    /// <param name="filepath"></param>
    /// <returns></returns>
    public byte[] ProjectLoader(ref string filepath)
    {
        //filepath ����Lua��require('�ļ���')
        string path = Application.dataPath;
        path = path.Substring(0, path.Length - 7) + "/DataPath/Lua/" + filepath + ".lua";

        //��Lua�ļ���ȡ��Ϊ�ֽ���
        //Xlua�Ľ�����������ִ�������Զ�����������ص�Lua����
        if (File.Exists(path))
            return File.ReadAllBytes(path);
        else
            return null;
    }
}
