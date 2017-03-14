﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Windows.Markup;
using System.Windows;
using System.ComponentModel;

namespace PurpleProse.Lib
{
    public abstract class Object : INotifyPropertyChanged //This will be a parent class to all objects
    {
        public enum relationshipTypes {Null, Father, Mother, Sibling, Friend, Enemy}; //Types of relationships... let me know if we need more
        public string Name { get; set; }
		protected string description, history, imageFile;
        protected List<relationship> MyRelationships; //List of this objects relationships
		public Window its_window;
		public static System.IO.FileNotFoundException InvalidTextFile;

		public event PropertyChangedEventHandler PropertyChanged;
		public void NotifyPropertyChanged(string propName)
		{
			if(PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(propName));
		}

		protected struct relationship { //A relationship.  Including the type of relationship and who it is with.
            public relationshipTypes type;
            public Object myRelationship;
        }

		public Object(Object Original) {
			Name = Original.Name;
			description = Original.description;
			imageFile = Original.imageFile;
			MyRelationships = Original.MyRelationships;
		//	attributes = copy.attributes;
		}

		/*public Object(string name, Window wind, string desc, string hist, string pict = "") {
			if (!string.IsNullOrEmpty(name)) Name = name;
			if (wind != null) its_window = wind;
			if (!string.IsNullOrEmpty(desc)) description = desc; //desc, hist, and imageFile hold filenames with extension
			if (!string.IsNullOrEmpty(hist)) history = hist;
			if (!string.IsNullOrEmpty(pict)) imageFile = pict;
			MyRelationships = new List<relationship>();
		}*/

		public Object(string name, string desc, string hist, string pict = "") {
			if (!string.IsNullOrEmpty(name)) Name = name;
			if (!string.IsNullOrEmpty(desc)) description = desc; //desc, hist, and imageFile hold filenames with extension
			if (!string.IsNullOrEmpty(hist)) history = hist;
			if (!string.IsNullOrEmpty(pict)) imageFile = pict;
			MyRelationships = new List<relationship>();
		}

	public string DescFile	{ get { return description; } set { description = value; } }
	public string HistFile		{ get { return history; } set { history = value; } }
	public string ImageFile	{ get { return imageFile; } set { imageFile = value; } }
	public string DescText { //Gets and Sets the description text
		get{
			if (description == null) return null;
			else{ 
				try{ return string.Join("\n", File.ReadAllLines(description)); }
				  catch (FileNotFoundException) { return null; }
			}
		}
		set{
			string[] fullDesc = { value }; 
			File.WriteAllLines(description, fullDesc);
		} //Writes the history to the file
	}

	public string HistText { //Gets and Sets the history text
		get{
			if (history == null) return null;
			else{ 
				try { return string.Join("\n", File.ReadAllLines(history)); }
				  catch (FileNotFoundException) { return null; }
			}
		}
		set{
			string[] fullHist = { value }; 
			File.WriteAllLines(history, fullHist);
		} //Writes the history to the file
	}

        public void establishRelationship(Object relateMe, relationshipTypes myType) { //Create a new relationship
            relationship newRelationship = new relationship();
            newRelationship.myRelationship = relateMe;
            newRelationship.type = myType;
            MyRelationships.Add(newRelationship);
        }

        public void removeRelationship(Object removeMe) { //Removes a relationship
            foreach (relationship theRelationships in MyRelationships) {
                if (theRelationships.myRelationship == removeMe) MyRelationships.Remove(theRelationships);
            }
        }
        public relationshipTypes whatsTheRelationshipTo(Object myName) { //Return relationship type to given object
            foreach (relationship theRelationship in MyRelationships) {
                if (theRelationship.myRelationship.Name == myName.Name) {
                    return theRelationship.type;
                }
            }
            return relationshipTypes.Null; //If the given object does not have a relationship to this object, return null type
        }
    }
}
