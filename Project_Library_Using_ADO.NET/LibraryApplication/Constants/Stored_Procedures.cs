namespace Library_Infrastructure.Constants
{
    public class Stored_Procedures
    {
        public const string spDoesBookExistById = "spDoesBookExistById";
        public const string spDoesBookExistByTitle = "spDoesBookExistByTitle";
        public const string spIsBookAvailableById = "spIsBookAvailableById";
        public const string spIsBookAvailableByTitle = "spIsBookAvailableByTitle";
        public const string spGetBookById = "spGetBookById";
        public const string spGetBookByTitle = "spGetBookByTitle";
        public const string spGetAllBooks = "spGetAllBooks";
        public const string spGetAvailableBooks = "spGetAvailableBooks";
        public const string spGetAllRentedBooks = "spGetAllRentedBooks";
        public const string spGetAllNotRentedBooks = "spGetAllNotRentedBooks";
        public const string spInsertNewBook = "spInsertNewBook";
        public const string spAddRemoveBookCopy = "spAddRemoveBookCopy";

        public const string spDoesMemberExistById = "spDoesMemberExistById";
        public const string spDoesMemberExistByFullName = "spDoesMemberExistByFullName";
        public const string spMemberHasMaxBooks = "spMemberHasMaxBooks";
        public const string spGetMemberById = "spGetMemberById";
        public const string spGetMemberByFullName = "spGetMemberByFullName";
        public const string spInsertMember = "spInsertMember";
        public const string spDeleteMember = "spDeleteMember";

        public const string spCreateTransaction = "spCreateTransaction";
        public const string spDoesTransactionExist = "spDoesTransactionExist";
        public const string spGetTransaction = "spGetTransaction";

        //i have to add a method in the members repo that is used when the book is returned
        //to change the number of books owed by a member
    }
}
