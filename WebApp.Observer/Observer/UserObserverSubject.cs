using BaseProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Observer.Observer
{
    public class UserObserverSubject
    {
        private readonly List<IUserObserver> _userObserver;

        public UserObserverSubject()
        {
            _userObserver = new List<IUserObserver>();
        }


        public void RegisterObserver(IUserObserver userObserver)
        {
            _userObserver.Add(userObserver);
        }

        public void RemoveObserver(IUserObserver userObserver)
        {
            _userObserver.Remove(userObserver);
        }

        public void NotifyObservers(AppUser appUser)
        {
            _userObserver.ForEach(x=> {
                x.CreateUser(appUser);            
            });

        }


    }
}
