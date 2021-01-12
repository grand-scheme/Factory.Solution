using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace Factory.Models
{
	public class Machine
	{
		public Machine()
		{
			this.Engineers = new HashSet<EngineerMachine>();
		}
		public int MachineId {get;set;}
		
		[DisplayName("Machine Name:")]
		public string MachineName {get;set;}
		[DisplayName("Machine Function:")]
		public string MachineDescription {get;set;}

		// [DataType(DataType.Date)]
		[DisplayName("Install Date:")]
		[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString ="{0:yyyy-MM-dd}")]
		public DateTime MachineInstallDate {get;set;}
		
		// [DataType(DataType.Date)]
		[DisplayName("Next Inspection Date:")]
		[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString ="{0:yyyy-MM-dd}")]
		public DateTime MachineNextInspectionDate {get;set;}
		
		public virtual ICollection<EngineerMachine> Engineers {get;set;}
	}
}