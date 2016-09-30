using System;
using System.IO;
using Newtonsoft.Json;

namespace SL_BackupTool
{
	public class info
	{
		public string SQLuser { get; set; }
		public string SQLpass { get; set; }
		public string FTPadress { get; set; }
		public string FTPuser { get; set; }
		public string FTPpass { get; set; }

		public info ()
		{
		}
	}
}

