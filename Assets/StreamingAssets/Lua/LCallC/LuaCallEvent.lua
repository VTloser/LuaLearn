print("Lua 事件Evetn")

--C# 添加事件 TestEvent.Static +=TestEvent.StaticFunc
--Lua

CS.TestEvent.Static("+" , CS.TestEvent.StaticFunc)
CS.TestEvent.CallStatic()
CS.TestEvent.Static("-" , CS.TestEvent.StaticFunc)

--添加动态成员变量
local func = function()
    print("来自Lua的回调")
end

--
local temp = CS.TestEvent()
temp:Dynamic("+",func)
temp:CallDynamic()
temp:Dynamic("-",func)

local D = CS.TestEvent().DD1
temp:Dynamic("+",D)
temp:CallDynamic()
temp:Dynamic("-",D)


--local D1 = CS.TestEvent().DynamicFunc
--temp:Dynamic("+",CS.TestEvent().DynamicFunc)
--temp:CallDynamic()
--temp:Dynamic("-",CS.TestEvent().DynamicFunc)