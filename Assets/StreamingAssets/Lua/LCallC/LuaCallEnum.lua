print("Lua 枚举")
--枚举类是userdata自定义类型数据，当获得其他语言数据类型时，就是userdata
print(CS.TestEnum.LoL)
print(CS.TestEnum.Dota)
print(type(CS.TestEnum))  --table
print(type(CS.TestEnum.LoL))  --userdata

--转换获得枚举值
print(CS.TestEnum.__CastFrom(0))
print(CS.TestEnum.__CastFrom("Dota"))