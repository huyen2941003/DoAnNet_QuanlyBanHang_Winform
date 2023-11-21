using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnNet.DTO
{
    internal class Position
    {
        private string id;
        private string namePosition;

        public Position(string id, string namePosition)
        {
            this.Id = id;
            this.NamePosition = namePosition;
        }

        public Position(DataRow row)
        {
            this.Id = row["id"].ToString();
            this.NamePosition = row["namePosition"].ToString();
        }

        public string Id { get => id; set => id = value; }
        public string NamePosition { get => namePosition; set => namePosition = value; }
    }
}
