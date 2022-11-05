using PManager.Controllers;
using PManager.Models;

namespace PManager.Views
{
    public class AccountView : BaseView
    {
        private AccountController controller;

        private string _accountName;

        private Account _account;

        private int _clearWarnigns = 0;

        public AccountView(App app, string accountName) : base(app)
        {
            _account = app.GetAccountByName(accountName);

            controller = new AccountController(this, app, _account);
            _accountName = accountName;


            _title = accountName;
            _displayTitle = false;

            _controls = new()
            {
                new UI.Label("Account Info"),
                new UI.Link($"Service: {_account.Name}") {Clickable = false},
                new UI.Link($"Login: {_account.Login}", controller.GetAccountInfoToClipboiard)
                    {ClickValue = "LOGIN"},
                new UI.Warning("Login Copied to Clipboard")
                    {ClickValue = "LOGIN_WARNING", ForegroundColor = ConsoleColor.Green},
                new UI.Link($"Password: {_account.Password}", controller.GetAccountInfoToClipboiard)
                    {ClickValue = "PASSWORD"},
                new UI.Warning("Password Copied to Clipboard")
                    {ClickValue = "PASSWORD_WARNING", ForegroundColor = ConsoleColor.Green},
                new UI.Link("Update Account", controller.UpdateAccount),
                new UI.Link("Delete Account", controller.DeleteAccount),
                new UI.Link("Back", controller.BackClick)
            };

            MoveControlIndexDown();
        }

        public void UpdateWarningVisibility(string controlName)
        {
            UI.BaseControl? warning = _controls.Find((c) => c.ClickValue == controlName);
            if (warning != null)
            {
                warning.UpdateVisibility(true);
                _clearWarnigns = 1;
            }
        }

        protected internal override void UpdateView()
        {
            base.UpdateView();

            if (_clearWarnigns > 0)
            {
                if (_clearWarnigns++ == 1)
                {
                    return;
                }

                foreach (UI.BaseControl control in
                    _controls.Where((c) => c.GetType().Name == "Warning"))
                {
                    control.UpdateVisibility(false);   
                }

                _clearWarnigns = 0;
            }

        }
    }
}