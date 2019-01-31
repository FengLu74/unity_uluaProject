// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Hidden/Unlit/Text 1" 
{
	Properties
	{
		_MainTex ("Alpha (A)", 2D) = "white" {}
	}

	SubShader
	{
		LOD 200

		Tags
		{
			"Queue" = "Transparent"
			"IgnoreProjector" = "True"
			"RenderType" = "Transparent"
			"DisableBatching" = "True"
		}
		
		Pass
		{
			Cull Off
			Lighting Off
			ZWrite Off
			Offset -1, -1
			Fog { Mode Off }
			//ColorMask RGB
			Blend SrcAlpha OneMinusSrcAlpha

			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag

			#include "UnityCG.cginc"

			sampler2D _MainTex;
			float4 _ClipRange0 = float4(0.0, 0.0, 1.0, 1.0);
			float2 _ClipArgs0 = float2(1000.0, 1000.0);

			struct appdata_t
			{
				float4 vertex : POSITION;
				half4 color : COLOR;
				float2 texcoord : TEXCOORD0;
				float3 normal : NORMAL;
			};

			struct v2f
			{
				float4 vertex : SV_POSITION;
				half4 color : COLOR;
				float2 texcoord : TEXCOORD0;
				float2 worldPos : TEXCOORD1;
				float3 normal : NORMAL;
			};

			v2f vert (appdata_t v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.color = v.color;
				o.texcoord = v.texcoord;
				o.worldPos = v.vertex.xy * _ClipRange0.zw + _ClipRange0.xy;
				o.normal = v.normal;
				return o;
			}

			half4 frag (v2f IN) : SV_Target
			{
				// Softness factor
				float2 factor = (float2(1.0, 1.0) - abs(IN.worldPos)) * _ClipArgs0;
			
				// Sample the texture
				half4 col = IN.color;

				if (IN.normal[0] != 1 || IN.normal[1] != 1 || IN.normal[2] != 1)
				{
					float avgLumR = 0.5;
					float avgLumG = 0.5;
					float avgLumB = 0.5;

					float3 LuminanceCoeff = float3(0.2125,0.7154,0.0721);

					float3 avgLumin = float3(avgLumR,avgLumG,avgLumB);
					float3 brtColor = col.rgb * IN.normal[0];
					float intensityf = dot(brtColor,LuminanceCoeff);
					float3 intensity = float3(intensityf,intensityf,intensityf);

					float3 satColor = lerp (intensity,brtColor,IN.normal[1]);

					float3 conColor = lerp (avgLumin,satColor,IN.normal[2]);
					col.rgb = conColor;
				}

				col.a *= tex2D(_MainTex, IN.texcoord).a;
				col.a *= clamp( min(factor.x, factor.y), 0.0, 1.0);

				return col;
			}
			ENDCG
		}
	}
	Fallback "Unlit/Text"
}
