﻿namespace BookStore.Domain.Models;

public class Translator : BaseEntity
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Description { get; set; }
    public DateTime DateCreation { get; set; }
    public DateTime DateModification { get; set; }
    public bool IsDeleted { get; set; }

    public List<Book>? Books { get; set; }
}