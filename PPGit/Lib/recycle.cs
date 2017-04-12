using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPGit.Lib
{
    public class recycle
    {
        private static recycle instance = null;
        private const int DAYS_TO_DELETE = 10;
        public struct item {
            public PurpleProse.Lib.Object myObject;
            public DateTime delete;
        }
        private List<item> bin;
        private recycle() {
            bin = new List<item>();
        }

        //Get single instance of recycle
        public static recycle Bin {
            get {
                if (instance == null) {
                    instance = new recycle();
                }
                return instance;
            }
        }
        public void add(List<PurpleProse.Lib.Object> myList) { //Add list of objects
            foreach (PurpleProse.Lib.Object theOb in myList) {
                item adding = new item();
                adding.myObject = theOb;
                adding.delete = DateTime.Now.AddDays(DAYS_TO_DELETE);
                bin.Add(adding);
            }
        }

        public void add(List<item> itemList) { //Add list of items
            foreach (item theItem in itemList) {
                bin.Add(theItem);
            }
        }

        public void add(PurpleProse.Lib.Object singleObject) { //Add a single object
            item newItem = new item();
            newItem.myObject = singleObject;
            newItem.delete = DateTime.Now.AddDays(DAYS_TO_DELETE);
            bin.Add(newItem);
        }

        //Delete all items older than 10 days
        private void clean() {
            foreach (item list in bin) {
                if (DateTime.Now > list.delete) bin.Remove(list);
            }
        }

        public List<item> getList {
            get {
                clean();
                return bin;
            }
        }
        public void restore(string name) {
            foreach (item theItem in bin) {
                if (theItem.myObject.Name == name)
                {
                    bool done;
                    int x = 0;
                    do
                    {
                        done = true;
                        try
                        {
                            if(x == 0) mainLists.locationList.Add((PurpleProse.Lib.Location)theItem.myObject);
                            else mainLists.characterList.Add((PurpleProse.Lib.Character)theItem.myObject);
                        }
                        catch (InvalidCastException)
                        {
                            done = false;
                            x++;
                        }
                    } while (!done);
                    bin.Remove(theItem);
                    break;
                }
            }
        }
    }
}
