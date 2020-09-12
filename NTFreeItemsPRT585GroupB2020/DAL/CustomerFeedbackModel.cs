using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NTFreeItemsPRT585GroupB2020.Model
{
    
    public class CustomerFeedback
    {
        [Key]
        public int FeedbackId { get; set; }

        public int Userid { get; set; }

        public string Feedback { get; set; }


        public DateTime CreatedTs { get; set; }

        public string UserType { get; set; }

        public string UserName { get; set; }
    }
}
