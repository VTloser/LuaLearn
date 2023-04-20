using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestRefOut
{
    public static void Func1()
    {

    }
    public static string Func2(string str1, out string str2)
    {
        str1 += "Func2_C1";
        str2 = "Func2_C2";

        return "F2";
    }
    public static string Func3(string str1, ref string str2)
    {
        str1 += "Func3_C1";
        str2 += "Func3_C2";

        return "F3";
    }

    public static string Func4(out string str1, string str2)
    {
        str1 = "Func4_C1";
        str2 += "Func4_C2";

        return "F4";
    }
    public static string Func5(ref string str1, string str2)
    {
        str1 += "Func5_C1";
        str2 += "Func5_C2";

        return "F5";
    }

    public static string Func6(ref string str1, out string str2)
    {
        str1 += "Func6_C1";
        str2 = "Func6_C2";

        return "F6";
    }

    public static string Func7(out string str1, ref string str2)
    {
        str1 = "Func7_C1";
        str2 = "Func7_C2";

        return "F7";
    }
}



public class LuaCalrefout : MonoBehaviour
{
    void Start()
    {
        xLuaEnv.Instance.Dostring("require('LCallC/LuaCalrefout')");
    }

    private void OnDestroy()
    {
        xLuaEnv.Instance.Free();
    }
}
