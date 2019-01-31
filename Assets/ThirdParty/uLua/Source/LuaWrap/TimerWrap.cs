using System;
using UnityEngine;
using LuaInterface;
using Object = UnityEngine.Object;

public class TimerWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("AddTimer", AddTimer),
			new LuaMethod("Yield", Yield),
			new LuaMethod("WaitEndOfFrame", WaitEndOfFrame),
			new LuaMethod("ResetTimer", ResetTimer),
			new LuaMethod("StopTimer", StopTimer),
			new LuaMethod("StopAllTimer", StopAllTimer),
			new LuaMethod("OnUpdate", OnUpdate),
			new LuaMethod("New", _CreateTimer),
			new LuaMethod("GetClassType", GetClassType),
			new LuaMethod("__eq", Lua_Eq),
		};

		LuaField[] fields = new LuaField[]
		{
			new LuaField("Instance", get_Instance, null),
		};

		LuaScriptMgr.RegisterLib(L, "Timer", typeof(Timer), regs, fields, typeof(MonoBehaviour));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateTimer(IntPtr L)
	{
		LuaDLL.luaL_error(L, "Timer class does not have a constructor function");
		return 0;
	}

	static Type classType = typeof(Timer);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Instance(IntPtr L)
	{
		LuaScriptMgr.Push(L, Timer.Instance);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int AddTimer(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 4)
		{
			Timer obj = (Timer)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Timer");
			float arg0 = (float)LuaScriptMgr.GetNumber(L, 2);
			int arg1 = (int)LuaScriptMgr.GetNumber(L, 3);
			Action arg2 = null;
			LuaTypes funcType4 = LuaDLL.lua_type(L, 4);

			if (funcType4 != LuaTypes.LUA_TFUNCTION)
			{
				 arg2 = (Action)LuaScriptMgr.GetNetObject(L, 4, typeof(Action));
			}
			else
			{
				LuaFunction func = LuaScriptMgr.GetLuaFunction(L, 4);
				arg2 = () =>
				{
					func.Call();
				};
			}

			object o = obj.AddTimer(arg0,arg1,arg2);
			LuaScriptMgr.PushVarObject(L, o);
			return 1;
		}
		else if (count == 5)
		{
			Timer obj = (Timer)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Timer");
			float arg0 = (float)LuaScriptMgr.GetNumber(L, 2);
			int arg1 = (int)LuaScriptMgr.GetNumber(L, 3);
			Action arg2 = null;
			LuaTypes funcType4 = LuaDLL.lua_type(L, 4);

			if (funcType4 != LuaTypes.LUA_TFUNCTION)
			{
				 arg2 = (Action)LuaScriptMgr.GetNetObject(L, 4, typeof(Action));
			}
			else
			{
				LuaFunction func = LuaScriptMgr.GetLuaFunction(L, 4);
				arg2 = () =>
				{
					func.Call();
				};
			}

			bool arg3 = LuaScriptMgr.GetBoolean(L, 5);
			object o = obj.AddTimer(arg0,arg1,arg2,arg3);
			LuaScriptMgr.PushVarObject(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Timer.AddTimer");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Yield(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		Timer obj = (Timer)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Timer");
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
		Action arg1 = null;
		LuaTypes funcType3 = LuaDLL.lua_type(L, 3);

		if (funcType3 != LuaTypes.LUA_TFUNCTION)
		{
			 arg1 = (Action)LuaScriptMgr.GetNetObject(L, 3, typeof(Action));
		}
		else
		{
			LuaFunction func = LuaScriptMgr.GetLuaFunction(L, 3);
			arg1 = () =>
			{
				func.Call();
			};
		}

		obj.Yield(arg0,arg1);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int WaitEndOfFrame(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Timer obj = (Timer)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Timer");
		Action arg0 = null;
		LuaTypes funcType2 = LuaDLL.lua_type(L, 2);

		if (funcType2 != LuaTypes.LUA_TFUNCTION)
		{
			 arg0 = (Action)LuaScriptMgr.GetNetObject(L, 2, typeof(Action));
		}
		else
		{
			LuaFunction func = LuaScriptMgr.GetLuaFunction(L, 2);
			arg0 = () =>
			{
				func.Call();
			};
		}

		obj.WaitEndOfFrame(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ResetTimer(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 6);
		Timer obj = (Timer)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Timer");
		object arg0 = LuaScriptMgr.GetVarObject(L, 2);
		float arg1 = (float)LuaScriptMgr.GetNumber(L, 3);
		int arg2 = (int)LuaScriptMgr.GetNumber(L, 4);
		Action arg3 = null;
		LuaTypes funcType5 = LuaDLL.lua_type(L, 5);

		if (funcType5 != LuaTypes.LUA_TFUNCTION)
		{
			 arg3 = (Action)LuaScriptMgr.GetNetObject(L, 5, typeof(Action));
		}
		else
		{
			LuaFunction func = LuaScriptMgr.GetLuaFunction(L, 5);
			arg3 = () =>
			{
				func.Call();
			};
		}

		bool arg4 = LuaScriptMgr.GetBoolean(L, 6);
		obj.ResetTimer(arg0,arg1,arg2,arg3,arg4);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int StopTimer(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Timer obj = (Timer)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Timer");
		object arg0 = LuaScriptMgr.GetVarObject(L, 2);
		obj.StopTimer(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int StopAllTimer(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Timer obj = (Timer)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Timer");
		obj.StopAllTimer();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int OnUpdate(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Timer obj = (Timer)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Timer");
		float arg0 = (float)LuaScriptMgr.GetNumber(L, 2);
		obj.OnUpdate(arg0);
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

