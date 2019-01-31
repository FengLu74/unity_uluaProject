// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Hidden/Unlit/Transparent Colored 1"
{
	Properties
	{
		_MainTex ("Base (RGB), Alpha (A)", 2D) = "black" {}
		_AlphaTex("AlphaTex",2D) = "red" {}
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
			sampler2D _AlphaTex;
			float4 _ClipRange0 = float4(0.0, 0.0, 1.0, 1.0);
			float2 _ClipArgs0 = float2(1000.0, 1000.0);

			struct appdata_t
			{
				float4 vertex : POSITION;
				half4 color : COLOR;
				float2 texcoord : TEXCOORD0;
				float4 texcoord2 : TEXCOORD2;
				float3 normal : NORMAL;
			};

			struct v2f
			{
				float4 vertex : SV_POSITION;
				half4 color : COLOR;
				float2 texcoord : TEXCOORD0;
				float2 worldPos : TEXCOORD1;
				float4 radialGradient : TEXCOORD2;
				float3 normal : NORMAL;
			};

			v2f o;

			v2f vert (appdata_t v)
			{
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.color = v.color;
				o.texcoord = v.texcoord;
				o.radialGradient = v.texcoord2;
				o.worldPos = v.vertex.xy * _ClipRange0.zw + _ClipRange0.xy;
				o.normal = v.normal;
				return o;
			}

			half4 frag (v2f IN) : SV_Target
			{
				// Softness factor
				half4 col=half4(0,0,0,0);
				float2 factor = (float2(1.0, 1.0) - abs(IN.worldPos)) * _ClipArgs0;
				
				if (IN.radialGradient[0] == 1)
				{
					col = IN.color;
					float2 spotPoint = float2(IN.radialGradient[1], IN.radialGradient[2]);
						float dist = length(float2(IN.texcoord.x, IN.texcoord.y) - spotPoint) / IN.radialGradient[3];
					col.a = lerp(0, 1, 1 - dist);
				}
				else if (IN.radialGradient[0] == 2)
				{
					col = IN.color;
				}
				else if (IN.radialGradient[0] == 3)
				{
					// Sample the texture
					col = tex2D(_MainTex, IN.texcoord);
					col = col * IN.color;
					//这里是为了处理以前的图集做的处理
					if (abs(tex2D(_AlphaTex, IN.texcoord).r - tex2D(_AlphaTex, IN.texcoord).g) < 0.1)
						col.a = tex2D(_AlphaTex, IN.texcoord).r * IN.color.a;

					float radius = IN.radialGradient[3];
					float dx = IN.texcoord.x - IN.radialGradient[1];
					float dy = IN.texcoord.y - IN.radialGradient[2];
					float d = dx * dx + dy * dy;
					float ratio = d / (radius * radius);
					if (ratio > 1)
					{
						if (ratio < 1.5){
							float t = (1.5 - ratio) / 0.5;
							t = (t * 10000 - 9500) / 500;
							col.a = col.a * lerp(0, 1, t);
						}
						else
						{
							col.a = 0;
						}
					}
				}
				else if (IN.radialGradient[0] == 0)
				{
					// Sample the texture
					col = tex2D(_MainTex, IN.texcoord);
					col = col * IN.color;
					//这里是为了处理以前的图集做的处理
					if (abs(tex2D(_AlphaTex, IN.texcoord).r - tex2D(_AlphaTex, IN.texcoord).g) < 0.1)
						col.a = tex2D(_AlphaTex, IN.texcoord).r * IN.color.a;
				} 
				if (IN.normal[0] != 1 || IN.normal[1] != 1 || IN.normal[2] != 1)
				{
					float avgLumR = 0.5;
					float avgLumG = 0.5;
					float avgLumB = 0.5;

					float3 LuminanceCoeff = float3(0.2125, 0.7154, 0.0721);

						float3 avgLumin = float3(avgLumR, avgLumG, avgLumB);
						float3 brtColor = col.rgb * IN.normal[0];
						float intensityf = dot(brtColor, LuminanceCoeff);
					float3 intensity = float3(intensityf, intensityf, intensityf);

						float3 satColor = lerp(intensity, brtColor, IN.normal[1]);

						float3 conColor = lerp(avgLumin, satColor, IN.normal[2]);
						col.rgb = conColor;
				}
				col.a *= clamp( min(factor.x, factor.y), 0.0, 1.0);
				return col;
			}
			ENDCG
		}
	}
	
	SubShader
	{
		LOD 100

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
			Fog { Mode Off }
			//ColorMask RGB
			Blend SrcAlpha OneMinusSrcAlpha
			ColorMaterial AmbientAndDiffuse
			
			SetTexture [_MainTex]
			{
				Combine Texture * Primary
			}
		}
	}
}
