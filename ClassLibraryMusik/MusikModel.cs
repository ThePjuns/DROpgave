using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Text;

namespace ClassLibraryMusik
{
    public class MusikModel
    {
        public string title { get; set; }
        public string artist { get; set; }
        public int duration { get; set; }
        public int yearOfPublication { get; set; }
        public string genre { get; set; }

        [Key]
        public int id { get; set; }

        public MusikModel()
        {

        }

        public MusikModel(string title, string artist, int duration, int yearOfPublication, string genre, int id)
        {
            this.title = title;
            this.artist = artist;
            this.duration = duration;
            this.yearOfPublication = yearOfPublication;
            this.genre = genre;
            this.id = id;
        }


        public override string ToString()
        {
            return $"title: {title}, artist: {artist}, duration: {duration}, yearOfPublication: {yearOfPublication}, genre: {genre}, id: {id}";
        }


    }
}
