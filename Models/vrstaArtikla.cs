using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Authorization;

namespace SeminarskaNaloga.Models;
public class vrstaArtikla
    {
        public int vrstaArtiklaId { get; set; }
        public string vrsta { get; set; }
        public string opis { get; set; }
        public List<Artikel> Artikeli { get; set; }
    }