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
using PPGit.Lib;

using MahApps.Metro.Controls;

namespace PPGit.GUI.DetailWindows
{
	/// <summary>
	/// Interaction logic for LocationWindow.xaml
	/// </summary>
	public partial class LocationWindow : MetroWindow
	{
		private PPGit.Lib.Location Place;

		public LocationWindow(PPGit.Lib.Location place) {
			InitializeComponent();
			this.Place = place;
			//Place.window = this;
			NameBox.Text = Place.Name;
			AgeBox.Text = Convert.ToString(Place.size);
			SizeBox.Text = Place.size;
		//	ParentLoc.Text = Place.??.Name;
		//	LingBox.Text = Place.Language;
		//	RaceBox.Text = Place.Race;
		//	PopBox.Text = Place.Population;
		//	TerraBox.Text = Place.terrain;
		//	GovBox.Text = Place._ocracy;
		//	EconBox.Text = Place.economy;

		}

        #region Title Bar and Border

        private void TitleBarText_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) { DragMove(); }

        private void CloseButton_Click(object sender, RoutedEventArgs e) { Close(); }

        private void MaxButton_Click(object sender, RoutedEventArgs e)
		{ WindowState = (WindowState == WindowState.Maximized) ? WindowState.Normal : WindowState.Maximized; }

        private void MinButton_Click(object sender, RoutedEventArgs e) { WindowState = WindowState.Minimized; }

        #endregion

		private void DescBtn_Click(object sender, RoutedEventArgs e)	{ TextOps.Open(Place.DescFile); }

		Binding name_binding;
		
		//Bug: Functions execute upon inital click. (Originally named XXX_LostKeyboardFocus)
		//ComboBox Tutorial: https://youtu.be/UDDYd3q5WM4

		private void NameBox_LostKeyFocus(object sender, KeyboardFocusChangedEventArgs e)
			{ if (NameBox.Text != "") Place.Name = NameBox.Text; }

		private void AgeBox_LostKeyFocus(object sender, KeyboardFocusChangedEventArgs e) 
		{	if (AgeBox.Text != "") try { Convert.ToInt64(AgeBox.Text); }
				catch(FormatException	exc) { AgeBox.Clear(); }
				catch(OverflowException exc) { AgeBox.Text = "OvrFlo"; }
		//	else Place.Age = 0; 
		}

		private void SizeBox_LostKeyFocus(object sender, KeyboardFocusChangedEventArgs e) 
			{ Place.size = SizeBox.Text; }

		private void ParentLoc_LostKeyFocus(object sender, KeyboardFocusChangedEventArgs e) 
			{ /*Place. = ParentLoc.Text*/; }
			
		private void LingBox_LostKeyFocus(object sender, KeyboardFocusChangedEventArgs e) 
			{ /*Place.Langage = LingBox.Text*/; }

		private void RaceBox_LostKeyFocus(object sender, KeyboardFocusChangedEventArgs e) 
			{ /*Place.Race = RaceBox.Text*/; }

		private void PopBox_LostKeyFocus(object sender, KeyboardFocusChangedEventArgs e) 
		{	if (PopBox.Text != "") try {/*Place.population = */Convert.ToInt64(PopBox.Text);}
				catch(FormatException	exc) { PopBox.Clear(); }
				catch(OverflowException exc) { PopBox.Text = "OvrFlo"; }
		}

		private void TerraBox_LostKeyFocus(object sender, KeyboardFocusChangedEventArgs e) 
			{ /*Place.terrain = TerraBox.Text*/; }

		private void GovBox_LostKeyFocus(object sender, KeyboardFocusChangedEventArgs e) 
			{ /*Place._ocracy = GovBox.Text*/; }

		private void EconBox_LostKeyFocus(object sender, KeyboardFocusChangedEventArgs e) 
			{ /*Place.economy = EconBox.Text*/; }

		private void MetroWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e) { Place.window = null; }
	}
}

