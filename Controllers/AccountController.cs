using PManager.Views;
using PManager.Models;

namespace PManager.Controllers
{
    public class AccountController
    {
        private readonly AccountView _view;
        private readonly App _app;

        private readonly Account _account;

        public AccountController(AccountView view, App app, Account account)
        {
            _view = view;
            _app = app;
            _account = account;
        }

        public void BackClick()
        {
            _app.GoBackToAllAccounts();
        }

        public void GetAccountInfoToClipboiard(string propertyName)
        {
            if (propertyName == "LOGIN")
            {
                Clipboard.SetText(_account.Login);
                _view.UpdateWarningVisibility($"{propertyName}_WARNING");
            }
            else if (propertyName == "PASSWORD")
            {
                Clipboard.SetText(_account.Password);
                _view.UpdateWarningVisibility($"{propertyName}_WARNING");
            }
        }

        public void UpdateAccount()
        {
            _app.SetNewView(new UpdateAccountView(_app, _account));
        }

        public void DeleteAccount()
        {
            _app.SetNewView(new DeleteAccountView(_app, _account.Name));
        }
    }
}