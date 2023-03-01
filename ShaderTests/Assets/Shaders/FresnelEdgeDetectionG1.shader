Shader "Example/FresnelEdgeDetectionG1"
{
    Properties
    { 
        _MainTex("Texture", 2D) = "white" {}
        _Color("Color", Color) = (1,1,1,1)
        _EdgeStart("Edge Start", Range(0, 1)) = 0.5
        _EdgeSmoothness("Edge Smoothness", Range(0, 1)) = 0.5
    }

    SubShader
    {
        Tags { "RenderType" = "Opaque" "RenderPipeline" = "UniversalRenderPipeline" }

        Pass
        {
            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"            

            struct Attributes
            {
                float4 positionOS   : POSITION;      
                float2 uv           : TEXCOORD0;     
                float3 normal     : NORMAL;      
            };



            struct Varyings
            {
                float4 positionHCS  : SV_POSITION;
                float2 uv           : TEXCOORD0;
                float fresnel       : TEXCOORD1;

            };    


            sampler2D _MainTex; //mostar textura en pantalla
            half4 _Color;
            float _EdgeStart;
            float _EdgeSmoothness;        


            Varyings vert(Attributes IN)
            {
                Varyings OUT;
                OUT.positionHCS = TransformObjectToHClip(IN.positionOS.xyz);
                OUT.uv = IN.uv;
                float3 ViewVector = IN.positionOS.xyz - TransformWorldToObject(_WorldSpaceCameraPos);
                OUT.fresnel = dot(-normalize(ViewVector), IN.normal);
                return OUT;
            }

            half4 frag(Varyings IN) : SV_Target
            {
                return tex2D(_MainTex, IN.uv);
            }
            ENDHLSL
        }
    }
}