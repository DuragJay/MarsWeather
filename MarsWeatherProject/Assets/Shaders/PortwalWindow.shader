Shader "Custom/PortwalWindow"
{
    
    SubShader
    {
Zwrite off
ColorMask 0
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
