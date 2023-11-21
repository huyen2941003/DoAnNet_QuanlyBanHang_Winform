using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnNet.DTO
{
    internal class Inventory
    {
        private string idProduct;
        private int amount;

        public Inventory(string idProduct, int amount)
        {
            this.IdProduct = idProduct;
            this.Amount = amount;
        }
        public Inventory(DataRow row)
        {
            this.idProduct = row["idProduct"].ToString();
            string Amount = row["amount"].ToString();
            if(int.TryParse(Amount, out int amount))
            {
                this.Amount = amount;
            }
            else
            {
                this.Amount = (int)amount;
            }
        }
        public string IdProduct { get => idProduct; set => idProduct = value; }
        public int Amount { get => amount; set => amount = value; }
    }
}
