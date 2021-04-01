using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace TDL
{
    class AppData
    {
        private const string FileName = "TDL_Data.json";
        public void Save(List<Task> TaskArray)
        {
            string JsonBody = JsonConvert.SerializeObject(TaskArray);
            File.WriteAllText(FileName, JsonBody);
        }
        public List<Task> Load()
        {
            if (File.Exists(FileName))
            {
                string FileBody = File.ReadAllText(FileName);
                 try
                 {
                    List<Task> FinalTaskList = JsonConvert.DeserializeObject<List<Task>>(FileBody) ?? new List<Task>();
                     return FinalTaskList;
                 }
                 catch
                 {

                     return new List<Task>();
                 }
            }
            else
            {
                return new List<Task>();
            }
        }
    }
}
