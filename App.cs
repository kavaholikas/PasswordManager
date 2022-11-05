using PManager.Models;
using PManager.Views;
using PManager.Database;

public class App
{
    private BaseView _currentView;
    private readonly DbManager _manager;

    public App(DbManager manager)
    {
       _manager = manager;
       _currentView = new MainMenuView(this); 
    }

    public void Run()
    {
        while (_currentView.IsRunning)
        {
            _currentView.RenderView();
            _currentView.UpdateView();
        }
    }

    public void AddAccount(string name, string login, string password)
    {
        _manager.CreateAccount(name, login, password);
    }

    public List<Account> GetAccounts()
    {
        return _manager.GetAllAccounts();
    }

    public Account GetAccountByName(string name)
    {
        return _manager.GetAccountByName(name);
    }

    public Account? GetLastUsedAccount()
    {
        return _manager.GetLastUsedAccount();
    }

    public void DeleteAccountByName(string name)
    {
        _manager.DeleteAccountByName(name);
    }

    public void UpdateAccount(int id, string name, string login, string password)
    {
        _manager.UpdateAccount(id, name, login, password);
    }

    public void SetNewView(BaseView newView)
    {
        _currentView = newView;
    }

    public void GoBackToMainMenu()
    {
        _currentView = new MainMenuView(this);
    }

    public void GoBackToAllAccounts()
    {
        _currentView = new GetAllAccountsView(this);
    }

    public void GoToAccountView(string accountName)
    {
        _currentView = new AccountView(this, accountName);
    }

    public void Exit()
    {
        System.Console.ResetColor();
        System.Console.Clear();
        Environment.Exit(1);
    }
}