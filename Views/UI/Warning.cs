using System;

namespace PManager.Views.UI
{
    public class Warning : BaseControl
    {
        protected bool _visibility = false;

        public Warning(string label) : base(label)
        {
            Clickable = false;
            ForegroundColor = ConsoleColor.Red;
        }

        public Warning(string label, Notify action) : base(label, action)
        {
            Clickable = false;
            ForegroundColor = ConsoleColor.Red;
        }

        protected internal override void Render(bool active = false)
        {
            if (_visibility)
            {
                Console.ForegroundColor = ForegroundColor;
                Console.WriteLine(_label);
            }
        }

        protected internal override void UpdateVisibility(bool visibility)
        {
            _visibility = visibility;
        }
    }
}