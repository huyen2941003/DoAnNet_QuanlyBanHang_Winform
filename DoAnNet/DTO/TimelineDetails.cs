using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnNet.DTO
{
    internal class TimelineDetails
    {
        private string idTimeline;
        private string idEmployee;
        private string idShift;

        public TimelineDetails(string idTimeline, string idEmployee, string idShift)
        {
            this.IdTimeline = idTimeline;
            this.IdEmployee = idEmployee;
            this.IdShift = idShift;
        }
        public TimelineDetails(DataRow row)
        {
            this.IdTimeline = row["idTimeline"].ToString();
            this.IdEmployee = row["idEmployee"].ToString();
            this.IdShift = row["idShift"].ToString();
        }

        public string IdTimeline { get => idTimeline; set => idTimeline = value; }
        public string IdEmployee { get => idEmployee; set => idEmployee = value; }
        public string IdShift { get => idShift; set => idShift = value; }
    }
}
