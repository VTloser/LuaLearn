print('Hello Unity')
--CS.[命名空间].类名.{方法名(参数)}/{属性}
require('LuaObject')


local rigidbody
local Tag
local Pos
Init = function ()
    Tag = CS.UnityEngine.GameObject.Find("Tag")
    print(Tag.name)
    --rigidbody = (CS.UnityEngine.Rigidbody)Tag:GetComponent(typeof(CS.UnityEngine.Rigidbody))

    rigidbody = Tag:GetComponent(typeof(CS.UnityEngine.Rigidbody))
    
    Pos = Tag.transform.position;
    print(Pos)
    print(Pos.x)
    
    --CS.GameManager.Instance:DT()
end

--[[
MoveControl = function(a,b)
    print("DDDDD")
    if a~=0 or b~=0 then
        Pos =  CS.UnityEngine.Vector3(a,0,b)-- Pos.x + 1 -- + CS.UnityEngine.Vector3(a,0,b)
        rigidbody.MoveControl(Pos*0.5)
    end
end
]]

local playA = PlayerInfo:new()

NewMoveControl = function()
    a = CS.UnityEngine.Input.GetAxisRaw("Horizontal")
    b = CS.UnityEngine.Input.GetAxisRaw("Vertical")
    if a~=0 or b~=0 then
        -- print(a)
        -- print(b)
        Pos = Pos +  CS.UnityEngine.Vector3(a,0,b) / 2    -- CS.UnityEngine.Vector3(a,0,b)-- Pos.x + 1 -- + CS.UnityEngine.Vector3(a,0,b)
        -- print(Pos)
        --Tag.transform.position = Pos        
        --rigidbody.useGravity = false;
        Tag.transform.name = playA.name..playA.age
        rigidbody:MovePosition(Pos)
    end
end

