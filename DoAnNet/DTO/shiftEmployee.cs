using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnNet.DTO
{
    internal class shiftEmployee
    {
        private string id;
        private string nameShift;
        private float timeInshift;
        private float timeOutWorkshift;
        private float coefficientSalary;

        public shiftEmployee(string id, string nameShift, float timeInshift, float timeOutWorkshift, float coefficientSalary)
        {
            this.Id = id;
            this.NameShift = nameShift;
            this.TimeInshift = timeInshift;
            this.TimeOutWorkshift = timeOutWorkshift;
            this.CoefficientSalary = coefficientSalary;
        }
        public shiftEmployee(DataRow row)
        {
            this.Id = row["id"].ToString();
            this.NameShift = row["nameShift"].ToString();

            string TimeInshift = row["timeInshift"].ToString();
            if(float.TryParse(TimeInshift, out float timeInshift))
            {
                this.TimeInshift = timeInshift;
            }
            else
            {
                this.TimeInshift = (float)0.0f;
            }

            string TimeOutWorkshift = row["timeOutWorkshift"].ToString();
            if (float.TryParse(TimeOutWorkshift, out float timeOutWorkshift))
            {
                this.TimeOutWorkshift = timeOutWorkshift;
            }
            else
            {
                this.TimeOutWorkshift = (float)0.0f;
            }

            string CoefficientSalary = row["coefficientSalary"].ToString();
            if (float.TryParse(CoefficientSalary, out float coefficientSalary))
            {
                this.CoefficientSalary = coefficientSalary;
            }
            else
            {
                this.CoefficientSalary = (float)0.0f;
            }

        }
        public string Id { get => id; set => id = value; }
        public string NameShift { get => nameShift; set => nameShift = value; }
        public float TimeInshift { get => timeInshift; set => timeInshift = value; }
        public float TimeOutWorkshift { get => timeOutWorkshift; set => timeOutWorkshift = value; }
        public float CoefficientSalary { get => coefficientSalary; set => coefficientSalary = value; }
    }
}
