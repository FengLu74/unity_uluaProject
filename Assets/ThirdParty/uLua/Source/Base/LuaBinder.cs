using System;
using System.Collections.Generic;

public static class LuaBinder
{
	public static List<string> wrapList = new List<string>();
	public static void Bind(IntPtr L, string type = null)
	{
		if (type == null || wrapList.Contains(type)) return;
		wrapList.Add(type); type += "Wrap";
		switch (type) {
			case "AnimatorWrap": AnimatorWrap.Register(L); break;
			case "ApplicationWrap": ApplicationWrap.Register(L); break;
			case "BehaviourWrap": BehaviourWrap.Register(L); break;
			case "BoxColliderWrap": BoxColliderWrap.Register(L); break;
			case "CameraWrap": CameraWrap.Register(L); break;
			case "ColliderWrap": ColliderWrap.Register(L); break;
			case "ColorWrap": ColorWrap.Register(L); break;
			case "ComponentWrap": ComponentWrap.Register(L); break;
			case "DebugWrap": DebugWrap.Register(L); break;
			case "DelegateWrap": DelegateWrap.Register(L); break;
			case "EnumWrap": EnumWrap.Register(L); break;
			case "EventWrap": EventWrap.Register(L); break;
			case "GameObjectWrap": GameObjectWrap.Register(L); break;
			case "IEnumeratorWrap": IEnumeratorWrap.Register(L); break;
			case "InputWrap": InputWrap.Register(L); break;
			case "LuaHelperWrap": LuaHelperWrap.Register(L); break;
			case "MonoToolsWrap": MonoToolsWrap.Register(L); break;
			case "NGUITextWrap": NGUITextWrap.Register(L); break;
			case "ObjectWrap": ObjectWrap.Register(L); break;
			case "PlayerPrefsWrap": PlayerPrefsWrap.Register(L); break;
			case "RectWrap": RectWrap.Register(L); break;
			case "RenderSettingsWrap": RenderSettingsWrap.Register(L); break;
			case "ScreenWrap": ScreenWrap.Register(L); break;
			case "SpringPanelWrap": SpringPanelWrap.Register(L); break;
			case "stringWrap": stringWrap.Register(L); break;
			case "SystemInfoWrap": SystemInfoWrap.Register(L); break;
			case "System_ObjectWrap": System_ObjectWrap.Register(L); break;
			case "TextureWrap": TextureWrap.Register(L); break;
			case "TimerWrap": TimerWrap.Register(L); break;
			case "TimeWrap": TimeWrap.Register(L); break;
			case "TransformWrap": TransformWrap.Register(L); break;
			case "TweenAlphaWrap": TweenAlphaWrap.Register(L); break;
			case "TweenPositionWrap": TweenPositionWrap.Register(L); break;
			case "TweenScaleWrap": TweenScaleWrap.Register(L); break;
			case "TypeWrap": TypeWrap.Register(L); break;
			case "UIBasicSpriteWrap": UIBasicSpriteWrap.Register(L); break;
			case "UICameraWrap": UICameraWrap.Register(L); break;
			case "UICenterOnChildWrap": UICenterOnChildWrap.Register(L); break;
			case "UIDragScrollViewWrap": UIDragScrollViewWrap.Register(L); break;
			case "UIEventListenerWrap": UIEventListenerWrap.Register(L); break;
			case "UIGridWrap": UIGridWrap.Register(L); break;
			case "UIInputWrap": UIInputWrap.Register(L); break;
			case "UILabelWrap": UILabelWrap.Register(L); break;
			case "UIPanelWrap": UIPanelWrap.Register(L); break;
			case "UIPlayTweenWrap": UIPlayTweenWrap.Register(L); break;
			case "UIProgressBarWrap": UIProgressBarWrap.Register(L); break;
			case "UIRectWrap": UIRectWrap.Register(L); break;
			case "UIRootWrap": UIRootWrap.Register(L); break;
			case "UIScrollViewWrap": UIScrollViewWrap.Register(L); break;
			case "UISliderWrap": UISliderWrap.Register(L); break;
			case "UISpriteWrap": UISpriteWrap.Register(L); break;
			case "UITableWrap": UITableWrap.Register(L); break;
			case "UITextureWrap": UITextureWrap.Register(L); break;
			case "UIToggleWrap": UIToggleWrap.Register(L); break;
			case "UITweenerWrap": UITweenerWrap.Register(L); break;
			case "UIWidgetContainerWrap": UIWidgetContainerWrap.Register(L); break;
			case "UIWidgetWrap": UIWidgetWrap.Register(L); break;
			case "Vector2Wrap": Vector2Wrap.Register(L); break;
			case "Vector3Wrap": Vector3Wrap.Register(L); break;
			case "Vector4Wrap": Vector4Wrap.Register(L); break;
		}
	}
}
