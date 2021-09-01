using System;

namespace TemperatureConverterLibrary
{
    public class Temperature
    {
        public const double ABSOLUT_ZERO_BY_CELSIUM = -273.15,
                            ABSOLUT_ZERO_BY_FAHRENHEIT = -459.67;
        private double _temperature;
        private readonly Scale _scale = Scale.Celsium;

        public Temperature(double temperature, Scale scale)
        {
            _scale = scale;
            Value = temperature;
        }

        public Temperature(double temperature) : this(temperature, Scale.Celsium)
        { }

        public Temperature() : this(0.0, Scale.Celsium)
        { }

        public double Value
        {
            get => _temperature;
            set => SetTemperature(value);
        }

        public Scale UnitsScale => _scale;

        private void SetTemperature(double temperature)
        {
            bool temperatureIsValid = (_scale == Scale.Celsium && temperature >= ABSOLUT_ZERO_BY_CELSIUM) ||
                                      (_scale == Scale.Kelvin && temperature >= 0.0) ||
                                      (_scale == Scale.Fahrenheit && temperature >= ABSOLUT_ZERO_BY_FAHRENHEIT);
            if (temperatureIsValid)
                _temperature = temperature;
            else
                throw new ArgumentOutOfRangeException("", $"Temperature is less then absolute zero.");
        }

        public override string ToString()
        {
            string units;
            if (UnitsScale == Scale.Celsium)
                units = " °C";
            else if (UnitsScale == Scale.Kelvin)
                units = " K";
            else
                units = " °F";
            return $"{Value:n}" + units;
        }
    }
}
