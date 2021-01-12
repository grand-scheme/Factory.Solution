using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Factory.Models
{
	public class Engineer
	{
		public Engineer()
		{
			this.Machines = new HashSet<EngineerMachine>();
		}
		public int EngineerId {get;set;}
		
		[DisplayName("Engineer Name:")]
		public string EngineerName {get;set;}
		[DisplayName("Engineer Title:")]
		public string EngineerDescription {get;set;}
		
		[DisplayName("Engineer Hire Date:")]
		[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyy-MM-dd}")]
		public DateTime EngineerHireDate {get;set;}

		[DisplayName("Engineer Next Certification Date:")]
		[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyy-MM-dd}")]
		public DateTime EngineerNextCertificationDate {get;set;}
		
		public virtual ICollection<EngineerMachine> Machines {get;set;}
	}
}
