using System.Collections.Generic;

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
    }
}
