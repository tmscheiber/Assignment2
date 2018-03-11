using System;
using System.ComponentModel.DataAnnotations;

namespace vs1
{
    public class VideoGame
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public string Platform { get; set; }
    }
}