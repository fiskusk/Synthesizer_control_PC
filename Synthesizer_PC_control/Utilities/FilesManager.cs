using System;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;
using Newtonsoft.Json;

namespace Synthesizer_PC_control.Utilities
{
    /// <summary>
    /// Type of data (1-DEFAULTS, 2-WINDOW, 3-MEMORY)
    /// </summary>
    public enum DataType
    {
        DEFAULTS = 1,
        WINDOW = 2,
        MEMORY = 3
    }

    /// <summary>
    /// This class is used to work with files. It contains static functions
    /// and these allows saving and loading different files.
    /// </summary>
    class FilesManager
    {
        /// <summary>
        /// Loads file to filename using basic Windows Forms dialog
        /// </summary>
        /// <param name="fileNamePath"> output file name path </param>
        /// <returns> success of operation </returns>
        public static bool LoadFile(out string fileNamePath)
        {
            OpenFileDialog file = new OpenFileDialog();
            // string location = file.InitialDirectory;
            //location = @"C:\Users\"
            file.Title = "Open Configuration File";
            file.Filter = "Json files (*.json)|*.json"; // default file filter
            file.FilterIndex = 1;
            file.RestoreDirectory = true;

            if (file.ShowDialog() == DialogResult.OK)
            {
                fileNamePath = file.FileName;
                return true;
            }
            else
            {
                fileNamePath = String.Empty;
                return false;
            }
        }

        /// <summary>
        /// gets file name path for save using basic Windows Forms dialog
        /// </summary>
        /// <param name="fileNamePath"> output file name path </param>
        /// <returns> success of operation </returns>
        public static bool SaveFile(out string fileNamePath)
        {
            SaveFileDialog file = new SaveFileDialog();
            // string location = file.InitialDirectory;
            //location = @"C:\Users\"
            file.Title = "Save Configuration File";     // title of Dialog
            file.Filter = "Json files (*.json)|*.json"; // default filter
            file.FilterIndex = 1;                       // Selected filter
            file.RestoreDirectory = true;

            if (file.ShowDialog() == DialogResult.OK)
            {
                fileNamePath = file.FileName;
                return true;
            }
            else
            {
                fileNamePath = String.Empty;
                return false;
            }
        }

        /// <summary>
        /// gets file name path for save using basic Windows Forms dialog
        /// with predefined file name
        /// </summary>
        /// <param name="fileNamePath"> output path to fileName </param>
        /// <param name="fileName"> predefined file name </param>
        /// <returns> success of operation </returns>
        public static bool SaveFile(out string fileNamePath, string fileName)
        {
            SaveFileDialog file = new SaveFileDialog();
            // string location = file.InitialDirectory;
            //location = @"C:\Users\"
            file.Title = "Save Configuration File";
            file.Filter = "Json files (*.json)|*.json"; // default filter
            file.FilterIndex = 1;
            file.RestoreDirectory = true;
            file.FileName = fileName;

            if (file.ShowDialog() == DialogResult.OK)
            {
                fileNamePath = file.FileName;
                return true;
            }
            else
            {
                fileNamePath = String.Empty;
                return false;
            }
        }

