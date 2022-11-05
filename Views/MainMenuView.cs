using PManager.Controllers;
using PManager.Models;

namespace PManager.Views
{
    public class MainMenuView : BaseView
    {
        private MainMenuController controller;

        private string lastUsedName = "No Result";

        public MainMenuView(App app) : base(app)
        {
            controller = new MainMenuController(this, app);

            Account? last = app.GetLastUsedAccount();
            if (last != null)
            {
                lastUsedName = last.Name;
            }

            _title = "Password Manager";
            IsRunning = true;
            _exitOnBack = true;

            _controls = new()
            {
                new UI.Link($"Last used: {lastUsedName}", controller.LastUsedAccountClick){ClickValue = lastUsedName},
                new UI.Link("Find Account", controller.FindAccountClick),
                new UI.Link("Get All Accounts", controller.GetAllAccountsClick),
                new UI.Link("Add New Account", controller.AddNewAccountClick),
                new UI.Link("Exit", controller.ExitClick)
            };
        }
    }
}