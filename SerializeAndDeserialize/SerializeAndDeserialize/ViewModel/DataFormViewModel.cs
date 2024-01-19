using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace SerializeAndDeserialize
{
    public class DataFormViewModel
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="BusinessObjectViewModel" /> class.
        /// </summary>
        public DataFormViewModel()
        {
            this.IntializeAppoitments();
            this.DisplayDate = DateTime.Now.Date.AddHours(8).AddMinutes(50);
        }

        #endregion Constructor

        #region Properties

        /// <summary>
        /// Gets or sets the schedule display date.
        /// </summary>
        public DateTime DisplayDate { get; set; }

        /// <summary>
        /// Gets or sets appointments.
        /// </summary>
        public ObservableCollection<Event> Events { get; set; }

        #endregion

        #region Methods



        /// <summary>
        /// Method to initialize the appointments.
        /// </summary>
        private void IntializeAppoitments()
        {
            this.Events = new ObservableCollection<Event>();

            Event clientMeeting = new Event();
            DateTime currentDate = DateTime.Now.AddDays(1);
            DateTime startTime = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, 10, 0, 0);
            DateTime endTime = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, 12, 0, 0);
            clientMeeting.From = startTime;
            clientMeeting.To = endTime;
            clientMeeting.Background = new SolidColorBrush(Colors.Red);
            clientMeeting.EventName = "ClientMeeting";


            var json = JsonConvert.SerializeObject(clientMeeting, new JsonSerializerSettings
            {
                Converters = new JsonConverter[] { new JsonColorConverter() }
            });

            Event test = JsonConvert.DeserializeObject<Event>(json, new JsonSerializerSettings
            {
                Converters = new JsonConverter[] { new JsonColorConverter() }
            });

            this.Events.Add(test);
        }   

        #endregion
    }
}