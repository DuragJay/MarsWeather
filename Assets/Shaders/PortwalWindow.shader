Shader "Custom/PortwalWindow"
{
    
    SubShader
    {
        Zwrite off
        ColorMask 0
        cull off
        Stencil
        {
            Ref 1
            Pass replace
        }
        Pass
        {
           
        }
    }
}
