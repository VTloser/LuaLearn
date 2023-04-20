print("----Lua RefOut----")


--C# out的返回变量会赋值给out2 ,Lua的返回变量会赋值给out1
local out2
local f1,out1 = CS.TestRefOut.Func2("s1",out2)
print(f1,out1,out2)

local Ref2
local f1,Ref1 = CS.TestRefOut.Func3("s2",Ref2)
print(f1,Ref1,Ref2)

local out2
local f1,out1 = CS.TestRefOut.Func4(out2,"s5")
print(f1,out1,out2)

local Ref2
local f1,Ref1 = CS.TestRefOut.Func5(Ref2,"s7")
print(f1,Ref1,Ref2)

local out,ref
local f1 ,out ,ref = CS.TestRefOut.Func6(out,ref)
print(f1,out,ref)

local out,ref
local f1 ,ref ,out = CS.TestRefOut.Func7(ref,out)
print(f1,out,ref)

--总结 Out ref 会变成多返回值而不是对原来的参数有影响