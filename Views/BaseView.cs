namespace PManager.Views
{
    public class BaseView
    {
        protected string _title;
        protected internal bool IsRunning = true;

        protected List<UI.BaseControl> _controls;
        protected int _controlIndex = 0;

        protected readonly App _app;
        protected bool _exitOnBack = false;
        protected bool _displayOnly = false;
        protected bool _displayTitle = true;

        public BaseView(App app)
        {
            _title = "BaseView";
            _controls = new();
        
            _app = app;
        }

        protected internal void RenderView()
        {
            Console.Clear();
            Console.ResetColor();
            if (_displayTitle)
            {
                Console.WriteLine(_title);
            }

            for (int i = 0; i < _controls.Count; i++)
            {
                _controls[i].Render(i == _controlIndex);
            }

            Console.ResetColor();
        }

        protected internal virtual void UpdateView()
        {
            ConsoleKeyInfo cki = Console.ReadKey(true);

            switch (cki.Key)
            {
                case ConsoleKey.J:
                case ConsoleKey.DownArrow:
                    MoveControlIndexDown();
                    break;
                
                case ConsoleKey.K:
                case ConsoleKey.UpArrow:
                    MoveControlIndexUp();
                    break;

                case ConsoleKey.Enter:
                    _controls[_controlIndex].Click();
                    break;
                
                case ConsoleKey.Backspace:
                    if (_exitOnBack)
                    {
                        _app.Exit();
                        return;
                    }

                    _app.GoBackToMainMenu();
                    break;

                case ConsoleKey.Escape:
                    _app.Exit();
                    break;
            }
        }

        protected internal void MoveControlIndexDown()
        {
            if (_displayOnly)
            {
                return;
            }

            _controlIndex = (_controlIndex + 1) % _controls.Count;
            if (!_controls[_controlIndex].Clickable)
            {
                MoveControlIndexDown();
            }
        }

        protected internal void MoveControlIndexUp()
        {
            if (_displayOnly)
            {
                return;
            }

            _controlIndex = (_controlIndex + (_controls.Count - 1)) % _controls.Count;
            if (!_controls[_controlIndex].Clickable)
            {
                MoveControlIndexUp();
            }
        }
    }
}