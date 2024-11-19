namespace BooksInventoryManagement.Domain.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string AuthorName { get; set; }
        public DateTime? PublicationDate { get; set; }
        public bool? IsBorrowed { get; private set; }
        public Guid? BorrowedBy { get; set; }
        public DateTime? BorrowedByDate { get; set; }
        public DateTime CancelBorrowDate { get; set; }     
        public int Quantity { get; set; }
        public int CreatedBy { get; set; }
        public int CreationDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? ModifiedBy { get; set; }
        public void MarkAsBorrowed(Guid userId)
        {
            IsBorrowed = true;
            BorrowedBy = userId;
            BorrowedByDate= DateTime.UtcNow;
        }
        public void MarkAsReturned()
        {
            IsBorrowed = false;
            CancelBorrowDate = DateTime.UtcNow;
        }
    }
}
