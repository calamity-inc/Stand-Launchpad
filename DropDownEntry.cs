using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stand_Launchpad
{
	internal class DropDownEntry
	{
		public int Id { get; set; }
		public string Name { get; set; }

		public DropDownEntry(int id, string name) 
		{
			Id = id;
			Name = name;
		}
	}
}
