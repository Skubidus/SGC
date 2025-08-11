namespace SGCUnitTest;

using SGCLibrary;

public class CalculationsTests
{
    private const double R = 8.31446261815324;

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
        double result = Calculations.CalculateMoles(P, T, V);
        result = double.Round(result, 2);

        // assert
        Assert.Equal(expectedResult, result);
    }
}
