using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * Challenge 2
Write a class called WeatherData
This class should store data for the current weather conditions. The data should include properties for

•	temperature
•	humidity
•	scale

The class should allow the user to set the current temperature to be anywhere between -60 or +60 Celsius (-76 and 140 Fahrenheit). Should a temperature of higher or lower than this value be set the class should generate a message that states that a reading mistake must have been made since the value seems unrealistic. 
Humidity values should be allowed between 0% and 100%. 
The scale attribute should accept either ’C’ or ’F’ as its value. 
The class should have a method called Convert(). When the method is called the current scale should be changed from F to C or from C to F. The formula to convert between these values are Celsius = (Fahrenheit – 32) 5/9 Fahrenheit = (Celsius 9/5) + 32. 
Add any code you deem necessary to ensure the data is robust.

Test the class using your own code.

 * */
namespace cSharpPrimerSkil
{
    internal class WeatherClass
    {
        private int _temperature;
        private int _humidity;
        private char _scale;

        public WeatherClass()
        {
            _temperature = -60;
            _humidity = 0;
            _scale = 'C';
        }

        public void Execute()
        {
            bool switcher = true;
            while (switcher)
            {
                Console.WriteLine("Welcome to the weather station!");
                Console.WriteLine("Please enter the current weather conditions.");

                Console.Write("Enter the scale ('F' for fahrenheit or 'C' for Celcius): ");
                string scale = Console.ReadLine();
                if (char.TryParse(scale, out char scaleChar))
                {
                    if (scaleChar == 'C' || scaleChar == 'F')
                    {
                        _scale = scaleChar;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter 'F' or 'C'.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter 'F' or 'C'.");
                }

                Console.Write($"Enter the temperature in °{_scale}: ");
                string temp = Console.ReadLine();
                if (int.TryParse(temp, out int temperature))
                {
                    if (_scale == 'C')
                    {
                        if (temperature >= -60 && temperature <= 60)
                        {
                            _temperature = temperature;
                        }
                        else if (temperature < -60 || temperature > 60)
                        {
                            Console.WriteLine("A reading mistake must have been made since the value seems unrealistic.");
                        }
                    }
                    else if (_scale == 'F')
                    {
                        if (temperature >= -76 && temperature <= 140)
                        {
                            _temperature = temperature;
                        }
                        else if (temperature < -76 || temperature > 140)
                        {
                            Console.WriteLine("A reading mistake must have been made since the value seems unrealistic.");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }

                Console.Write("Enter the humidity: ");
                string raki = Console.ReadLine();

                if (int.TryParse(raki, out int humidity))
                {
                    if (humidity >= 0 && humidity <= 100)
                    {
                        _humidity = humidity;
                    }
                    else
                    {
                        Console.WriteLine("A reading mistake must have been made, humidity can only be between 0% - 100%, please try again");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }

                Console.WriteLine($"The current weather conditions are: \nTemperature: {_temperature} {_scale}\nHumidity: {_humidity}%");
                Console.WriteLine("Would you like to convert the temperature to the other scale? (Y/N)");
                string convert = Console.ReadLine();
                if (convert == "Y" || convert == "y")
                {
                    Convert();
                    Console.WriteLine($"The temperature is now: {_temperature} °{_scale}");

                }
                else if (convert == "N" || convert == "n")
                {
                    Console.WriteLine("Thank you for using the weather station!");
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter 'Y' or 'N'.");
                }
                switcher = false;
            }
        } 
        public void Convert()
        {
            if (_scale == 'C')
            {
                _temperature = (_temperature * 9 / 5) + 32;
                _scale = 'F';
            }
            else if (_scale == 'F')
            {
                _temperature = (_temperature - 32) * 5 / 9;
                _scale = 'C';
            }
        }
    }
}
