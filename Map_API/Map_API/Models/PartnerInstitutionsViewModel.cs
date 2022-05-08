﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Map_API.Models
{
    public class PartnerInstitutionsViewModel
    {
        private int _id;
        private string _name;
        private string _address;
        private string _phone;
        private DateTime _created;

        public PartnerInstitutionsViewModel(int id, string name, string address, string phone, DateTime created)
        {
            this._id = id;
            this._name = name;
            this._address = address;
            this._phone = phone;
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

        public string Address
        {
            get
            {
                return _address;
            }
            set
            {
                _address = value;
            }
        }

        public string Phone
        {
            get
            {
                return _phone;
            }
            set
            {
                _phone = value;
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