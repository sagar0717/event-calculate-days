using System;
using System.Collections.Generic;
using System.Xml;

namespace CalculateDays.ExternalData
{
    public class LoadDataXML
    {
        public static List<EventDetails> events = new List<EventDetails>();

        /// <summary>
        /// This function get the details of input source in our case XML file and parse it store the value in 
        /// EventDetails object.
        /// </summary>
        public void Loaddata(string path)
        {
            try
            {
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
