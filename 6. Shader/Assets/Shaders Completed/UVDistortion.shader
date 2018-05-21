Shader "Completed/UVDistortion"
{
	Properties
	{
		_MainTex ("Main Texture", 2D) = "white" {}
		_Tint("Tint Color", Color) = (1,1,1,1)
		_NoiseTex("Noise Texture", 2D) = "white" {}
		_Intensity("Color Instensity", float) = 1
		_DistrStr("Distortion Strength", Range(0,1)) = 1
		_Mask("Mask", 2D) = "white" {}
	}
	SubShader
	{
		Tags { "RenderType"="Transparent" }
		LOD 100

		Blend One One

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				float4 vertex : SV_POSITION;
			};

			sampler2D _MainTex;
			sampler2D _NoiseTex;
			sampler2D _Mask;
			float4 _MainTex_ST;

			float _Intensity;
			fixed4 _Tint;
			float _DistrStr;
			
			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = TRANSFORM_TEX(v.uv, _MainTex);
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
				// sample the texture
				float2 distrUV = float2(_Time.x, _Time.x);
				float distr = tex2D(_NoiseTex, i.uv + distrUV).r * _DistrStr;
				float mask = tex2D(_Mask, i.uv).r;
				fixed4 col = tex2D(_MainTex, i.uv + distr) * _Tint * _Intensity * mask;
				return col;
			}
			ENDCG
		}
	}
}
