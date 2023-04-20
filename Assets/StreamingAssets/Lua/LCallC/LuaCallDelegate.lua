print("调用委托")

----静态委托----

CS.TestDelegate.StaticDele = CS.TestDelegate.StaticFunc --注意没有括号 C# 也没有
CS.TestDelegate.StaticDele()
--Lua如果添加了函数到静态委托变量中，再委托不再使用后，记得释放添加的委托，否则会报错
CS.TestDelegate.StaticDele = nil 


---------Lua委托------------

local func = function()
    print("这是Lua函数")
end

-- Lua为覆盖委托

--在进行 + - 操作的时候需要注意判断是不是已经有 如果没有可能会报空
if(CS.TestDelegate.StaticDele == nil) then
    CS.TestDelegate.StaticDele = func
else
    CS.TestDelegate.StaticDele = CS.TestDelegate.StaticDele + func 
end

--CS.TestDelegate.StaticDele = CS.TestDelegate.StaticDele - func  -- -=

--调用以前应确定委托有值
if(CS.TestDelegate.StaticDele ~= nil) then
    CS.TestDelegate.StaticDele()
end

CS.TestDelegate.StaticDele = nil  


---------普通委托------------
local obj = CS.TestDelegate()
obj.Dynamic = func
obj.Dynamic()
--对象委托可以不释放 
obj.Dynamic = nil

--这样获取不到 因为返回值是个空值 而且实例访问自己的方法应该是：
local Act1 = obj.DynamicFunc 
--local Act = CS.TestDelegate.StaticFunc
--Act1()
--obj:ADD(Act1)

--返回一个委托就可以了
local Act2 = obj.DDP1
Act2()
obj:ADD(Act2)

local Act3 = obj.DDP2
obj:ADD(Act3)

--总结 静态方法调用可以正常绑定方法
--成员方法 需要返回值是委托才可以绑定
