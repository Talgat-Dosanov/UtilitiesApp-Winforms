using CommunalApp_Winforms.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CommunalApp_Winforms.Controller
{
    public class GasController : ControllerBase<Gas>
    {
        public List<Gas> GasList { get; }

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
    }
}
