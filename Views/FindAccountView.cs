using PManager.Controllers;
using PManager.Models;

namespace PManager.Views
{
    public class FindAccountView : BaseView
    {
        private FindAccountController controller;

        private bool _clickOnNextUpdate = false;

        public FindAccountView(App app) : base(app)
        {
            controller = new FindAccountController(this, app);

            _title = "Find Account";
            IsRunning = true;

           _initBaseControls(); 
        }

        public void UpdateSeacrhResults(List<Account> accounts, string searchString)
        {
            if (accounts.Count == 0)
            {
                _initBaseControls(searchString);
                _clickOnNextUpdate = true;
                return;
            }

            _controls.Clear();
            _controls = new()
            {
                new UI.Input("Search", controller.SetSearch, searchString, true)
            };

            foreach (Account item in accounts)
            {
                _controls.Add(
                    new UI.Link(item.Name, controller.ClickOnLink) {ClickValue = item.Name}
                );
            }

            _controls.Add(new UI.Link("Back", controller.BackClick));

            _clickOnNextUpdate = true;
        }

        private void _initBaseControls(string searchString = "")
        {
            _controls = new()
            {
                new UI.Input("Search", controller.SetSearch, searchString, true),
                new UI.Label("No Results"),
                new UI.Link("Back", controller.BackClick)
            };
        }

        protected internal override void UpdateView()
        {
            if (_clickOnNextUpdate)
            {
                _clickOnNextUpdate = false;
                _controls[0].Click();
            }
            else
            {
                base.UpdateView();
            }
        }
    }
}
