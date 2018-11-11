namespace CalculateDays.ExternalData
{
    /// <summary>
    /// This class contains the details of an event i.e eventId, start date and end date to store the values from 
    /// Input source
    /// </summary>
    public class EventDetails
    {
        private string _eventId;
        private string _eventStartDate;
        private string _eventEndDate;

        public string EventId
        {
            get
            {
                return this._eventId;
            }
            set
            {
                this._eventId = value;
            }
        }
        public string EventStartDate
        {
            get
            {
                return this._eventStartDate;
            }
            set
            {
                this._eventStartDate = value;
            }
        }

        public string EventEndDate
        {
            get
            {
                return this._eventEndDate;
            }
            set
            {
                this._eventEndDate = value;
            }
        }
    }
}
