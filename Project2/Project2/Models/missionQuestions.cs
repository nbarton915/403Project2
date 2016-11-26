using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Project2.Models
{
    [Table(missionQuestions)]
    public class missionQuestions
    {
        [Key]
        public int QuestionID { get; set; }
        public int missionID { get; set; }
        public int userID { get; set; }
        public string question { get; set; }
        public string answer { get; set; }

    }
}