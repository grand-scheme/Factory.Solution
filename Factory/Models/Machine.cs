using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System;

namespace Factory.Models
{
	public class Machine
	{
		public Machine()
		{
			this.Engineers = new HashSet<EngineerMachine>();
		}
		public int MachineId {get;set;}
		public string MachineName {get;set;}
		public bool MachineOnlineStatus {get;set;}

		// [DisplayName ("")]
		[DataType(DataType.Date)]
		[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString ="{0:yyyy-MM-dd}")]
		public DateTime MachineInstallDate {get;set;}
		public DateTime MachineNextInspectionDate {get;set;}

		public virtual ICollection<EngineerMachine> Engineers {get;set;}
	}
}