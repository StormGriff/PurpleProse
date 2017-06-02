﻿using System;
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

namespace PPGit.GUI.TextEditor
{
    /// <summary>
    /// Interaction logic for TextEditor.xaml
    /// </summary>
    public partial class TextEditor : MetroWindow
    {
        private bool fullStory; //Is the user writing the full story in this window?
        private Lib.Object thisObject;
        private bool save;
        public TextEditor(bool fullStory = false)
        {
            InitializeComponent();

            cmbFontFamily.ItemsSource = Fonts.SystemFontFamilies;

            cmbFontSize.ItemsSource = new List<double>() { 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24, 28, 36, 48, 72 };
            this.fullStory = fullStory;
            thisObject = null;
            save = false;
        }

        public TextEditor(string FQpath, bool fullStory = false)
        {
            InitializeComponent();

            cmbFontFamily.ItemsSource = Fonts.SystemFontFamilies;

            cmbFontSize.ItemsSource = new List<double>() { 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24, 28, 36, 48, 72 };

            OpenFile(FQpath);
            this.fullStory = fullStory;
            thisObject = null;
            save = false;
        }

        public TextEditor(Lib.Object thisObject) {
            InitializeComponent();
            cmbFontFamily.ItemsSource = Fonts.SystemFontFamilies;
            cmbFontSize.ItemsSource = new List<double>() { 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24, 28, 36, 48, 72 };
            this.thisObject = thisObject;
            if (thisObject.DescFile != null) {
                OpenFile(thisObject.DescFile);
            }
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
            FileStream fs = new FileStream(FQpath, FileMode.Open);
            TextRange range = new TextRange(rtbEditor.Document.ContentStart, rtbEditor.Document.ContentEnd);
            range.Load(fs, DataFormats.Rtf);
            fs.Close();

            this.Title = FQpath;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (fullStory)
            {
                FileStream fs = new FileStream(mainLists.storyLocation, FileMode.Create);
                TextRange range = new TextRange(rtbEditor.Document.ContentStart, rtbEditor.Document.ContentEnd);
                range.Save(fs, DataFormats.Rtf);
                fs.Close();
                save = true;
            }
            else if (thisObject != null && thisObject.DescFile != null)
            {
                FileStream fs = new FileStream(thisObject.DescFile, FileMode.Create);
                TextRange range = new TextRange(rtbEditor.Document.ContentStart, rtbEditor.Document.ContentEnd);
                range.Save(fs, DataFormats.Rtf);
                fs.Close();
                save = true;
            }
            else
            {
                Ookii.Dialogs.Wpf.VistaSaveFileDialog sfd = new VistaSaveFileDialog();
                sfd.InitialDirectory = mainLists.projectDir;
                sfd.Filter = "Rich Text (*.rtf) | *.rtf";

                if (sfd.ShowDialog() == true)
                {
                    FileStream fs = new FileStream(sfd.FileName, FileMode.Create);
                    TextRange range = new TextRange(rtbEditor.Document.ContentStart, rtbEditor.Document.ContentEnd);
                    range.Save(fs, DataFormats.Rtf);
                    if (fullStory)
                    {
                        mainLists.storyLocation = sfd.FileName;  //Store location of story
                        mainLists.wordCount = countWords();
                    }
                    else if (thisObject != null)
                    {
                        thisObject.DescFile = sfd.FileName;
                    }
                    fs.Close(); //Close the stream
                    save = true;
                }
            }
        }

        private void cmbFontFamily_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbFontFamily.SelectedItem != null)
            {
                rtbEditor.Selection.ApplyPropertyValue(Inline.FontFamilyProperty, cmbFontFamily.SelectedItem);
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
            rtbEditor.Selection.ApplyPropertyValue(Inline.FontSizeProperty, cmbFontSize.Text);
        }

        private void rtbEditor_SelectionChanged(object sender, RoutedEventArgs e)
        {
            object temp = rtbEditor.Selection.GetPropertyValue(Inline.FontWeightProperty);
            btnBold.IsChecked = (temp != DependencyProperty.UnsetValue) && (temp.Equals(FontWeights.Bold));

            temp = rtbEditor.Selection.GetPropertyValue(Inline.FontStyleProperty);
            btnItalic.IsChecked = (temp != DependencyProperty.UnsetValue) && (temp.Equals(FontStyles.Italic));

            temp = rtbEditor.Selection.GetPropertyValue(Inline.TextDecorationsProperty);
            btnUnderline.IsChecked = (temp != DependencyProperty.UnsetValue) && (temp.Equals(TextDecorations.Underline));

            temp = rtbEditor.Selection.GetPropertyValue(Inline.FontFamilyProperty);
            cmbFontFamily.SelectedItem = temp;

            temp = rtbEditor.Selection.GetPropertyValue(Inline.FontSizeProperty);
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

        private void rtbEditor_TextChanged(object sender, TextChangedEventArgs e)
        {
            save = false;
        }

        private void MetroWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!save) {
                MessageBoxResult result = MessageBox.Show("All unsaved progress will be lost", "WARNING", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Cancel) e.Cancel = true;
            }
        }
    }
}
