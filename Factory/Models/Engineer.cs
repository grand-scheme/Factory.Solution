using System;
using System.Collections.Generic;
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
		
		public string EngineerName {get;set;}
		public string EngineerDescription {get;set;}
		
		[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyy-MM-dd}")]
		public DateTime EngineerHireDate {get;set;}

		[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyy-MM-dd}")]
		public DateTime EngineerNextCertificationDate {get;set;}
		
		public virtual ICollection<EngineerMachine> Machines {get;set;}
	}
}
