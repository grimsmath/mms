using MMS.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace MMS.ViewModels
{
	public class ChaplainViewModel
	{
        public int PersonId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public int MinistryId { get; set; }
        public string MinistryName { get; set; }
        public int ProfileId { get; set; }
        public string Username { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
	}
}