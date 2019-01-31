﻿using System;
using UnityEngine;
using LuaInterface;
using Object = UnityEngine.Object;

public class UIDragScrollViewWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("OnPan", OnPan),
			new LuaMethod("New", _CreateUIDragScrollView),
			new LuaMethod("GetClassType", GetClassType),
			new LuaMethod("__eq", Lua_Eq),
		};

		LuaField[] fields = new LuaField[]
		{
			new LuaField("scrollView", get_scrollView, set_scrollView),
		};

		LuaScriptMgr.RegisterLib(L, "UIDragScrollView", typeof(UIDragScrollView), regs, fields, typeof(MonoBehaviour));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateUIDragScrollView(IntPtr L)
	{
		LuaDLL.luaL_error(L, "UIDragScrollView class does not have a constructor function");
		return 0;
	}

	static Type classType = typeof(UIDragScrollView);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_scrollView(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		UIDragScrollView obj = (UIDragScrollView)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name scrollView");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index scrollView on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.scrollView);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_scrollView(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		UIDragScrollView obj = (UIDragScrollView)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name scrollView");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index scrollView on a nil value");
			}
		}

		obj.scrollView = (UIScrollView)LuaScriptMgr.GetUnityObject(L, 3, typeof(UIScrollView));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int OnPan(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		UIDragScrollView obj = (UIDragScrollView)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UIDragScrollView");
		Vector2 arg0 = LuaScriptMgr.GetVector2(L, 2);
		obj.OnPan(arg0);
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

