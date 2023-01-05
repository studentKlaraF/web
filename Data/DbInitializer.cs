using SeminarskaNaloga.Data;
using SeminarskaNaloga.Models;
using System;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace SeminarskaNaloga.Data
{
    
    public static class DbInitializer
    
    {
        public static void Initialize(TrgovinaContext context)
        {
            context.Database.EnsureCreated();
            /*
            // Pogleda za stranke
            if (context.Uporabnik.Any())
            {
                return;   // DB has been seeded
            }
            
            var uporabniki = new Uporabnik[]
            {
                new Uporabnik{UporabnikId=1,ime="Carson",priimek="Alexander",naslov="Ulica zmage 5",posta="Ljubljana",stPoste=1000,telefon=070995170,admin=true},
                new Uporabnik{UporabnikId=2,ime="Meredith",priimek="Alonso",naslov="Ulica zmage 1",posta="Ljubljana",stPoste=1000,telefon=070995188},
                new Uporabnik{UporabnikId=3,ime="Arturo",priimek="Anand",naslov="Hrvaška ulica 3",posta="Ljubljana",stPoste=1000,telefon=070995175},
                new Uporabnik{UporabnikId=4,ime="Gytis",priimek="Barzdukas",naslov="Ulica zmage 5",posta="Ljubljana",stPoste=1000,telefon=070995100},
                new Uporabnik{UporabnikId=5,ime="Yan",priimek="Li",naslov="Ulica Jakoba Škofa 5",posta="Ljubljana",stPoste=1000,telefon=070995200},
                new Uporabnik{UporabnikId=6,ime="Peggy",priimek="Justice",naslov="Ulica herojev 9",posta="Ljubljana",stPoste=1000,telefon=070995999},
                new Uporabnik{UporabnikId=7,ime="Laura",priimek="Norman",naslov="Ulica svobode 5",posta="Ljubljana",stPoste=1000,telefon=080556974,admin=true},
                new Uporabnik{UporabnikId=8,ime="Nino",priimek="Olivetto",naslov="Ulica zmage 90",posta="Ljubljana",stPoste=1000,telefon=060974511}
            };

            context.Uporabnik.AddRange(uporabniki);
            context.SaveChanges();*/

            var artikli = new Artikel[]
            {
                new Artikel{ArtikelId=1050,naziv="Chemistry",cena=3.50,opis="Zelo kvalitetno"},
                new Artikel{ArtikelId=1051,naziv="Cat",cena=30,opis="Zelo puhasto"}
            };

            context.Artikel.AddRange(artikli);
            context.SaveChanges();

            var user = new AppUser
            {
                ime = "Bob",
                priimek = "Dilon",
                Email = "bob@example.com",
                NormalizedEmail = "XXXX@EXAMPLE.COM",
                UserName = "bob@example.com",
                NormalizedUserName = "bob@example.com",
                PhoneNumber = "+111111111111",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString("D")
            };

            if (!context.Users.Any(u => u.UserName == user.UserName))
            {
                var password = new PasswordHasher<AppUser>();
                var hashed = password.HashPassword(user,"Testni123!");
                user.PasswordHash = hashed;
                context.Users.Add(user);       
                }

            context.SaveChanges();
            
        }
    }
}