using System;

namespace TemperatureConverterLibrary
{
    public class Temperature
    {
        private double _temperature;
        private readonly Scale _scale = Scale.Celsium;

        public Temperature(double temperature, Scale scale)
        {
            _scale = scale;
            SetTemperature(temperature);
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
            bool temperatureIsValid = (_scale == Scale.Celsium && temperature >= -273.15) ||
                                      (_scale == Scale.Kelvin && temperature >= 0.0) ||
                                      (_scale == Scale.Fahrenheit && temperature >= -459.67);
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
