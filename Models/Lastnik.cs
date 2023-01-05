using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Authorization;

namespace SeminarskaNaloga.Models;
public class Lastnik
{
    public int LastnikId { get; set; }
    public Trgovina Trgovina { get; set; }
}
