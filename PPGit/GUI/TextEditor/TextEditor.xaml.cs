using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.IO;

using MahApps.Metro.Controls;
using MahApps.Metro;

using Ookii.Dialogs.Wpf;
//using SautinSoft.Document;

namespace PPGit.GUI.TextEditor
{
    /// <summary>
    /// Interaction logic for TextEditor.xaml
    /// </summary>
    public partial class TextEditor : MetroWindow
    {
        private bool fullStory; //Is the user writing the full story in this window?
        private string fileName; // Name of file and extension
        
        public TextEditor(bool fullStory = false)
        {
            InitializeComponent();

            cmbFontFamily.ItemsSource = Fonts.SystemFontFamilies;

            cmbFontSize.ItemsSource = new List<double>() { 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24, 28, 36, 48, 72 };
            this.fullStory = fullStory;
        }


        public TextEditor(string FQpath, bool fullStory = false)
        {
            InitializeComponent();

            cmbFontFamily.ItemsSource = Fonts.SystemFontFamilies;

            cmbFontSize.ItemsSource = new List<double>() { 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24, 28, 36, 48, 72 };

            OpenFile(FQpath);
            this.fullStory = fullStory;
        }

        // Create new file with this constructor
        public TextEditor(string FQpath, string filename, bool fullStory = false)
        {
            InitializeComponent();

            cmbFontFamily.ItemsSource = Fonts.SystemFontFamilies;

            cmbFontSize.ItemsSource = new List<double>() { 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24, 28, 36, 48, 72 };

            this.fileName = filename;
            //OpenFile(FQpath); // full path with extension
            this.fullStory = fullStory;
        }

        private void btnOpen_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Ookii.Dialogs.Wpf.VistaOpenFileDialog ofd = new VistaOpenFileDialog();
                ofd.Filter = "Rich Text Format (*.rtf)|*.rtf|All Files (*.*)|*.*";

