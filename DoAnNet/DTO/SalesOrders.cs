using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnNet.DTO
{
    internal class SalesOrders
    {
        private string id;
        private DateTime dateInvoice;
        private float pay;
        private int orderStatus;
        public SalesOrders(string id, DateTime dateInvoice, float pay, int orderStatus)
        {
            this.Id = id;
            this.DateInvoice = dateInvoice;
            this.Pay = pay;
            this.OrderStatus = orderStatus;
        }
        public SalesOrders(DataRow row)
        {
            this.Id = row["id"].ToString();
            var dateInvoice = row["dateInvoice"];
            if (dateInvoice != DBNull.Value)
            {
                this.DateInvoice = Convert.ToDateTime(dateInvoice);
            }
            string payy = row["pay"].ToString();
            if (float.TryParse(payy, out float pay))
            {
                this.Pay = pay;
            }
            else
            {
                this.Pay = 0.0f;
            }
            string OrderStatus = row["orderStatus"].ToString();
            if (int.TryParse(OrderStatus, out int orderStatus))
            {
                this.OrderStatus = orderStatus;
            }
            else
            {
                this.OrderStatus = (int)0.0d;
            }
        }
        public string Id { get => id; set => id = value; }
        public DateTime DateInvoice { get => dateInvoice; set => dateInvoice = value; }
        public float Pay { get => pay; set => pay = value; }
        public int OrderStatus { get => orderStatus; set => orderStatus = value; }
    }
}
