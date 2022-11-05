using PManager.Views;
using PManager.Models;

namespace PManager.Controllers
{
    public class DeleteAccountController
    {
        private readonly DeleteAccountView _view;
        private readonly App _app;

        public DeleteAccountController(DeleteAccountView view, App app)
        {
            _view = view;
            _app = app;
        }

        public void DeleteAccount(string accountName)
        {
            _app.DeleteAccountByName(accountName);
            _app.GoBackToAllAccounts();
        }

        public void BackClick(string accountName)
        {
            _app.SetNewView(new AccountView(_app, accountName));
        }
    }
}