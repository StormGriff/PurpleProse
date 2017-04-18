using System.Collections.Generic;
using System.IO;
using System.ComponentModel;
using System.Windows;

using MahApps.Metro.Controls;

namespace PPGit.Lib
{
	public abstract class Object : INotifyPropertyChanged //This will be a parent class to all objects
	{	
		public string Name { get; set; }
		protected string description, history;
		public List<string> Images;
		protected List<relationship> MyRelationships; //List of this objects relationships
		private object window;//A reference to the Object's page
		public static System.IO.FileNotFoundException InvalidTextFile;
		public enum relationshipTypes { Null, Father, Mother, Sibling, Friend, Enemy }; //Types of relationships... let me know if we need more

		
		public event PropertyChangedEventHandler PropertyChanged;
		public void NotifyPropertyChanged(string propName)
		{
		    if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(propName));
		}
		
		protected struct relationship
		{ //A relationship.  Including the type of relationship and who it is with.
		    public relationshipTypes type;
		    public Object myRelationship;
		}
		
		public Object(Object Original)
		{
		    Name = Original.Name;
		    description = Original.description;
		    Images = Original.Images;
		    MyRelationships = Original.MyRelationships;
		    //	attributes = copy.attributes;
		}
		
		/*public Object(string name, Window wind, string desc, string hist, string pict = "") {
			if (!string.IsNullOrEmpty(name)) Name = name;
			if (wind != null) Page = wind;
			if (!string.IsNullOrEmpty(desc)) description = desc; //desc, hist, and images hold filenames with extension
			if (!string.IsNullOrEmpty(hist)) history = hist;
			if (!string.IsNullOrEmpty(pict)) images = pict;
			MyRelationships = new List<relationship>();
		}*/
		
		public Object(string name, string desc, string hist, List<string> pics = null) {
			if (!string.IsNullOrEmpty(name)) Name = name;
			if (!string.IsNullOrEmpty(desc)) description = desc; //desc, hist, and Images hold filenames with extension
			if (!string.IsNullOrEmpty(hist)) history = hist;
			if (null != pics) Images = pics;
			else Images = new List<string>();
			MyRelationships = new List<relationship>();
		}
		
		public MetroWindow Page
		{	get { return window as MetroWindow; }  /*	
		*/	set { window = value;				}	}

		public string DescFile { get { return description; } set { description = value; } }
		public string HistFile { get { return history; } set { history = value; } }
//	public List<string> ImgFiles{ get { return Images;		} set { Images		= value; } }
		public string DescText
		{ //Gets and Sets the description text
			get
			{	if (description == null) return null;
				else
				{	try { return string.Join("\n", File.ReadAllLines(description)); }
					catch (FileNotFoundException) { return null; }
				}
			}
			set
			{	string[] fullDesc = { value };
				File.WriteAllLines(description, fullDesc);
			} //Writes the history to the file
		}
		
		public string HistText
		{ //Gets and Sets the history text
			get
			{	if (history == null) return null;
				else
				{	try { return string.Join("\n", File.ReadAllLines(history)); }
					catch (FileNotFoundException) { return null; }
				}
			}
			set
			{	string[] fullHist = { value };
				File.WriteAllLines(history, fullHist);
			} //Writes the history to the file
		}
		
		public void establishRelationship(Object relateMe, relationshipTypes myType)
		{ //Create a new relationship
		    relationship newRelationship = new relationship();
		    newRelationship.myRelationship = relateMe;
		    newRelationship.type = myType;
		    MyRelationships.Add(newRelationship);
		}
		
		public void removeRelationship(Object removeMe)
		{ //Removes a relationship
		    foreach (relationship theRelationships in MyRelationships)
		    {
		        if (theRelationships.myRelationship == removeMe) MyRelationships.Remove(theRelationships);
		    }
		}
		public relationshipTypes whatsTheRelationshipTo(Object myName)
		{ //Return relationship type to given object
		    foreach (relationship theRelationship in MyRelationships)
		    {
		        if (theRelationship.myRelationship.Name == myName.Name)
		        {
		            return theRelationship.type;
		        }
		    }
		    return relationshipTypes.Null; //If the given object does not have a relationship to this object, return null type
		}
		
		public override string ToString() { return Name; }
	
	}
}
