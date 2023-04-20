Core = {  Name = "小美" }
Core.ID = 77
Core.IsMan = true

function Core.Func1(str)
    print(str)
end
function Core.Func2(str)
    print(str)
end
function Core:Func4()
    print(self.Name)
end

function Core:Func5(a)
    print(self.Name..a)
end
