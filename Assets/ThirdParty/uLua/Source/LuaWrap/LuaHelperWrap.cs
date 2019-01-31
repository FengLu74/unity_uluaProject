using System;
using UnityEngine;
using LuaInterface;

public class LuaHelperWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("GetType", GetType),
			new LuaMethod("GetComponentInChildren", GetComponentInChildren),
			new LuaMethod("GetComponent", GetComponent),
			new LuaMethod("GetComponentsInChildren", GetComponentsInChildren),
			new LuaMethod("GetAllChild", GetAllChild),
			new LuaMethod("Action", Action),
			new LuaMethod("OnClick", OnClick),
			new LuaMethod("OnPress", OnPress),
			new LuaMethod("OnDragEnd", OnDragEnd),
			new LuaMethod("OnDragStart", OnDragStart),
			new LuaMethod("OnHover", OnHover),
			new LuaMethod("OnClickWithLuaTable", OnClickWithLuaTable),
			new LuaMethod("AddObjOnClickEvent", AddObjOnClickEvent),
			new LuaMethod("CoolDown", CoolDown),
			new LuaMethod("StopSkillCDAndMpHpCoroutines", StopSkillCDAndMpHpCoroutines),
			new LuaMethod("HpMpTweenShow", HpMpTweenShow),
			new LuaMethod("New", _CreateLuaHelper),
			new LuaMethod("GetClassType", GetClassType),
		};

		LuaScriptMgr.RegisterLib(L, "LuaHelper", regs);
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateLuaHelper(IntPtr L)
	{
		LuaDLL.luaL_error(L, "LuaHelper class does not have a constructor function");
		return 0;
	}

	static Type classType = typeof(LuaHelper);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetType(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		Type o = LuaHelper.GetType(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetComponentInChildren(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		GameObject arg0 = (GameObject)LuaScriptMgr.GetUnityObject(L, 1, typeof(GameObject));
		string arg1 = LuaScriptMgr.GetLuaString(L, 2);
		Component o = LuaHelper.GetComponentInChildren(arg0,arg1);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetComponent(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		GameObject arg0 = (GameObject)LuaScriptMgr.GetUnityObject(L, 1, typeof(GameObject));
		string arg1 = LuaScriptMgr.GetLuaString(L, 2);
		Component o = LuaHelper.GetComponent(arg0,arg1);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetComponentsInChildren(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		GameObject arg0 = (GameObject)LuaScriptMgr.GetUnityObject(L, 1, typeof(GameObject));
		string arg1 = LuaScriptMgr.GetLuaString(L, 2);
		Component[] o = LuaHelper.GetComponentsInChildren(arg0,arg1);
		LuaScriptMgr.PushArray(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetAllChild(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		GameObject arg0 = (GameObject)LuaScriptMgr.GetUnityObject(L, 1, typeof(GameObject));
		Transform[] o = LuaHelper.GetAllChild(arg0);
		LuaScriptMgr.PushArray(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Action(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		LuaFunction arg0 = LuaScriptMgr.GetLuaFunction(L, 1);
		Action o = LuaHelper.Action(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int OnClick(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		LuaFunction arg0 = LuaScriptMgr.GetLuaFunction(L, 1);
		UIEventListener.VoidDelegate o = LuaHelper.OnClick(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int OnPress(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 1)
		{
			LuaFunction arg0 = LuaScriptMgr.GetLuaFunction(L, 1);
			UIEventListener.BoolDelegate o = LuaHelper.OnPress(arg0);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 2)
		{
			LuaFunction arg0 = LuaScriptMgr.GetLuaFunction(L, 1);
			int arg1 = (int)LuaScriptMgr.GetNumber(L, 2);
			UIEventListener.BoolDelegate o = LuaHelper.OnPress(arg0,arg1);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: LuaHelper.OnPress");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int OnDragEnd(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		LuaFunction arg0 = LuaScriptMgr.GetLuaFunction(L, 1);
		UIEventListener.VoidDelegate o = LuaHelper.OnDragEnd(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int OnDragStart(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		LuaFunction arg0 = LuaScriptMgr.GetLuaFunction(L, 1);
		UIEventListener.VoidDelegate o = LuaHelper.OnDragStart(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int OnHover(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		LuaFunction arg0 = LuaScriptMgr.GetLuaFunction(L, 1);
		int arg1 = (int)LuaScriptMgr.GetNumber(L, 2);
		UIEventListener.BoolDelegate o = LuaHelper.OnHover(arg0,arg1);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int OnClickWithLuaTable(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		LuaFunction arg0 = LuaScriptMgr.GetLuaFunction(L, 1);
		LuaTable arg1 = LuaScriptMgr.GetLuaTable(L, 2);
		UIEventListener.VoidDelegate o = LuaHelper.OnClickWithLuaTable(arg0,arg1);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int AddObjOnClickEvent(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		GameObject arg0 = (GameObject)LuaScriptMgr.GetUnityObject(L, 1, typeof(GameObject));
		LuaFunction arg1 = LuaScriptMgr.GetLuaFunction(L, 2);
		LuaHelper.AddObjOnClickEvent(arg0,arg1);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int CoolDown(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 5);
		UIProgressBar arg0 = (UIProgressBar)LuaScriptMgr.GetUnityObject(L, 1, typeof(UIProgressBar));
		UILabel arg1 = (UILabel)LuaScriptMgr.GetUnityObject(L, 2, typeof(UILabel));
		BoxCollider arg2 = (BoxCollider)LuaScriptMgr.GetUnityObject(L, 3, typeof(BoxCollider));
		float arg3 = (float)LuaScriptMgr.GetNumber(L, 4);
		float arg4 = (float)LuaScriptMgr.GetNumber(L, 5);
		LuaHelper.CoolDown(arg0,arg1,arg2,arg3,arg4);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int StopSkillCDAndMpHpCoroutines(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 0);
		LuaHelper.StopSkillCDAndMpHpCoroutines();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int HpMpTweenShow(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 4);
		UIProgressBar arg0 = (UIProgressBar)LuaScriptMgr.GetUnityObject(L, 1, typeof(UIProgressBar));
		float arg1 = (float)LuaScriptMgr.GetNumber(L, 2);
		float arg2 = (float)LuaScriptMgr.GetNumber(L, 3);
		float arg3 = (float)LuaScriptMgr.GetNumber(L, 4);
		LuaHelper.HpMpTweenShow(arg0,arg1,arg2,arg3);
		return 0;
	}
}

