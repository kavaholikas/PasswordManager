using PManager.Views;
using PManager.Models;

namespace PManager.Controllers
{
    public class UpdateAccountController
    {
        private readonly UpdateAccountView _view;
        private readonly App _app;

        private Account _account;

        private string _originalServiceName;
        private string _serviceName;
        private string _login;
        private string _password;
        private string _reapeatPassword;

        public UpdateAccountController(UpdateAccountView view, App app, Account account)
        {
            _view = view;
            _app = app;

            _account = account;

            _originalServiceName = account.Name;

            _serviceName = account.Name;
            _login = account.Login;
            _password = account.Password;
            _reapeatPassword = account.Password;
        }

        public void SetServiceName(object? sender, string serviceName)
        {
            _serviceName = serviceName;
            MoveControlIndexDown();
        }

        public void SetLogin(Object? sender, string login)
        {
            _login = login;
            MoveControlIndexDown();
        }

        public void SetPassword(Object? sender, string password)
        {
            _password = password;
            MoveControlIndexDown();
        }

        public void SetRepeatPassword(Object? sender, string repeatPassword)
        {
            _reapeatPassword = repeatPassword;
            MoveControlIndexDown();
        }

        public void UpdateAccount()
        {
            if (string.IsNullOrWhiteSpace(_serviceName)
                || string.IsNullOrWhiteSpace(_login))
            {
                _view.UpdateWarningVisibility(true);
                return;
            }

            if (_password != _reapeatPassword)
            {
                _view.UpdateWarningVisibility(true);
                return;
            }

            _view.UpdateWarningVisibility(false);

            _app.UpdateAccount(_account.AccountId, _serviceName, _login, _password);

            _app.GoBackToAllAccounts();
        }

        public void BackClick()
        {
            _app.SetNewView(new AccountView(_app, _originalServiceName));
        }

        private void MoveControlIndexDown()
        {
            _view.MoveControlIndexDown();
        }
    }
}