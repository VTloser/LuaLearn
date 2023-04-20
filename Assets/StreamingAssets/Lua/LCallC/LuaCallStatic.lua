print("Lua 调用静态类")
--规则"CS.命名空间.类名.成员变量"

--静态成员变量
print(CS.YY.TestStatic.ID);
CS.YY.TestStatic.Name = "admin";

--静态成员方法
print(CS.YY.TestStatic.Output());
CS.YY.TestStatic.Default();
CS.YY.TestStatic.Default("Hello I Call U");

