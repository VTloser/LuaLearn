using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YY
{
    public static class TestStatic
    {
        public static int ID = 78;
        public static string Name { get; set; }

        public static string Output()
        {
            return "Static";
        }
        public static void Default(string str = "abc")
        {
            Debug.Log(str);
        }
    }
}


public class LuaCallStatic : MonoBehaviour
{
    void Start()
    {
        xLuaEnv.Instance.Dostring("require('LCallC/LuaCallStatic')");
    }

    private void OnDestroy()
    {
        xLuaEnv.Instance.Free();
    }
}

