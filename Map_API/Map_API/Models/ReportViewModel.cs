using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Map_API.Models
{
    public class ReportViewModel
    {
        private int _id;
        private string _address;
        private string _type;
        private string _description;
        private int _userId;
        private DateTime _created;

        public ReportViewModel(int id, string address, string type, string description, int userId, DateTime created)
        {
            this._id = id;
            this._address = address;
            this._type = type;
            this._description = description;
            this._userId = userId;
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

        public string Type
        {
            get
            {
                return _type;
            }
            set
            {
                _type = value;
            }
        }

        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
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

        public int UserId
        {
            get
            {
                return _userId;
            }
            set
            {
                _userId = value;
            }
        }
    }
}