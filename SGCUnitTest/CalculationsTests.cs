namespace SGCUnitTest;

using SGCLibrary;

using System.Transactions;

public class CalculationsTests
{
    private const double R = 8.31446261815324;

    #region CalculateMoles Tests
    [Fact]
    // n = (P * V) / (R * T)
    public void Test_CalculateMoles()
    {
        // arrange
        double P = 8000.0;
        double V = 6000.0;
        double T = 293.15;
        double expectedResult = 19693.24;

        // act
        double result = Calculations.CalculateMoles(P, V, T);
        result = double.Round(result, 2);

        // assert
        Assert.Equal(expectedResult, result);
    }

    [Theory]
    [InlineData(8000.0, 6000.0, 293.15, 19693.24)]
    [InlineData(8000.0, 6000.0, 0.01, 577307304.21)]
    [InlineData(40000.0, 64.0, 273.15, 1127.21)]
    public void Test_CalculateMoles_Expect_Valid_Results(double P, double V, double T, double expectedResult)
    {
        // act
        double result = Calculations.CalculateMoles(P, V, T);
        result = double.Round(result, 2);

        // assert
        Assert.Equal(expectedResult, result);
    }

    [Theory]
    [InlineData(0.0, 6000.0, 293.15)]
    [InlineData(-1.0, 6000.0, 293.15)]
    [InlineData(8000.0, 0.0, 293.15)]
    [InlineData(8000.0, -0.0, 293.15)]
    [InlineData(8000.0, 6000.0, 0.0)]
    [InlineData(8000.0, 6000.0, -0.0)]
    public void Test_CalculateMoles_Expect_ArgumentOutOfRangeException(double P, double V, double T)
    {
        // act + assert
        Assert.Throws<ArgumentOutOfRangeException>(() => Calculations.CalculateMoles(P, V, T));
    }
    #endregion

    #region CalculateVolume Tests
    // V = (n * R * T) / P
    [Fact]
    public void Test_CalculateVolume()
    {
        // arrange
        double n = 2000.0;
        double T = 293.15;
        double P = 8000.0;
        double expectedResult = 609.35;

        // act
        double result = Calculations.CalculateVolume(n, T, P);
        result = double.Round(result, 2);

        // assert
        Assert.Equal(expectedResult, result);
    }

    [Theory]
    [InlineData(2000.0, 293.15, 8000.0, 609.35)]
    [InlineData(20.0, 293.15, 8000.0, 6.09)]
    [InlineData(2000.0, 493.15, 8000.0, 1025.07)]
    [InlineData(2000.0, 293.15, 500.0, 9749.54)]
    public void Test_CalculateVolume_Expect_Valid_Results(double n, double T, double P, double expectedResult)
    {
        // act
        double result = Calculations.CalculateVolume(n, T, P);
        result = double.Round(result, 2);

        // assert
        Assert.Equal(expectedResult, result);
    }

    [Theory]
    [InlineData(0.0, 293.15, 8000.0)]
    [InlineData(-1.0, 293.15, 8000.0)]
    [InlineData(2000.0, 0.0, 8000.0)]
    [InlineData(2000.0, -1.0, 8000.0)]
    [InlineData(2000.0, 293.15, 0.0)]
    [InlineData(2000.0, 293.15, -1.0)]
    public void Test_CalculateVolume_Expect_ArgumentOutOfRangeException(double n, double T, double P)
    {
        // act + assert
        Assert.Throws<ArgumentOutOfRangeException>(() => Calculations.CalculateVolume(n, T, P));
    }
    #endregion

    #region CalculatePressure Tests
    // P = (n * R * T) / V
    [Fact]
    public void Test_CalculatePressure()
    {
        // arrange
        double n = 2000.0;
        double T = 293.15;
        double V = 6000.0;
        double expectedResult = 812.46;

        // act
        double result = Calculations.CalculatePressure(n, T, V);
        result = double.Round(result, 2);

        // assert
        Assert.Equal(expectedResult, result);
    }

    [Theory]
    [InlineData(2000.0, 293.15, 6000.0, 812.46)]
    [InlineData(20.0, 293.15, 6000.0, 8.12)]
    [InlineData(2000.0, 493.15, 6000.0, 1366.76)]
    [InlineData(2000.0, 193.15, 6000.0, 535.31)]
    [InlineData(2000.0, 293.15, 600.0, 8124.62)]
    public void Test_CalculatePressure_Expect_Valid_Results(double n, double T, double V, double expectedResult)
    {
        // act
        double result = Calculations.CalculatePressure(n, T, V);
        result = double.Round(result, 2);

        // assert
        Assert.Equal(expectedResult, result);
    }

    [Theory]
    [InlineData(0.0, 293.15, 6000.0)]
    [InlineData(-1.0, 293.15, 6000.0)]
    [InlineData(2000.0, 0.0, 6000.0)]
    [InlineData(2000.0, -1.0, 6000.0)]
    [InlineData(2000.0, 293.15, 0.0)]
    [InlineData(2000.0, 293.15, -1.0)]
    public void Test_CalculatePressure_Expect_ArgumentOutOfRangeException(double n, double T, double V)
    {
        // act + assert

        Assert.Throws<ArgumentOutOfRangeException>(() => Calculations.CalculatePressure(n, T, V));
    }
    #endregion

    #region CalculateTemperature Tests
    // T = (P * V) / (R * n)
    [Fact]
    public void Test_CalculateTemperature()
    {
        // arrange
        double P = 8000.0;
        double V = 6000.0;
        double n = 2000.0;
        double expectedResult = 2886.54;

        // act
        double result = Calculations.CalculateTemperature(P, V, n);
        result = double.Round(result, 2);

        // assert
        Assert.Equal(expectedResult, result);
    }

    [Theory]
    [InlineData(8000.0, 6000.0, 2000.0, 2886.54)]
    [InlineData(80.0, 6000.0, 2000.0, 28.87)]
    [InlineData(8000.0, 60.0, 2000.0, 28.87)]
    [InlineData(8000.0, 6000.0, 20.0, 288653.65)]
    public void Test_CalculateTemperature_Expect_Valid_Results(double P, double V, double n, double expectedResult)
    {
        // act
        double result = Calculations.CalculateTemperature(P, V, n);
        result = double.Round(result, 2);

        // assert
        Assert.Equal(expectedResult, result);
    }

    [Theory]
    [InlineData(0.0, 6000.0, 2000.0)]
    [InlineData(-1.0, 6000.0, 2000.0)]
    [InlineData(8000.0, 0.0, 2000.0)]
    [InlineData(8000.0, -1.0, 2000.0)]
    [InlineData(8000.0, 6000.0, 0.0)]
    [InlineData(8000.0, 6000.0, -1.0)]
    public void Test_CalculateTemperature_Expect_ArgumentOutOfRangeException(double P, double V, double n)
    {
        // act + assert
        Assert.Throws<ArgumentOutOfRangeException>(() => Calculations.CalculateTemperature(P, V, n));
    }
    #endregion
}
