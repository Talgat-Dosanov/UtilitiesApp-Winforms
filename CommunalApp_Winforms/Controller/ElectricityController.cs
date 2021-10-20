using CommunalApp_Winforms.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CommunalApp_Winforms.Controller
{
    public class ElectricityController : ControllerBase<Electricity>
    {
        public List<Electricity> ElectricityList { get; private set; }
        public Electricity newElectricityData { get; private set; }

        
        public ElectricityController()
        {
            ElectricityList = base.GetAllItems();
        }
        public void Add(Electricity electricity)
        {
            base.Add(ElectricityList, electricity);
            Save();
            
        }
        public Electricity GetElectricityInfo(DateTime fromDate, DateTime toDate)
        {
            return Load<Electricity>().SingleOrDefault(i => i.FromDate == fromDate && i.ToDate == i.ToDate);
        }
        public Electricity GetElectricityLastInfo()
        {
            return base.GetLastInfo();
        }
        public void SetNewElectricityData(string serviceName,
                                          double price,
                                          int volumeLast,
                                          int volumeNow,
                                          DateTime fromDate,
                                          DateTime toDate)
        {
             newElectricityData = new Electricity(serviceName, price, volumeLast, volumeNow, fromDate, toDate);
        }
        public void DeleteLast()
        {
            ElectricityList.RemoveAt(ElectricityList.Count - 1);
            Save();
        }
        public void Save()
        {
            base.Save(ElectricityList);
        }
        

    }
}
