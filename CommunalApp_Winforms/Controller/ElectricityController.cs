using CommunalApp_Winforms.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CommunalApp_Winforms.Controller
{
    public class ElectricityController : ControllerBase<Electricity>
    {
        public List<Electricity> ElectricityList { get; }
        public Electricity newElectricityData { get; private set; }

        
        public ElectricityController()
        {
            ElectricityList = base.GetAllItems();
        }
        public void Add(Electricity electricity)
        {
            base.Add(ElectricityList, electricity);
            base.Save(ElectricityList);
        }
        public Electricity GetElectricityInfo(DateTime fromDate, DateTime toDate)
        {
            return Load<Electricity>().SingleOrDefault(i => i.FromDate == fromDate && i.ToDate == i.ToDate);
        }
        public Electricity GetElectricityLastInfo()
        {
            return base.GetLastInfo();
        }
        public void SetNewElectricityData(double price,
                                    double volumeLast,
                                    double volumeNow,
                                    DateTime fromDate,
                                    DateTime toDate)
        {
             newElectricityData = new Electricity(price, volumeLast, volumeNow, fromDate, toDate);
        }

    }
}
