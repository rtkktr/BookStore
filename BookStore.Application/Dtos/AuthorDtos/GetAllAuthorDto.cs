namespace BookStore.Application.Dtos.AuthorDtos
{
    public class GetAllAuthorDto
    {
        public Guid? Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}