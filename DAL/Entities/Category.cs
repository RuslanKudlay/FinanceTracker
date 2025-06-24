﻿namespace DAL.Entities;

public class Category : BaseEntity
{
    public string Name { get; set; }
    public Guid? UserId { get; set; }
    public User? User { get; set; }
}