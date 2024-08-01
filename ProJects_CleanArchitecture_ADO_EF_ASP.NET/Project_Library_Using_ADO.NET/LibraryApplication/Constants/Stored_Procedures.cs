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

        public const string spAddRentedBookToMember = "spAddRentedBookToMember";
        public const string spRemoveRentedBookFromMember = "spRemoveRentedBookFromMember";

        public const string spDeleteMember = "spDeleteMember";

        public const string spCreateTransaction = "spCreateTransaction";
        public const string spDoesTransactionExist = "spDoesTransactionExist";

        public const string spUpdateTransaction = "spUpdateTransaction";
        public const string spHasMemberAlreadyRentedBook = "spHasMemberAlreadyRentedBook";

        

    }
}
