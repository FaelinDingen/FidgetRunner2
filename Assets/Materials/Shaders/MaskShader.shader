Shader "Custom/Mask"
{
	SubShader{
		tags{ "Queue" = "Transparent+1"}

		Pass{
		Blend Zero One
	}
	}
}