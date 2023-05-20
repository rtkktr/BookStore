using System.ComponentModel.DataAnnotations;

namespace BookStore.Domain.Models
{
    public class Author : BaseEntity
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Description { get; set; }

        #region Relations

        public List<Book>? Books { get; set; }

        #endregion
    }
}