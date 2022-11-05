using PManager.Views;

namespace PManager.Controllers
{
    public class GetAllAccountsController
    {
        private readonly GetAllAccountsView _view;
        private readonly App _app;

        public GetAllAccountsController(GetAllAccountsView view, App app)
        {
            _view = view;
            _app = app;
        }

        public void AccountClick(string s)
        {
            _app.SetNewView(new AccountView(_app, s));
        }

        public void BackClick()
        {
            _app.GoBackToMainMenu();
        }
    }
}