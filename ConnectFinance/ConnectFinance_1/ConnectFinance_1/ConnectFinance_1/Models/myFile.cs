using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ConnectFinance_1.Models
{
   public class myFile
    {
	    public static  void WriteFiles(string texte)
	    {
			//Ecrire dans un fichier, 
			string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			string filename = Path.Combine(path, "myfile.txt");

		    using (var streamWriter = new StreamWriter(filename, true))
		    {
			    streamWriter.WriteLine(texte);
			    streamWriter.Close();
		    }
	    }

	   public static void ReadFiles()
	   {
			//Lire un fichier
			string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			string filename = Path.Combine(path, "myfile.txt");
			using (var streamReader = new StreamReader(filename, true))
			{
				streamReader.Read();
				streamReader.Close();
			}
		}
    }
}