        /// <summary>
        /// Returns the complete file path, and create 'conf' folder, if does not exist
        /// </summary>
        /// <param name="fileName"> file name at the end of path </param>
        /// <returns> Complete file path </returns>
        public static string GetFileNamePath(string fileName)
        {
            string actual_dir = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);
            if (!Directory.Exists(actual_dir + @"\conf\"))
                Directory.CreateDirectory(Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName) + @"\conf\");
            string folder = actual_dir + @"\conf\";
            return folder + fileName;
        }

    #region Workspace part
        /// <summary>
        /// Save workspace data into json file */conf/saved_workspace.json
        /// </summary>
        /// <param name="data"> Data to be saved </param>
        /// <returns> returns true if the save occurred correctly, false if an error occurred </returns>
        public static bool SaveWorkspaceData(SaveWindow data)
        {
            try
            {
                string fileName = GetFileNamePath(@"saved_workspace.json");

                data.dataType = DataType.WINDOW;   // sets saved type as WINDOW

                // serialize JSON to a string and then write string to a file
                File.WriteAllText(fileName, JsonConvert.SerializeObject(data, Formatting.Indented));
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Load data from json file */conf/saved_workspace.json
        /// </summary>
        /// <param name="settings_loaded"> loaded data </param>
        /// <returns> success of operation </returns>
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
                    // deserialize JSON file into SaveWindow class
                    settings_loaded = JsonConvert.DeserializeObject<SaveWindow>(File.ReadAllText(fileName));

                    // return the error if the data type is not set to 'WINDOW'
                    if (settings_loaded.dataType != DataType.WINDOW)
                        success = false;
                    else
                        success = true;
                }

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

        /// <summary>
        /// Save workspace data into json file */conf/default.json
        /// </summary>
        /// <param name="data"> data to be saved </param>
        /// <returns> success of operation </returns>
        public static bool SaveDefRegsData(SaveDefaults data)
        {
            try
            {
                string fileName = GetFileNamePath(@"default.json");

                data.dataType = DataType.DEFAULTS;  // sets saved type as DEFAULTS

                // serialize JSON to a string and then write string to a file
                File.WriteAllText(fileName, JsonConvert.SerializeObject(data, Formatting.Indented));
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Save workspace data into json file with specified path
        /// </summary>
        /// <param name="data"> Data to be stored </param>
        /// <param name="path"> path including file name </param>
        /// <returns> success of operation </returns>
        public static bool SaveDefRegsData(SaveDefaults data, string path)
        {
            try
            {
                data.dataType = DataType.DEFAULTS;  // sets saved type as DEFAULTS
                // serialize JSON to a string and then write string to a file
                File.WriteAllText(path, JsonConvert.SerializeObject(data, Formatting.Indented));
                return true;
            }
            catch
            {
                return false;
            }
        }
        
        /// <summary>
        /// Load default registers data from json file */conf/default.json
        /// </summary>
        /// <param name="settings_loaded"> loaded data </param>
        /// <returns> success of operation </returns>
        public static bool LoadDefRegsData(out SaveDefaults settings_loaded)
        {
            try
            {
                bool success;
                string fileName = GetFileNamePath(@"default.json");

                settings_loaded = JsonConvert.DeserializeObject<SaveDefaults>(File.ReadAllText(fileName));

                // check if correct type is loaded
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

        /// <summary>
        /// Load default registers data from json file with specified path
        /// </summary>
        /// <param name="settings_loaded"> data to be loaded </param>
        /// <param name="path"> path including file name</param>
        /// <returns> success of operation </returns>
        public static bool LoadDefRegsData(out SaveDefaults settings_loaded, string path)
        {
            try
            {
                bool success;
                
                settings_loaded = JsonConvert.DeserializeObject<SaveDefaults>(File.ReadAllText(path));

                // check if correct type is loaded
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

        /// <summary>
        /// Save memory registers data into json file with specified path
        /// </summary>
        /// <param name="data"> Data to be stored </param>
        /// <param name="path"> path including file name </param>
        /// <returns> success of operation </returns>
        public static bool SaveMemRegsData(SaveMemories data, string path)
        {
            try
            {
                data.dataType = DataType.MEMORY;    // sets saved type as MEMORY

                // serialize JSON to a string and then write string to a file
                File.WriteAllText(path, JsonConvert.SerializeObject(data, Formatting.Indented));

                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Load memory registers data from json file with specified path
        /// </summary>
        /// <param name="settings_loaded"> data to be loaded </param>
        /// <param name="path"> path including file name</param>
        /// <returns> success of operation </returns>
        public static bool LoadMemRegsData(out SaveMemories settings_loaded, string path)
        {
            try
            {
                bool success;
                settings_loaded = JsonConvert.DeserializeObject<SaveMemories>(File.ReadAllText(path));

                // check if correct type is loaded
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

    #region VCO Calibration
        public static bool VcoCalibDataFileExist()
        {
            string fileName = GetFileNamePath(@"vcoCalibration.txt");
            return File.Exists(fileName);
        }
        public static bool DeleteVcoCalibData()
        {
            try
            {
                string fileName = GetFileNamePath(@"vcoCalibration.txt");
                File.Delete(fileName);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool SaveVcoCalibData(decimal frequency, UInt16 vco, decimal frequencyStep)
        {
            try
            {
                string fileName = GetFileNamePath(@"vcoCalibration.txt");

                if (!File.Exists(fileName))
                {
                    // Create a file to write to.
                    using (StreamWriter sw = File.CreateText(fileName))
                    {
                        sw.WriteLine("#FreqMin = \t3000\tMHz");
                        sw.WriteLine("#FreqMax = \t6000\tMHz");
                        sw.WriteLine("#FreqStep = \t" + frequencyStep.ToString("0.000") + "\tMHz");
                        sw.WriteLine("#");
                        sw.WriteLine("#Freq\t\tVCO-ID");
                    }	
                }

                using (StreamWriter sw = File.AppendText(fileName))
                {
                    sw.WriteLine(frequency.ToString("0.000") + "\t" + vco.ToString());
                }	
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool LoadVcoCalibrationData(out decimal[] calibrationData)
        {
            calibrationData = new decimal[0];
            try
            {
                string fileName = GetFileNamePath(@"vcoCalibration.txt");
                if (File.Exists(fileName))
                {
                    decimal freqMin = 0;    // MHz
                    decimal freqMax = 0;    // MHz
                    decimal freqStep = 0;   // MHz
                    UInt16 headerLines = 0;
                    int calibTableLine = 0;

                    foreach (string line in File.ReadLines(fileName))
                    {
                        string[] separrated;
                        if (line.Contains("#"))
                        {
                            headerLines++;
                            if (line.Contains("#FreqMin"))
                            {
                                separrated = line.Split('\t');
                                freqMin = Convert.ToDecimal(separrated[1]);
                            }
                            else if (line.Contains("#FreqMax"))
                            {
                                separrated = line.Split('\t');
                                freqMax = Convert.ToDecimal(separrated[1]);
                            }
                            else if (line.Contains("#FreqStep"))
                            {
                                separrated = line.Split('\t');
                                freqStep = Convert.ToDecimal(separrated[1]);
                                calibrationData = new decimal[Convert.ToInt32((freqMax-freqMin)/freqStep) + 1 + 3];
                                calibrationData[0] = freqMin;
                                calibrationData[1] = freqMax;
                                calibrationData[2] = freqStep;
                            }
                        }
                        else 
                        {
                            separrated = line.Split('\t');
                            calibrationData[calibTableLine+3] =  Convert.ToDecimal(separrated[1]);
                            calibTableLine++;
                        }
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

    #endregion
    }
}
