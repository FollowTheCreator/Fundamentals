namespace ITechart.Fundamentals.Logger.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

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
