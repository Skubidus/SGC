using System.Reflection.Metadata.Ecma335;

namespace SGCLibrary;

public static class Calculations
{
    public const double GAS_CONSTANT = 8.31446261815324;
    public const double ABSOLUTE_ZERO_CELSIUS = -273.15;

    /// <summary>
    /// Checks if a number is positive.
    /// </summary>
    /// <returns>
    /// True if the number is positive or false if it is negative.
    /// </returns>
    private static bool IsPositiveNumber(double value)
    {
        return value > 0.0;
    }

    /// <summary>
    /// Calculates the number of moles (n) using the ideal gas law.
    /// </summary>
    /// <returns>
    /// The number of moles (n) or 0, if an invalid argument has been passed in.
    /// </returns>
    public static double CalculateMoles(double P, double V, double T)
    {
        if (IsPositiveNumber(P) == false) return default;
        if (IsPositiveNumber(V) == false) return default;
        if (IsPositiveNumber(T) == false) return default;
        return (P * V) / (GAS_CONSTANT * T);
    }

    /// <summary>
    /// Calculates the volume (V) in liters (L) using the ideal gas law.
    /// </summary>
    /// <returns>
    /// The volume (V) in liters (L) or 0, if an invalid argument has been passed in.
    /// </returns>
    public static double CalculateVolume(double n, double T, double P)
    {
        if (IsPositiveNumber(n) == false) return default;
        if (IsPositiveNumber(T) == false) return default;
        if (IsPositiveNumber(P) == false) return default;
        return (n * GAS_CONSTANT * T) / P;
    }

    /// <summary>
    /// Calculates the pressure (P) in kPa using the ideal gas law.
    /// </summary>
    /// <returns>
    /// The pressure (P) in kPa or 0, if an invalid argument has been passed in.
    /// </returns>
    public static double CalculatePressure(double n, double T, double V)
    {
        if (IsPositiveNumber(n) == false) return default;
        if (IsPositiveNumber(T) == false) return default;
        if (IsPositiveNumber(V) == false) return default;
        return (n * GAS_CONSTANT * T) / V;
    }

    /// <summary>
    /// Calculates the temperature (T) in Kelvin (K) using the ideal gas law.
    /// </summary>
    /// <returns>
    /// The temperature (T) in Kelvin (K) or 0, if an invalid argument has been passed in.
    /// </returns>
    public static double CalculateTemperature(double P, double V, double n)
    {
        if (IsPositiveNumber(P) == false) return default;
        if (IsPositiveNumber(V) == false) return default;
        if (IsPositiveNumber(n) == false) return default;
        return (P * V) / (GAS_CONSTANT * n);
    }

    /// <summary>
    /// Converts Celsius to Kelvin.
    /// </summary>
    /// <returns>
    /// The temperature in Kelvin (K).
    /// </returns>
    /// <exception cref="ArgumentOutOfRangeException" />
    public static double ConvertToKelvin(double tempInCelsius)
    {
        if (tempInCelsius <= ABSOLUTE_ZERO_CELSIUS)
            throw new ArgumentOutOfRangeException(nameof(tempInCelsius), $"The value of {nameof(tempInCelsius)} cannot be <= {ABSOLUTE_ZERO_CELSIUS} (absolute zero)!");

        return tempInCelsius + 273.15;
    }

    /// <summary>
    /// Converts Kelvin to Celsius.
    /// </summary>
    /// <returns>
    /// The temperature in Celsius (C) or 0, if an invalid argument has been passed in.
    /// </returns>
    public static double ConvertToCelsius(double tempInKelvin)
    {
        if (IsPositiveNumber(tempInKelvin) == false) return default;

        return tempInKelvin - 273.15;
    }
}