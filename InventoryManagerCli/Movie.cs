//Rating: Raza Hussain Mirza
//File Name: Movie.cs
//Project Name: OOP_PASS 
//Creation Date: Sept. 21, 2021
//Modified Date: Oct. 30, 2021
//Description: The Movie Class Creates Specific Instance Data Through Inheritance and Polymorphism
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PASS_2_New
{
    class Movie : Media
    {
        //Store Custom Movie Class Values
        private string director;
        private int movieDuration;
        private string rating;

        public Movie(string mediaType, string name, double cost, string barcode, string genre, string platform, int releaseYear, string director, string rating, int movieDuration) : base(mediaType, name, cost, barcode, genre, platform, releaseYear)
        {
            //Set Custom Movie Class Values
            this.director = director;
            this.movieDuration = movieDuration;
            this.rating = rating;
        }
        //Pre: None
        //Post: String Of Director Name
        //Desc: Get The Director Of The Movie
        public string GetDirector()
        {
            return director;
        }
        //Pre: None
        //Post: String Of Rating Score
        //Desc: Get The Rating Of The Movie
        public string GetRating()
        {
            return rating;
        }
        //Pre: None
        //Post: Int Of Movie Duration
        //Desc: Get The Movie Director
        public int GetMovieDuration()
        {
            return movieDuration;
        }
        //Pre: Int Storing New Rating
        //Post: None
        //Desc: Modify The Rating Of The Movie
        public void SetRating(string newRating)
        {
            rating =  newRating;
        }
        //Pre: String Storing New Directors Name
        //Post: None
        //Desc: Modify The Director Name 
        public void SetDirector(string newDirector)
        {
            director = newDirector;
        }
        //Pre: Int Storing New Movie Duration
        //Post: None
        //Desc: Modify The Movie Duration 
        public void SetMovieDuration(int newMovieDuration)
        {
            movieDuration = newMovieDuration;
        }
        //Pre: None
        //Post: String Formated Into A Table
        //Desc: Displays Game Data In Specific Table Format
        public override string DisplayTable()
        {
            return "Type: " + mediaType + "\n" + "Name: " + name + "\n" + "Cost: " + cost + "\n" + "Barcode: " + barcode + "\n" + "Genre: " + genre + "\n" + "Platform: " + platform + "\n" + "Release Year: " + releaseYear + "\n" + "Director: " + director + "\n" + "MPAA Rating: " + rating + "\n" + "Duration: " + movieDuration;
        } 
        //Pre: None
        //Post: String Formated Into A Line
        //Desc: Displays Game Data In Specific Line Format
        public override string DisplayLine()
        {
            return mediaType + "," + name + "," + cost + "," + barcode + "," + genre + "," + platform + "," + releaseYear + "," + director + "," + rating + "," + movieDuration;
        }
    }
}
