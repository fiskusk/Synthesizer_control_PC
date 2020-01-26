using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Windows.Forms;
using System.Drawing;
using System.Diagnostics;
using Newtonsoft.Json;
using static Synthesizer_PC_control.Form1;

namespace Synthesizer_PC_control.Utilities
{
    class FilesManager
    {
        /// <summary>
        /// Loads file to filename using basic Windows Forms dialog
        /// </summary>
        /// <param name="filename"> output filename </param>
        /// <returns> suuces of operation </returns>
        public static bool LoadFile(out string filename)
        {
            OpenFileDialog file = new OpenFileDialog();
            // string location = file.InitialDirectory;
            //location = @"C:\Users\"
            file.Title = "Open Configuration File";
            file.Filter = "Json files (*.json)|*.json|All files (*.*)|*.*"; // default filter
            file.FilterIndex = 1;
            file.RestoreDirectory = true;

            if (file.ShowDialog() == DialogResult.OK)
            {
                filename = file.FileName;
                return true;
            }
            else
            {
                filename = String.Empty;
                return false;
            }
        }

        public static string GetFileNamePath(string fileName)
        {
            string actual_dir = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);
            if (!Directory.Exists(actual_dir + @"\conf\"))
                Directory.CreateDirectory(Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName) + @"\conf\");
            string folder = actual_dir + @"\conf\";
            return folder + fileName;
        }

        public static bool SaveWorkspaceData(SaveWindow saved)
        {
            try
            {
                string fileName = GetFileNamePath(@"saved_workspace.json");

                // serialize JSON to a string and then write string to a file
                File.WriteAllText(fileName, JsonConvert.SerializeObject(saved, Formatting.Indented));
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool LoadSavedWorkspaceData(out SaveWindow settings_loaded)
        {
            try
            {
                string fileName = GetFileNamePath(@"saved_workspace.json");

                // if saved data doesn't exist, create it from default data
                if (!File.Exists(fileName))
                {
                    settings_loaded = SaveWindow.GetDefaultSaveWindow();
                    SaveWorkspaceData(settings_loaded);
                }
                else
                {
                    settings_loaded = JsonConvert.DeserializeObject<SaveWindow>(File.ReadAllText(fileName));
                }

                // now exists, so load it into workspace, but use save window from before
                return true;
            }
            catch
            {
                settings_loaded = null;
                return false;
            }
        }
    }
}
