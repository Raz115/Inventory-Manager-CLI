//Author: Raza Hussain Mirza
//File Name: Book.cs
//Project Name: OOP_PASS 
//Creation Date: Sept. 21, 2021
//Modified Date: Oct. 30, 2021
//Description: The Book Class Creates Specific Instance Data Through Inheritance and Polymorphism
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PASS_2_New
{
    class Book : Media
    {
        //Store Custom Book Class Values
        private string author;
        private string publisher;
        public Book(string mediaType, string name, double cost, string barcode, string genre, string platform, int releaseYear, string author, string publisher) : base(mediaType, name, cost, barcode, genre, platform, releaseYear)
        {
            //Set Custom Book Class Values
            this.author = author;
            this.publisher = publisher;
        }
        //Pre: None
        //Post: String Of Custom Book Data Which Is Author In This Case
        //Desc: Get The Author Of The Book
        public string GetAuthor()
        {
            return author;
        }
        //Pre: None
        //Post: String Of Custom Book Data Which Is Publisher In This Case
        //Desc: Get The Author Of The Book
        public string GetPublisher()
        {
            return publisher;
        }
        //Pre: String Which Stores New Author
        //Post: None
        //Desc: Set The Author's Name
        public void SetAuthor(string newAuthor)
        {
            //Set Author to New Author
            author = newAuthor;
        }
        //Pre: String Which Stores New Publisher
        //Post: None
        //Desc: Set The Author's Name
        public void SetPublisher(string newPublisher)
        {
            //Set Publisher to New Publisher
            publisher = newPublisher;
        }
        //Pre: None
        //Post: String Formated InTo A Table
        //Desc: Displays Book Data In Specific Table Format
        public override string DisplayTable()
        {
            return "Type: " + mediaType + "\n" + "Name: " + name + "\n" + "Cost: " + cost + "\n" + "Barcode: " + barcode + "\n" + "Genre: " + genre + "\n" + "Palform: " + platform + "\n" + "Release Year: " + releaseYear + "\n" + "Author: " + author + "\n" + "Publisher: " + publisher;
        }
        //Pre: None
        //Post: String Formated InTo A Line
        //Desc: Displays Book Data In Specific Line Format
        public override string DisplayLine()
        {
            return mediaType + "," + name + "," + cost + "," + barcode + "," + genre + "," + platform + "," + releaseYear + "," + author + "," + publisher;
        }

    }
}
