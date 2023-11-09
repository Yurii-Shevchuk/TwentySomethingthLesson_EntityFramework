using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Metrics;
using Microsoft.EntityFrameworkCore;

namespace EF_db.Data;

public class User 
{
    public int UserId {get; set;}
    public string Username {get; set;}
    public string Email {get; set;}
    public DateTime BirthDate {get; set;}
    public ICollection<Review> Review {get; set;}
    public Gender GenderName{get; set;}
    public Country CountryName{get; set;}
}

public class Review 
{
    public int ReviewId {get; set;}
    public string Title {get; set;}
    public string Body {get; set;}
    public DateTime CreationDate {get; set;}
    public User User {get; set;}

    public Media Media {get; set;}
}

public class Gender
{
    public int GenderId {get; set;}
    public string GenderName {get; set;}
}

public class Country
{
    public int CountryId {get; set;}
    public string Name {get; set;}
    public string Code {get; set;}
}

public class Media 
{
    public int MediaId {get; set;}
    public string Title {get; set;}
    public DateTime ReleaseDate {get; set;}
    public string Description {get; set;}
    public byte[] CoverImage {get; set;}
    public Media_Type Type {get; set;}

    public ICollection<Review> Reviews {get;set;}
}

public class Media_Type
{
    public int Id {get; set;}
    public string Type {get; set;}
}

public class MediaAggregatorDbContext : DbContext
{
    public DbSet<User> Users {get; set;}
    public DbSet<Review> Reviews {get; set;}
    public DbSet<Gender> Genders {get; set;}
    public DbSet<Country> Countries {get; set;}
    public DbSet<Media> Medias {get; set;}
    //stupid name, I know
    public DbSet<Media_Type> Media_Types {get; set;}

    public MediaAggregatorDbContext()
    : base()
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseNpgsql("Server=127.0.0.1;Port=5432;User Id=admin;Password=admin;Database=media_aggregator");
    }

}