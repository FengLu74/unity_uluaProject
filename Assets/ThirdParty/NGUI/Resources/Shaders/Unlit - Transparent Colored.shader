// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Unlit/Transparent Colored"
{
	Properties
	{
		_MainTex("Base (RGB), Alpha (A)", 2D) = "black" {}
		_AlphaTex("AlphaTex", 2D) = "red" {}
	}

		SubShader
	{
		LOD 200

		Tags
		{
			"Queue" = "Transparent"
			"IgnoreProjector" = "True"
			"RenderType" = "Transparent"
		}

		Pass
			{
				Cull Off
				Lighting Off
				ZWrite Off
				Fog{ Mode Off }
				Offset -1, -1
				Blend SrcAlpha OneMinusSrcAlpha

				CGPROGRAM
#pragma vertex vert
#pragma fragment frag			
#include "UnityCG.cginc"

				sampler2D _MainTex;
				sampler2D _AlphaTex;
				float4 _MainTex_ST;

				struct appdata_t
				{
					float4 vertex : POSITION;
					float2 texcoord : TEXCOORD0;
					float4 texcoord2 : TEXCOORD2;
					fixed4 color : COLOR;
					float3 normal : NORMAL;
				};

				struct v2f
				{
					float4 vertex : SV_POSITION;
					half2 texcoord : TEXCOORD0;
					float4 radialGradient : TEXCOORD2;
					fixed4 color : COLOR;
					fixed gray : TEXCOORD1;
					float3 imageEffect : NORMAL;
				};

				v2f o;

				v2f vert(appdata_t v)
				{
					o.vertex = UnityObjectToClipPos(v.vertex);
					o.texcoord = v.texcoord;
					o.radialGradient = v.texcoord2;
					o.color = v.color;
					o.gray = dot(v.color, fixed4(1, 1, 1, 0));
					o.imageEffect = v.normal;
					return o;
				}

				fixed4 frag(v2f IN) : COLOR
				{
					fixed4 col=fixed4(0,0,0,0);
					bool isNormal = IN.radialGradient[0] < 0.1;
					bool isRadialGradient = abs(IN.radialGradient[0] - 1) < 0.1;
					bool isColorGradient = abs(IN.radialGradient[0] - 2) < 0.1;
					bool isRadialClipping = abs(IN.radialGradient[0] - 3) < 0.1;


					//径向渐变处理，一般只会在第一个panel下，所以colored 1以及以后的shader中就不去修改了
					if (isRadialGradient)
					{
						col = IN.color;
						float2 spotPoint = float2(IN.radialGradient[1], IN.radialGradient[2]);
							float dist = length(float2(IN.texcoord.x, IN.texcoord.y) - spotPoint) / IN.radialGradient[3];
						col.a = lerp(0, 1, 1 - dist)*col.a;
					}
					else if (isColorGradient)
					{
						col = IN.color;
					}
					else if (isRadialClipping)
					{
						col = tex2D(_MainTex, IN.texcoord);
						if (IN.gray == 0)
						{
							col.rgb = dot(col.rgb, fixed3(.299, .587, .114)*0.6);
						}
						else
						{
							col = col * IN.color;
						}
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
					else if (isNormal)
					{
						col = tex2D(_MainTex, IN.texcoord);
						if (IN.gray == 0)
						{
							col.rgb = dot(col.rgb, fixed3(.299, .587, .114)*0.6);
						}
						else
						{
							col = col * IN.color;
						}
						//这里是为了处理以前的图集做的处理
						if (abs(tex2D(_AlphaTex, IN.texcoord).r - tex2D(_AlphaTex, IN.texcoord).g) < 0.1)
							col.a = tex2D(_AlphaTex, IN.texcoord).r * IN.color.a;
					}
					if (IN.imageEffect[0] != 1 || IN.imageEffect[1] != 1 || IN.imageEffect[2] != 1)
					{
						float avgLumR = 0.5;
						float avgLumG = 0.5;
						float avgLumB = 0.5;

						float3 LuminanceCoeff = float3(0.2125, 0.7154, 0.0721);

							float3 avgLumin = float3(avgLumR, avgLumG, avgLumB);
							float3 brtColor = col.rgb * IN.imageEffect[0];
							float intensityf = dot(brtColor, LuminanceCoeff);
						float3 intensity = float3(intensityf, intensityf, intensityf);

							float3 satColor = lerp(intensity, brtColor, IN.imageEffect[1]);

							float3 conColor = lerp(avgLumin, satColor, IN.imageEffect[2]);
							col.rgb = conColor;
					}
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
					}

					Pass
						{
							Cull Off
							Lighting Off
							ZWrite Off
							Fog{ Mode Off }
							Offset -1, -1
							ColorMask RGB
							Blend SrcAlpha OneMinusSrcAlpha
							ColorMaterial AmbientAndDiffuse

							SetTexture[_MainTex]
							{
								Combine Texture * Primary
							}
						}
				}
}
