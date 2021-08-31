using System;
using TemperatureConverterLibrary;

namespace TempConvertTest_App
{
    class Program
    {
        static void Main(string[] args)
        {
            Temperature temp1 = new();
            Temperature temp2 = new(33);
            Temperature temp3 = new(22, Scale.Kelvin);

            Console.WriteLine(temp1);
            Console.WriteLine(temp2);
            Console.WriteLine(temp3);
            Console.WriteLine();

            temp1 = TemperatureConverter.ToKelvin(temp1);
            Console.WriteLine(temp1);
            temp2 = TemperatureConverter.ToFahrenheit(temp2);
            Console.WriteLine(temp2);
            temp3 = TemperatureConverter.ToCelsium(temp3);
            Console.WriteLine(temp3);
            temp1 = TemperatureConverter.ToFahrenheit(temp1);
            Console.WriteLine(temp1);
        }
    }
}
