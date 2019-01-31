using System;
using UnityEngine;
using LuaInterface;
using Object = UnityEngine.Object;

public class DebugWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("DrawLine", DrawLine),
			new LuaMethod("DrawRay", DrawRay),
			new LuaMethod("Break", Break),
			new LuaMethod("DebugBreak", DebugBreak),
			new LuaMethod("Log", Log),
			new LuaMethod("LogFormat", LogFormat),
			new LuaMethod("LogError", LogError),
			new LuaMethod("LogErrorFormat", LogErrorFormat),
			new LuaMethod("ClearDeveloperConsole", ClearDeveloperConsole),
			new LuaMethod("LogException", LogException),
			new LuaMethod("LogWarning", LogWarning),
			new LuaMethod("LogWarningFormat", LogWarningFormat),
			new LuaMethod("Assert", Assert),
			new LuaMethod("AssertFormat", AssertFormat),
			new LuaMethod("LogAssertion", LogAssertion),
			new LuaMethod("LogAssertionFormat", LogAssertionFormat),
			new LuaMethod("New", _CreateDebug),
			new LuaMethod("GetClassType", GetClassType),
		};

		LuaField[] fields = new LuaField[]
		{
			new LuaField("unityLogger", get_unityLogger, null),
			new LuaField("developerConsoleVisible", get_developerConsoleVisible, set_developerConsoleVisible),
			new LuaField("isDebugBuild", get_isDebugBuild, null),
		};

		LuaScriptMgr.RegisterLib(L, "UnityEngine.Debug", typeof(Debug), regs, fields, typeof(object));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateDebug(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			Debug obj = new Debug();
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Debug.New");
		}

		return 0;
	}

	static Type classType = typeof(Debug);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_unityLogger(IntPtr L)
	{
		LuaScriptMgr.PushObject(L, Debug.unityLogger);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_developerConsoleVisible(IntPtr L)
	{
		LuaScriptMgr.Push(L, Debug.developerConsoleVisible);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_isDebugBuild(IntPtr L)
	{
		LuaScriptMgr.Push(L, Debug.isDebugBuild);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_developerConsoleVisible(IntPtr L)
	{
		Debug.developerConsoleVisible = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int DrawLine(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2)
		{
			Vector3 arg0 = LuaScriptMgr.GetVector3(L, 1);
			Vector3 arg1 = LuaScriptMgr.GetVector3(L, 2);
			Debug.DrawLine(arg0,arg1);
			return 0;
		}
		else if (count == 3)
		{
			Vector3 arg0 = LuaScriptMgr.GetVector3(L, 1);
			Vector3 arg1 = LuaScriptMgr.GetVector3(L, 2);
			Color arg2 = LuaScriptMgr.GetColor(L, 3);
			Debug.DrawLine(arg0,arg1,arg2);
			return 0;
		}
		else if (count == 4)
		{
			Vector3 arg0 = LuaScriptMgr.GetVector3(L, 1);
			Vector3 arg1 = LuaScriptMgr.GetVector3(L, 2);
			Color arg2 = LuaScriptMgr.GetColor(L, 3);
			float arg3 = (float)LuaScriptMgr.GetNumber(L, 4);
			Debug.DrawLine(arg0,arg1,arg2,arg3);
			return 0;
		}
		else if (count == 5)
		{
			Vector3 arg0 = LuaScriptMgr.GetVector3(L, 1);
			Vector3 arg1 = LuaScriptMgr.GetVector3(L, 2);
			Color arg2 = LuaScriptMgr.GetColor(L, 3);
			float arg3 = (float)LuaScriptMgr.GetNumber(L, 4);
			bool arg4 = LuaScriptMgr.GetBoolean(L, 5);
			Debug.DrawLine(arg0,arg1,arg2,arg3,arg4);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Debug.DrawLine");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int DrawRay(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2)
		{
			Vector3 arg0 = LuaScriptMgr.GetVector3(L, 1);
			Vector3 arg1 = LuaScriptMgr.GetVector3(L, 2);
			Debug.DrawRay(arg0,arg1);
			return 0;
		}
		else if (count == 3)
		{
			Vector3 arg0 = LuaScriptMgr.GetVector3(L, 1);
			Vector3 arg1 = LuaScriptMgr.GetVector3(L, 2);
			Color arg2 = LuaScriptMgr.GetColor(L, 3);
			Debug.DrawRay(arg0,arg1,arg2);
			return 0;
		}
		else if (count == 4)
		{
			Vector3 arg0 = LuaScriptMgr.GetVector3(L, 1);
			Vector3 arg1 = LuaScriptMgr.GetVector3(L, 2);
			Color arg2 = LuaScriptMgr.GetColor(L, 3);
			float arg3 = (float)LuaScriptMgr.GetNumber(L, 4);
			Debug.DrawRay(arg0,arg1,arg2,arg3);
			return 0;
		}
		else if (count == 5)
		{
			Vector3 arg0 = LuaScriptMgr.GetVector3(L, 1);
			Vector3 arg1 = LuaScriptMgr.GetVector3(L, 2);
			Color arg2 = LuaScriptMgr.GetColor(L, 3);
			float arg3 = (float)LuaScriptMgr.GetNumber(L, 4);
			bool arg4 = LuaScriptMgr.GetBoolean(L, 5);
			Debug.DrawRay(arg0,arg1,arg2,arg3,arg4);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Debug.DrawRay");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Break(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 0);
		Debug.Break();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int DebugBreak(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 0);
		Debug.DebugBreak();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Log(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 1)
		{
			object arg0 = LuaScriptMgr.GetVarObject(L, 1);
			Debug.Log(arg0);
			return 0;
		}
		else if (count == 2)
		{
			object arg0 = LuaScriptMgr.GetVarObject(L, 1);
			Object arg1 = (Object)LuaScriptMgr.GetUnityObject(L, 2, typeof(Object));
			Debug.Log(arg0,arg1);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Debug.Log");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LogFormat(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (LuaScriptMgr.CheckTypes(L, 1, typeof(Object), typeof(string)) && LuaScriptMgr.CheckParamsType(L, typeof(object), 3, count - 2))
		{
			Object arg0 = (Object)LuaScriptMgr.GetLuaObject(L, 1);
			string arg1 = LuaScriptMgr.GetString(L, 2);
			object[] objs2 = LuaScriptMgr.GetParamsObject(L, 3, count - 2);
			Debug.LogFormat(arg0,arg1,objs2);
			return 0;
		}
		else if (LuaScriptMgr.CheckTypes(L, 1, typeof(string)) && LuaScriptMgr.CheckParamsType(L, typeof(object), 2, count - 1))
		{
			string arg0 = LuaScriptMgr.GetString(L, 1);
			object[] objs1 = LuaScriptMgr.GetParamsObject(L, 2, count - 1);
			Debug.LogFormat(arg0,objs1);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Debug.LogFormat");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LogError(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 1)
		{
			object arg0 = LuaScriptMgr.GetVarObject(L, 1);
			Debug.LogError(arg0);
			return 0;
		}
		else if (count == 2)
		{
			object arg0 = LuaScriptMgr.GetVarObject(L, 1);
			Object arg1 = (Object)LuaScriptMgr.GetUnityObject(L, 2, typeof(Object));
			Debug.LogError(arg0,arg1);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Debug.LogError");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LogErrorFormat(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (LuaScriptMgr.CheckTypes(L, 1, typeof(Object), typeof(string)) && LuaScriptMgr.CheckParamsType(L, typeof(object), 3, count - 2))
		{
			Object arg0 = (Object)LuaScriptMgr.GetLuaObject(L, 1);
			string arg1 = LuaScriptMgr.GetString(L, 2);
			object[] objs2 = LuaScriptMgr.GetParamsObject(L, 3, count - 2);
			Debug.LogErrorFormat(arg0,arg1,objs2);
			return 0;
		}
		else if (LuaScriptMgr.CheckTypes(L, 1, typeof(string)) && LuaScriptMgr.CheckParamsType(L, typeof(object), 2, count - 1))
		{
			string arg0 = LuaScriptMgr.GetString(L, 1);
			object[] objs1 = LuaScriptMgr.GetParamsObject(L, 2, count - 1);
			Debug.LogErrorFormat(arg0,objs1);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Debug.LogErrorFormat");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ClearDeveloperConsole(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 0);
		Debug.ClearDeveloperConsole();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LogException(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 1)
		{
			Exception arg0 = (Exception)LuaScriptMgr.GetNetObject(L, 1, typeof(Exception));
			Debug.LogException(arg0);
			return 0;
		}
		else if (count == 2)
		{
			Exception arg0 = (Exception)LuaScriptMgr.GetNetObject(L, 1, typeof(Exception));
			Object arg1 = (Object)LuaScriptMgr.GetUnityObject(L, 2, typeof(Object));
			Debug.LogException(arg0,arg1);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Debug.LogException");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LogWarning(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 1)
		{
			object arg0 = LuaScriptMgr.GetVarObject(L, 1);
			Debug.LogWarning(arg0);
			return 0;
		}
		else if (count == 2)
		{
			object arg0 = LuaScriptMgr.GetVarObject(L, 1);
			Object arg1 = (Object)LuaScriptMgr.GetUnityObject(L, 2, typeof(Object));
			Debug.LogWarning(arg0,arg1);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Debug.LogWarning");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LogWarningFormat(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (LuaScriptMgr.CheckTypes(L, 1, typeof(Object), typeof(string)) && LuaScriptMgr.CheckParamsType(L, typeof(object), 3, count - 2))
		{
			Object arg0 = (Object)LuaScriptMgr.GetLuaObject(L, 1);
			string arg1 = LuaScriptMgr.GetString(L, 2);
			object[] objs2 = LuaScriptMgr.GetParamsObject(L, 3, count - 2);
			Debug.LogWarningFormat(arg0,arg1,objs2);
			return 0;
		}
		else if (LuaScriptMgr.CheckTypes(L, 1, typeof(string)) && LuaScriptMgr.CheckParamsType(L, typeof(object), 2, count - 1))
		{
			string arg0 = LuaScriptMgr.GetString(L, 1);
			object[] objs1 = LuaScriptMgr.GetParamsObject(L, 2, count - 1);
			Debug.LogWarningFormat(arg0,objs1);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Debug.LogWarningFormat");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Assert(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 1)
		{
			bool arg0 = LuaScriptMgr.GetBoolean(L, 1);
			Debug.Assert(arg0);
			return 0;
		}
		else if (count == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(bool), typeof(string)))
		{
			bool arg0 = LuaDLL.lua_toboolean(L, 1);
			string arg1 = LuaScriptMgr.GetString(L, 2);
			Debug.Assert(arg0,arg1);
			return 0;
		}
		else if (count == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(bool), typeof(Object)))
		{
			bool arg0 = LuaDLL.lua_toboolean(L, 1);
			Object arg1 = (Object)LuaScriptMgr.GetLuaObject(L, 2);
			Debug.Assert(arg0,arg1);
			return 0;
		}
		else if (count == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(bool), typeof(object)))
		{
			bool arg0 = LuaDLL.lua_toboolean(L, 1);
			object arg1 = LuaScriptMgr.GetVarObject(L, 2);
			Debug.Assert(arg0,arg1);
			return 0;
		}
		else if (count == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof(bool), typeof(string), typeof(Object)))
		{
			bool arg0 = LuaDLL.lua_toboolean(L, 1);
			string arg1 = LuaScriptMgr.GetString(L, 2);
			Object arg2 = (Object)LuaScriptMgr.GetLuaObject(L, 3);
			Debug.Assert(arg0,arg1,arg2);
			return 0;
		}
		else if (count == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof(bool), typeof(object), typeof(Object)))
		{
			bool arg0 = LuaDLL.lua_toboolean(L, 1);
			object arg1 = LuaScriptMgr.GetVarObject(L, 2);
			Object arg2 = (Object)LuaScriptMgr.GetLuaObject(L, 3);
			Debug.Assert(arg0,arg1,arg2);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Debug.Assert");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int AssertFormat(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (LuaScriptMgr.CheckTypes(L, 1, typeof(bool), typeof(Object), typeof(string)) && LuaScriptMgr.CheckParamsType(L, typeof(object), 4, count - 3))
		{
			bool arg0 = LuaDLL.lua_toboolean(L, 1);
			Object arg1 = (Object)LuaScriptMgr.GetLuaObject(L, 2);
			string arg2 = LuaScriptMgr.GetString(L, 3);
			object[] objs3 = LuaScriptMgr.GetParamsObject(L, 4, count - 3);
			Debug.AssertFormat(arg0,arg1,arg2,objs3);
			return 0;
		}
		else if (LuaScriptMgr.CheckTypes(L, 1, typeof(bool), typeof(string)) && LuaScriptMgr.CheckParamsType(L, typeof(object), 3, count - 2))
		{
			bool arg0 = LuaDLL.lua_toboolean(L, 1);
			string arg1 = LuaScriptMgr.GetString(L, 2);
			object[] objs2 = LuaScriptMgr.GetParamsObject(L, 3, count - 2);
			Debug.AssertFormat(arg0,arg1,objs2);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Debug.AssertFormat");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LogAssertion(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 1)
		{
			object arg0 = LuaScriptMgr.GetVarObject(L, 1);
			Debug.LogAssertion(arg0);
			return 0;
		}
		else if (count == 2)
		{
			object arg0 = LuaScriptMgr.GetVarObject(L, 1);
			Object arg1 = (Object)LuaScriptMgr.GetUnityObject(L, 2, typeof(Object));
			Debug.LogAssertion(arg0,arg1);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Debug.LogAssertion");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LogAssertionFormat(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (LuaScriptMgr.CheckTypes(L, 1, typeof(Object), typeof(string)) && LuaScriptMgr.CheckParamsType(L, typeof(object), 3, count - 2))
		{
			Object arg0 = (Object)LuaScriptMgr.GetLuaObject(L, 1);
			string arg1 = LuaScriptMgr.GetString(L, 2);
			object[] objs2 = LuaScriptMgr.GetParamsObject(L, 3, count - 2);
			Debug.LogAssertionFormat(arg0,arg1,objs2);
			return 0;
		}
		else if (LuaScriptMgr.CheckTypes(L, 1, typeof(string)) && LuaScriptMgr.CheckParamsType(L, typeof(object), 2, count - 1))
		{
			string arg0 = LuaScriptMgr.GetString(L, 1);
			object[] objs1 = LuaScriptMgr.GetParamsObject(L, 2, count - 1);
			Debug.LogAssertionFormat(arg0,objs1);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Debug.LogAssertionFormat");
		}

		return 0;
	}
}

