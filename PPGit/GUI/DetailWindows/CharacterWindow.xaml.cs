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
using System.Windows.Markup;

using MahApps.Metro.Controls;
using Microsoft.Win32;
using System.Diagnostics;

namespace PPGit.GUI.DetailWindows
{
    /// <summary>
    /// Interaction logic for CharacterWindow.xaml
    /// </summary>
    public partial class CharacterWindow : MetroWindow
    {
        private PPGit.Lib.Character Person;
		private const int defaultwidth = 413;

		public double DescNormWidth = 180, DescNormHeight = 92;

        public CharacterWindow(PPGit.Lib.Character person)
		{	InitializeComponent();
			this.Person = person;
			Person.window = this;
			NameBox.Text = Person.Name;
			AgeBox.Text = Convert.ToString(Person.charAge);
			GenderBox.Text = Person.charGender;
			HomeBox.Text = Person.charHometown;
			RoleBox.Text = Person.charRole;
			LingBox.Text = Person.charLanguage;
			RaceBox.Text = Person.charKind;
			if (Person.DescText == null) DescBox.AppendText("Double Click to add (not yet available).");
			else DescBox.AppendText(Person.DescText);
			foreach(string image_file in Person.Images){ Add_picture(image_file); }
		}

        #region Title Bar and Border

        private void TitleBarText_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) { DragMove(); }

        private void CloseButton_Click(object sender, RoutedEventArgs e) { this.Close(); }
        // A I am assuming this will completely deallocate the data here, if I'm wrong we have a leak.
        // I sometimes use A ^ and /\s to denote that a comment applies to the code above it.

        private void MaxButton_Click(object sender, RoutedEventArgs e)
        { WindowState = (WindowState == WindowState.Maximized) ? WindowState.Normal : WindowState.Maximized; }

        private void MinButton_Click(object sender, RoutedEventArgs e) { WindowState = WindowState.Minimized; }

        #endregion

        Binding name_binding;

        //Bug: Functions execute upon inital click. (Originally named XXX_LostKeyboardFocus)
        //ComboBox Tutorial: https://youtu.be/UDDYd3q5WM4

		private void NameBox_LostKeyFocus(object sender, KeyboardFocusChangedEventArgs e)
			{ if (NameBox.Text != "") Person.Name = NameBox.Text; }
		
		private void AgeBox_LostKeyFocus(object sender, KeyboardFocusChangedEventArgs e)
        {	if (AgeBox.Text != "") try { Person.charAge = Convert.ToInt64(AgeBox.Text); }// I figured sometimes the ages of fictional characters can get long.
                catch (FormatException exc) { AgeBox.Clear(); }
                catch (OverflowException exc) { AgeBox.Text = "OvrFlo"; }
            else Person.charAge = 0;
        }
		
		private void GenderBox_LostKeyFocus(object sender, KeyboardFocusChangedEventArgs e)
			{ Person.charGender = GenderBox.Text; }
		
		private void HomeBox_LostKeyFocus(object sender, KeyboardFocusChangedEventArgs e)
			{ Person.charHometown = HomeBox.Text; }
		
		private void RoleBox_LostKeyFocus(object sender, KeyboardFocusChangedEventArgs e)
			{ Person.charRole = RoleBox.Text; }
		
		private void LingBox_LostKeyFocus(object sender, KeyboardFocusChangedEventArgs e)
			{ Person.charLanguage = LingBox.Text; }
		
		private void RaceBox_LostKeyFocus(object sender, KeyboardFocusChangedEventArgs e)
			{ Person.charKind = RaceBox.Text; }
		
		private void NewPic_Click(object sender, RoutedEventArgs e)
		{	try
			{	OpenFileDialog dlg = new OpenFileDialog();
				dlg.Title = "Insert image";
				dlg.Filter = "Image (*.png;*.jpg;*.jpeg;*.gif;*.bmp;*.tif;*.tiff;*.wdp)|*.png;*.jpg;*.jpeg;*.gif;*.bmp;*.tif;*.tiff;*.wdp";
				if (dlg.ShowDialog() == true)	//Calls show dialog, if the function does not fail then...
				{	Person.Images.Add(dlg.FileName);
					Add_picture(dlg.FileName);
				} else{				MessageBox.Show("Error, bad filename.");		Trace.Write("dlg failed to open."); }
            } catch (Exception x) { MessageBox.Show("An unexpected error occured.");Trace.Write("Exception: "+x); }
		}

		private void Add_picture(string FQP)
		{	try
			{	double yval = 0;
				Image picture = new Image();
				BitmapImage bitpic = new BitmapImage(new Uri(FQP));
				picture.Source = bitpic;
				picture.Width = bitpic.Width;
				picture.Height = bitpic.Height;
				picture.Margin = new Thickness(5,5,5,5);
#if OPT1	
				double maxX = Canvas_pics.Width - bitpic.Width;
				double maxY = Canvas_pics.Height - bitpic.Height;		
#endif
			/*	if (null != Pics.Children.OfType<Image>().Last())
					foreach(Image imy in Pics.Children.OfType<Image>()) { yval += imy.Height; }
				Canvas.SetLeft(picture, 31);
				Canvas.SetTop( picture, yval + 1);
			*/	WrapP_pics.Children.Add(picture);
				
			} catch (Exception x) { MessageBox.Show("An unexpected error occured."); Trace.Write("Exception: "+x); }
		}

		private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
		{	/*Thickness marge = Art_space.Margin;//Can this be made static?
			if(this.Width <= 413) marge.Left = this.Width/2;
			else marge.Left = -((100*defaultwidth)/(this.Width+200-defaultwidth))+defaultwidth;
			Art_space.Margin = marge;
			marge.Right = this.Width - marge.Left - 1;
			marge.Left = 0;
			Info.Margin = marge;*/
		}

		private void MetroWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e) { Person.window = null; }

		private void DescBox_PreviewMouseDoubleClick(object sender, MouseButtonEventArgs e) 
		{	//Person.DescFile = "D:\\Documents\\Visual Studio 2015\\Projects\\PurpleProse\\PPGit\\Resources\\Lolly.rtf";
			if (Person.DescFile == null) Lib.TextOps.Open();
			else Lib.TextOps.Open(Person.DescFile);
		}

		private void gridSplitter_DragStarted(object sender, System.Windows.Controls.Primitives.DragStartedEventArgs e) {
			Trace.WriteLine("DragStarted");
		}

		private void gridSplitter_DragDelta(object sender, System.Windows.Controls.Primitives.DragDeltaEventArgs e) {
			double ColWidth = MainGrid.ColumnDefinitions[0].ActualWidth;
			var marginoffset = DescControl.Margin.Left + DescControl.Margin.Right;
			if (ColWidth < DescNormWidth + marginoffset) DescControl.Width = ColWidth-marginoffset; 
		}

		private void gridSplitter_DragCompleted(object sender, System.Windows.Controls.Primitives.DragCompletedEventArgs e) {
			Trace.WriteLine("DragCompleted");
		}
	}
}
