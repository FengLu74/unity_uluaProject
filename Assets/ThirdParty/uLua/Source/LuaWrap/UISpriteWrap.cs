using System;
using UnityEngine;
using System.Collections.Generic;
using LuaInterface;
using Object = UnityEngine.Object;

public class UISpriteWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("GetAtlasSprite", GetAtlasSprite),
			new LuaMethod("MakePixelPerfect", MakePixelPerfect),
			new LuaMethod("OnFill", OnFill),
			new LuaMethod("New", _CreateUISprite),
			new LuaMethod("GetClassType", GetClassType),
			new LuaMethod("__eq", Lua_Eq),
		};

		LuaField[] fields = new LuaField[]
		{
			new LuaField("mainTexture", get_mainTexture, set_mainTexture),
			new LuaField("material", get_material, set_material),
			new LuaField("atlas", get_atlas, set_atlas),
			new LuaField("spriteName", get_spriteName, set_spriteName),
			new LuaField("isValid", get_isValid, null),
			new LuaField("applyGradient", get_applyGradient, set_applyGradient),
			new LuaField("gradientTop", get_gradientTop, set_gradientTop),
			new LuaField("gradientBottom", get_gradientBottom, set_gradientBottom),
			new LuaField("border", get_border, null),
			new LuaField("pixelSize", get_pixelSize, null),
			new LuaField("minWidth", get_minWidth, null),
			new LuaField("minHeight", get_minHeight, null),
			new LuaField("drawingDimensions", get_drawingDimensions, null),
			new LuaField("premultipliedAlpha", get_premultipliedAlpha, null),
		};

		LuaScriptMgr.RegisterLib(L, "UISprite", typeof(UISprite), regs, fields, typeof(UIBasicSprite));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateUISprite(IntPtr L)
	{
		LuaDLL.luaL_error(L, "UISprite class does not have a constructor function");
		return 0;
	}

	static Type classType = typeof(UISprite);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_mainTexture(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		UISprite obj = (UISprite)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name mainTexture");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index mainTexture on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.mainTexture);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_material(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		UISprite obj = (UISprite)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name material");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index material on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.material);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_atlas(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		UISprite obj = (UISprite)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name atlas");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index atlas on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.atlas);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_spriteName(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		UISprite obj = (UISprite)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name spriteName");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index spriteName on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.spriteName);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_isValid(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		UISprite obj = (UISprite)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name isValid");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index isValid on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.isValid);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_applyGradient(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		UISprite obj = (UISprite)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name applyGradient");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index applyGradient on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.applyGradient);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_gradientTop(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		UISprite obj = (UISprite)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name gradientTop");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index gradientTop on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.gradientTop);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_gradientBottom(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		UISprite obj = (UISprite)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name gradientBottom");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index gradientBottom on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.gradientBottom);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_border(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		UISprite obj = (UISprite)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name border");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index border on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.border);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_pixelSize(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		UISprite obj = (UISprite)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name pixelSize");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index pixelSize on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.pixelSize);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_minWidth(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		UISprite obj = (UISprite)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name minWidth");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index minWidth on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.minWidth);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_minHeight(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		UISprite obj = (UISprite)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name minHeight");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index minHeight on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.minHeight);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_drawingDimensions(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		UISprite obj = (UISprite)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name drawingDimensions");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index drawingDimensions on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.drawingDimensions);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_premultipliedAlpha(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		UISprite obj = (UISprite)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name premultipliedAlpha");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index premultipliedAlpha on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.premultipliedAlpha);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_mainTexture(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		UISprite obj = (UISprite)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name mainTexture");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index mainTexture on a nil value");
			}
		}

		obj.mainTexture = (Texture)LuaScriptMgr.GetUnityObject(L, 3, typeof(Texture));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_material(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		UISprite obj = (UISprite)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name material");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index material on a nil value");
			}
		}

		obj.material = (Material)LuaScriptMgr.GetUnityObject(L, 3, typeof(Material));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_atlas(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		UISprite obj = (UISprite)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name atlas");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index atlas on a nil value");
			}
		}

		obj.atlas = (UIAtlas)LuaScriptMgr.GetUnityObject(L, 3, typeof(UIAtlas));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_spriteName(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		UISprite obj = (UISprite)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name spriteName");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index spriteName on a nil value");
			}
		}

		obj.spriteName = LuaScriptMgr.GetString(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_applyGradient(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		UISprite obj = (UISprite)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name applyGradient");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index applyGradient on a nil value");
			}
		}

		obj.applyGradient = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_gradientTop(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		UISprite obj = (UISprite)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name gradientTop");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index gradientTop on a nil value");
			}
		}

		obj.gradientTop = LuaScriptMgr.GetColor(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_gradientBottom(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		UISprite obj = (UISprite)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name gradientBottom");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index gradientBottom on a nil value");
			}
		}

		obj.gradientBottom = LuaScriptMgr.GetColor(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetAtlasSprite(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		UISprite obj = (UISprite)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UISprite");
		UISpriteData o = obj.GetAtlasSprite();
		LuaScriptMgr.PushObject(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int MakePixelPerfect(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		UISprite obj = (UISprite)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UISprite");
		obj.MakePixelPerfect();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int OnFill(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 4);
		UISprite obj = (UISprite)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UISprite");
		List<Vector3> arg0 = (List<Vector3>)LuaScriptMgr.GetNetObject(L, 2, typeof(List<Vector3>));
		List<Vector2> arg1 = (List<Vector2>)LuaScriptMgr.GetNetObject(L, 3, typeof(List<Vector2>));
		List<Color> arg2 = (List<Color>)LuaScriptMgr.GetNetObject(L, 4, typeof(List<Color>));
		obj.OnFill(arg0,arg1,arg2);
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

