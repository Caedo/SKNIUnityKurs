Shader "Completed/Triplanar" {
	Properties {
		_Color ("Color", Color) = (1,1,1,1)
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
		_TopeTex("Top Texture", 2D) = "white" {}
		_Glossiness ("Smoothness", Range(0,1)) = 0.5
		_Metallic ("Metallic", Range(0,1)) = 0.0
		_TopTexSpread("Top Texture Spread", Range(0,1)) = 0.5
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200

		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surf Standard fullforwardshadows

		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 3.0

		sampler2D _MainTex;
		sampler2D _TopeTex;		

		struct Input {
			float2 uv_MainTex;
			float3 worldNormal;
			float3 worldPos;
		};

		half _Glossiness;
		half _Metallic;
		fixed4 _Color;
		float _mapPower;
		float _TopTexSpread;

		// Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
		// See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
		// #pragma instancing_options assumeuniformscaling
		UNITY_INSTANCING_BUFFER_START(Props)
			// put more per-instance properties here
		UNITY_INSTANCING_BUFFER_END(Props)

		void surf (Input IN, inout SurfaceOutputStandard o) {

			float3 worldNormal = saturate(pow(IN.worldNormal * 1.4, 4));

			float3 texX = tex2D(_MainTex, IN.worldPos.zy);
			float3 texY = tex2D(_MainTex, IN.worldPos.zx);
			float3 texZ = tex2D(_MainTex, IN.worldPos.yx);			

			float3 blend = texZ;
			blend = lerp(blend, texX, worldNormal.x);
			blend = lerp(blend, texY, worldNormal.y);		

			float3 topX = tex2D(_TopeTex, IN.worldPos.zy);
			float3 topY = tex2D(_TopeTex, IN.worldPos.zx);
			float3 topZ = tex2D(_TopeTex, IN.worldPos.yx);			

			float3 blendTop = topZ;
			blendTop = lerp(blendTop, topX, worldNormal.x);
			blendTop = lerp(blendTop, topY, worldNormal.y);

			float worldUpDot = dot(o.Normal, saturate(IN.worldNormal.y));

			blend = step(worldUpDot, _TopTexSpread) * blend;
			blendTop = step(_TopTexSpread, worldUpDot) * blendTop;
			

			fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
			o.Albedo = blend + blendTop;
			o.Metallic = _Metallic;
			o.Smoothness = _Glossiness;
			o.Alpha = c.a;
		}
		ENDCG
	}
	FallBack "Diffuse"
}
