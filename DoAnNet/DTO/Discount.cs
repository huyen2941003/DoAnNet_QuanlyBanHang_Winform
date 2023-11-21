using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnNet.DTO
{
    internal class Discount
    {
        private string iD;
        private string nameDiscount;
        private DateTime startDiscount;
        private DateTime finishDiscount;
        private float percentDiscount;

        public Discount(string iD, string nameDiscount, DateTime startDiscount, DateTime finishDiscount, float percentDiscount)
        {
            this.ID = iD;
            this.NameDiscount = nameDiscount;
            this.StartDiscount = startDiscount;
            this.FinishDiscount = finishDiscount;
            this.PercentDiscount = percentDiscount;
        }

        public Discount(DataRow row)
        {
            this.ID = row["id"].ToString();
            this.NameDiscount = row["nameDiscount"].ToString();
            var startDate = row["startDiscount"];
            if (startDate != DBNull.Value)
            {
                this.StartDiscount = Convert.ToDateTime(startDate);
            }
            var endDate = row["finishDiscount"];
            if (endDate != DBNull.Value)
            {
                this.FinishDiscount = Convert.ToDateTime(endDate);
            }
            this.PercentDiscount = (float)Convert.ToDouble(row["percentDiscount"].ToString());
        }
        public string ID { get => iD; set => iD = value; }
        public string NameDiscount { get => nameDiscount; set => nameDiscount = value; }
        public DateTime StartDiscount { get => startDiscount; set => startDiscount = value; }
        public DateTime FinishDiscount { get => finishDiscount; set => finishDiscount = value; }
        public float PercentDiscount { get => percentDiscount; set => percentDiscount = value; }

    }
}
