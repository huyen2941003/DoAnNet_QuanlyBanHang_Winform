using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnNet.DTO
{
    internal class Account
    {
        private string idPosition;
        private string userName;
        private string pass;

        public Account(string idPosition, string userName, string pass)
        {
            this.IdPosition = idPosition;
            this.UserName = userName;
            this.Pass = pass;
        }

        public Account(DataRow row)
        {
            this.IdPosition = row["idPosition"].ToString();
            this.UserName = row["userName"].ToString();
            this.Pass = row["pass"].ToString();
        }

        public string IdPosition { get => idPosition; set => idPosition = value; }
        public string UserName { get => userName; set => userName = value; }
        public string Pass { get => pass; set => pass = value; }

    }
}
