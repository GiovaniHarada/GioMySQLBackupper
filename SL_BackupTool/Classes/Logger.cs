using System;
using System.IO;

namespace SL_BackupTool
{
	public class Logger
	{
		public Logger ()
		{
		}
		public static void logar(string action){
			DateTime now = DateTime.Now;
			string momento = string.Format ("{0}/{1}/{2} {3}:{4} -> ", now.Day, now.Month, now.Year, now.Hour, now.Minute);
			string textToLog = string.Format ("{0} -- {1}",momento, action);
			string path = "backups.log";

			if (!File.Exists(path))
			{
				string createText = "--LOG DE BACKUPS SLSoluções--" + Environment.NewLine;
				File.WriteAllText(path, createText);
			}
			string appendText = textToLog + Environment.NewLine;
			File.AppendAllText(path, appendText);
		}
	}
}

