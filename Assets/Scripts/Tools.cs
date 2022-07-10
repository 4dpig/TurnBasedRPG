using System;

[System.Serializable]
public struct ObjectText
{
    public bool isPlayer;
    public string text;
}

public class FloatTools
{
    public const float PRECISION = 1e-6f;

    public static bool IsZero(float number)
    {
        return Math.Abs(number) <= PRECISION;
    }
    
    public static bool IsNotZero(float number)
    {
        return Math.Abs(number) > PRECISION;
    }
    
    public static bool equals(float a, float b)
    {
        return Math.Abs(a - b) <= PRECISION;
    }
    
    public static bool notEquals(float a, float b)
    {
        return Math.Abs(a - b) > PRECISION;
    }
}