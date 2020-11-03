using System;
using System.ComponentModel.DataAnnotations;

namespace ModelLib
{
    public class Record
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }
        public string Artist { get; set; }
        public int Duration { get; set; }
        public int YearOfPublication { get; set; }
        public string Genre { get; set; }

        public Record(int id, string title, string artist, int duration, int yearOfPublication, string genre)
        {
            Id = id;
            Title = title;
            Artist = artist;
            Duration = duration;
            YearOfPublication = yearOfPublication;
            Genre = genre;
        }

        public Record()
        {

        }

        public override string ToString()
        {
            return $"Id: {Id}, Title: {Title}, Artist: {Artist}, Duration: {Duration}, YearOfPublication: {YearOfPublication}, Genre: {Genre}";
        }
    }
}
