using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Authorization;

namespace SeminarskaNaloga.Models;
public class Ocena
    {
        public int OcenaId { get; set; }
        public AppUser AppUser { get; set; }
        public int ArtikelId { get; set; }
        [ForeignKey("ArtikelId")]
        public Artikel Artikel { get; set; }
        public int vrednostOcene { get; set; }
        public string Komentar { get; set; }
    }