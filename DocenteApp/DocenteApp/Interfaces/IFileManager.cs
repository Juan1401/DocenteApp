using System;
using System.Collections.Generic;
using System.Text;

namespace DocenteApp.Interfaces
{
    public interface IFileManager  
    {
        bool SaveText(string filename, string text, bool overWrite = true);
        string LoadText(string filename);
        bool exist(string filename, string path = "");
        bool delete(string filename, string documentsPath = "");
        string getFullPath();

    }
}
