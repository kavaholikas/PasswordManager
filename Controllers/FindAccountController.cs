using PManager.Views;
using PManager.Models;

namespace PManager.Controllers
{
    public class FindAccountController
    {
        private readonly FindAccountView _view;
        private readonly App _app;
        private readonly List<Account> _accounts;

        public FindAccountController(FindAccountView view, App app)
        {
            _view = view;
            _app = app;

            _accounts = _app.GetAccounts();
        }

        public void SetSearch(object? sender, string searchString)
        {
            if (searchString.Length < 3)
            {
                _view.UpdateSeacrhResults(new List<Account>(), searchString);
                return;
            }

            List<Account> results = _accounts.FindAll(
                (a) => a.Name.ToLower().Contains(searchString.ToLower())
            );

            _view.UpdateSeacrhResults(results, searchString);
        }

        public void ClickOnLink(string name)
        {
            _app.GoToAccountView(name);
        }


        public void BackClick()
        {
            _app.GoBackToMainMenu();
        }
    }
}