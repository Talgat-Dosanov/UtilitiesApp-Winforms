using CommunalApp_Winforms.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunalApp_Winforms.Controller
{
    public class WaterController : ControllerBase<Water>
    {
        public List<Water> WaterList { get; }

        public WaterController()
        {
            WaterList = base.GetAllItems();
        }
        public void Add(Water water)
        {
            base.Add(WaterList, water);
            base.Save(WaterList);
        }
        public Water GetWaterInfo(DateTime fromDate, DateTime toDate)
        {
            return Load<Water>().SingleOrDefault(i => i.FromDate == fromDate && i.ToDate == i.ToDate);
        }
    }
}
