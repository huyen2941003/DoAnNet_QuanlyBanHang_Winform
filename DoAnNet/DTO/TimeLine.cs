using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnNet.DTO
{
    internal class TimeLine
    {
        private string id;
        private string nameTimeline;
        private DateTime dayWork;

        public TimeLine(string id, string nameTimeline, DateTime dayWork)
        {
            this.Id = id;
            this.NameTimeline = nameTimeline;
            this.DayWork = dayWork;
        }
        public TimeLine(DataRow row)
        {
            this.Id = row["id"].ToString();
            this.NameTimeline = row["nameTimeline"].ToString();
            var week = row["dayWork"];
            if (week != DBNull.Value)
            {
                this.DayWork = Convert.ToDateTime(week);
            }
        }
        public string Id { get => id; set => id = value; }
        public DateTime DayWork { get => dayWork; set => dayWork = value; }
        public string NameTimeline { get => nameTimeline; set => nameTimeline = value; }
    }
}
