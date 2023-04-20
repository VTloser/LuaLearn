using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Npc
{
    public string Name;
    public int Hp { get; set; }

    public Npc()
    {

    }

    public Npc(string name)
    {
        Name = name;
    }

    public string Output()
    {
        return Name;
    }
}

public class LuaCallObject : MonoBehaviour
{
    void Start()
    {
        xLuaEnv.Instance.Dostring("require('LCallC/LuaCallObject')");
        this.gameObject.AddComponent(typeof(BoxCollider));
    }

    private void OnDestroy()
    {
        xLuaEnv.Instance.Free();
    }
}
