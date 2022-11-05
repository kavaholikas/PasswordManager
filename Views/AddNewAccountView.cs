using PManager.Controllers;

namespace PManager.Views
{
    public class AddNewAccountView : BaseView
    {
        private AddNewAccountController controller;
        public AddNewAccountView(App app) : base(app)
        {
            controller = new AddNewAccountController(this, app);

            _title = "Add New Account";
            IsRunning = true;

            _controls = new()
            {
                new UI.Input("Service Name", controller.SetServiceName),
                new UI.Input("Login", controller.SetLogin),
                new UI.Input("Password", controller.SetPassword),
                new UI.Input("Repeat Password", controller.SetRepeatPassword),
                new UI.Link("Create Account", controller.CreateAccount),
                new UI.Warning("Service/Login Empty or Passwords dont match."),
                new UI.Link("Back", controller.BackClick)
            };
        }

        // TODO: Find a better way to update warning visibility
        public void UpdateWarningVisibility(bool visibility)
        {
            _controls[5].UpdateVisibility(visibility);
        }
    }
}