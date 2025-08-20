namespace SGCLibrary;

public static class Calculations
{
    public const double GAS_CONSTANT = 8.31446261815324;
    public const double ABSOLUTE_ZERO_CELSIUS = -273.15;

    private static void ValidatePositive(string paramName, double value)
    {
        if (value <= 0.0)
            throw new ArgumentOutOfRangeException(paramName, $"The value of {paramName} cannot be <= 0.0!");
    }

    private static void ValidateAboveAbsoluteZero(string paramName, double value)
    {
        if (value <= ABSOLUTE_ZERO_CELSIUS)
            throw new ArgumentOutOfRangeException(paramName, $"The value of {paramName} cannot be <= {ABSOLUTE_ZERO_CELSIUS} (absolute zero)!");
    }

    /// <summary>
    /// Calculates the number of moles (n) using the ideal gas law.
    /// </summary>
    public static double CalculateMoles(double P, double V, double T)
    {
        ValidatePositive(nameof(P), P);
        ValidatePositive(nameof(V), V);
        ValidatePositive(nameof(T), T);
        return (P * V) / (GAS_CONSTANT * T);
    }

    /// <summary>
    /// Calculates the volume (V) using the ideal gas law.
    /// </summary>
    public static double CalculateVolume(double n, double T, double P)
    {
        ValidatePositive(nameof(n), n);
        ValidatePositive(nameof(T), T);
        ValidatePositive(nameof(P), P);
        return (n * GAS_CONSTANT * T) / P;
    }

    /// <summary>
    /// Calculates the pressure (P) using the ideal gas law.
    /// </summary>
    public static double CalculatePressure(double n, double T, double V)
    {
        ValidatePositive(nameof(n), n);
        ValidatePositive(nameof(T), T);
        ValidatePositive(nameof(V), V);
        return (n * GAS_CONSTANT * T) / V;
    }

    /// <summary>
    /// Calculates the temperature (T) using the ideal gas law.
    /// </summary>
    public static double CalculateTemperature(double P, double V, double n)
    {
        ValidatePositive(nameof(P), P);
        ValidatePositive(nameof(V), V);
        ValidatePositive(nameof(n), n);
        return (P * V) / (GAS_CONSTANT * n);
    }

    /// <summary>
    /// Converts Celsius to Kelvin.
    /// </summary>
    public static double ConvertToKelvin(double tempInCelsius)
    {
        ValidateAboveAbsoluteZero(nameof(tempInCelsius), tempInCelsius);
        return tempInCelsius + 273.15;
    }

    /// <summary>
    /// Converts Kelvin to Celsius.
    /// </summary>
    public static double ConvertToCelsius(double tempInKelvin)
    {
        ValidatePositive(nameof(tempInKelvin), tempInKelvin);
        return tempInKelvin - 273.15;
    }
}