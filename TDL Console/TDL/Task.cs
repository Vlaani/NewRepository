using System.Runtime.Serialization;

namespace TDL
{
    [DataContract]
    class Task
    {
        [DataMember]
        public string Text { get; set; }
        [DataMember]
        public string Priority { get; set; }
        [DataMember]
        public string Date { get; set; }
        public Task(string text, string prority=null, string date=null)
            {
            Text = text;
            Priority = prority;
            Date = date;
            }
    }
}