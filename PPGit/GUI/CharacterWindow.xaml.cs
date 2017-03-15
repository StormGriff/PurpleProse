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
using PurpleProse.Lib;

namespace PurpleProse
{
	/// <summary>
	/// Interaction logic for CharacterWindow.xaml
	/// </summary>
	public partial class CharacterWindow :Window
	{
		private Character Person;

		public CharacterWindow(Character person) {
			InitializeComponent();
			this.Person = person;
			Person.its_window = this;
			NameBox.Text = Person.Name;
			AgeBox.Text = Convert.ToString(Person.charAge);
			GenderBox.Text = Person.charGender;
			HomeBox.Text = Person.charHometown;
			RoleBox.Text = Person.charRole;
			LingBox.Text = Person.charLanguage;
			RaceBox.Text = Person.charKind;
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
			{ TextOps.Open(Person.DescFile); }

		Binding name_binding;
		
		//Bug: Functions execute upon inital click. (Originally named XXX_LostKeyboardFocus)
		//ComboBox Tutorial: https://youtu.be/UDDYd3q5WM4

		private void NameBox_LostKeyFocus(object sender, KeyboardFocusChangedEventArgs e)
			{ if (NameBox.Text != "") Person.Name = NameBox.Text; }

		private void AgeBox_LostKeyFocus(object sender, KeyboardFocusChangedEventArgs e) 
		{	if (AgeBox.Text != "") try { Person.charAge = Convert.ToInt64(AgeBox.Text); }// I figured sometimes the ages of fictional characters can get long.
				catch(FormatException	exc) { AgeBox.Clear(); }
				catch(OverflowException exc) { AgeBox.Text = "OvrFlo"; }
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

		private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e) { Person.its_window = null; }
	}
}
