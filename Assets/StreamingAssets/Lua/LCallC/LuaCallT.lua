print("Lua 泛型")
local Stu = CS.TestT()
Stu:OutPut(76.56)
Stu:OutPut("string")


local gam = CS.UnityEngine.GameObject("T") --注意区别 C# new Gameobjec 省区了new 多了CS.UnityEngine
--Lua实现了 typeof关键字 ,所以可以使用类型API代替Unity内置的泛型方法
gam:AddComponent(typeof(CS.UnityEngine.BoxCollider))  --获取类型也应该有CS.UnityEngine

