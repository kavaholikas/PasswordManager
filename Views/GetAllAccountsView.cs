using PManager.Models;
using PManager.Controllers;

namespace PManager.Views
{
    public class GetAllAccountsView : BaseView
    {
        private GetAllAccountsController controller;

        public GetAllAccountsView(App app) : base(app)
        {
            controller = new GetAllAccountsController(this, app);

            _title = "All Accounts";
            IsRunning = true;

            _controls = new();
            _getAccounts(app);

            _controls.Add(new UI.Link("Back", controller.BackClick));
        }

        private void _getAccounts(App app)
        {
            List<Account> accounts = app.GetAccounts();

            foreach (Account account in accounts)
            {
                _controls.Add(
                    new UI.Link(account.Name, controller.AccountClick)
                );
            }
        }
    }
}