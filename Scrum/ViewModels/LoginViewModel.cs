using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ReactiveUI;
using Scrum.Model;
using Scrum.SQL;
using Scrum.View;

namespace Scrum.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public LoginViewModel()
        {
            Context = new EntityContext();
            InitCommands();
        }
        

        void InitCommands()
        {
            var canLogin = this.WhenAny(x => x.Login, x => x.Password,
                            (e, p) => !string.IsNullOrEmpty(e.Value) && !string.IsNullOrEmpty(p.Value));

            LoginCommand = ReactiveCommand.CreateFromTask(async _ =>
            {
                var password = Security.HashSHA1(Password);
                var user = Context.GetEntities<User>().FirstOrDefault(u => u.Name == Login && u.Password == password);
                if (user == null)
                {

                }
                else
                {
                    if (user.IsSuperUser)
                    {
                        
                    }
                    else
                    {
                        //TODO: cae of the regular user 
                    }
                }
            }, canLogin);
        }

        string login;
        public string Login
        {
            get => login;
            set { login = value; OnPropertyChanged(); }
        }

        string _password;
        public string Password
        {
            get => _password;
            set { _password = value; OnPropertyChanged(); }
        }

        private ICommand loginCommand;

        public ICommand LoginCommand
        {
            get => loginCommand;
            set => loginCommand = value;
        }

        public EntityContext Context { get; set; }


    }
}
