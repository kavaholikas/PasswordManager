using PManager.Views;

namespace PManager.Controllers
{
    public class MainMenuController
    {
        private readonly MainMenuView _view;
        private readonly App _app;

        public MainMenuController(MainMenuView view, App app)
        {
           _view = view; 
           _app = app;
        }

        public void LastUsedAccountClick(string name)
        {
            if (name == "No Result")
            {
                return;
            }
            _app.SetNewView(new AccountView(_app, name));
        }

        public void FindAccountClick()
        {
            _app.SetNewView(new FindAccountView(_app));
        }

        public void GetAllAccountsClick()
        {
            _app.SetNewView(new GetAllAccountsView(_app));
        }

        public void AddNewAccountClick()
        {
            _app.SetNewView(new AddNewAccountView(_app));
        }

        public void ExitClick()
        {
            _app.Exit();
        }
    }
}