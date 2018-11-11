using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace CalculateDays.ExternalData
{
    public class LoadDataXML
    {
        public static List<EventDetails> events = new List<EventDetails>();
        public void Loaddata()
        {
            try
            {
                string path = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\CalculateDays.ExternalData\Resources"));
                XmlDocument xd = new XmlDocument();
                xd.Load(path + @"\EventDates.xml");
                XmlNodeList nodelist = xd.SelectNodes("/Events/Event");
                foreach (XmlNode node in nodelist) //for each Event Node
                {
                    string eventId = node.Attributes.GetNamedItem("id").Value;
                    string eventStartDate = node.ChildNodes.Item(0).InnerText;
                    string eventEndDate = node.ChildNodes.Item(1).InnerText;
                    events.Add(new EventDetails
                    {
                        EventId = eventId,
                        EventStartDate = eventStartDate,
                        EventEndDate = eventEndDate
                    });
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }

    }
}
