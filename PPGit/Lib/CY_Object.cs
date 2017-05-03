#if false

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
//INotifyPropertyChanging
//INotifyPropertyChanged

namespace StoryPlanner
{
	public class Object : System.ComponentModel.IEditableObject  //This will be a parent class to all objects
	{
		public enum relationshipTypes {Null, Father, Mother, Sibling, Friend, Enemy}; //Types of relationships... let me know if we need more
		public string Name { get; set; }
		protected string description, history, image;
		protected List<relationship> MyRelationships; //List of this objects relationships
		public static System.IO.FileNotFoundException InvalidTextFile;
		private static List<Object> BackupData;
		private static bool inTxn = false;
		
		public Object(Object Original) {
			Name = Original.Name;
			description = Original.description;
			image = Original.image;
			MyRelationships = Original.MyRelationships;
		//	attributes = copy.attributes;
		}
	
	/*
		public string GetFQPath(string path) {
			if (System.IO.File.Exists(path)) return path;
			else throw InvalidTextFile;
		}
		public string GetText(string path) {
			if (System.IO.Directory.Exists(path))
				return string.Join("\n", File.ReadAllLines(path));
			else return path;
		}

		public void SetMethod(string path, ref string value, bool fqponly = false) {
			if		(System.IO.File.Exists(value)) path = value;
			else if (System.IO.File.Exists(path ) && !fqponly){
				string[] fullDesc = { value };
				File.WriteAllLines(path, fullDesc);
		   }else throw InvalidTextFile;
		}
		public void SetMethod(string path, ref string[] value, bool fqponly = false) {
			if		(System.IO.File.Exists(value[0])		) path = value[0];
			else if (System.IO.File.Exists(path) && !fqponly) File.WriteAllLines(path, value);
			else throw InvalidTextFile;
		}

		public string DescrptFQP { get{return GetFQPath(description);} set{SetMethod(description, ref value, false );} }//Gets and Sets the fully qualified path that contains the description of the object
		public string DescrptTXT { get{return GetText  (description);} set{SetMethod(description, ref value, false);} }//Gets and Sets the description text
		public string HistoryFQP { get{return GetFQPath(history    );} set{SetMethod(history	, ref value, false );} }//Gets and sets the fully qualified path that contains the history of the object
		public string HistoryTXT { get{return GetText  (history    );} set{SetMethod(history	, ref value, false);} }//Gets and Sets the history text
		public string PictureFQP { get{return GetFQPath(images  );} set{SetMethod(images	, ref value, false );} }//Gets and sets the fully qualified path that contains the image of the object
		*/

#if USER_GENERATED_OBJECTS
		public Object(string name, string desc, string hist, string pict = "") {
			if (!string.IsNullOrEmpty(name)) attributes.Find(x => x.Label.called == "Name"		).text = name;
			if (!string.IsNullOrEmpty(desc)) attributes.Find(x => x.Label.called =="Description").text = desc;
			if (!string.IsNullOrEmpty(hist)) attributes.Find(x => x.Label.called == "History"	).text = hist;
			if (!string.IsNullOrEmpty(pict)) ImageFil = pict;
			MyRelationships = new List<relationship>();
		}
#else
		public Object(string name, string desc, string hist, string pict = "") {
			if (!string.IsNullOrEmpty(name)) Name = name;
			if (!string.IsNullOrEmpty(desc)) description = desc; //desc, hist, and images hold filenames with extension
			if (!string.IsNullOrEmpty(hist)) history = hist;
			if (!string.IsNullOrEmpty(pict)) ImageFil = pict;
			MyRelationships = new List<relationship>();
		}
#endif
		protected struct relationship { //A relationship.  Including the type of relationship and who it is with.
		    public relationshipTypes type;
		    public Object MyRelationship;
		}
		
#if USER_GENERATED_OBJECTS
		public List<Attribute> attributes = new List<Attribute> {
			new Attribute("Name", ""),
			new Attribute("Description", ""),
			new Attribute("History", "")
		};
		//private List<string> Gallery = new List<string> {};
		
		public class Attribute //: System.ComponentModel.IEditableObject
		{	public class Attribute_ID
			{	public   Attribute_ID(string name)
					{ called = name;	ind = (uint)AIDs.Count() + 1; }
				public uint	  ind	{ get; set; }
				public string called{ get; set; }
#region == and related overload
				/*public static bool operator ==(Attribute_ID Left, Attribute_ID Right) { return (Left.ind	== Right.ind); }
				public static bool operator !=(Attribute_ID Left, Attribute_ID Right) { return (Left.ind	!= Right.ind); }
				public static bool operator <=(Attribute_ID Left, Attribute_ID Right) { return (Left.ind	<= Right.ind); }
				public static bool operator >=(Attribute_ID Left, Attribute_ID Right) { return (Left.ind	>= Right.ind); }
				public static bool operator ==(Attribute_ID Left, 		   int Right) { return (Left.ind	== Right	); }
				public static bool operator !=(Attribute_ID Left,		   int Right) { return (Left.ind	!= Right	); }
				public static bool operator <=(Attribute_ID Left,		   int Right) { return (Left.ind	<= Right	); }
				public static bool operator >=(Attribute_ID Left,		   int Right) { return (Left.ind	>= Right	); }
				public static bool operator ==(Attribute_ID Left,		string Right) { return (Left.called == Right	); }
				public static bool operator !=(Attribute_ID Left,		string Right) { return (Left.called != Right	); }*/
#endregion //It's best to minimize these
			}
			public Attribute(string name, string txt)
			{	if (AIDs == null) AIDs = new List<Attribute_ID>();//Initialization
				else foreach (Attribute_ID AID in AIDs) if (name == AID.called) Label = AID;
				if (Label == (Attribute_ID)null)
				{	AIDs.Add(new Attribute_ID(name));
					Label = AIDs.Last();
				}
				path = txt;
			}

