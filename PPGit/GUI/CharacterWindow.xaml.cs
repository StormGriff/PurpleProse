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

		private void DescBtn_Click(object sender, RoutedEventArgs e)
			{ TextOps.Open(Person.DescFile); }

	//	private void NameBox_IsKeyboardFocusedChanged(object sender, DependencyPropertyChangedEventArgs e)
	//	private void NameBox_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e) 
	//		{ if (!it) it = true; }
		
		//Bug: Functions execute upon inital click
		private void NameBox_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
			{ if (NameBox.Text != "") Person.Name = NameBox.Text; } 

		private void AgeBox_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e) 
			{ if (AgeBox.Text != "") Person.charAge = 5; }	//Some sort of atoi needs to be implimented

		private void GenderBox_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e) 
			{ if (GenderBox.Text != "") Person.Name = GenderBox.Text; }

		private void HomeBox_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e) 
			{ if (HomeBox.Text != "") Person.charHometown = HomeBox.Text; }

		private void RoleBox_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
			{ if (RoleBox.Text != "") Person.charRole = RoleBox.Text; }

		private void LingBox_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e) 
			{ if (LingBox.Text != "") Person.charLanguage = LingBox.Text; }

		private void RaceBox_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e) 
			{ if (RaceBox.Text != "") Person.charKind = RaceBox.Text; }
	}
}
