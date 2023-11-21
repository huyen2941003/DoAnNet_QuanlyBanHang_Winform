using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnNet.DTO
{
    internal class Distribute
    {
        private string id;
        private string nameDistribute;

        public Distribute(string id, string nameDistribute)
        {
            this.Id = id;
            this.NameDistribute = nameDistribute;
        }

        public Distribute(DataRow row)
        {
            this.Id = row["id"].ToString();
            this.NameDistribute = row["nameDistribute"].ToString();
        }
        public string Id { get => id; set => id = value; }
        public string NameDistribute { get => nameDistribute; set => nameDistribute = value; }
    }
}