			public  static List< Attribute_ID > AIDs;
			public  			 Attribute_ID  Label = null;

			private string path;
			public  string text	//Gets and Sets the text in "path"
			{	get{
					if (System.IO.Directory.Exists(path))
						return string.Join("\n", File.ReadAllLines(path));
					else return path;
				}
				set{
					if ( System.IO.Directory.Exists(value)||
						!System.IO.Directory.Exists(path ) ) path = value;
					else{
						string[] fullDesc = { value };
						File.WriteAllLines(path, fullDesc);
					}
				}
			}					//Gets and Sets the text in "path"
#region Begin-, End-, and Cancel-Edit
			/*public  void BeginEdit(){
				Console.WriteLine("Start BeginEdit");
				if (!inTxn) 
				{
					backupData = ;
					inTxn = true;
					Console.WriteLine("BeginEdit - " + this.backupData.lastName);
				}
				Console.WriteLine("End BeginEdit");
			}
			public  void EndEdit()	{}
			public  void CancelEdit(){}*/
#endregion
		
#region more == overloads
			public static bool operator ==(Attribute Left, string Right) { return (Left.Label.called == Right); }
			public static bool operator !=(Attribute Left, string Right) { return (Left.Label.called != Right); }
			public static bool operator ==(string Left, Attribute Right) { return (Left == Right.Label.called); }
			public static bool operator !=(string Left, Attribute Right) { return (Left != Right.Label.called); }
			//public static bool operator <=(Attribute Left,    int Right) { return (Left.Label <= Right/*.Label*/); }
			//public static bool operator >=(Attribute Left,    int Right) { return (Left.Label >= Right/*.Label*/); } //It's best to minimize these
#endregion
		}
#endif

		public string GetFQPath(string path) {
			if (System.IO.File.Exists(path)) return path;
			else throw InvalidTextFile;
		}
		public string[] GetText(string path) {
			if (!System.IO.File.Exists(path)) throw InvalidTextFile;
			else return File.ReadAllLines(path);
		}

		public void SetMethod(string path, ref string value) {
			if		(System.IO.File.Exists(value)) path = value;
			else if (System.IO.File.Exists(path )){
				string[] fullDesc = { value };
				File.WriteAllLines(path, fullDesc);		
		   }else throw InvalidTextFile;
		}
		public void SetMethod(string path, ref string[] value) {
			if		(System.IO.File.Exists(value[0])) path = value[0];
			else if (System.IO.File.Exists(path    )) File.WriteAllLines(path, value);
			else throw InvalidTextFile;
		}

		public string   DescrptS { get{return GetFQPath(description);} set{SetMethod(description, ref value);} }//Gets and Sets the file name that contains the description of the object
		public string[] DescrptP { get{return GetText  (description);} set{SetMethod(description, ref value);} }//Gets and Sets the description text
		public string   HistoryS { get{return GetFQPath(history    );} set{SetMethod(history	, ref value);} }//Gets and sets the file name that contains the history of the object
		public string[] HistoryP { get{return GetText  (history    );} set{SetMethod(history	, ref value);} }//Gets and Sets the history text
		public string   ImageFil { get{return GetFQPath(image      );} set{SetMethod(image		, ref value);} }//Gets and sets the file name that contains the image of the object

#region more Begin-, End, Cancel-Edit
		public  void BeginEdit() {
			Console.WriteLine("Start BeginEdit");
			if (!inTxn) 
			{
				BackupData.Add(new Object(this));
				inTxn = true;
				//Console.WriteLine("BeginEdit - " + this.BackupData.Last().);
			}
			Console.WriteLine("End BeginEdit");
		}

		public  void EndEdit() {
			Console.WriteLine("Start EndEdit" + this.custData.id + this.custData.lastName);
			if (inTxn) 
			{
				BackupData = new CustomerData();
				inTxn = false;
				//Console.WriteLine("Done EndEdit - " + this.custData.id + this.custData.lastName);
			}
			Console.WriteLine("End EndEdit");
		}

		public  void CancelEdit() {
			Console.WriteLine("Start CancelEdit");
				if (inTxn) 
				{
					inTxn = false;
					//Console.WriteLine("CancelEdit - " + this.custData.lastName);
					this = BackupData.First();
				}
			Console.WriteLine("End CancelEdit");
		}
#endregion
		
#region Relationships
		public void EstablishRelationship(Object relateMe, relationshipTypes myType) { //Create a new relationship
		    relationship newRelationship = new relationship();
		    newRelationship.MyRelationship = relateMe;
		    newRelationship.type = myType;
		    MyRelationships.Add(newRelationship);
		}
		public void RemoveRelationship(Object removeMe) { //Removes a relationship
		    foreach (relationship theRelationships in MyRelationships) {
		        if (theRelationships.MyRelationship == removeMe) MyRelationships.Remove(theRelationships);
		    }
		}
		public relationshipTypes WhatsTheRelationshipTo(Object myName) { //Return relationship type to given object
		    foreach(relationship theRelationship in MyRelationships)
		        { if (theRelationship.MyRelationship.Name == myName.Name) return theRelationship.type; }
		    return relationshipTypes.Null; //If the given object does not have a relationship to this object, return null type
		}
#endregion
	}
	
	/*public class Temp_Opener {
		public void Opener(Object it) {
			Proccess.Start
		}
	}*/
}

#endif