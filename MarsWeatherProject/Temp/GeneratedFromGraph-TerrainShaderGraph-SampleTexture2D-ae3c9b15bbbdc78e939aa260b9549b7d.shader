Shader "Sample Texture 2D"
    {
        Properties
        {
            [NoScaleOffset]Texture2D_93CF949F("ColorMap_Texture2D", 2D) = "white" {}
            [NoScaleOffset]Texture2D_8E051B0E("NormMap_Texture2D", 2D) = "bump" {}
            [NoScaleOffset]Texture2D_A99B2965("ColorSoil_Texture2D", 2D) = "white" {}
            [NoScaleOffset]Texture2D_7486C89E("NormSoil_Texture2D", 2D) = "bump" {}
            [NoScaleOffset]Texture2D_A5ABD68("SpecSoil_Texture2D", 2D) = "white" {}
        }
        SubShader
        {
            Tags
            {
                // RenderPipeline: <None>
                "RenderType"="Opaque"
                "Queue"="Geometry"
            }
            Pass
            {
                // Name: <None>
                Tags
                {
                    // LightMode: <None>
                }
    
                // Render State
                // RenderState: <None>
    
                // Debug
                // <None>
    
                // --------------------------------------------------
                // Pass
    
                HLSLPROGRAM
    
                // Pragmas
                #pragma vertex vert
                #pragma fragment frag
    
                // DotsInstancingOptions: <None>
                // HybridV1InjectedBuiltinProperties: <None>
    
                // Keywords
                // PassKeywords: <None>
                // GraphKeywords: <None>
    
                // Defines
                #define ATTRIBUTES_NEED_TEXCOORD0
                #define VARYINGS_NEED_TEXCOORD0
                /* WARNING: $splice Could not find named fragment 'PassInstancing' */
                #define SHADERPASS SHADERPASS_PREVIEW
                #define SHADERGRAPH_PREVIEW
                /* WARNING: $splice Could not find named fragment 'DotsInstancingVars' */
    
                // Includes
                #include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Common.hlsl"
                #include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Packing.hlsl"
                #include "Packages/com.unity.render-pipelines.core/ShaderLibrary/TextureStack.hlsl"
                #include "Packages/com.unity.render-pipelines.core/ShaderLibrary/NormalSurfaceGradient.hlsl"
                #include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Color.hlsl"
                #include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Texture.hlsl"
                #include "Packages/com.unity.render-pipelines.core/ShaderLibrary/UnityInstancing.hlsl"
                #include "Packages/com.unity.render-pipelines.core/ShaderLibrary/EntityLighting.hlsl"
                #include "Packages/com.unity.shadergraph/ShaderGraphLibrary/ShaderVariables.hlsl"
                #include "Packages/com.unity.shadergraph/ShaderGraphLibrary/ShaderVariablesFunctions.hlsl"
                #include "Packages/com.unity.shadergraph/ShaderGraphLibrary/Functions.hlsl"
    
                // --------------------------------------------------
                // Structs and Packing
    
                struct Attributes
                {
                    float3 positionOS : POSITION;
                    float4 uv0 : TEXCOORD0;
                    #if UNITY_ANY_INSTANCING_ENABLED
                    uint instanceID : INSTANCEID_SEMANTIC;
                    #endif
                };
                struct Varyings
                {
                    float4 positionCS : SV_POSITION;
                    float4 texCoord0;
                    #if UNITY_ANY_INSTANCING_ENABLED
                    uint instanceID : CUSTOM_INSTANCE_ID;
                    #endif
                    #if defined(SHADER_STAGE_FRAGMENT) && defined(VARYINGS_NEED_CULLFACE)
                    FRONT_FACE_TYPE cullFace : FRONT_FACE_SEMANTIC;
                    #endif
                };
                struct SurfaceDescriptionInputs
                {
                    float4 uv0;
                };
                struct VertexDescriptionInputs
                {
                };
                struct PackedVaryings
                {
                    float4 positionCS : SV_POSITION;
                    float4 interp0 : TEXCOORD0;
                    #if UNITY_ANY_INSTANCING_ENABLED
                    uint instanceID : CUSTOM_INSTANCE_ID;
                    #endif
                    #if defined(SHADER_STAGE_FRAGMENT) && defined(VARYINGS_NEED_CULLFACE)
                    FRONT_FACE_TYPE cullFace : FRONT_FACE_SEMANTIC;
                    #endif
                };
    
                PackedVaryings PackVaryings (Varyings input)
                {
                    PackedVaryings output;
                    output.positionCS = input.positionCS;
                    output.interp0.xyzw =  input.texCoord0;
                    #if UNITY_ANY_INSTANCING_ENABLED
                    output.instanceID = input.instanceID;
                    #endif
                    #if defined(SHADER_STAGE_FRAGMENT) && defined(VARYINGS_NEED_CULLFACE)
                    output.cullFace = input.cullFace;
                    #endif
                    return output;
                }
                Varyings UnpackVaryings (PackedVaryings input)
                {
                    Varyings output;
                    output.positionCS = input.positionCS;
                    output.texCoord0 = input.interp0.xyzw;
                    #if UNITY_ANY_INSTANCING_ENABLED
                    output.instanceID = input.instanceID;
                    #endif
                    #if defined(SHADER_STAGE_FRAGMENT) && defined(VARYINGS_NEED_CULLFACE)
                    output.cullFace = input.cullFace;
                    #endif
                    return output;
                }
    
                // --------------------------------------------------
                // Graph
    
                // Graph Properties
                CBUFFER_START(UnityPerMaterial)
                float4 Texture2D_93CF949F_TexelSize;
                float4 Texture2D_8E051B0E_TexelSize;
                float4 Texture2D_A99B2965_TexelSize;
                float4 Texture2D_7486C89E_TexelSize;
                float4 Texture2D_A5ABD68_TexelSize;
                CBUFFER_END
                
                // Object and Global properties
                SAMPLER(SamplerState_Linear_Repeat);
                TEXTURE2D(Texture2D_93CF949F);
                SAMPLER(samplerTexture2D_93CF949F);
                TEXTURE2D(Texture2D_8E051B0E);
                SAMPLER(samplerTexture2D_8E051B0E);
                TEXTURE2D(Texture2D_A99B2965);
                SAMPLER(samplerTexture2D_A99B2965);
                TEXTURE2D(Texture2D_7486C89E);
                SAMPLER(samplerTexture2D_7486C89E);
                TEXTURE2D(Texture2D_A5ABD68);
                SAMPLER(samplerTexture2D_A5ABD68);
    
                // Graph Functions
                // GraphFunctions: <None>
    
                // Graph Vertex
                // GraphVertex: <None>
    
                // Graph Pixel
                struct SurfaceDescription
                {
                    float4 Out;
                };
                
                SurfaceDescription SurfaceDescriptionFunction(SurfaceDescriptionInputs IN)
                {
                    SurfaceDescription surface = (SurfaceDescription)0;
                    UnityTexture2D _Property_0e4659a63ce99a868dd5de1620e0aca1_Out_0 = UnityBuildTexture2DStructNoScale(Texture2D_93CF949F);
                    float4 _SampleTexture2D_ae3c9b15bbbdc78e939aa260b9549b7d_RGBA_0 = SAMPLE_TEXTURE2D(_Property_0e4659a63ce99a868dd5de1620e0aca1_Out_0.tex, _Property_0e4659a63ce99a868dd5de1620e0aca1_Out_0.samplerstate, IN.uv0.xy);
                    float _SampleTexture2D_ae3c9b15bbbdc78e939aa260b9549b7d_R_4 = _SampleTexture2D_ae3c9b15bbbdc78e939aa260b9549b7d_RGBA_0.r;
                    float _SampleTexture2D_ae3c9b15bbbdc78e939aa260b9549b7d_G_5 = _SampleTexture2D_ae3c9b15bbbdc78e939aa260b9549b7d_RGBA_0.g;
                    float _SampleTexture2D_ae3c9b15bbbdc78e939aa260b9549b7d_B_6 = _SampleTexture2D_ae3c9b15bbbdc78e939aa260b9549b7d_RGBA_0.b;
                    float _SampleTexture2D_ae3c9b15bbbdc78e939aa260b9549b7d_A_7 = _SampleTexture2D_ae3c9b15bbbdc78e939aa260b9549b7d_RGBA_0.a;
                    surface.Out = all(isfinite(_SampleTexture2D_ae3c9b15bbbdc78e939aa260b9549b7d_RGBA_0)) ? half4(_SampleTexture2D_ae3c9b15bbbdc78e939aa260b9549b7d_RGBA_0.x, _SampleTexture2D_ae3c9b15bbbdc78e939aa260b9549b7d_RGBA_0.y, _SampleTexture2D_ae3c9b15bbbdc78e939aa260b9549b7d_RGBA_0.z, 1.0) : float4(1.0f, 0.0f, 1.0f, 1.0f);
                    return surface;
                }
    
                // --------------------------------------------------
                // Build Graph Inputs
    
                SurfaceDescriptionInputs BuildSurfaceDescriptionInputs(Varyings input)
                {
                    SurfaceDescriptionInputs output;
                    ZERO_INITIALIZE(SurfaceDescriptionInputs, output);
                
                
                
                
                
                    output.uv0 =                         input.texCoord0;
                #if defined(SHADER_STAGE_FRAGMENT) && defined(VARYINGS_NEED_CULLFACE)
                #define BUILD_SURFACE_DESCRIPTION_INPUTS_OUTPUT_FACESIGN output.FaceSign =                    IS_FRONT_VFACE(input.cullFace, true, false);
                #else
                #define BUILD_SURFACE_DESCRIPTION_INPUTS_OUTPUT_FACESIGN
                #endif
                #undef BUILD_SURFACE_DESCRIPTION_INPUTS_OUTPUT_FACESIGN
                
                    return output;
                }
                
    
                // --------------------------------------------------
                // Main
    
                #include "Packages/com.unity.shadergraph/ShaderGraphLibrary/PreviewVaryings.hlsl"
                #include "Packages/com.unity.shadergraph/ShaderGraphLibrary/PreviewPass.hlsl"
    
                ENDHLSL
            }
        }
        FallBack "Hidden/Shader Graph/FallbackError"
    }