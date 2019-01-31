// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Unlit/Text"
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

		Cull Off
		Lighting Off
		ZWrite Off
		Offset -1, -1
		Fog { Mode Off }
		Blend SrcAlpha OneMinusSrcAlpha

		Pass
		{
			CGPROGRAM
				#pragma vertex vert
				#pragma fragment frag
				#include "UnityCG.cginc"

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
					float3 normal : NORMAL;
				};

				sampler2D _MainTex;
				float4 _MainTex_ST;

				v2f vert (appdata_t v)
				{
					v2f o;
					o.vertex = UnityObjectToClipPos(v.vertex);
					o.texcoord = v.texcoord;
					o.color = v.color;
					o.normal = v.normal;
					return o;
				}

				half4 frag (v2f i) : SV_Target
				{
					half4 col = i.color;
					col.a *= tex2D(_MainTex, i.texcoord).a;

					if (i.normal[0] != 1 || i.normal[1] != 1 || i.normal[2] != 1)
					{
						float avgLumR = 0.5;
						float avgLumG = 0.5;
						float avgLumB = 0.5;

						float3 LuminanceCoeff = float3(0.2125,0.7154,0.0721);

						float3 avgLumin = float3(avgLumR,avgLumG,avgLumB);
						float3 brtColor = col.rgb * i.normal[0];
						float intensityf = dot(brtColor,LuminanceCoeff);
						float3 intensity = float3(intensityf,intensityf,intensityf);

						float3 satColor = lerp (intensity,brtColor,i.normal[1]);

						float3 conColor = lerp (avgLumin,satColor,i.normal[2]);
						col.rgb = conColor;
					}

					return col;
				}
			ENDCG
		}
	}

	SubShader
	{
		Tags
		{
			"Queue"="Transparent"
			"IgnoreProjector"="True"
			"RenderType"="Transparent"
			"DisableBatching" = "True"
		}
		
		Lighting Off
		Cull Off
		ZTest Always
		ZWrite Off
		Fog { Mode Off }
		Blend SrcAlpha OneMinusSrcAlpha
		
		BindChannels
		{
			Bind "Color", color
			Bind "Vertex", vertex
			Bind "TexCoord", texcoord
		}
		
		Pass
		{
			SetTexture [_MainTex]
			{ 
				combine primary, texture
			}
		}
	}
}
