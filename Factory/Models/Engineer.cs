using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System;

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
		public bool EngineerWorkStatus {get;set;}

		[DisplayName ("name")]
		[DataType(DataType.Date)]
		[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
		public DateTime EngineerHireDate {get;set;}
		public DateTime EngineerNextCertificationDate {get;set;}

		public virtual ICollection<EngineerMachine> Machines {get;set;}
	}
}
