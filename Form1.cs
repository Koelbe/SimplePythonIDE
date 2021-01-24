using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace SimplePythonIDE
{
    public partial class Form1 : Form
    {

        string currentFilePath = "";
        bool hasOpenedFileYet = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void OpenButton_MouseClick(object sender, MouseEventArgs e)
        {
            DialogResult dr = fileDialog.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                TextEditorBox.Text = File.ReadAllText(fileDialog.FileName);
                currentFilePath = fileDialog.FileName;
                hasOpenedFileYet = true;
                SaveButton.Visible = true;
                RunButton.Visible = true;
            }
        }

        private void SaveButton_MouseClick(object sender, MouseEventArgs e)
        {
            File.WriteAllText(currentFilePath, TextEditorBox.Text);
        }

        private void RunButton_MouseClick(object sender, MouseEventArgs e)
        {
            //string[] undisterbedFileLines = File.ReadAllLines(fileDialog.FileName);
           // string[] tempFileLines = undisterbedFileLines;
           // tempFileLines.Append<string>("print(\">>>>Application finished, you may close CMD.\")");
           // tempFileLines.Append<string>("input()");
            //File.WriteAllLines(currentFilePath,tempFileLines);
            System.Diagnostics.Process.Start("CMD.exe", $"/Cpython {currentFilePath}");
            //File.WriteAllLines(currentFilePath,undisterbedFileLines);
        }
    }
}