                if (ofd.ShowDialog() == true) OpenFile(ofd.FileName);
            }
            catch (Exception) { }
        }
        
        private void OpenFile(string FQpath)
        {
            
            TextRange range = new TextRange(rtbEditor.Document.ContentStart, rtbEditor.Document.ContentEnd);
            //string txt = @"{\rtf1\ansi\ansicpg1252\uc1\htmautsp\deff2{\fonttbl{\f0\fcharset0 Times New Roman;}{\f2\fcharset0 Segoe UI, Lucida Sans Unicode, Verdana;}}{\colortbl\red0\green0\blue0;\red255\green255\blue255;}\loch\hich\dbch\pard\plain\ltrpar\itap0{\lang1033\fs18\f2\cf1 \cf1\ql{\f2 {\ltrch Hello}\li0\ri0\sa0\sb0\fi0\ql\par}}}";
            
            FileStream fs = new FileStream(FQpath, FileMode.Open);
            range.Load(fs, DataFormats.Rtf); // DataFormats.Rtf

            this.Title = FQpath;
        }

        public void OpenTextFile(string textFilePath, string fileName)
        {
            // Extracting rtf ansi code out of txt file
            // Removing last 3 lines out of the file
            // check if text in file consists of curly braces or "charset"
            if(File.ReadAllText(textFilePath + fileName).Contains("charset"))
            {
                var lines = System.IO.File.ReadAllLines(textFilePath + fileName);
                System.IO.File.WriteAllLines(textFilePath + fileName, lines.Take(lines.Length - 3).ToArray());
            }
            
            this.fileName = fileName;
            TextRange range;
            FileStream fStream;
            if (File.Exists(textFilePath + fileName))
            {
                range = new TextRange(rtbEditor.Document.ContentStart, rtbEditor.Document.ContentEnd);
                fStream = new FileStream(textFilePath + fileName, FileMode.Open);
                range.Load(fStream, DataFormats.Text);
                fStream.Close();
            }
        }

        public void SaveTextFile(string textFilePath)
        {
            TextRange range;
            FileStream fStream;
            if (File.Exists(textFilePath))
            {
                range = new TextRange(rtbEditor.Document.ContentStart, rtbEditor.Document.ContentEnd);
                fStream = new FileStream(textFilePath, FileMode.Open);
                range.Save(fStream, DataFormats.Text);
                fStream.Close();
            }
        }

        public void SaveRTFFile(string RTFFilePath)
        {
            TextRange range;
            FileStream fStream;
            if (File.Exists(RTFFilePath))
            {
                range = new TextRange(rtbEditor.Document.ContentStart, rtbEditor.Document.ContentEnd);
                fStream = new FileStream(RTFFilePath, FileMode.OpenOrCreate);
                range.Save(fStream, DataFormats.Rtf);
                fStream.Close();
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            Ookii.Dialogs.Wpf.VistaSaveFileDialog sfd = new VistaSaveFileDialog();

            sfd.FileName = this.fileName;
            //if (sfd.ShowDialog() == true)
            //{
            //FileStream fs = new FileStream(mainLists.storyLocation + "/" + sfd.FileName, FileMode.Create);

            if (fileName.Contains(".rtf"))
            {
                SaveRTFFile(mainLists.locationToSaveTo + @"/" + this.fileName);
            }
            else if(fileName.Contains(".txt"))
            {
                SaveTextFile(mainLists.locationToSaveTo + @"/" + this.fileName);
            }

            //FileStream fs = new FileStream(mainLists.locationToSaveTo + @"/" + sfd.FileName, FileMode.Create);
            //TextRange range = new TextRange(rtbEditor.Document.ContentStart, rtbEditor.Document.ContentEnd);
            //range.Save(fs, DataFormats.Rtf); // DataFormats.Rtf

            if (fullStory)
            {
                mainLists.storyLocation = sfd.FileName;  //Store location of story
                mainLists.wordCount = countWords();
            }
            //}
        }

        private void cmbFontFamily_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbFontFamily.SelectedItem != null)
            {
                rtbEditor.Selection.ApplyPropertyValue(System.Windows.Documents.Inline.FontFamilyProperty, cmbFontFamily.SelectedItem);
            }
        }

        private int countWords() { //Count words in textbox
            TextRange newRange = new TextRange(rtbEditor.Document.ContentStart, rtbEditor.Document.ContentEnd);
            if (newRange.Text == "\r\n") return 0; //No words in text box
            int words = 0;
            bool white = false;
            foreach (char theChar in newRange.Text.ToCharArray())
            {
                if (char.IsWhiteSpace(theChar) && !white)
                {
                    words++; //Count spaces
                    white = !white; //white is going to equal true
                }
                else if (!char.IsWhiteSpace(theChar)) white = false; //No more successive white space
            }
            return words;
        }

        private void cmbFontSize_TextChanged(object sender, RoutedEventArgs e)
        {
            rtbEditor.Selection.ApplyPropertyValue(System.Windows.Documents.Inline.FontSizeProperty, cmbFontSize.Text);
        }

        private void rtbEditor_SelectionChanged(object sender, RoutedEventArgs e)
        {
            object temp = rtbEditor.Selection.GetPropertyValue(System.Windows.Documents.Inline.FontWeightProperty);
            btnBold.IsChecked = (temp != DependencyProperty.UnsetValue) && (temp.Equals(FontWeights.Bold));

            temp = rtbEditor.Selection.GetPropertyValue(System.Windows.Documents.Inline.FontStyleProperty);
            btnItalic.IsChecked = (temp != DependencyProperty.UnsetValue) && (temp.Equals(FontStyles.Italic));

            temp = rtbEditor.Selection.GetPropertyValue(System.Windows.Documents.Inline.TextDecorationsProperty);
            btnUnderline.IsChecked = (temp != DependencyProperty.UnsetValue) && (temp.Equals(TextDecorations.Underline));

            temp = rtbEditor.Selection.GetPropertyValue(System.Windows.Documents.Inline.FontFamilyProperty);
            cmbFontFamily.SelectedItem = temp;

            temp = rtbEditor.Selection.GetPropertyValue(System.Windows.Documents.Inline.FontSizeProperty);
            cmbFontSize.Text = temp.ToString();
        }

        private void btnRightWindowChangeTheme_Click(object sender, RoutedEventArgs e)
        {
            AppThemeChanger wnd = new AppThemeChanger();

            wnd.Show();
        }

        private void WordsBTN_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Word Count: " + countWords().ToString(), "NUMBER OF WORDS", MessageBoxButton.OK, MessageBoxImage.None);
        }

        private void MetroWindow_Closed(object sender, EventArgs e)
        {
            if(fullStory) mainLists.fullEditor = null;
        }
    }
}
