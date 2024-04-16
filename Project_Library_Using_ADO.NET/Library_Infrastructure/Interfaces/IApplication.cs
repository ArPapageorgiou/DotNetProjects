﻿using Domain.Entities;

namespace Library_Application.Interfaces
{
    public interface IApplication
    {

        Books SearchBook(int bookId);//

        //message user if
        //1)book doesnt exist - simple message
        //2)book is available and return number of copies in inventory and how many are available
        //3)book has no copies available -simple message

        Books SearchBook(string title);//

        //message user if
        //1)book doesnt exist - simple message
        //2)book is available - return number of copies in inventory and how many are available
        //3)book has no copies available -simple message
        IEnumerable<Books> SearchAllRentedBooks();//
        //returns all rented books, how many are originally in inventory and how many are available
        IEnumerable<Books> SearchAllNotRentedBooks();//
        //returns all books that dont have a single rented copy
        IEnumerable<Books> SearchAllBooks();//
        //returns all books with all rental info 
        IEnumerable<Books> SearchAllAvailableBooks();//

        void CreateNewBook(Books book);//
        void AddRemoveBookCopy(int bookId, int ChangeByNumber);//does both jobs at once

        Members SearchMember(int id);//
        //checks if member exists, if they do return all their info and whether they have rented any books
        //and whether they can rent more
        Members SearchMember(string fullName);
        //checks if member exists, if they do return all their info and whether they have rented any books
        //and whether they can rent more

        void CreateMember(Members member);//
        //checks if member exists
        //if they do it messages user that the user allready exists
        //if they dont it prompts the user to input all relevant info about the new member
        void RentBookToMember(int memberId, int bookId, Transactions transaction);//
        //enter member name or member id and Book id  or book title
        //check if input is correct or exists
        //check if member is elligible for more books and if book has available copies
        //update database
        void ReturnBook(int memberId, int bookId);//
        //enter member name or member id and Book id  or book title
        //check if input is correct or exists
        //update database
        void HardDeleteMember(int memberId);//
        //check if member owes books and if he does then those copies should be subtracted from the
        //inventory as they are considered lost

    }
}
