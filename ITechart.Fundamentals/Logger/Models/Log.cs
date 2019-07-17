namespace ITechart.Fundamentals.Logger.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public partial class Log
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Type { get; set; }

        [StringLength(150)]
        public string Message { get; set; }

        public DateTime? Date { get; set; }
    }
}
