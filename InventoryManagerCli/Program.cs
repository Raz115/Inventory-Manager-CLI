//Author: Raza Hussain Mirza
//File Name: Program.cs
//Project Name: OOP_PASS 
//Creation Date: Sept. 21, 2021
//Modified Date: Oct. 30, 2021
//Description: The Driver Class Allows Different Actions To Change The Inventory
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PASS_2_New
{
    class Program
    {
        //Store Action And Result File Names
        static string actionFile = "actions.txt";
        static string resultsFile = "MirzaR_PASS2.txt";

        //Setup File IO
        static StreamReader inFile;
        static StreamWriter outFile;

        //Stores Current Line Inside File Being Read
        public static string line = "";

        //Constructs Manager
        private static Manager mediaManager = new Manager();
        
        //Stores Action Types
        const string ADD = "Add";
        const string DISPLAY2 = "Display2";
        const string FINDBARCODE = "FindBarcode";
        const string FINDNAME = "FindName";
        const string SORTBYCOST = "SortByCost";
        const string SORTBYNAME = "SortByName"; 
        const string DISPLAY = "Display";
        const string MODIFY = "Modify";
        const string DELETE = "Delete";

        static void Main(string[] args)
        {
            //Reads Inventory File
            mediaManager.ReadInventory();

            //Begins Actions
            ReadActionFile();

            //Retrieve User Input To Ensure User Has Seen Output On Console
            Console.ReadLine();
        }
        //Pre: None
        //Post: None
        //Desc: Retrieves All Actions And After Calculating Displays
        private static void ReadActionFile()
        {
            //Stores action details 
            string[] actionData;

            //Stores Display 2 values
            string[] display2Array = new string[2];

            //Stores barcode Index
            int barcodeIndex;

            List<int> nameIndices = new List<int>();

            try
            {
                //Stores Action File Text & Writes Result File
                inFile = File.OpenText(actionFile);
                outFile = File.CreateText(resultsFile);

                //Loop Unit End Of File Hasn't Been Reached
                while (!(inFile.EndOfStream))
                {
                    //Stores One Line At A Time From Action File
                    line = inFile.ReadLine();

                    //Splits Action File Lines In To Data So That It Can Be Used
                    actionData = line.Split(':');

                    //Perform The Appropriate Actions Based On The Action File
                    switch (actionData[0])
                    {
                        case ADD:
                            //Add & Save Instance Using Manager
                            mediaManager.AddItem(actionData[1]);
                            mediaManager.SaveInventory();
                            break;
                        case DISPLAY2:
                            //returns and stores it into the array 
                             display2Array = mediaManager.FindFirstTwo(actionData[1]);
                            //if it returns a null, display error message
                            if (display2Array == null)
                            {
                                //displays error message when none of the media types is found
                                Console.WriteLine("No items of type " + actionData[1] + " found.\n");
                                //writes the error to the results file
                                outFile.WriteLine("No items of type " + actionData[1] + " found.\n");
                            }
                            //if it doesn't return a null
                            else
                            {
                                //displays the first item of the two items to the console 
                                Console.WriteLine(display2Array[0] + "\n");
                                //writes the first item of the two items to the results file
                                outFile.WriteLine(display2Array[0] + "\n");
                                //checks if the second index is null
                                if (display2Array[1] != null)
                                {
                                    //displays the second item of the two items to the console 
                                    outFile.WriteLine(display2Array[1] + "\n");
                                    //writes the second item of the two items to the results file
                                    Console.WriteLine(display2Array[1] + "\n");
                                }
                            }
                            break;
                        case FINDBARCODE:
                            //Checks Whether Barcode Has Matched Any Instances
                            barcodeIndex = mediaManager.MatchedBarcode(actionData[1]);
                            if (barcodeIndex != -1)
                            {
                                //Check What Next Part Of The Action Is And Performs Actions
                                switch (actionData[2])
                                {
                                    case DISPLAY:
                                        //Displays The Media Instance 
                                        outFile.WriteLine(mediaManager.Display(barcodeIndex) + "\n");
                                        break;
                                    case DELETE:
                                        //Deletes The Media Instance
                                        mediaManager.DeleteItem(barcodeIndex);
                                        break;
                                    case MODIFY:
                                        //Modifies The Cost Of The Media Instance And The Displays it 
                                        mediaManager.ModifyCost(barcodeIndex, Convert.ToDouble(actionData[3]));
                                        break;
                                }
                            }
                            else
                            {
                                //Display Error in Console and Result File
                                Console.WriteLine("Item: " + actionData[1] + " not found" + "\n");
                                outFile.WriteLine("Item: " + actionData[1] + " not found" + "\n");
                            }
                            break;
                        case FINDNAME:
                            //Checks Whether Name Has Matched Any Instances
                            nameIndices = mediaManager.MatchedNames(actionData[1]);
                            if (nameIndices.Count() > 0)
                            {
                                switch (actionData[2])
                                {
                                    case DISPLAY:
                                        //Displays The Media Instance 
                                        outFile.WriteLine(mediaManager.Display(nameIndices[Convert.ToInt32(actionData[3])]) + "\n");
                                        break;
                                    case DELETE:
                                        //Deletes The Media Instance
                                        mediaManager.DeleteItem(nameIndices[Convert.ToInt32(actionData[3])]);
                                        break;
                                    case MODIFY:
                                        //Modifies The Cost Of The Media Instance And The Displays it
                                        mediaManager.ModifyCost(nameIndices[Convert.ToInt32(actionData[3])], Convert.ToDouble(actionData[4]));
                                        break;
                                }
                            }
                            else
                            {
                                //Display Error in Console and Result File
                                Console.WriteLine("Item: " + actionData[1] + " not found" + "\n");
                                outFile.WriteLine("Item: " + actionData[1] + " not found" + "\n");
                            }
                                break;
                        case SORTBYCOST:
                            //Sorts Media List By Cost 
                            mediaManager.SortByCost();
                            //Saves Media List
                            mediaManager.SaveInventory();
                            break;
                        case SORTBYNAME:
                            //Sorts Media List By Name 
                            mediaManager.SortByName();
                            //Saves Media List
                            mediaManager.SaveInventory();
                            break;
                        default:
                            //Display Error In Both Console and File
                            Console.WriteLine("Action Command: " + actionData[0] + " not recognized" + "\n");
                            outFile.WriteLine("Action Command: " + actionData[0] + " not recognized" + "\n");
                            break;
                    }
                }
                //Close result and action File
                outFile.Close();
                inFile.Close();
            }
            catch (FileNotFoundException)
            {
                //Display Error Message 
                Console.WriteLine("ERROR: File(s) Not Found");
            }
        } 
    }
}
