namespace TemperatureConverterLibrary
{
    public static class TemperatureConverter
    {
        public static Temperature ToCelsium(Temperature temperature)
        {
            Temperature otherTemperature;
            if (temperature.UnitsScale == Scale.Celsium)
                otherTemperature = new(temperature.Value, Scale.Celsium);
            else if (temperature.UnitsScale == Scale.Kelvin)
                otherTemperature = new(temperature.Value - 273.15, Scale.Celsium);
            else
                otherTemperature = new((temperature.Value - 32) * 5 / 9, Scale.Celsium);

            return otherTemperature;
        }

        public static Temperature ToKelvin(Temperature temperature)
        {
            Temperature otherTemperature;
            if (temperature.UnitsScale == Scale.Celsium)
                otherTemperature = new(temperature.Value + 273.15, Scale.Kelvin);
            else if (temperature.UnitsScale == Scale.Kelvin)
                otherTemperature = new(temperature.Value, Scale.Kelvin);
            else
                otherTemperature = new((temperature.Value - 32) * 5 / 9 + 273.15, Scale.Kelvin);

            return otherTemperature;
        }

        public static Temperature ToFahrenheit(Temperature temperature)
        {

            Temperature otherTemperature;
            if (temperature.UnitsScale == Scale.Celsium)
                otherTemperature = new(temperature.Value * 9 / 5 + 32, Scale.Fahrenheit);
            else if (temperature.UnitsScale == Scale.Kelvin)
                otherTemperature = new((temperature.Value - 273.15) * 9 / 5 + 32, Scale.Fahrenheit);
            else
                otherTemperature = new(temperature.Value, Scale.Fahrenheit);

            return otherTemperature;
        }
    }
}
