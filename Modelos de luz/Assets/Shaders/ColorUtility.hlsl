void GetSaturation_float(float4 Color, out float Saturation)
{
    float minC = min(min(Color.r, Color.g), Color.b);
    float maxC = max(max(Color.r, Color.g), Color.b);
    Saturation = maxC > 0 ? (1 - minC) / maxC : 0;
}