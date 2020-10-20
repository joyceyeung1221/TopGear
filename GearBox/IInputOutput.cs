using System;
namespace GearBox
{
    public interface IInputOutput
    {
        string GetUserInput();
        void Output(string text);
    }
}
