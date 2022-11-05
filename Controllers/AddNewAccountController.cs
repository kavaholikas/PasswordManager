using PManager.Models;
using PManager.Views;

namespace PManager.Controllers
{
    public class AddNewAccountController
    {
        private readonly AddNewAccountView _view;
        private readonly App _app;

        private string _serviceName = string.Empty;
        private string _login = string.Empty;
        private string _password = string.Empty;
        private string _reapeatPassword = string.Empty;

        public AddNewAccountController(AddNewAccountView view, App app)
        {
            _view = view;
            _app = app;
        }

        public void SetServiceName(object? sender, string serviceName)
        {
            _serviceName = serviceName;
            MoveControlIndexDown();
        }

        public void SetLogin(object? sender, string login)
        {
            _login = login;
            MoveControlIndexDown();
        }

        public void SetPassword(object? sender, string password)
        {
            _password = password;
            MoveControlIndexDown();
        }

        public void SetRepeatPassword(object? sender, string repeatPassword)
        {
            _reapeatPassword = repeatPassword;
            MoveControlIndexDown();
        }

        public void CreateAccount()
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

            _app.AddAccount(_serviceName, _login, _password);

            _app.GoBackToMainMenu();
        }

        public void BackClick()
        {
            _app.GoBackToMainMenu();
        }

        private void MoveControlIndexDown()
        {
            _view.MoveControlIndexDown();
        }
    }
}
