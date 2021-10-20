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
        public List<Water> WaterList { get; set; }
        public Water newWaterData { get; set; }
       
        public WaterController()
        {
            WaterList = base.GetAllItems();
            
        }
        public void Add(Water water)
        {
            base.Add(WaterList, water);
        }
        public Water GetWaterInfo(DateTime fromDate, DateTime toDate)
        {
            return base.Load<Water>().SingleOrDefault(i => i.FromDate == fromDate && i.ToDate == i.ToDate);
        }
        public Water GetWaterLastInfo()
        {
            return base.GetLastInfo();
        }
        public void DeleteLast()
        {
            WaterList.RemoveAt(WaterList.Count - 1);
            Save();
        }

        public void SetNewWaterData(string serviceName,
                                    double price,
                                    int volumeLast,
                                    int volumeNow,
                                    DateTime fromDate,
                                    DateTime toDate)
        {
            newWaterData = new Water(serviceName, price, volumeLast, volumeNow, fromDate, toDate);
        }
        public void Save()
        {
            base.Save(WaterList);
        }
    }
}
