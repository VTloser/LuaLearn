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
    /// �Զ��������
    /// �Զ��������������ϵͳ���ü�����ִ�У����Զ���������ҵ��ļ��󣬺����ļ�������ػ����ִ��
    /// �����Ҫ���ص��ļ������ڼǵ÷��� null
    /// ��Lua����ִ��require()����ʱ���Զ���������᳢�Ի���ļ�������
    /// ������������Lua�ļ���·��
    /// </summary>
    /// <param name="filepath"></param>
    /// <returns></returns>
    private byte[] _ProjectLoade(ref string filePath)
    {
        //filepath ����Lua��require('�ļ���')
        string path = PATH + filePath + ".lua";

        //��Lua�ļ���ȡ��Ϊ�ֽ���
        //Xlua�Ľ�����������ִ�������Զ�����������ص�Lua����
        if (File.Exists(path))
            return File.ReadAllBytes(path);
        else
        {
            Debug.LogError($"δ�ҵ��ļ������¼��·��:{path}");
            return null;
        }
    }
    #endregion


    #region Free LuaEnv

    /// <summary>
    /// �ͷŵ���
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

    //����Lua������ȫ�ֱ���
    public LuaTable Global => _Env.Global;



    #endregion

}
