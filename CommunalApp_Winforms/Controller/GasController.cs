using CommunalApp_Winforms.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CommunalApp_Winforms.Controller
{
    public class GasController : ControllerBase<Gas>
    {
        public List<Gas> GasList { get; private set; }
        public Gas newGasData { get; private set; }
        public GasController()
        {
            GasList = base.GetAllItems();
        }
        public void Add(Gas gas)
        {
            base.Add(GasList, gas);
            base.Save(GasList);
        }
        public Gas GetGasInfo(DateTime fromDate, DateTime toDate)
        {
            return Load<Gas>().SingleOrDefault(i => i.FromDate == fromDate && i.ToDate == i.ToDate);
        }
        public Gas GetGasLastInfo()
        {
            return base.GetLastInfo();
        }
        public void SetNewGasData(double price,
                                    double volumeLast,
                                    double volumeNow,
                                    DateTime fromDate,
                                    DateTime toDate)
        {
            newGasData = new Gas(price, volumeLast, volumeNow, fromDate, toDate);
        }
    }
}
