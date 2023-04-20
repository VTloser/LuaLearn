--面向对象实现
Object = {}
Object.ID = 998

--实例化方法/封装
function Object:new()
    local obj ={}
    --给空对象设置元表以及__index
    self.__index = self
    setmetatable(obj,self)
    return obj;
end

local A = Object:new()
A.ID = 997
print(A.ID)

local B = Object:new()
print(B.ID)


--继承
function Object:Subclass(className)
    _G[className]={}
    local obj = _G[className]
    --设置自己的父类
    obj.base = self
    self.__index = self
    setmetatable(obj,self)
end


--继承对象
Object:Subclass("PlayerInfo")
PlayerInfo.name = "测试"
PlayerInfo.age = 100

function PlayerInfo:ChangeAge(newAge)
    print(newAge)
    self.age = newAge
    print(self.age)
end


function PlayerInfo.Func1(str)
    print(str)
end



--示例化对象
local playA = PlayerInfo:new()
playA.name = "A"
print(playA.ID)

local playB = PlayerInfo:new()
playB.name = "B"
print(playB.ID)

--print(playA.name)
--print(playA.age)
--print(playA.ID)
--print(playA:ChangeAge(10))
--print(playA.age)
