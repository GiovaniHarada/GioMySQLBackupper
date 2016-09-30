using System;
using Newtonsoft.Json;
using System.Net;
using System.IO;
using System.Text;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;


namespace SL_BackupTool
{
	class MainClass
	{
		public static void Main (string[] args)
		{	
			string JSONcontent = File.ReadAllText ("settings.json");
			info infos = JsonConvert.DeserializeObject<info> (JSONcontent);

			FTPTool ftp = new FTPTool ();
			SQLDump dump = new SQLDump ();
			dump.setUser (infos.SQLuser);
			dump.setPass (infos.SQLpass);

			ftp.setFtp (infos.FTPadress);
			ftp.setUser (infos.FTPuser);
			ftp.setPass (infos.FTPpass);


			string filename = dump.generate ();
			Console.WriteLine ("SQL Dump saved to {0}{1}", System.AppDomain.CurrentDomain.BaseDirectory, filename);
			Logger.logar (string.Format ("SQL Dump saved to {0}{1}", System.AppDomain.CurrentDomain.BaseDirectory, filename));
			string filegzip = Gzipper.gzip (System.AppDomain.CurrentDomain.BaseDirectory, filename);
			Console.WriteLine ("SQL Dump gziped to {0}{1}", System.AppDomain.CurrentDomain.BaseDirectory, filegzip);
			Logger.logar (string.Format ("SQL Dump gziped to {0}{1}", System.AppDomain.CurrentDomain.BaseDirectory, filegzip));

			ftp.setFile (filegzip);
			ftp.upload ();
			Logger.logar (string.Format("File {0} uploaded to the backupcentral", filegzip));
			Console.WriteLine (string.Format("File {0} uploaded to the backupcentral", filegzip));
			dump.delete (filename);
			Logger.logar (string.Format("File {0} deleted", filename));
			Console.WriteLine (string.Format("File {0} deleted", filename));

		}


	}
}
