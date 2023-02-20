Shader "ExamplesG1/SimpleColorG1"
{
    Properties
        {
			_Color ("Color", Color) = (1,1,1,1)
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
                
            };

            struct Varyings
            {
                float4 positionHCS  : SV_POSITION;
            };            

            half4 _Color;
            Varyings vert(Attributes IN)
            {
                Varyings OUT;
				OUT.positionHCS = TransformObjectToHClip(IN.positionOS);
                return OUT;
            }

            half4 frag() : SV_Target
            {
				return _Color;
            }
            ENDHLSL
        }
    }
}