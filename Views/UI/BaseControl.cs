using System;

namespace PManager.Views.UI
{
    public class BaseControl
    {
        protected string _label;
        protected event Notify? _action;
        protected event NotifyWithString? _actionWithString;

        protected internal bool Clickable = true;
        protected internal string ClickValue;
        protected internal ConsoleColor ForegroundColor = ConsoleColor.Gray;

        public BaseControl(string label)
        {
            _label = label;
            ClickValue = label;
        }

        public BaseControl(string label, Notify action)
        {
            _label = label;
            _action = action;
            ClickValue = label;
        }

        public BaseControl(string label, NotifyWithString action)
        {
            _label = label;
            _actionWithString = action;
            ClickValue = label;
        }

        protected internal virtual void Render(bool active = false)
        {
            if (active)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
            }
            else
            {
                Console.ForegroundColor = ForegroundColor;
                // Console.ResetColor();
            }

            Console.WriteLine(_label);
        }

        protected internal virtual void Click()
        {
            if (_actionWithString != null)
            {
                _actionWithString?.Invoke(ClickValue);
            }
            else if (_action != null)
            {
                _action?.Invoke();
            }
        }
        
        protected internal virtual void UpdateVisibility(bool visibility) {}

        public override string ToString()
        {
            return _label;
        }
    }
}