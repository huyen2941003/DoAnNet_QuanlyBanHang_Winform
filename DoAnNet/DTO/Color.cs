using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnNet.DTO
{
    internal class Color
    {
        private string id;
        private string nameColor;

        public Color(string id, string nameColor)
        {
            this.Id = id;
            this.NameColor = nameColor;
        }

        public Color(DataRow row)
        {
            this.Id = row["id"].ToString();
            this.NameColor = row["nameColor"].ToString();
        }
        public string Id { get => id; set => id = value; }
        public string NameColor { get => nameColor; set => nameColor = value; }
    }

}
