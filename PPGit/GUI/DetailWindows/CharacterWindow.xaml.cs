using System;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using MahApps.Metro.Controls;
using Microsoft.Win32;
using System.Diagnostics;
using System.IO;

namespace PPGit.GUI.DetailWindows
{
	/// <summary>
	/// Interaction logic for CharacterWindow.xaml
	/// </summary>
	public partial class CharacterWindow : /*Adornment_Win//*/MetroWindow
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
			UpdateDescBox();
			foreach (string image_file in Person.Images) { Add_picture(image_file); }

			this.Title = Person.Name;
		}

		private void SetPrimaryBitmapSize(ref BitmapImage bmp)
		{	/* */if (bmp.Height < bmp.Width && bmp.Width >= 200)					{ bmp.DecodePixelWidth = 180; }
			else if (bmp.Height > bmp.Width && bmp.Height>= 300)					{ bmp.DecodePixelHeight= 180; }
			else if (bmp.Height ==bmp.Width &&(bmp.Width >  200 || bmp.Height > 300)){bmp.DecodePixelWidth = 180; }
		}

		Binding name_binding;

		//Bug: Functions execute upon inital click. (Originally named XXX_LostKeyboardFocus)
		//ComboBox Tutorial: https://youtu.be/UDDYd3q5WM4

		private void NameBox_LostKeyFocus(object sender, KeyboardFocusChangedEventArgs e)
		{	if (NameBox.Text != "")
			{	//rename folder and deletes the old one
				Directory.Move(mainLists.projectDir + "\\items\\characters\\" + Person.Name.ToLower() + Person.Number, mainLists.projectDir + "\\items\\characters\\" + NameBox.Text.ToLower() + Person.Number);

				//rename info file and deletes old one
				Directory.Move(mainLists.projectDir + "\\items\\characters\\" + NameBox.Text.ToLower() + Person.Number + "\\" + Person.Name.ToLower() + ".info", mainLists.projectDir + "\\items\\characters\\" + NameBox.Text.ToLower() + Person.Number + "\\" + NameBox.Text.ToLower() + ".info");

				Person.Name = NameBox.Text;
			}
		}

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
		{try{	OpenFileDialog dlg = new OpenFileDialog();
				dlg.Title = "Insert image";
				dlg.Filter = "Image (*.png;*.jpg;*.jpeg;*.gif;*.bmp;*.tif;*.tiff;*.wdp)|*.png;*.jpg;*.jpeg;*.gif;*.bmp;*.tif;*.tiff;*.wdp";
				
				if (dlg.ShowDialog() == true)   //Calls show dialog, if the function does not fail then...
				{	Person.Images.Add(dlg.FileName);
					System.IO.File.Copy(dlg.FileName, Person.Directory + "\\images\\" + System.IO.Path.GetFileName(dlg.FileName));
					Add_picture(dlg.FileName);
				}
			} catch (Exception x) { MessageBox.Show("An unexpected error occured."); Trace.Write("Exception: " + x); }
		}

		private void Add_picture(string FQP)
		{	BitmapImage bmp = new BitmapImage(new Uri(FQP));

			SetPrimaryBitmapSize(ref bmp);

			if (Person.Images.Count == 1) { PrimaryImage.Source = bmp; }
			else if(Person.Images.Count == 2)
			{	bmp.DecodePixelHeight = 60;
				bmp.DecodePixelWidth = 60;
				SecondaryImage1.Source = bmp;
			}
			else if (Person.Images.Count == 3)
			{	bmp.DecodePixelWidth = 60;
				bmp.DecodePixelHeight = 60;
				SecondaryImage2.Source = bmp;
			}

			//try
			//{	double yval = 0;
			//	Image picture = new Image();
			//	BitmapImage bitpic = new BitmapImage(new Uri(FQP));
			//	picture.Source = bitpic;
			//	picture.Width = bitpic.Width;
			//	picture.Height = bitpic.Height;
			//	picture.Margin = new Thickness(5, 5, 5, 5);
			//	//picture += new SizeChangedEventHandler(PictureSizeChanged);
			//	//WrapP_pics.Children.Add(picture);

			//}
			//catch (Exception x) { MessageBox.Show("An unexpected error occured."); Trace.Write("Exception: " + x); }
		}

		private void PictureSizeChanged(object sender, SizeChangedEventArgs e)
			{ throw new NotImplementedException(); }

		private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
		{   /*Thickness marge = Art_space.Margin;//Can this be made static?
			if(this.Width <= 413) marge.Left = this.Width/2;
			else marge.Left = -((100*defaultwidth)/(this.Width+200-defaultwidth))+defaultwidth;
			Art_space.Margin = marge;
			marge.Right = this.Width - marge.Left - 1;
			marge.Left = 0;
			Info.Margin = marge;*/
		}

		private void MetroWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e) { Person.window = null; }

		private void DescBox_PreviewMouseUp(object sender, MouseButtonEventArgs e) { UpdateDescBox(); }

		private void UpdateDescBox()
		{	if (Person.DescText == null) DescBox.AppendText("Double Click to add.");
			else DescBox.AppendText(Person.DescText);
		}

		private void DescBox_PreviewMouseDoubleClick(object sender, MouseButtonEventArgs e)
		{   //Person.DescFile = "D:\\Documents\\Visual Studio 2015\\Projects\\PurpleProse\\PPGit\\Resources\\Lolly.rtf";
			//if (Person.DescFile == null) { Lib.TextOps.Open(); }
			//else { Lib.TextOps.Open(Person.DescFile); }
			Lib.TextOps.Open(Person.DescFile);
		}

		private void btnBrowseImage_Click(object sender, RoutedEventArgs e)
			{ Process.Start(Person.Directory + "\\images\\"); }

		//private void gridSplitter_DragStarted(object sender, System.Windows.Controls.Primitives.DragStartedEventArgs e)
		//{
		//Trace.WriteLine("DragStarted");
		//}

		//private void gridSplitter_DragDelta(object sender, System.Windows.Controls.Primitives.DragDeltaEventArgs e)
		//{
		//double ColWidth = MainGrid.ColumnDefinitions[0].ActualWidth;
		//var marginoffset = DescControl.Margin.Left + DescControl.Margin.Right;
		//if (ColWidth < DescNormWidth + marginoffset) DescControl.Width = ColWidth - marginoffset;
		//}

		private void PrimaryPic_Click(object sender, RoutedEventArgs e)
		{	OpenFileDialog fd = new OpenFileDialog();
			fd.InitialDirectory = Person.Directory + "\\images\\";
			fd.Filter = "Image (*.png;*.jpg;*.jpeg;*.gif;*.bmp;*.tif;*.tiff;*.wdp)|*.png;*.jpg;*.jpeg;*.gif;*.bmp;*.tif;*.tiff;*.wdp";

			if (fd.ShowDialog() == true)
			{	BitmapImage bmp = new BitmapImage(new Uri(fd.FileName));
				int index = Person.Images.IndexOf(fd.FileName);

				SetPrimaryBitmapSize(ref bmp);
				PrimaryImage.Source = bmp;

				if (Person.Images.Count == 2)
				{	BitmapImage sbmp;

					if (index == 0) sbmp = new BitmapImage(new Uri(Person.Images.ElementAt(1)));
					else			sbmp = new BitmapImage(new Uri(Person.Images.ElementAt(0)));

					sbmp.DecodePixelHeight = 60;
					sbmp.DecodePixelWidth = 60;

					SecondaryImage1.Source = sbmp;
					
					if (Person.Images.Count >= 3)
					{	if (index==0 || index==1) sbmp = new BitmapImage(new Uri(Person.Images.ElementAt(2)));
						else					  sbmp = new BitmapImage(new Uri(Person.Images.ElementAt(1)));

						sbmp.DecodePixelHeight = 60;
						sbmp.DecodePixelWidth = 60;

						SecondaryImage2.Source = sbmp;
					}
				}
			}
		}

		//private void gridSplitter_DragCompleted(object sender, System.Windows.Controls.Primitives.DragCompletedEventArgs e)
		//{
		//Trace.WriteLine("DragCompleted");
		//}

	}
}