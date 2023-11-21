using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnNet.DTO
{
    internal class Provider
    {
        private string id;
        private string nameProvider;
        private string address;
        private string telephone;
        private string email;
        public Provider() { }
        public Provider(string id, string nameProvider, string address, string telephone, string email)
        {
            this.Id = id;
            this.NameProvider = nameProvider;
            this.Address = address;
            this.Telephone = telephone;
            this.Email = email;
        }
        public Provider(DataRow row)
        {
            this.Id = row["id"].ToString();
            this.NameProvider = row["nameProvider"].ToString();
            this.Address = row["adress"].ToString();
            this.Telephone = row["telephone"].ToString();
            this.Email = row["email"].ToString();
        }
        public string Id { get => id; set => id = value; }
        public string NameProvider { get => nameProvider; set => nameProvider = value; }
        public string Address { get => address; set => address = value; }
        public string Telephone { get => telephone; set => telephone = value; }
        public string Email { get => email; set => email = value; }
    }
}
