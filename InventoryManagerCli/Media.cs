//Rating: Raza Hussain Mirza
//File Name: Media.cs
//Project Name: OOP_PASS 
//Creation Date: Sept. 21, 2021
//Modified Date: Oct. 30, 2021
//Description: The Media Class Is the Parent Class Of the Movie, Game And Book Class. It Creates General Data Which The Child Classes Use Through Inheritance
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PASS_2_New
{
    class Media
    {
        //Store What Media Type An Instance Is
        public string mediaType;

        //Store General Instance Data Used Via Inheritance And Polymorphism 
        protected double cost;
        protected string barcode;
        protected string genre;
        protected string name;
        protected string platform;
        protected int releaseYear;

        public Media(string mediaType, string name, double cost, string barcode, string genre, string platform, int releaseYear)
        {
            // Set General Media Values
            this.mediaType = mediaType;
            this.cost = cost;
            this.barcode = barcode;
            this.genre = genre;
            this.name = name;
            this.platform = platform;
            this.releaseYear = releaseYear;
        }
        //Pre: None
        //Post: String Of Media Type
        //Desc: Get Media Type 
        public string GetType()
        {
            return mediaType;
        }
        //Pre: Store new Media Type
        //Post: None
        //Desc: Modifies Media Type
        public void SetType(string newMediaType)
        {
            mediaType = newMediaType;
        }
        //Pre: None
        //Post: Double Storing Cost
        //Desc: Get Cost 
        public double GetCost()
        {
            return cost;
        }

        public void SetCost(double newCost)
        {
            cost = newCost;
        }
        //Pre: None
        //Post: String Storing Barcode
        //Desc: Get Barcode
        public string GetBarcode()
        {
            return barcode;
        }
        //Pre: None
        //Post: String Storing Genre
        //Desc: Get Genre
        public string GetGenre()
        {
            return genre;
        }
        //Pre: None
        //Post: String Storing Name
        //Desc: Get Name
        public string GetName()
        {
            return name;
        }
        //Pre: None
        //Post: String Storing Platform
        //Desc: Get Platform
        public string GetPlatform()
        {
            return platform;
        }
        //Pre: None
        //Post: Int Storing Year
        //Desc: Get Year
        public int GetYear()
        {
            return releaseYear;
        }
        //Pre: None
        //Post: String Formated Into A Table
        //Desc: Displays Game Data In Specific Table Format
        public virtual string DisplayTable()
        {
            return "Type: " + mediaType + "\n" + "Name: " + name + "\n" + "Cost: " + cost + "\n" + "Barcode: " + barcode + "\n" + "Genre: " + genre + "\n" + "Palform: " + platform + "\n" + "Release Year: " + releaseYear;
        }
        //Pre: None
        //Post: String Formated Into A Line
        //Desc: Displays Game Data In Specific Line Format
        public virtual string DisplayLine()
        {
            return mediaType + "," + name + "," + cost + "," + barcode + "," + genre + "," + platform + "," + releaseYear;
        }
    }
}
