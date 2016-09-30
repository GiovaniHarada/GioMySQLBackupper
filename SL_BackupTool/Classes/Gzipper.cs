using System;
using System.IO;
using ICSharpCode.SharpZipLib.GZip;

namespace SL_BackupTool
{
	public class Gzipper
	{
		public Gzipper ()
		{
			
		}
		public static string gzip(string filepath, string filename){
			string tfile = string.Format ("{0}{1}", filepath, filename);
			Stream s = new GZipOutputStream(File.Create(tfile + ".gz"));
			FileStream fs = File.OpenRead(tfile);
			int size;
			byte[] data = new byte[2048];
			do
			{
				size = fs.Read(data, 0, data.Length);
				s.Write(data, 0, size);
			} while (size > 0);
			s.Close();
			fs.Close();

			return string.Format("{0}.gz", filename);
		}
			
	}
}

