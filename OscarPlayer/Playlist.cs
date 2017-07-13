using System;
using System.Collections.Generic;
using System.IO;

namespace OscarPlayer
{
    [Serializable]
    public class Playlist
    {

        public static string _strPlayListPath = Directory.GetCurrentDirectory() + "/Playlist/Playlist.lst";
        private List<string> lstPath = new List<string>();

        public string ParsePathToFile(string path)
        {
            this.lstPath.Add(path);
            int pos = path.LastIndexOf(@"\", StringComparison.Ordinal);
            return path.Substring(pos + 1);
        }

        public void ClearList()
        {
            this.lstPath.Clear();
        }

        public void DeletePathFromList(int pos)
        {
            this.lstPath.RemoveAt(pos);
        }

        public List<string> ReadPathsFromList()
        {
            return this.lstPath;
        }

        public string GetFile()
        {
            return Directory.GetCurrentDirectory() + "/Playlist/Playlist.lst";
        }

        public string GetDirectory()
        {
            return Directory.GetCurrentDirectory() + "/Playlist";
        }
    }
}
