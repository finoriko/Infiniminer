// Pixel shader extracts the brighter areas of an image.
// This is the first step in applying a bloom postprocess.

sampler TextureSampler : register(s0);

float BloomThreshold;


float4 BEPixelShader(float2 texCoord : TEXCOORD0) : COLOR0
{
    // Look up the original image color.
    float4 c = tex2D(TextureSampler, texCoord);

    // Adjust it to keep only values brighter than the specified threshold.
    float colorSum = saturate( ((c.x + c.y + c.z) / 3 - BloomThreshold) / (1 - BloomThreshold) );
    return c * colorSum;
}


technique BloomExtract
{
    pass Pass1
    {
#if SM4
		PixelShader = compile ps_4_0 BEPixelShader();
#else
		PixelShader = compile ps_2_0 BEPixelShader();
#endif
    }
}
