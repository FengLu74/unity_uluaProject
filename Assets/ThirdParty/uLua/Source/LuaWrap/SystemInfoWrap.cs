using System;
using UnityEngine;
using LuaInterface;

public class SystemInfoWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("SupportsRenderTextureFormat", SupportsRenderTextureFormat),
			new LuaMethod("SupportsTextureFormat", SupportsTextureFormat),
			new LuaMethod("New", _CreateSystemInfo),
			new LuaMethod("GetClassType", GetClassType),
		};

		LuaField[] fields = new LuaField[]
		{
			new LuaField("unsupportedIdentifier", get_unsupportedIdentifier, null),
			new LuaField("batteryLevel", get_batteryLevel, null),
			new LuaField("batteryStatus", get_batteryStatus, null),
			new LuaField("operatingSystem", get_operatingSystem, null),
			new LuaField("operatingSystemFamily", get_operatingSystemFamily, null),
			new LuaField("processorType", get_processorType, null),
			new LuaField("processorFrequency", get_processorFrequency, null),
			new LuaField("processorCount", get_processorCount, null),
			new LuaField("systemMemorySize", get_systemMemorySize, null),
			new LuaField("graphicsMemorySize", get_graphicsMemorySize, null),
			new LuaField("graphicsDeviceName", get_graphicsDeviceName, null),
			new LuaField("graphicsDeviceVendor", get_graphicsDeviceVendor, null),
			new LuaField("graphicsDeviceID", get_graphicsDeviceID, null),
			new LuaField("graphicsDeviceVendorID", get_graphicsDeviceVendorID, null),
			new LuaField("graphicsDeviceType", get_graphicsDeviceType, null),
			new LuaField("graphicsUVStartsAtTop", get_graphicsUVStartsAtTop, null),
			new LuaField("graphicsDeviceVersion", get_graphicsDeviceVersion, null),
			new LuaField("graphicsShaderLevel", get_graphicsShaderLevel, null),
			new LuaField("graphicsMultiThreaded", get_graphicsMultiThreaded, null),
			new LuaField("supportsShadows", get_supportsShadows, null),
			new LuaField("supportsRawShadowDepthSampling", get_supportsRawShadowDepthSampling, null),
			new LuaField("supportsMotionVectors", get_supportsMotionVectors, null),
			new LuaField("supportsRenderToCubemap", get_supportsRenderToCubemap, null),
			new LuaField("supportsImageEffects", get_supportsImageEffects, null),
			new LuaField("supports3DTextures", get_supports3DTextures, null),
			new LuaField("supports2DArrayTextures", get_supports2DArrayTextures, null),
			new LuaField("supports3DRenderTextures", get_supports3DRenderTextures, null),
			new LuaField("supportsCubemapArrayTextures", get_supportsCubemapArrayTextures, null),
			new LuaField("copyTextureSupport", get_copyTextureSupport, null),
			new LuaField("supportsComputeShaders", get_supportsComputeShaders, null),
			new LuaField("supportsInstancing", get_supportsInstancing, null),
			new LuaField("supportsSparseTextures", get_supportsSparseTextures, null),
			new LuaField("supportedRenderTargetCount", get_supportedRenderTargetCount, null),
			new LuaField("usesReversedZBuffer", get_usesReversedZBuffer, null),
			new LuaField("npotSupport", get_npotSupport, null),
			new LuaField("deviceUniqueIdentifier", get_deviceUniqueIdentifier, null),
			new LuaField("deviceName", get_deviceName, null),
			new LuaField("deviceModel", get_deviceModel, null),
			new LuaField("supportsAccelerometer", get_supportsAccelerometer, null),
			new LuaField("supportsGyroscope", get_supportsGyroscope, null),
			new LuaField("supportsLocationService", get_supportsLocationService, null),
			new LuaField("supportsVibration", get_supportsVibration, null),
			new LuaField("supportsAudio", get_supportsAudio, null),
			new LuaField("deviceType", get_deviceType, null),
			new LuaField("maxTextureSize", get_maxTextureSize, null),
			new LuaField("maxCubemapSize", get_maxCubemapSize, null),
		};

		LuaScriptMgr.RegisterLib(L, "UnityEngine.SystemInfo", typeof(SystemInfo), regs, fields, typeof(object));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateSystemInfo(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			SystemInfo obj = new SystemInfo();
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: SystemInfo.New");
		}

		return 0;
	}

	static Type classType = typeof(SystemInfo);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_unsupportedIdentifier(IntPtr L)
	{
		LuaScriptMgr.Push(L, SystemInfo.unsupportedIdentifier);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_batteryLevel(IntPtr L)
	{
		LuaScriptMgr.Push(L, SystemInfo.batteryLevel);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_batteryStatus(IntPtr L)
	{
		LuaScriptMgr.Push(L, SystemInfo.batteryStatus);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_operatingSystem(IntPtr L)
	{
		LuaScriptMgr.Push(L, SystemInfo.operatingSystem);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_operatingSystemFamily(IntPtr L)
	{
		LuaScriptMgr.Push(L, SystemInfo.operatingSystemFamily);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_processorType(IntPtr L)
	{
		LuaScriptMgr.Push(L, SystemInfo.processorType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_processorFrequency(IntPtr L)
	{
		LuaScriptMgr.Push(L, SystemInfo.processorFrequency);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_processorCount(IntPtr L)
	{
		LuaScriptMgr.Push(L, SystemInfo.processorCount);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_systemMemorySize(IntPtr L)
	{
		LuaScriptMgr.Push(L, SystemInfo.systemMemorySize);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_graphicsMemorySize(IntPtr L)
	{
		LuaScriptMgr.Push(L, SystemInfo.graphicsMemorySize);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_graphicsDeviceName(IntPtr L)
	{
		LuaScriptMgr.Push(L, SystemInfo.graphicsDeviceName);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_graphicsDeviceVendor(IntPtr L)
	{
		LuaScriptMgr.Push(L, SystemInfo.graphicsDeviceVendor);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_graphicsDeviceID(IntPtr L)
	{
		LuaScriptMgr.Push(L, SystemInfo.graphicsDeviceID);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_graphicsDeviceVendorID(IntPtr L)
	{
		LuaScriptMgr.Push(L, SystemInfo.graphicsDeviceVendorID);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_graphicsDeviceType(IntPtr L)
	{
		LuaScriptMgr.Push(L, SystemInfo.graphicsDeviceType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_graphicsUVStartsAtTop(IntPtr L)
	{
		LuaScriptMgr.Push(L, SystemInfo.graphicsUVStartsAtTop);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_graphicsDeviceVersion(IntPtr L)
	{
		LuaScriptMgr.Push(L, SystemInfo.graphicsDeviceVersion);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_graphicsShaderLevel(IntPtr L)
	{
		LuaScriptMgr.Push(L, SystemInfo.graphicsShaderLevel);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_graphicsMultiThreaded(IntPtr L)
	{
		LuaScriptMgr.Push(L, SystemInfo.graphicsMultiThreaded);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_supportsShadows(IntPtr L)
	{
		LuaScriptMgr.Push(L, SystemInfo.supportsShadows);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_supportsRawShadowDepthSampling(IntPtr L)
	{
		LuaScriptMgr.Push(L, SystemInfo.supportsRawShadowDepthSampling);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_supportsMotionVectors(IntPtr L)
	{
		LuaScriptMgr.Push(L, SystemInfo.supportsMotionVectors);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_supportsRenderToCubemap(IntPtr L)
	{
		LuaScriptMgr.Push(L, SystemInfo.supportsRenderToCubemap);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_supportsImageEffects(IntPtr L)
	{
		LuaScriptMgr.Push(L, SystemInfo.supportsImageEffects);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_supports3DTextures(IntPtr L)
	{
		LuaScriptMgr.Push(L, SystemInfo.supports3DTextures);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_supports2DArrayTextures(IntPtr L)
	{
		LuaScriptMgr.Push(L, SystemInfo.supports2DArrayTextures);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_supports3DRenderTextures(IntPtr L)
	{
		LuaScriptMgr.Push(L, SystemInfo.supports3DRenderTextures);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_supportsCubemapArrayTextures(IntPtr L)
	{
		LuaScriptMgr.Push(L, SystemInfo.supportsCubemapArrayTextures);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_copyTextureSupport(IntPtr L)
	{
		LuaScriptMgr.Push(L, SystemInfo.copyTextureSupport);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_supportsComputeShaders(IntPtr L)
	{
		LuaScriptMgr.Push(L, SystemInfo.supportsComputeShaders);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_supportsInstancing(IntPtr L)
	{
		LuaScriptMgr.Push(L, SystemInfo.supportsInstancing);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_supportsSparseTextures(IntPtr L)
	{
		LuaScriptMgr.Push(L, SystemInfo.supportsSparseTextures);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_supportedRenderTargetCount(IntPtr L)
	{
		LuaScriptMgr.Push(L, SystemInfo.supportedRenderTargetCount);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_usesReversedZBuffer(IntPtr L)
	{
		LuaScriptMgr.Push(L, SystemInfo.usesReversedZBuffer);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_npotSupport(IntPtr L)
	{
		LuaScriptMgr.Push(L, SystemInfo.npotSupport);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_deviceUniqueIdentifier(IntPtr L)
	{
		LuaScriptMgr.Push(L, SystemInfo.deviceUniqueIdentifier);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_deviceName(IntPtr L)
	{
		LuaScriptMgr.Push(L, SystemInfo.deviceName);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_deviceModel(IntPtr L)
	{
		LuaScriptMgr.Push(L, SystemInfo.deviceModel);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_supportsAccelerometer(IntPtr L)
	{
		LuaScriptMgr.Push(L, SystemInfo.supportsAccelerometer);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_supportsGyroscope(IntPtr L)
	{
		LuaScriptMgr.Push(L, SystemInfo.supportsGyroscope);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_supportsLocationService(IntPtr L)
	{
		LuaScriptMgr.Push(L, SystemInfo.supportsLocationService);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_supportsVibration(IntPtr L)
	{
		LuaScriptMgr.Push(L, SystemInfo.supportsVibration);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_supportsAudio(IntPtr L)
	{
		LuaScriptMgr.Push(L, SystemInfo.supportsAudio);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_deviceType(IntPtr L)
	{
		LuaScriptMgr.Push(L, SystemInfo.deviceType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_maxTextureSize(IntPtr L)
	{
		LuaScriptMgr.Push(L, SystemInfo.maxTextureSize);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_maxCubemapSize(IntPtr L)
	{
		LuaScriptMgr.Push(L, SystemInfo.maxCubemapSize);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SupportsRenderTextureFormat(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		RenderTextureFormat arg0 = (RenderTextureFormat)LuaScriptMgr.GetNetObject(L, 1, typeof(RenderTextureFormat));
		bool o = SystemInfo.SupportsRenderTextureFormat(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SupportsTextureFormat(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		TextureFormat arg0 = (TextureFormat)LuaScriptMgr.GetNetObject(L, 1, typeof(TextureFormat));
		bool o = SystemInfo.SupportsTextureFormat(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}
}

