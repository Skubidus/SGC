namespace SGCLibrary;

public static class Calculations
{
    public const double GAS_CONSTANT = 8.31446261815324;

    public static double CalculateMoles(double P, double T, double V)
    {
        if (P <= 0.0)
        {
            throw new ArgumentOutOfRangeException(nameof(P), $"The value of {nameof(P)} can not be <= 0.0!");
        }

        if (T <= 0.0)
        {
            throw new ArgumentOutOfRangeException(nameof(T), $"The value of {nameof(T)} can not be <= 0.0!");
        }

        if (V <= 0.0)
        {
            throw new ArgumentOutOfRangeException(nameof(V), $"The value of {nameof(V)} can not be <= 0.0!");
        }

        return (V * P) / (GAS_CONSTANT * T);
    }

    public static double CalculateVolume(double n, double P, double T)
    {
        if (n <= 0.0)
        {
            throw new ArgumentOutOfRangeException(nameof(n), $"The nalue of {nameof(n)} can not be <= 0.0!");
        }

        if (P <= 0.0)
        {
            throw new ArgumentOutOfRangeException(nameof(P), $"The nalue of {nameof(P)} can not be <= 0.0!");
        }

        if (T <= 0.0)
        {
            throw new ArgumentOutOfRangeException(nameof(T), $"The nalue of {nameof(T)} can not be <= 0.0!");
        }

        return (n * GAS_CONSTANT * T) / P;
    }

    public static double CalculatePressure(double n, double T, double V)
    {
        if (n <= 0.0)
        {
            throw new ArgumentOutOfRangeException(nameof(n), $"The nalue of {nameof(n)} can not be <= 0.0!");
        }

        if (T <= 0.0)
        {
            throw new ArgumentOutOfRangeException(nameof(T), $"The nalue of {nameof(T)} can not be <= 0.0!");
        }

        if (V <= 0.0)
        {
            throw new ArgumentOutOfRangeException(nameof(V), $"The value of {nameof(V)} can not be <= 0.0!");
        }

        return (n * GAS_CONSTANT * T) / V;
    }

    public static double CalculateTemperature(double n, double P, double V)
    {
        if (n <= 0.0)
        {
            throw new ArgumentOutOfRangeException(nameof(n), $"The nalue of {nameof(n)} can not be <= 0.0!");
        }

        if (P <= 0.0)
        {
            throw new ArgumentOutOfRangeException(nameof(P), $"The nalue of {nameof(P)} can not be <= 0.0!");
        }

        if (V <= 0.0)
        {
            throw new ArgumentOutOfRangeException(nameof(V), $"The value of {nameof(V)} can not be <= 0.0!");
        }

        return (P * V) / (n * GAS_CONSTANT);
    }
}