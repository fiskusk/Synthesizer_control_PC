using System;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;
using Newtonsoft.Json;

namespace Synthesizer_PC_control.Utilities
{
    public enum DataType
    {
        DEFAULTS = 1,
        WINDOW = 2,
        MEMORY = 3
    }
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

        public static bool SaveFile(out string filename)
        {
            SaveFileDialog file = new SaveFileDialog();
            // string location = file.InitialDirectory;
            //location = @"C:\Users\"
            file.Title = "Save Configuration File";
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

        public static bool SaveFile(out string filename, string fileName)
        {
            SaveFileDialog file = new SaveFileDialog();
            // string location = file.InitialDirectory;
            //location = @"C:\Users\"
            file.Title = "Save Configuration File";
            file.Filter = "Json files (*.json)|*.json|All files (*.*)|*.*"; // default filter
            file.FilterIndex = 1;
            file.RestoreDirectory = true;
            file.FileName = fileName;

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

    #region Workspace part

        public static bool SaveWorkspaceData(SaveWindow saved)
        {
            try
            {
                string fileName = GetFileNamePath(@"saved_workspace.json");

                saved.dataType = DataType.WINDOW;   // set saved type as WINDOW

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
            bool success;
            try
            {
                string fileName = GetFileNamePath(@"saved_workspace.json");

                // if saved data doesn't exist, create it from default data
                if (!File.Exists(fileName))
                {
                    settings_loaded = SaveWindow.GetDefaultSaveWindow();
                    SaveWorkspaceData(settings_loaded);
                    success = true;
                }
                else
                {
                    settings_loaded = JsonConvert.DeserializeObject<SaveWindow>(File.ReadAllText(fileName));
                    if (settings_loaded.dataType != DataType.WINDOW)
                        success = false;
                    else
                        success = true;
                }

                // now exists, so load it into workspace, but use save window from before
                return success;
            }
            catch
            {
                settings_loaded = null;
                return false;
            }
        }

    #endregion

    #region Default registers part
        public static bool SaveDefRegsData(SaveDefaults saved)
        {
            try
            {
                string fileName = GetFileNamePath(@"default.json");

                saved.dataType = DataType.DEFAULTS;

                // serialize JSON to a string and then write string to a file
                File.WriteAllText(fileName, JsonConvert.SerializeObject(saved, Formatting.Indented));
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool SaveDefRegsData(SaveDefaults saved, string path)
        {
            try
            {
                saved.dataType = DataType.DEFAULTS;
                // serialize JSON to a string and then write string to a file
                File.WriteAllText(path, JsonConvert.SerializeObject(saved, Formatting.Indented));
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool LoadDefRegsData(out SaveDefaults settings_loaded)
        {
            try
            {
                bool success;
                string fileName = GetFileNamePath(@"default.json");

                settings_loaded = JsonConvert.DeserializeObject<SaveDefaults>(File.ReadAllText(fileName));

                if (settings_loaded.dataType != DataType.DEFAULTS)
                    success = false;
                else
                    success = true;
                return success;
            }
            catch
            {
                settings_loaded = null;
                return false;
            }
        }

        public static bool LoadDefRegsData(out SaveDefaults settings_loaded, string path)
        {
            try
            {
                bool success;
                
                settings_loaded = JsonConvert.DeserializeObject<SaveDefaults>(File.ReadAllText(path));
                
                if (settings_loaded.dataType != DataType.DEFAULTS)
                    success = false;
                else
                    success = true;
                return success;
            }
            catch
            {
                settings_loaded = null;
                return false;
            }
        }

    #endregion
    
    #region Memory registers part

        public static bool SaveMemRegsData(SaveMemories saved, string path)
        {
            try
            {
                saved.dataType = DataType.MEMORY;

                // serialize JSON to a string and then write string to a file
                File.WriteAllText(path, JsonConvert.SerializeObject(saved, Formatting.Indented));

                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool LoadMemRegsData(out SaveMemories settings_loaded, string path)
        {
            try
            {
                bool success;
                settings_loaded = JsonConvert.DeserializeObject<SaveMemories>(File.ReadAllText(path));

                if (settings_loaded.dataType != DataType.MEMORY)
                    success = false;
                else
                    success = true;
                return success;
            }
            catch
            {
                settings_loaded = null;
                return false;
            }
        }

    #endregion

    }
}
