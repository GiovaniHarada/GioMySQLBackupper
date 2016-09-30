using System;
using System.Diagnostics;
using System.IO;

namespace SL_BackupTool
{
	public class SQLDump
	{
		private string user;
		private string pass;
		public SQLDump (){
			
		}
		public void setUser(string puser){
			this.user = puser;
		}
		public void setPass(string ppass){
			this.pass = ppass;
		}
		public string generate(){
			DateTime now = DateTime.Now;
			string dumpname = String.Format("SL_Dump_{0}_{1}_{2}.sql", now.Day, now.Month, now.Year);
			string executavel = "mysqldump";
			string argumentos = String.Format("-u {0} -p{1} --result-file={2} --all-databases", this.user, this.pass, dumpname);

			var info = new ProcessStartInfo();
			info.FileName = executavel;
			info.Arguments = argumentos;

			info.UseShellExecute = false;
			info.CreateNoWindow = true;

			info.RedirectStandardOutput = true;
			info.RedirectStandardError = true;

			var p = Process.Start(info);

			p.WaitForExit();
			return dumpname;
		}
		public void delete(string filename){
			string executavel = "rm";
			string argumentos = String.Format("{0}", filename);
			var info = new ProcessStartInfo();
			info.FileName = executavel;
			info.Arguments = argumentos;
			info.UseShellExecute = false;
			info.CreateNoWindow = true;
			info.RedirectStandardOutput = true;
			info.RedirectStandardError = true;
			Process.Start(info);

			return;
		}
	}
}

