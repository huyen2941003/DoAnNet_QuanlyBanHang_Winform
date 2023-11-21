using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnNet.DTO
{
    internal class Size
    {
        private string id;
        private string nameSize;

        public Size(string id, string nameSize)
        {
            this.Id = id;
            this.NameSize = nameSize;
        }

        public Size(DataRow row)
        {
            this.id = row["id"].ToString();
            this.NameSize = row["nameSize"].ToString();
        }
        public string Id { get => id; set => id = value; }
        public string NameSize { get => nameSize; set => nameSize = value; }
    }
}
