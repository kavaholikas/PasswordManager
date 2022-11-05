using PManager.Controllers;
using PManager.Models;

namespace PManager.Views
{
    public class UpdateAccountView : BaseView
    {
        private UpdateAccountController controller;

        private readonly Account _account;

        public UpdateAccountView(App app, Account account) : base(app)
        {
            controller = new UpdateAccountController(this, app, account);
            _account = account;

            _title = $"Update {_account.Name}";

            _controls = new()
            {
                new UI.Input("Service Name", controller.SetServiceName, _account.Name),
                new UI.Input("Service Login", controller.SetLogin, _account.Login),
                new UI.Input("Service Password", controller.SetPassword, _account.Password),
                new UI.Input("Service Repeat Password", controller.SetRepeatPassword, _account.Password),
                new UI.Warning("Service/Login Empty or Passwords dont match."),
                new UI.Link("Update Account", controller.UpdateAccount),
                new UI.Link("Back", controller.BackClick)
            };
        }
        public void UpdateWarningVisibility(bool visibility)
        {
            _controls[4].UpdateVisibility(visibility);
        }
    }
}