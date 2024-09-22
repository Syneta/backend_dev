using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cSharpPrimerSkil
{
    internal class NumberClass
    {
        // Fields
        private List<int> _numbers;
        private string _userInput;

        // Constructor
        public NumberClass()
        {
            _numbers = new List<int>();
            _userInput = string.Empty;
        }

        // Method to execute the logic
        public void Execute()
        {
            Console.WriteLine("Enter numbers. Press enter to finish. \nThen I'll tell you the value of your highest and lowest number");
            do
            {
                Console.Write("Enter a number: ");
                _userInput = Console.ReadLine();
                if (int.TryParse(_userInput, out int number))
                {
                    _numbers.Add(number);
                }
                else if (!string.IsNullOrEmpty(_userInput))
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }
            } while (!string.IsNullOrEmpty(_userInput));

            int numMin = _numbers.Min();
            int numMax = _numbers.Max();

            Console.WriteLine($"Your number with the highest value: {numMax}");
            Console.WriteLine($"Your number with the lowest value: {numMin}");
        }
    }
}

