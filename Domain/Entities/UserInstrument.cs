using Domain.Entities;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class UserInstrument
{
    [Required]
    public int UserId { get; set; }

    [Required]
    public int InstrumentId { get; set; }

    // Relaciones
    [ForeignKey("UserId")]
    public virtual Profile User { get; set; }

    [ForeignKey("InstrumentId")]
    public virtual Instrument Instrument { get; set; }
}
