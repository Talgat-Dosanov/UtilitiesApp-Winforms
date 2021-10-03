using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace CommunalApp_Winforms.Controller
{
    public class SerializableSaver
    {
        public List<T> Load<T>()
        {
            var formatter = new BinaryFormatter();
            var filename = typeof(T).Name;
            using (var fs = new FileStream(filename, FileMode.OpenOrCreate))
            {
                if (fs.Length > 0 && formatter.Deserialize(fs) is List<T> items)
                {
                    return items;
                }
                else
                {
                    return new List<T>();
                }
            }
        }
        public void Save<T>(List<T> item)
        {
            var formatter = new BinaryFormatter();
            var filename = typeof(T).Name;
            using (var fs = new FileStream(filename, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, item);
            }
        }
    }
}
