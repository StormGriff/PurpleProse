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
	/// Interaction logic for ChildWindow.xaml
	/// </summary>
	public partial class CharacterWindow :Window
	{
		private Character Person;

		public CharacterWindow() {
			InitializeComponent();
		}

		public CharacterWindow(Character person) {
			InitializeComponent();
			this.Person = person;
		}

        #region Title Bar and Border

        private void TitleBarText_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void MaxButton_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = (this.WindowState == WindowState.Maximized) ? WindowState.Normal : WindowState.Maximized;
        }

        private void MinButton_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        #endregion

		private void DescBtn_Click(object sender, RoutedEventArgs e)
			{ TextOps.Open(Person.DescFile); }

	//	private void NameBox_IsKeyboardFocusedChanged(object sender, DependencyPropertyChangedEventArgs e)
	//	private void NameBox_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e) 
	//		{ if (!it) it = true; }
		
		//Bug: Functions execute upon inital click. (Originally named XXX_LostKeyboardFocus)
		//ComboBox Tutorial: https://youtu.be/UDDYd3q5WM4
		private void NameBox_LostKeyFocus(object sender, KeyboardFocusChangedEventArgs e)
			{ if (NameBox.Text != "") Person.Name = NameBox.Text; } 

		private void AgeBox_LostKeyFocus(object sender, KeyboardFocusChangedEventArgs e) 
			{ if (AgeBox.Text != "") Person.charAge = 5; }	//Some sort of atoi needs to be implimented

		private void GenderBox_LostKeyFocus(object sender, KeyboardFocusChangedEventArgs e) 
			{ if (GenderBox.Text != "") Person.charGender = GenderBox.Text; }

		private void HomeBox_LostKeyFocus(object sender, KeyboardFocusChangedEventArgs e) 
			{ if (HomeBox.Text != "") Person.charHometown = HomeBox.Text; }

		private void RoleBox_LostKeyFocus(object sender, KeyboardFocusChangedEventArgs e)
			{ if (RoleBox.Text != "") Person.charRole = RoleBox.Text; }

		private void LingBox_LostKeyFocus(object sender, KeyboardFocusChangedEventArgs e) 
			{ if (LingBox.Text != "") Person.charLanguage = LingBox.Text; }

		private void RaceBox_LostKeyFocus(object sender, KeyboardFocusChangedEventArgs e) 
			{ if (RaceBox.Text != "") Person.charKind = RaceBox.Text; }
    }
}
