using System;

namespace PManager.Views.UI
{
    public class Link : BaseControl
    {
        public Link(string label) : base(label) { }

        public Link(string label, NotifyWithString action) : base(label, action) { }

        public Link(string label, Notify action) : base(label, action) {}
    }
}