using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Authorization;

namespace SeminarskaNaloga.Models;
public class Trgovina
{
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int TrgovinaId { get; set; }
	public string img { get; set; }
	public string ime { get; set; }
    public List<Artikel> Artikli { get; set;}

}
