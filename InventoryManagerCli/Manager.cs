//Author: Raza Hussain Mirza
//Author: Raza Hussain Mirza
//File Name: Manager.cs
//Project Name: OOP_PASS 
//Creation Date: Sept. 21, 2021
//Modified Date: Oct. 30, 2021
//Description: The Manager Class Manages Actions That Change/Delete/Create Instances Of Different Media Types
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PASS_2_New
{
    class Manager
    {
        //Store All Instances Of Media
        private List<Media> mediaList = new List<Media>();
        
        //Store Inventory File Name 
        public string inventoryFile = "inventory.txt";

        //Setup File IO
        static StreamReader inFile;
        static StreamWriter outFile;

        //Constructor For Manager
        public Manager()
        {

        }
        //Pre: None
        //Post: None
        //Desc: Save Inventory File
        public void SaveInventory()
        {
            //Setup Write On Inventory File
            outFile = File.CreateText(inventoryFile);

            //Loop Through All Media List Indexes 
            for (int i = 0; i < mediaList.Count(); i++)
            {
                //Write MediaList On Inventory File
                outFile.WriteLine(mediaList[i].DisplayLine());
            }

            //Close Inventory File
            outFile.Close();
        }
        //Pre: string of action details storing instance data
        //Post: Boolean whether the item has been added
        //Desc: Add To Inventory 
        public bool AddItem(string actionDetails)
        {
            //Split Inventory
            string [] tempAddDetails = actionDetails.Split(',');
            
            //Checks Media Type and Whether Correct Data Is Given 
            if (tempAddDetails[0] == "Movie")
            {
                //Creates Instance And Adds To Media List
                mediaList.Add(new Movie(tempAddDetails[0], tempAddDetails[1], Convert.ToDouble(tempAddDetails[2]), tempAddDetails[3], tempAddDetails[4], tempAddDetails[5], Convert.ToInt32(tempAddDetails[6]), tempAddDetails[7], tempAddDetails[8], Convert.ToInt32(tempAddDetails[9])));
                return true;
            }
            else if (tempAddDetails[0] == "Game")
            {
                //Creates Instance And Adds To Media List
                mediaList.Add(new Game(tempAddDetails[0], tempAddDetails[1], Convert.ToDouble(tempAddDetails[2]), tempAddDetails[3], tempAddDetails[4], tempAddDetails[5], Convert.ToInt32(tempAddDetails[6]), tempAddDetails[7], Convert.ToInt32(tempAddDetails[8]))); 
                return true;
            }
            else if (tempAddDetails[0] == "Book")
            {
                //Creates Instance And Adds To Media List
                mediaList.Add(new Book(tempAddDetails[0], tempAddDetails[1], Convert.ToDouble(tempAddDetails[2]), tempAddDetails[3], tempAddDetails[4], tempAddDetails[5], Convert.ToInt32(tempAddDetails[6]), tempAddDetails[7], tempAddDetails[8]));
                return true;
            }
            else
            {
                return false;
            }
        }
        //Pre: string of action details storing instance data
        //Post: Boolean whether the item has been added
        //Desc: Add To Inventory 
        public string[] FindFirstTwo(string currentMediaType)
        {
            //counter to count the amount inside the list
            int counter = 0;
            //list that stores the first two of a type
            string[] displayArray = new string[2];
            for (int i = 0; i < mediaList.Count(); i++)
            {
                if (currentMediaType.Equals(mediaList[i].GetType()))
                {
                    if (counter < 2)
                    {
                        //adds the first instance into the list
                        displayArray[counter] = mediaList[i].DisplayTable();
                        counter++;
                    }
                }
            }
            //when the counter is equal to 1, return the array with a name in the first index and null for the second index
            if (counter == 1)
            {
                displayArray[1] = null;
                return displayArray;
            }
            //when the counter is equal to 2, return the array
            else if (counter == 2)
            {
                return displayArray;
            }
            //when the counter is equal to neither 1 or 2, return null
            else
            {
                return null;
            }
        }
        //Pre: string of barcode 
        //Post: int index machted
        //Desc: Find matching barcode
        public int MatchedBarcode(string barcode)
        {
            //Initialize barcode
            int barcodeIndex = -1;

            //Loop through all media types to check if barcode matched
            for (int i = 0; i < mediaList.Count(); i++)
            {
                //Check if barcode Matched
                if (barcode.Equals(mediaList[i].GetBarcode()))
                {
                    //Set Barcode to current index in loop
                    barcodeIndex = i;

                    //Exit loop
                    break;
                }
            }
            return barcodeIndex;
        }
        //Pre: string on name
        //Post: List of integers storing Indexes 
        //Desc: Check if inventory has matched
        public List <int> MatchedNames(string name)
        {
            //stores Indexes of matched names
            List<int> nameIndices = new List<int>();

            //Loops through all instances to see matches
            for (int i = 0; i < mediaList.Count(); i++)
            {
                //Checks if instance names match
                if (mediaList[i].GetName().Equals(name))
                {
                    //Add instance to list
                    nameIndices.Add(i);
                }
            }
            return nameIndices;
        }
        //Pre: None
        //Post: None
        //Desc: Sort Inventory File based of lowest cost 
        public void SortByCost()
        {
            //Sort inventory based of lowest cost
            mediaList = mediaList.OrderBy(x => x.GetType()).ThenByDescending(x => x.GetCost()).ToList();
        }
        //Pre: None 
        //Post: None
        //Desc: Sort inventory file based of name
        public void SortByName()
        {
            //Sort inventory based of name
            mediaList = mediaList.OrderBy(x => x.GetType()).ThenBy(x => x.GetName()).ToList();
        }
        //Pre: int storing index  of instance in media list 
        //Post: string of formated table for result file
        //Desc: Display formated table of instance
        public string Display(int index)
        {
            //display formated table in console
            Console.WriteLine(mediaList[index].DisplayTable() + "\n");
            //display formated table in result file 
            return mediaList[index].DisplayTable();
        }
        //Pre: index of media and new cost  
        //Post: None
        //Desc: Changes instance cost 
        public void ModifyCost(int mediaIndex, double cost)
        {
            //Changes Cost
            mediaList[mediaIndex].SetCost(cost);
            //Save Cost
            SaveInventory();
        }
        //Pre: None 
        //Post: None
        //Desc: Read Inventory and adds to media list
        public void ReadInventory()
        {
            //Stores current line being read
            string line = "";

            //Stores current line number
            int lineNum = 0;

            try
            {
                //Reads inventory file line by line 
                inFile = File.OpenText(inventoryFile);

                //Loop until inventory file ends
                while (!(inFile.EndOfStream))
                {
                    try
                    {
                        //Stores current line 
                        line = inFile.ReadLine();

                        //Adds to line number
                        lineNum++;

                        //Checks if line has not been added
                        if (AddItem(line) == false)
                        {
                            //Display error
                            Console.WriteLine("ERROR: Line " + lineNum + " was incorrectly formatted" + line);
                        }
                    }
                    catch (FormatException fe)
                    {
                        //Display error
                        Console.WriteLine("ERROR: Line " + lineNum + " was incorrectly formatted" + line);
                    }
                }
                //Close inventory file
                inFile.Close();
            }
            catch (FileNotFoundException)
            {
                //Display error
                Console.WriteLine("ERROR: File Not Found");
            }
        }
        //Pre: index of instance which is about to be deleted
        //Post: None
        //Desc: Deletes instances
        public void DeleteItem(int deleteIndex)
        {
            //Delete instance
            mediaList.RemoveAt(deleteIndex);
            //Save updated version of inventory 
            SaveInventory();
        }
    }
}
