using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FTMS.Models
{
	public class TraineeInfo
	{
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
    }
}   