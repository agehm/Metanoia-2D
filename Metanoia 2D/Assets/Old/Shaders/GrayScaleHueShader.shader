// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Custom/GrayScaleHue"
{
	Properties
	{
		[PerRendererData] _MainTex ("Sprite Texture", 2D) = "white" {}
		_Color ("Tint", Color) = (1,1,1,1)
		[MaterialToggle] PixelSnap ("Pixel snap", Float) = 0
		_Intensity ("Intensity", Range(0.0, 1.0)) = 0
	}

	SubShader
	{
		Tags
		{ 
			"Queue"="Transparent" 
			"IgnoreProjector"="True" 
			"RenderType"="Transparent" 
			"PreviewType"="Plane"
			"CanUseSpriteAtlas"="True"
		}

		Cull Off
		Lighting Off
		ZWrite Off
		Blend One OneMinusSrcAlpha

		Pass
		{
		CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#pragma multi_compile _ PIXELSNAP_ON
			#include "UnityCG.cginc"
			
			struct appdata_t
			{
				float4 vertex   : POSITION;
				float4 color    : COLOR;
				float2 texcoord : TEXCOORD0;
			};

			struct v2f
			{
				float4 vertex   : SV_POSITION;
				fixed4 color    : COLOR;
				float2 texcoord  : TEXCOORD0;
			};
			
			fixed4 _Color;

			v2f vert(appdata_t IN)
			{
				v2f OUT;
				OUT.vertex = UnityObjectToClipPos(IN.vertex);
				OUT.texcoord = IN.texcoord;
				OUT.color = IN.color * _Color;
				#ifdef PIXELSNAP_ON
				OUT.vertex = UnityPixelSnap (OUT.vertex);
				#endif

				return OUT;
			}

			sampler2D _MainTex;
			sampler2D _AlphaTex;
			float _AlphaSplitEnabled;
			float _Intensity;

			fixed4 SampleSpriteTexture (float2 uv)
			{
				fixed4 color = tex2D (_MainTex, uv);

			#if UNITY_TEXTURE_ALPHASPLIT_ALLOWED
							if (_AlphaSplitEnabled)
								color.a = tex2D (_AlphaTex, uv).r;
			#endif //UNITY_TEXTURE_ALPHASPLIT_ALLOWED

				return color;
			}

			//fixed4 frag(v2f IN) : SV_Target
			//{
			//	fixed4 c = SampleSpriteTexture (IN.texcoord) * IN.color;
			//	c.rgb *= c.a;
			//	return c;
			//}

			fixed4 frag(v2f IN) : SV_Target
			{
				fixed4 original = SampleSpriteTexture (IN.texcoord) * IN.color;
				fixed lum = saturate(Luminance(original.rgb));
			
				fixed4 output;
				output.rgb = lerp(original.rgb, fixed3(lum + 0.1,lum,lum), _Intensity);
				output.a = original.a;
				output.rgb *= output.a;
				return output;
			}

			//fixed4 frag (v2f_img i) : COLOR
			//{
			//	fixed4 original = tex2D(_MainTex, i.uv);
			//	fixed lum = saturate(Luminance(original.rgb));
			//
			//	fixed4 output;
			//	output.rgb = lerp(original.rgb, fixed3(lum,lum,lum), _Intensity);
			//	output.a = original.a;
			//	return output;
			//}
		ENDCG
		}
	}
}