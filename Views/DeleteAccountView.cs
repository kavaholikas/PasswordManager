using PManager.Controllers;
using PManager.Models;

namespace PManager.Views
{
    public class DeleteAccountView : BaseView
    {
        private DeleteAccountController controller;

        private string _accountName;

        public DeleteAccountView(App app, string accountName) : base(app)
        {
            controller = new DeleteAccountController(this, app);
            _accountName = accountName;

            _title = $"Delete {_accountName}";
            _displayTitle = false;

            _controls = new()
            {
                new UI.Label($"Are you sure you wanna delete {_accountName} account?"),
                new UI.Link("YES", controller.DeleteAccount) {ClickValue = _accountName},
                new UI.Link("NO", controller.BackClick) {ClickValue = _accountName},
            };

            MoveControlIndexDown();
        }
    }
}