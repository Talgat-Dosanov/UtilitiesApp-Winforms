using System.Collections.Generic;
using System.Linq;

namespace CommunalApp_Winforms.Controller
{
    public abstract class ControllerBase<T> : SerializableSaver
    {
        public List<T> GetAllItems()
        {
            return base.Load<T>() ?? new List<T>();
        }
        public void Add(List<T> items, T item)
        {
            items.Add(item);
            Save(items);
        }
        private void Save(List<T> Service)
        {
            base.Save(Service);
        }
        public T GetLastInfo()
        {
            return base.Load<T>().LastOrDefault();
        }
        
    }
}
