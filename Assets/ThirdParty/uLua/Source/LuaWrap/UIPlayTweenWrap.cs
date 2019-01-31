using System;
using UnityEngine;
using System.Collections.Generic;
using LuaInterface;
using Object = UnityEngine.Object;

public class UIPlayTweenWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("Play", Play),
			new LuaMethod("New", _CreateUIPlayTween),
			new LuaMethod("GetClassType", GetClassType),
			new LuaMethod("__eq", Lua_Eq),
		};

		LuaField[] fields = new LuaField[]
		{
			new LuaField("current", get_current, set_current),
			new LuaField("tweenTarget", get_tweenTarget, set_tweenTarget),
			new LuaField("tweenGroup", get_tweenGroup, set_tweenGroup),
			new LuaField("trigger", get_trigger, set_trigger),
			new LuaField("playDirection", get_playDirection, set_playDirection),
			new LuaField("resetOnPlay", get_resetOnPlay, set_resetOnPlay),
			new LuaField("resetIfDisabled", get_resetIfDisabled, set_resetIfDisabled),
			new LuaField("ifDisabledOnPlay", get_ifDisabledOnPlay, set_ifDisabledOnPlay),
			new LuaField("disableWhenFinished", get_disableWhenFinished, set_disableWhenFinished),
			new LuaField("includeChildren", get_includeChildren, set_includeChildren),
			new LuaField("onFinished", get_onFinished, set_onFinished),
		};

		LuaScriptMgr.RegisterLib(L, "UIPlayTween", typeof(UIPlayTween), regs, fields, typeof(MonoBehaviour));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateUIPlayTween(IntPtr L)
	{
		LuaDLL.luaL_error(L, "UIPlayTween class does not have a constructor function");
		return 0;
	}

	static Type classType = typeof(UIPlayTween);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_current(IntPtr L)
	{
		LuaScriptMgr.Push(L, UIPlayTween.current);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_tweenTarget(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		UIPlayTween obj = (UIPlayTween)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name tweenTarget");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index tweenTarget on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.tweenTarget);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_tweenGroup(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		UIPlayTween obj = (UIPlayTween)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name tweenGroup");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index tweenGroup on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.tweenGroup);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_trigger(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		UIPlayTween obj = (UIPlayTween)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name trigger");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index trigger on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.trigger);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_playDirection(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		UIPlayTween obj = (UIPlayTween)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name playDirection");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index playDirection on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.playDirection);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_resetOnPlay(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		UIPlayTween obj = (UIPlayTween)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name resetOnPlay");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index resetOnPlay on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.resetOnPlay);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_resetIfDisabled(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		UIPlayTween obj = (UIPlayTween)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name resetIfDisabled");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index resetIfDisabled on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.resetIfDisabled);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_ifDisabledOnPlay(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		UIPlayTween obj = (UIPlayTween)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name ifDisabledOnPlay");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index ifDisabledOnPlay on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.ifDisabledOnPlay);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_disableWhenFinished(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		UIPlayTween obj = (UIPlayTween)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name disableWhenFinished");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index disableWhenFinished on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.disableWhenFinished);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_includeChildren(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		UIPlayTween obj = (UIPlayTween)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name includeChildren");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index includeChildren on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.includeChildren);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_onFinished(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		UIPlayTween obj = (UIPlayTween)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name onFinished");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index onFinished on a nil value");
			}
		}

		LuaScriptMgr.PushObject(L, obj.onFinished);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_current(IntPtr L)
	{
		UIPlayTween.current = (UIPlayTween)LuaScriptMgr.GetUnityObject(L, 3, typeof(UIPlayTween));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_tweenTarget(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		UIPlayTween obj = (UIPlayTween)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name tweenTarget");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index tweenTarget on a nil value");
			}
		}

		obj.tweenTarget = (GameObject)LuaScriptMgr.GetUnityObject(L, 3, typeof(GameObject));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_tweenGroup(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		UIPlayTween obj = (UIPlayTween)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name tweenGroup");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index tweenGroup on a nil value");
			}
		}

		obj.tweenGroup = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_trigger(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		UIPlayTween obj = (UIPlayTween)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name trigger");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index trigger on a nil value");
			}
		}

		obj.trigger = (AnimationOrTween.Trigger)LuaScriptMgr.GetNetObject(L, 3, typeof(AnimationOrTween.Trigger));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_playDirection(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		UIPlayTween obj = (UIPlayTween)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name playDirection");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index playDirection on a nil value");
			}
		}

		obj.playDirection = (AnimationOrTween.Direction)LuaScriptMgr.GetNetObject(L, 3, typeof(AnimationOrTween.Direction));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_resetOnPlay(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		UIPlayTween obj = (UIPlayTween)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name resetOnPlay");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index resetOnPlay on a nil value");
			}
		}

		obj.resetOnPlay = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_resetIfDisabled(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		UIPlayTween obj = (UIPlayTween)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name resetIfDisabled");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index resetIfDisabled on a nil value");
			}
		}

		obj.resetIfDisabled = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_ifDisabledOnPlay(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		UIPlayTween obj = (UIPlayTween)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name ifDisabledOnPlay");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index ifDisabledOnPlay on a nil value");
			}
		}

		obj.ifDisabledOnPlay = (AnimationOrTween.EnableCondition)LuaScriptMgr.GetNetObject(L, 3, typeof(AnimationOrTween.EnableCondition));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_disableWhenFinished(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		UIPlayTween obj = (UIPlayTween)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name disableWhenFinished");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index disableWhenFinished on a nil value");
			}
		}

		obj.disableWhenFinished = (AnimationOrTween.DisableCondition)LuaScriptMgr.GetNetObject(L, 3, typeof(AnimationOrTween.DisableCondition));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_includeChildren(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		UIPlayTween obj = (UIPlayTween)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name includeChildren");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index includeChildren on a nil value");
			}
		}

		obj.includeChildren = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_onFinished(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		UIPlayTween obj = (UIPlayTween)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name onFinished");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index onFinished on a nil value");
			}
		}

		obj.onFinished = (List<EventDelegate>)LuaScriptMgr.GetNetObject(L, 3, typeof(List<EventDelegate>));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Play(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		UIPlayTween obj = (UIPlayTween)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UIPlayTween");
		bool arg0 = LuaScriptMgr.GetBoolean(L, 2);
		obj.Play(arg0);
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

