using System;
using System.Text.RegularExpressions;

namespace GearBox
{
    public class ConsoleSetup
    {
        private IInputOutput _io;
        private Regex _numberRegex = new Regex(@"^-?\d+$");
        private const int MaxRPM = 12000;

        public ConsoleSetup(IInputOutput io)
        {
            _io = io;
        }

        public Gear CreateGear(int lowerLimit, int gear)
        {
            var upperLimit = GetRPM(lowerLimit, gear);
            return new Gear(lowerLimit, upperLimit);
        }

        private int GetRPM(int lowerLimit, int gear)
        {
            string result;
            string errorMessage;
            do
            {
                errorMessage = "";
                _io.Output($"Setup for {gear}");
                result = _io.GetUserInput();
                errorMessage = HasInputError(result, lowerLimit);
                PrintErrorMessage(errorMessage);
            } while (errorMessage != "");

            return Int32.Parse(result);
        }

        private string HasInputError(string input, int lowerLimit)
        {
            if (IsInvalidInput(input))
            {
                return "Invalid Input, please put in a number.";
            }
            var rpm = Int32.Parse(input);
            if(IsInvalidRPM(rpm, lowerLimit))
            {
                return $"Upper limit needs to be larger than {lowerLimit} and less than {MaxRPM}.";
            }
            return "";
        }

        private bool IsInvalidInput(string input)
        {
            return input == "" || !_numberRegex.IsMatch(input);
        }

        private bool IsInvalidRPM(int rpm, int lowerLimit)
        {
            return rpm < lowerLimit || rpm > MaxRPM;
        }

        private void PrintErrorMessage(string errorMessage)
        {
            if (errorMessage != "")
            {
                _io.Output(errorMessage);
            }
        }
    }
}
