using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnNet.DTO
{
    internal class InputInvoices
    {
        private string id;
        private DateTime dateInvoice;
        private string idProvider;
        private float pay;
        private float paidAmount;
        private int orderStatus;
        public InputInvoices(string id, DateTime dateInvoice, string idProvider, float pay, float paidAmount, int orderStatus)
        {
            this.Id = id;
            this.DateInvoice = dateInvoice;
            this.IdProvider = idProvider;
            this.Pay = pay;
            this.PaidAmount = paidAmount;
            this.OrderStatus = orderStatus;
        }
        public InputInvoices(DataRow row)
        {
            this.Id = row["id"].ToString();
            var dateInvoice = row["dateInvoice"];
            if (dateInvoice != DBNull.Value)
            {
                this.DateInvoice = Convert.ToDateTime(dateInvoice);
            }
            this.IdProvider = row["idProvider"].ToString();
            string payy = row["pay"].ToString();
            if (float.TryParse(payy, out float pay))
            {
                this.Pay = pay;
            }
            else
            {
                this.Pay = 0.0f;
            }
            string PaidAmount = row["paidAmount"].ToString();
            if (float.TryParse(PaidAmount, out float paidAmount))
            {
                this.PaidAmount = paidAmount;
            }
            else
            {
                this.PaidAmount = 0.0f;
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
        public string IdProvider { get => idProvider; set => idProvider = value; }
        public float Pay { get => pay; set => pay = value; }
        public float PaidAmount { get => paidAmount; set => paidAmount = value; }
        public int OrderStatus { get => orderStatus; set => orderStatus = value; }
    }
}
