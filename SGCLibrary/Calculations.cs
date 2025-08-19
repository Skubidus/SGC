namespace SGCLibrary;

public static class Calculations
{
    public const double GAS_CONSTANT = 8.31446261815324;

    public static double CalculateMoles(double P, double V, double T)
    {
        if (P <= 0.0)
        {
            throw new ArgumentOutOfRangeException(nameof(P), $"The value of {nameof(P)} can not be <= 0.0!");
        }

        if (V <= 0.0)
        {
            throw new ArgumentOutOfRangeException(nameof(V), $"The value of {nameof(V)} can not be <= 0.0!");
        }

        if (T <= 0.0)
        {
            throw new ArgumentOutOfRangeException(nameof(T), $"The value of {nameof(T)} can not be <= 0.0!");
        }

        return (P * V) / (GAS_CONSTANT * T);
    }

    public static double CalculateVolume(double n, double T, double P)
    {
        if (n <= 0.0)
        {
            throw new ArgumentOutOfRangeException(nameof(n), $"The nalue of {nameof(n)} can not be <= 0.0!");
        }

        if (T <= 0.0)
        {
            throw new ArgumentOutOfRangeException(nameof(T), $"The nalue of {nameof(T)} can not be <= 0.0!");
        }

        if (P <= 0.0)
        {
            throw new ArgumentOutOfRangeException(nameof(P), $"The nalue of {nameof(P)} can not be <= 0.0!");
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

    public static double CalculateTemperature(double P, double V, double n)
    {
        if (P <= 0.0)
        {
            throw new ArgumentOutOfRangeException(nameof(P), $"The nalue of {nameof(P)} can not be <= 0.0!");
        }

        if (V <= 0.0)
        {
            throw new ArgumentOutOfRangeException(nameof(V), $"The value of {nameof(V)} can not be <= 0.0!");
        }

        if (n <= 0.0)
        {
            throw new ArgumentOutOfRangeException(nameof(n), $"The nalue of {nameof(n)} can not be <= 0.0!");
        }

        return (P * V) / (GAS_CONSTANT * n);
    }

    public static double ConvertToKelvin(double tempInCelsius)
    {
        if (tempInCelsius <= -273.15)
        {
            throw new ArgumentOutOfRangeException(nameof(tempInCelsius), $"The nalue of {nameof(tempInCelsius)} can not be <= -273.15 (absolute zero)!");
        }

        return tempInCelsius + 273.15;
    }

    public static double ConvertToCelsius(double tempInKelvin)
    {
        if (tempInKelvin <= 0.0)
        {
            throw new ArgumentOutOfRangeException(nameof(tempInKelvin), $"The nalue of {nameof(tempInKelvin)} can not be <= 0.0 (absolute zero)!");
        }

        return tempInKelvin - 273.15;
    }
}