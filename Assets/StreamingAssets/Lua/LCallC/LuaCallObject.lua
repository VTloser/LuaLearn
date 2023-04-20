print("Lua 调用Object")

--通过调用构造函数创建对象
local Npc = CS.Npc("MeiMei")
Npc.Hp = 100;
print(Npc.Name)
print(Npc.Hp)

--表调用表成员变量 :  C#中的this 
--注意： 对象引用成员变量时，会印象调用this,相当于Lua的self
print(Npc:Output())

--Lua实例化GameObject   Unity中会创建出一个LuaCreateGo物体 坐标为10,10,20
local Tag = CS.UnityEngine.GameObject("LuaCreateGo")
Tag.transform.position = CS.UnityEngine.Vector3(10,10,20)
--注意是:  调用成员方法
Tag:AddComponent(typeof(CS.UnityEngine.BoxCollider)); 