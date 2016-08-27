using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RocketLeagueModManager
{
    public partial class Main : Form
    {
#if (DEBUG == FALSE)
        private static string rootDirectory = "";
#endif
#if (DEBUG == TRUE)
        private static string rootDirectory = @"D:\SteamLibrary\steamapps\common\rocketleague\";
#endif
        private static string coockedPCConsoleDirectory = @"TAGame\CookedPCConsole";
        private static string modsDirectory = @"Mods";
        private static string rlBinaryLocation = @"Binaries\Win32\RocketLeague.exe";
        private string file;
        private static string[] jsonFileNames = new Json().GetIgnored();
        private bool loadingDone = false;
        //Backup directory
        DirectoryInfo backupDirectory = new DirectoryInfo(rootDirectory + "Backup");

        private string[] installedFiles;

        public Main()
        {
            InitializeComponent();

            lblStockStatus.Text = "Stock satus: OK!";
            lblStockStatus.ForeColor = Color.Green;
            
            // Add extra settings when application starts up.
            System.Configuration.SettingsProperty lmf = new System.Configuration.SettingsProperty("lastModFiles");
            if (lmf.DefaultValue == null)
            {
                lmf.DefaultValue = "Park_P";
                lmf.IsReadOnly = false;
                lmf.PropertyType = typeof(string);
                lmf.Attributes.Add(typeof(System.Configuration.UserScopedSettingAttribute), new System.Configuration.UserScopedSettingAttribute());
                //Properties.Settings.Default.Properties.Add(lmf);
            }

            System.Configuration.SettingsProperty dtu = new System.Configuration.SettingsProperty("defaultToLastUsed");
            if (dtu.DefaultValue == null)
            {
                dtu.DefaultValue = "Null_Just_Do_Not_Name_Your_Mod_Directory_Like_This";
                dtu.IsReadOnly = false;
                dtu.PropertyType = typeof(string);
                dtu.Attributes.Add(typeof(System.Configuration.UserScopedSettingAttribute), new System.Configuration.UserScopedSettingAttribute());
                //Properties.Settings.Default.Properties.Add(dtu);
            }
            // Load settings now.

            //Properties.Settings.Default.Reload();
            Properties.Settings.Default.Save();

            //Create 'Mods' and 'Stock' directory, if non-existant
            DirectoryInfo modsDirectoryInfo = new DirectoryInfo(rootDirectory + modsDirectory);
            if (modsDirectoryInfo.Exists == false)
            {
                Directory.CreateDirectory(rootDirectory + modsDirectory);
                Directory.CreateDirectory(rootDirectory + modsDirectory + "\\Stock");
                MessageBox.Show("Welcome to the Rocket League Mod Manager, to get started, place mods in the 'Mods' directory I've just created for you.\n\nAlso make sure to make a copy of your (unmodified) 'Park_P.upk' file to the 'Mods/Stock' directory.");
            }
            
            DirectoryInfo rlDirectoryInfo = new DirectoryInfo(rootDirectory + coockedPCConsoleDirectory);
            if (rlDirectoryInfo.Exists == false)
            {
                Directory.CreateDirectory(rootDirectory + coockedPCConsoleDirectory);
                MessageBox.Show("Make sure you have extracted the application in your Rocket League root directory.");
            }

        }

        private void Main_Load(object sender, EventArgs e)
        {
            //Show unignored files in the TAGame\CookedPCConsole folder
            getInstalledFiles();

            //Are the installed files modified since last use?
            checkInstalledFiles();

            //Are there mods in the Mods folder?
            checkProvidedMods();

            loadingDone = true;

            //Set checkbox status
            cbLastDefault.Checked = (Properties.Settings.Default["defaultToLastUsed"].ToString() != "Null_Just_Do_Not_Name_Your_Mod_Directory_Like_This") ? true : false;
        }

        private void checkInstalledFiles()
        {
            string[] lastModFiles = Properties.Settings.Default["lastModFiles"].ToString().Split(',');
            if (!lastModFiles.SequenceEqual(installedFiles))
            {
                //Modified file(s) (filenames)
                lblCheckInstalled.Text = "Installed files: modified since last use.";
                lblCheckInstalled.ForeColor = Color.Tomato;
            }
            else
            {
                //Unmodified files
                lblCheckInstalled.Text = "Installed files: unmodified since last use.";
                lblCheckInstalled.ForeColor = Color.Green;
            }
        }

        private void checkProvidedMods()
        {
            DirectoryInfo modsDirectoryInfo = new DirectoryInfo(rootDirectory + modsDirectory + "\\Stock");
            if (modsDirectoryInfo.Exists == false)
            {
                Directory.CreateDirectory(rootDirectory + modsDirectory + "\\Stock");
                MessageBox.Show("You removed all directories in the 'Mods' directory. I have taken the liberty to create the 'Stock' directory again, please copy your (unmodified) 'Park_P.upk' file to it again.");
            }

            string[] moddedFiles = Directory.GetDirectories(rootDirectory + modsDirectory);
            ModComboboxItems mci;
            foreach (string f in moddedFiles)
            {
                file = f;
                file = file.Replace(rootDirectory + modsDirectory, "");
                file = file.Substring(1);
                mci = new ModComboboxItems();
                mci.DirectoryName = file;
                mci.DirectoryLocation = f;
                cmbMods.Items.Add(mci);
            }

            int index = 0;
            bool stockDirectory = false;
            string theSearchForDefault = "Stock";
            mci = new ModComboboxItems();

            if (Properties.Settings.Default["defaultToLastUsed"].ToString() != "Null_Just_Do_Not_Name_Your_Mod_Directory_Like_This")
            {

                DirectoryInfo defaultLastDirectory = new DirectoryInfo(rootDirectory + modsDirectory + "\\" + Properties.Settings.Default["defaultToLastUsed"].ToString());
                if (modsDirectoryInfo.Exists == false)
                {
                    mci.DirectoryName = "Stock";
                    mci.DirectoryLocation = rootDirectory + modsDirectory + @"\Stock";
                }
                else
                {
                    mci.DirectoryName = Properties.Settings.Default["defaultToLastUsed"].ToString();
                    theSearchForDefault = Properties.Settings.Default["defaultToLastUsed"].ToString();
                    mci.DirectoryLocation = rootDirectory + modsDirectory + @"\" + Properties.Settings.Default["defaultToLastUsed"].ToString();
                }
            }
            else
            {
                mci.DirectoryName = "Stock";
                mci.DirectoryLocation = rootDirectory + modsDirectory + @"\Stock";
            }


            foreach (var item in cmbMods.Items)
            {
                //;-; why doesn't break; work with ternary...
                if (item.ToString() == theSearchForDefault) { stockDirectory = true; break; }
                if (index == cmbMods.Items.Count - 1) { index = 0; break; }
                index++;
            }
            if ((index == 0 && !stockDirectory) || (Directory.GetFiles(rootDirectory + modsDirectory + @"\Stock", "Park_P.upk").Length < 1 || Directory.GetFiles(rootDirectory + modsDirectory + @"\Stock", "*.upk").Length > 1))
            {
                lblStockStatus.Text = "Stock status: Error! (Incorrect contents or missing file)";
                lblStockStatus.ForeColor = Color.Tomato;
            }

            cmbMods.SelectedIndex = index;
        }

        private void updateIgnoreList()
        {
            //write default installed files to file... json
            using (System.IO.StreamWriter swFile = new System.IO.StreamWriter("ignore.json", true))
            {
                swFile.WriteLine("[");
                foreach (string f in installedFiles)
                {
                    file = f;
                    file = file.Replace(rootDirectory + coockedPCConsoleDirectory, "");
                    swFile.WriteLine(@"\" + file + @"\");
                }
                swFile.WriteLine("]");
            }
        }

        private void btnBootRL_Click(object sender, EventArgs e)
        {

            //boot RL...
#if (DEBUG == FALSE)
            try
            {

                Process firstProc = new Process();
                firstProc.StartInfo.FileName = rootDirectory + rlBinaryLocation;
                firstProc.EnableRaisingEvents = true;

                firstProc.Start();

                /* //Running... (or nah)
                firstProc.WaitForExit();

                //You may want to perform different actions depending on the exit code.
                Console.WriteLine("First process exited: " + firstProc.ExitCode);

                Process secondProc = new Process();
                secondProc.StartInfo.FileName = "mspaint.exe";
                secondProc.Start();*/

            }
            catch (Exception ex)
            {
                MessageBox.Show("Couldn't launch Rocket League:" + ex.Message);
            }
#endif
        }

        private void cbLastDefault_CheckedChanged(object sender, EventArgs e)
        {
            string defaultLast = (cbLastDefault.Checked) ? cmbMods.SelectedItem.ToString() : "Null_Just_Do_Not_Name_Your_Mod_Directory_Like_This";
            Properties.Settings.Default["defaultToLastUsed"] = defaultLast;
            Properties.Settings.Default.Save();
        }

        private void btnInstallMod_Click(object sender, EventArgs e)
        {
            //Selected mod directory
            string selectedModDirectory = (cmbMods.SelectedItem as ModComboboxItems).DirectoryLocation;

            if (backupDirectory.Exists == false)
            {
                Directory.CreateDirectory(rootDirectory + "Backup");
            }
            else
            {
                //Clear directory for next backup
                foreach (FileInfo file in backupDirectory.GetFiles()) { file.Delete(); }
            }

            //Selected mod directory, all files, including those in sub folders
            List<string> selectedModDirectoryFiles = Directory.GetFiles(selectedModDirectory, "*.upk", SearchOption.AllDirectories).ToList();
            if (selectedModDirectoryFiles.Count == 0) { MessageBox.Show("Selected mod directory seems to contain no '.upk' files."); return; }

            try
            {
                //Move installed files to Backup directory
                foreach (string file in installedFiles)
                {
                    FileInfo mFile = new FileInfo(rootDirectory + coockedPCConsoleDirectory + "\\" + file);
                    mFile.MoveTo(backupDirectory + "\\" + mFile.Name);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Rocket League (or some other application) seems to be using the files that we need to modify. Please close it, or abort it's action and try again.");
                return;
            }
            List<string> unReplacedFiles = new List<string>();
            //Get selected mod files and move to TAGame\CookedPCConsole ("installtion") directory.
            foreach (string file in selectedModDirectoryFiles)
            {
                FileInfo mFile = new FileInfo(file);

                if (new FileInfo(rootDirectory + coockedPCConsoleDirectory + "\\" + mFile.Name).Exists == false)
                {
                    mFile.CopyTo(rootDirectory + coockedPCConsoleDirectory + "\\" + mFile.Name);
                }
                else
                {
                    //File exists already, what do I do?
                    DialogResult dialogResult = MessageBox.Show("File exists, do you want to replace it?", coockedPCConsoleDirectory + "\\" + mFile.Name, MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        (new FileInfo(coockedPCConsoleDirectory + "\\" + mFile.Name)).Delete();
                        mFile.CopyTo(coockedPCConsoleDirectory + "\\" + mFile.Name);
                        MessageBox.Show("The file: " + coockedPCConsoleDirectory + "\\" + mFile.Name + " has been replaced.");
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        unReplacedFiles.Add(coockedPCConsoleDirectory + "\\" + mFile.Name);
                        MessageBox.Show("The file: " + coockedPCConsoleDirectory + "\\" + mFile.Name + " was not replaced.");
                    }
                }
            }
            if (unReplacedFiles.Count > 0)
            {
                string fileList = "";
                foreach (var item in unReplacedFiles)
                {
                    fileList = fileList + ", " + item;
                }
                MessageBox.Show("Installation complete. The following files have not been replaced:\n\n", fileList);
            }
            else
            {
                MessageBox.Show("Installation complete.");
            }

            getInstalledFiles();
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            DirectoryInfo backupDirectory = new DirectoryInfo(rootDirectory + "Backup");
            if (backupDirectory.Exists == false || (Directory.EnumerateFileSystemEntries(backupDirectory.ToString(), "*.upk").Count() < 1))
            {
                MessageBox.Show("No backup available.");
            }
            else
            {
                //temp directory
                DirectoryInfo tempDirectory = new DirectoryInfo(rootDirectory + "Backup" + "\\temp");
                if (tempDirectory.Exists == false)
                {
                    Directory.CreateDirectory(rootDirectory + "Backup" + "\\temp");
                }
                else
                {
                    //Clear directory for next restoration
                    foreach (FileInfo file in tempDirectory.GetFiles()) { file.Delete(); }
                }

                //Move installed files to temp directory
                foreach (string file in installedFiles)
                {
                    FileInfo mFile = new FileInfo(rootDirectory + coockedPCConsoleDirectory + "\\" + file);
                    mFile.MoveTo(tempDirectory + "\\" + mFile.Name);
                }

                //Move backup files to installation directory
                List<string> backupDirectoryFiles = Directory.GetFiles(backupDirectory.ToString(), "*.upk").ToList();
                foreach (string file in backupDirectoryFiles)
                {
                    FileInfo mFile = new FileInfo(file);
                    mFile.MoveTo(rootDirectory + coockedPCConsoleDirectory + "\\" + mFile.Name);
                }
                MessageBox.Show("Restoration complete.");
                getInstalledFiles();
            }
        }


        private void getInstalledFiles()
        {
            installedFiles = Directory.GetFiles(rootDirectory + coockedPCConsoleDirectory, "*.upk").Select(path => Path.GetFileName(path)).Except(jsonFileNames).ToArray();
            Properties.Settings.Default["lastModFiles"] = string.Join(",", installedFiles);
            Properties.Settings.Default.Save();
            lstInstalled.DataSource = null;
            lstInstalled.DataSource = installedFiles;
        }

        private void cmbMods_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (loadingDone && cbLastDefault.Checked)
            {
                Properties.Settings.Default["defaultToLastUsed"] = cmbMods.SelectedItem.ToString();
                Properties.Settings.Default.Save();
            }
        }
    }
}
