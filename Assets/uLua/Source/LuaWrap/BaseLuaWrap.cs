﻿using System;
using UnityEngine;
using LuaInterface;
using Object = UnityEngine.Object;

public class BaseLuaWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("AddClick", AddClick),
			new LuaMethod("RemoveClick", RemoveClick),
			new LuaMethod("ClearClick", ClearClick),
			new LuaMethod("New", _CreateBaseLua),
			new LuaMethod("GetClassType", GetClassType),
			new LuaMethod("__eq", Lua_Eq),
		};

		LuaField[] fields = new LuaField[]
		{
		};

		LuaScriptMgr.RegisterLib(L, "BaseLua", typeof(BaseLua), regs, fields, typeof(MonoBehaviour));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateBaseLua(IntPtr L)
	{
		LuaDLL.luaL_error(L, "BaseLua class does not have a constructor function");
		return 0;
	}

	static Type classType = typeof(BaseLua);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int AddClick(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		BaseLua obj = (BaseLua)LuaScriptMgr.GetUnityObjectSelf(L, 1, "BaseLua");
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		obj.AddClick(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int RemoveClick(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		BaseLua obj = (BaseLua)LuaScriptMgr.GetUnityObjectSelf(L, 1, "BaseLua");
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		obj.RemoveClick(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ClearClick(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		BaseLua obj = (BaseLua)LuaScriptMgr.GetUnityObjectSelf(L, 1, "BaseLua");
		obj.ClearClick();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Lua_Eq(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Object arg0 = LuaScriptMgr.GetLuaObject(L, 1) as Object;
		Object arg1 = LuaScriptMgr.GetLuaObject(L, 2) as Object;
		bool o = arg0 == arg1;
		LuaScriptMgr.Push(L, o);
		return 1;
	}
}

