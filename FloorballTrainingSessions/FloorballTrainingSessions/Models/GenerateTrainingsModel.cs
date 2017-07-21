using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FloorballTrainingSessions
{
    public partial class GenerateTrainings
    {
        public GenerateTrainings()
        {
            

        }
       
        public string CurrentUser { get; set; }
        public int CurrentPlayer { get; set; }
        public string CurrentPlayerName { get; set; }
        public int SelectedSeason { get; set; }
        public string SelectedSeasonName { get; set; }
        public int SelectedTeam { get; set; }
        public string SelectedTeamName { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public int dayinweek { get; set; }
        public int SeasonPart { get; set; }
        public int TrainingLocation { get; set; }
        public int TrainingFocus { get; set; }
        public int TrainingSchemeModel { get; set; }
        public int TrainingLength { get; set; }
        public int Weekday { get; set; }
        public int SigningLimitDaysAhead { get; set; }
        public DateTime TrainingTime { get; set; }
        public DateTime SigningTime { get; set; }
        public DateTime MeetTime { get; set; }



    }
    public partial class DayInWeek
    {
        public DayInWeek()
        {
            

        }
        public int day { get; set; }
        public string dayname { get; set; }
    }
}



