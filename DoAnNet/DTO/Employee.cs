using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnNet.DTO
{
    internal class Employee
    {
        private string iD;
        string idPosition;
        private string nameEmployee;
        private DateTime birthday;
        private string telephone;
        private string address;
        private string image;

        public Employee(string iD, string idPosition, string nameEmployee, DateTime birthday, string telephone, string address, string image)
        {
            this.ID = iD;
            this.IdPosition = idPosition;
            this.NameEmployee = nameEmployee;
            this.Birthday = birthday;
            this.Telephone = telephone;
            this.Address = address;
            this.Image = image;
        }

        public Employee(DataRow row)
        {
            this.ID = row["id"].ToString();
            this.IdPosition = row["idPosition"].ToString();
            this.NameEmployee = row["nameEmployee"].ToString();
            var birthDay = row["birthday"];
            if (birthDay != DBNull.Value)
            {
                this.Birthday = Convert.ToDateTime(birthDay);
            }
            this.Telephone = row["telephone"].ToString();
            this.Address = row["adress"].ToString();
            this.Image = row["employeeImage"].ToString();
        }

        public string ID { get => iD; set => iD = value; }
        public string NameEmployee { get => nameEmployee; set => nameEmployee = value; }
        public DateTime Birthday { get => birthday; set => birthday = value; }
        public string Telephone { get => telephone; set => telephone = value; }
        public string Address { get => address; set => address = value; }
        public string Image { get => image; set => image = value; }
        public string IdPosition { get => idPosition; set => idPosition = value; }
    }
}
