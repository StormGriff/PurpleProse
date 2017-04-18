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

        public CharacterWindow(PPGit.Lib.Character person)
		{	InitializeComponent();
			this.Person = person;
			Person.Page = this;
			NameBox.Text = Person.Name;
			AgeBox.Text = Convert.ToString(Person.charAge);
			GenderBox.Text = Person.charGender;
			HomeBox.Text = Person.charHometown;
			RoleBox.Text = Person.charRole;
			LingBox.Text = Person.charLanguage;
			RaceBox.Text = Person.charKind;
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

        private void DescBtn_Click(object sender, RoutedEventArgs e)
        { PPGit.Lib.TextOps.Open(Person.DescFile); }

        Binding name_binding;

        //Bug: Functions execute upon inital click. (Originally named XXX_LostKeyboardFocus)
        //ComboBox Tutorial: https://youtu.be/UDDYd3q5WM4

		private void NameBox_LostKeyFocus(object sender, KeyboardFocusChangedEventArgs e)
			{ if (NameBox.Text != "") Person.Name = NameBox.Text; }
		
		private void AgeBox_LostKeyFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (AgeBox.Text != "") try { Person.charAge = Convert.ToInt64(AgeBox.Text); }// I figured sometimes the ages of fictional characters can get long.
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
				picture.Source = bitpic;//new BitmapImage( new Uri(FQP) );
				picture.Width = bitpic.Width;
				picture.Height = bitpic.Height;

#if OPT1	
				double maxX = Canvas_pics.Width - bitpic.Width;
				double maxY = Canvas_pics.Height - bitpic.Height;		
#endif
#if OPT2
				picture.Height = 20;
				picture.Width = 20;
#endif
#if OPT3
				//picture.Margin = new MyControl.Margin.Thickness(60,89,0,0);// VerticalAlignment="Top" Height="100" Width="100"
				Thickness marge = picture.Margin;
				marge.Left = 60;
				marge.Top = 89;
				picture.Margin = marge;
#endif
			/*	if (null != Pics.Children.OfType<Image>().Last())
					foreach(Image imy in Pics.Children.OfType<Image>()) { yval += imy.Height; }
				Canvas.SetLeft(picture, 31);
				Canvas.SetTop( picture, yval + 1);
			*/	WrapP_pics.Children.Add(picture);
				
			} catch (Exception x) { MessageBox.Show("An unexpected error occured."); Trace.Write("Exception: "+x); }
		}

		private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
		{	Thickness marge = Art_space.Margin;//Can this be made static?
			if(this.Width <= 413) marge.Left = this.Width/2;
			else marge.Left = -((100*defaultwidth)/(this.Width+200-defaultwidth))+defaultwidth;
			Art_space.Margin = marge;
			marge.Right = this.Width - marge.Left - 1;
			marge.Left = 0;
			Info.Margin = marge;
		}

		private void MetroWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e) { Person.Page = null; }
	}
}
