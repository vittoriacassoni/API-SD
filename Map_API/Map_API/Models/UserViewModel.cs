using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Map_API.Models
{
    public class UserViewModel
    {
        private int _id;
        private string _name;
        private string _email;
        private string _country;
        private string _state;
        private DateTime _created;

        public UserViewModel(int id, string name, string email, string country, string state, DateTime created)
        {
            this._id = id; 
            this._name = name;
            this._email = email;
            this._country = country;
            this._state = state;
            this._created = DateTime.Now;
        }

        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
            }
        }

        public string Country
        {
            get
            {
                return _country;
            }
            set
            {
                _country = value;
            }
        }

        public string State
        {
            get
            {
                return _state;
            }
            set
            {
                _state = value;
            }
        }

        public DateTime Created
        {
            get
            {
                return _created;
            }
            set
            {
                _created = value;
            }
        }
    }
}