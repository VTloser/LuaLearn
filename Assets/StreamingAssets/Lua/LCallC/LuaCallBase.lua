print("Lua 调用继承重写")

local fa = CS.Father()
fa.Name = "Fa"
fa:Override()

local ch = CS.Child()
print(ch.Name)
ch:Override()
ch:Talk()

