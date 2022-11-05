using System;

namespace PManager.Views.UI
{
    public class Input : BaseControl
    {
        private int _cursorLeft;
        private int _cursorTop;

        private string _input = "";
        private bool _updateOnTrigger = false;

        private event EventHandler<string> SetInput;

        public Input(string label, EventHandler<string> setInput,
            string input = "", bool updateOnTrigger = false)
            : base(label)
        {
             SetInput = setInput;
             _input = input;
             _updateOnTrigger = updateOnTrigger;
        }

        public Input(string label, Notify action,
            EventHandler<string> setInput, string input = "",
            bool updateOnTrigger = false)
            : base(label, action)
        {
            SetInput = setInput;
            _input = input;
            _updateOnTrigger = updateOnTrigger;
        }

        protected internal override void Render(bool active = false)
        {
            if (active)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
            }
            else
            {
                Console.ResetColor();
            }

            Console.Write($"{_label}: {_input}");
            _cursorLeft = Console.CursorLeft;
            _cursorTop = Console.CursorTop;
            Console.Write("\n");
        }

        protected internal override void Click()
        {
            Console.CursorLeft = _cursorLeft;
            Console.CursorTop = _cursorTop;

            bool reading = true;

            while (reading)
            {
                ConsoleKeyInfo cki = Console.ReadKey(true);
                if ((char.IsLetterOrDigit(cki.KeyChar)
                    || char.IsPunctuation(cki.KeyChar)
                    || char.IsSeparator(cki.KeyChar)
                    ) && !char.IsWhiteSpace(cki.KeyChar))
                {
                    _input += cki.KeyChar;
                    Console.Write(cki.KeyChar);
                }

                if (cki.Key == ConsoleKey.Backspace)
                {
                    if (_input.Length > 0)
                    {
                        _input = _input.Remove(_input.Length - 1);    
                        Console.Write("\b \b");
                    }
                }

                if (cki.Key == ConsoleKey.Escape 
                    || cki.Key == ConsoleKey.Enter)
                {
                    reading = false;
                    if (_updateOnTrigger)
                    {
                        return;
                    }
                }
                
                if (_updateOnTrigger)
                {
                    SetInput?.Invoke(this, _input);
                    return;
                }
            }

            if (!_updateOnTrigger)
            {
                SetInput?.Invoke(this, _input);
            }
        }
    }
}