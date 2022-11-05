using System;

namespace PManager.Views.UI
{
    public class Label : BaseControl
    {
        public Label(string label) : base(label)
        {
            Clickable = false;
        }

        public Label(string label, Notify action) : base(label, action)
        {
            Clickable = false;
        }

        public Label(string label, NotifyWithString action) : base(label, action)
        {
            Clickable = false;
        }

        protected internal override void Render(bool active = false)
        {
            Console.ResetColor();
            Console.WriteLine(_label);
        }
    }
}