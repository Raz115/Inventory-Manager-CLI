//Rating: Raza Hussain Mirza
//File Name: Game.cs
//Project Name: OOP_PASS 
//Creation Date: Sept. 21, 2021
//Modified Date: Oct. 30, 2021
//Description: The Game Class Creates Specific Instance Data Through Inheritance and Polymorphism
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PASS_2_New
{
    class Game : Media
    {
        //Store Custom Game Class Values
        private int score;
        private string rating;

        public Game(string mediaType, string name, double cost, string barcode, string genre, string platform, int releaseYear, string rating, int score) : base(mediaType, name, cost, barcode, genre, platform, releaseYear)
        {
            //Set Custom Game Class Values
            this.rating = rating;
            this.score = score;
        }
        //Pre: None
        //Post: Int Of Custom Game Data Which Is Rating In This Case
        //Desc: Get The Rating Of The Game
        public string GetRating()
        {
            return rating;
        }
        //Pre: None
        //Post: Int Of Custom Game Data Which Is MetacriticScore In This Case
        //Desc: Get The MetacriticScore Of The Game
        public int GetMetacriticScore()
        {
            return score;
        }
        //Pre: String Of Custom Game Data Which Is Rating In This Case
        //Post: None
        //Desc: Get The Rating Of The Game
        public void SetRating(string newRating)
        {
            //Set Rating to New Rating
            rating = newRating;
        }

        //Pre: String Which Stores New MetacriticScore
        //Post: None
        //Desc: Set The MetacriticScore
        public void SetMetacriticScore(int newScore)
        {
            //Set MetacriticScore to New MetacriticScore
            score = newScore;
        }
        //Pre: None
        //Post: String Formated InTo A Table
        //Desc: Displays Game Data In Specific Table Format
        public override string DisplayTable()
        {
            return "Type: " + mediaType + "\n" + "Name: " + name + "\n" + "Cost: " + cost + "\n" + "Barcode: " + barcode + "\n" + "Genre: " + genre + "\n" + "Palform: " + platform + "\n" + "Release Year: " + releaseYear + "\n" + "Rating: " + rating + "\n" + "Score: " + score ;
        }
        //Pre: None
        //Post: String Formated Into A Line
        //Desc: Displays Game Data In Specific Line Format
        public override string DisplayLine()
        {
            return mediaType + "," + name + "," + cost + "," + barcode + "," + genre + "," + platform + "," + releaseYear + "," + rating + "," + score;
        }
    }
}
