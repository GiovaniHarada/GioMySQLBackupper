using System;
using System.Net;
using System.Diagnostics;

namespace SL_BackupTool
{
	public class FTPTool
	{
		public FTPTool ()
		{

		}
		private string user;
		private string pass;
		private string file;
		private string ftpserver;
		public void setUser(string puser){
			this.user = puser;
		}
		public void setPass(string ppass){
			this.pass = ppass;
		}
		public void setFile(string pfile){
			this.file = pfile;
		}
		public void setFtp(string pftp){
			this.ftpserver = pftp;
		}
		public void upload(){
			string executavel = "curl";
			string argumentos = String.Format("-T {0} {1} --user {2}:{3}",this.file, this.ftpserver, this.user, this.pass);

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

