using System.Collections.Generic;
using System.IO;
using ICSharpCode.SharpZipLib.Zip;

namespace Flow
{
    public class OutputWriter
    {
        List<string> _commands = new List<string>();

        public void AddString(string myString)
        {
            _commands.Add(myString);
        }

        public void WriteOutputFile(string filename)
        {
            _writeOutputFile(filename, _commands);
        }

        private static void _writeOutputFile(string filename, IEnumerable<string> content)
        {
            var outputPath = "..\\..\\Output\\" + filename + ".out";
            File.WriteAllLines(outputPath, content);
        }
        
        private static void _writeOutputFile(string filename, string content)
        {
            var outputPath = "..\\..\\Output\\" + filename + ".out";
            File.WriteAllText(outputPath, content);
        }

        public static void ExportSourceCodeZip()
        {
            const string zipFileName = "..\\..\\Zip\\Sources.zip";
            const string sourceDirectory = "..\\..\\";
            const bool recurse = false;
            const string fileFilter = "\\.cs$";
            const string directoryFilter = "";

            var fastZip = new FastZip();
            fastZip.CreateZip(zipFileName, sourceDirectory, recurse, fileFilter, directoryFilter);
        }

        public void ResetOutput()
        {
            _commands.Clear();
        }
    }
}
