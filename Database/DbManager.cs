using System;
using PManager.Models;

namespace PManager.Database
{
    public class DbManager
    {
        public DbManager() { }

        public void CreateAccount(string name, string login, string password)
        {
            using var db = new Context();

            db.Add(new Account()
            {
                Name = name,
                Login = login,
                Password = password,
                LastUsed = false
            });

            db.SaveChanges();
        }

        public List<Account> GetAllAccounts()
        {
            using var db = new Context();

            return db.Accounts.ToList();
        }

        public Account GetAccountByName(string name)
        {
            using var db = new Context();

            foreach (var item in db.Accounts)
            {
                item.LastUsed = false;
            }

            Account result = db.Accounts.First(a => a.Name == name);
            result.LastUsed = true;
            db.SaveChanges();

            return result;
        }

        public Account? GetLastUsedAccount()
        {
            using var db = new Context();
            try
            {
                return db.Accounts.First(a => a.LastUsed == true);
            }
            catch (System.InvalidOperationException)
            {
                return null;
            }
        }

        public void DeleteAccountByName(string name)
        {
            using var db = new Context();
            db.Remove(db.Accounts.First(a => a.Name == name));
            db.SaveChanges();
        }

        public void UpdateAccount(int id, string name, string login, string password)
        {
            using var db = new Context();

            Account account = db.Accounts.First(a => a.AccountId == id);
            account.Name = name;
            account.Login = login;
            account.Password = password;

            db.SaveChanges();
        }
    }
}