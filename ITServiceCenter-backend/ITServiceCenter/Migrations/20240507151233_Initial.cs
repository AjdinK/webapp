using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace itservicecenter.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FAQ",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Pitanje = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Odgovor = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FAQ", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Grad",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grad", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Kategorija",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategorija", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "KorsnickiNalog",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prezime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Passweord = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: false),
                    IsServiser = table.Column<bool>(type: "bit", nullable: false),
                    IsProdavac = table.Column<bool>(type: "bit", nullable: false),
                    Is2FActive = table.Column<bool>(type: "bit", nullable: false),
                    JelObrisan = table.Column<bool>(type: "bit", nullable: false),
                    SlikaKorisnikaMala = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SlikaKorisnikaVelika = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KorsnickiNalog", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Proizvodjac",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proizvodjac", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Racun",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SifraRacuna = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DatumPreuzimanja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Napomena = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CijenaServisa = table.Column<float>(type: "real", nullable: false),
                    Garancija = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Racun", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ServisniNalog",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SifraNaloga = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DatumZaprimanja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DatumPredaje = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Napomena = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Problem = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServisniNalog", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Spol",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spol", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "VrstaDio",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VrstaDio", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Uredjaj",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KategorijaID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uredjaj", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Uredjaj_Kategorija_KategorijaID",
                        column: x => x.KategorijaID,
                        principalTable: "Kategorija",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "AutenfitikacijaToken",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Vrijednost = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VrijemeEvidentiranja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IpAdresa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsOtkljucano = table.Column<bool>(type: "bit", nullable: false),
                    TwoFKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KorisnickiNalogID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutenfitikacijaToken", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AutenfitikacijaToken_KorsnickiNalog_KorisnickiNalogID",
                        column: x => x.KorisnickiNalogID,
                        principalTable: "KorsnickiNalog",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "LogKretanjePoSistemu",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QueryPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostData = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Vrijeme = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IpAdresa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExceptionMessage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsException = table.Column<bool>(type: "bit", nullable: false),
                    KorisnikID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogKretanjePoSistemu", x => x.ID);
                    table.ForeignKey(
                        name: "FK_LogKretanjePoSistemu_KorsnickiNalog_KorisnikID",
                        column: x => x.KorisnikID,
                        principalTable: "KorsnickiNalog",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    GradID = table.Column<int>(type: "int", nullable: false),
                    SpolID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Admin_Grad_GradID",
                        column: x => x.GradID,
                        principalTable: "Grad",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Admin_KorsnickiNalog_ID",
                        column: x => x.ID,
                        principalTable: "KorsnickiNalog",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Admin_Spol_SpolID",
                        column: x => x.SpolID,
                        principalTable: "Spol",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Prodavac",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    GradID = table.Column<int>(type: "int", nullable: false),
                    SpolID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prodavac", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Prodavac_Grad_GradID",
                        column: x => x.GradID,
                        principalTable: "Grad",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Prodavac_KorsnickiNalog_ID",
                        column: x => x.ID,
                        principalTable: "KorsnickiNalog",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Prodavac_Spol_SpolID",
                        column: x => x.SpolID,
                        principalTable: "Spol",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Serviser",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    GradID = table.Column<int>(type: "int", nullable: false),
                    SpolID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Serviser", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Serviser_Grad_GradID",
                        column: x => x.GradID,
                        principalTable: "Grad",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Serviser_KorsnickiNalog_ID",
                        column: x => x.ID,
                        principalTable: "KorsnickiNalog",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Serviser_Spol_SpolID",
                        column: x => x.SpolID,
                        principalTable: "Spol",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "ServisniDio",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cijena = table.Column<float>(type: "real", nullable: false),
                    ProizvodjacID = table.Column<int>(type: "int", nullable: false),
                    VrstaDioID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServisniDio", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ServisniDio_Proizvodjac_ProizvodjacID",
                        column: x => x.ProizvodjacID,
                        principalTable: "Proizvodjac",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_ServisniDio_VrstaDio_VrstaDioID",
                        column: x => x.VrstaDioID,
                        principalTable: "VrstaDio",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Prodavac_Uredjaj",
                columns: table => new
                {
                    ProdavacID = table.Column<int>(type: "int", nullable: false),
                    UredjajID = table.Column<int>(type: "int", nullable: false),
                    ServisniNalogID = table.Column<int>(type: "int", nullable: false),
                    RacunID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prodavac_Uredjaj", x => new { x.ProdavacID, x.UredjajID, x.ServisniNalogID });
                    table.ForeignKey(
                        name: "FK_Prodavac_Uredjaj_Prodavac_ProdavacID",
                        column: x => x.ProdavacID,
                        principalTable: "Prodavac",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Prodavac_Uredjaj_Racun_RacunID",
                        column: x => x.RacunID,
                        principalTable: "Racun",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Prodavac_Uredjaj_ServisniNalog_ServisniNalogID",
                        column: x => x.ServisniNalogID,
                        principalTable: "ServisniNalog",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Prodavac_Uredjaj_Uredjaj_UredjajID",
                        column: x => x.UredjajID,
                        principalTable: "Uredjaj",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Serviser_Kategorija",
                columns: table => new
                {
                    ServiserID = table.Column<int>(type: "int", nullable: false),
                    KategorijaID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Serviser_Kategorija", x => new { x.ServiserID, x.KategorijaID });
                    table.ForeignKey(
                        name: "FK_Serviser_Kategorija_Kategorija_KategorijaID",
                        column: x => x.KategorijaID,
                        principalTable: "Kategorija",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Serviser_Kategorija_Serviser_ServiserID",
                        column: x => x.ServiserID,
                        principalTable: "Serviser",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Serviser_Uredjaj",
                columns: table => new
                {
                    ServiserID = table.Column<int>(type: "int", nullable: false),
                    UredjajID = table.Column<int>(type: "int", nullable: false),
                    ID = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Popravljeno = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Serviser_Uredjaj", x => new { x.ServiserID, x.UredjajID });
                    table.ForeignKey(
                        name: "FK_Serviser_Uredjaj_Serviser_ServiserID",
                        column: x => x.ServiserID,
                        principalTable: "Serviser",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Serviser_Uredjaj_Uredjaj_UredjajID",
                        column: x => x.UredjajID,
                        principalTable: "Uredjaj",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Serviser_ServisniDio",
                columns: table => new
                {
                    Datum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ServiserID = table.Column<int>(type: "int", nullable: false),
                    ServisniDioID = table.Column<int>(type: "int", nullable: false),
                    Kolicina = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Serviser_ServisniDio", x => new { x.ServiserID, x.ServisniDioID, x.Datum });
                    table.ForeignKey(
                        name: "FK_Serviser_ServisniDio_Serviser_ServiserID",
                        column: x => x.ServiserID,
                        principalTable: "Serviser",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Serviser_ServisniDio_ServisniDio_ServisniDioID",
                        column: x => x.ServisniDioID,
                        principalTable: "ServisniDio",
                        principalColumn: "ID");
                });

            migrationBuilder.InsertData(
                table: "FAQ",
                columns: new[] { "ID", "Odgovor", "Pitanje" },
                values: new object[,]
                {
                    { 1, "Cijena servisa se određuje u odnosu na model i kvar uređaja.", "Koja je cijena servisa?" },
                    { 2, "Vrijeme završetka servisa se određuje u trenutku kada se uređaj ostavlja na servis. Količina servisa, vrsta kvara, vrijeme ostavljanja servisa su neki od parametra koju utječu kada će vaš servis biti završen.", "Kada će moj telefon biti završen?" },
                    { 3, "Servis se plaća pri preuzimanju uređaja iz poslovnice.", "Kada se plaća servis?" }
                });

            migrationBuilder.InsertData(
                table: "Grad",
                columns: new[] { "ID", "Naziv" },
                values: new object[,]
                {
                    { 1, "Zenica" },
                    { 2, "Bihać" },
                    { 3, "Bijeljina" },
                    { 4, "Mostar" },
                    { 5, "Cazin" },
                    { 6, "Čapljina" },
                    { 7, "Drventa" },
                    { 8, "Doboj" },
                    { 9, "Goražde" },
                    { 10, "Gračanica" },
                    { 11, "Gradačac" },
                    { 12, "Gradiška" },
                    { 13, "Konjic" },
                    { 14, "Laktaši" },
                    { 15, "Livno" },
                    { 16, "Lukavac" },
                    { 17, "Ljubuški" },
                    { 18, "Bosanska Krupa" },
                    { 19, "Orašje" },
                    { 20, "Prijedor" },
                    { 21, "Prnjavor" },
                    { 22, "Sarajevo" },
                    { 23, "Srebrenik" },
                    { 24, "Stolac" },
                    { 25, "Široki Brijeg" },
                    { 26, "Travnik" },
                    { 27, "Tuzla" },
                    { 28, "Visoko" },
                    { 29, "Zavidovići" },
                    { 30, "Banja Luka" },
                    { 31, "Zvornik" },
                    { 32, "Živinice" },
                    { 33, "Donji Vakuf" },
                    { 34, "Zavidovići" }
                });

            migrationBuilder.InsertData(
                table: "Kategorija",
                columns: new[] { "ID", "Naziv" },
                values: new object[,]
                {
                    { 1, "Mobitel" },
                    { 2, "Tablet" },
                    { 3, "Laptop" },
                    { 4, "Računar" }
                });

            migrationBuilder.InsertData(
                table: "KorsnickiNalog",
                columns: new[] { "ID", "Email", "Ime", "Is2FActive", "IsAdmin", "IsProdavac", "IsServiser", "JelObrisan", "Passweord", "Prezime", "SlikaKorisnikaMala", "SlikaKorisnikaVelika", "Username" },
                values: new object[,]
                {
                    { 1, "test@test.com", "Ajdin", false, true, false, false, false, "ajdin", "Kuduzović", null, null, "ajdin" },
                    { 2, "test@test.com", "Jasir", false, false, false, true, false, "jasir", "Burić", null, null, "jasir" },
                    { 3, "test@test.com", "Adis", false, false, false, true, false, "adis", "Mešić", null, null, "adis" },
                    { 4, "test@test.com", "Alina", false, false, true, false, false, "alina", "Burić", null, null, "alina" },
                    { 5, "test@test.com", "Vedad", false, false, true, false, false, "vedad", "Keskin", null, null, "vedad" },
                    { 6, "test@test.com", "test", false, true, true, true, false, "test", "test", null, null, "test" }
                });

            migrationBuilder.InsertData(
                table: "Proizvodjac",
                columns: new[] { "ID", "Naziv" },
                values: new object[,]
                {
                    { 1, "Samsung" },
                    { 2, "Apple" },
                    { 3, "Xiaomi" }
                });

            migrationBuilder.InsertData(
                table: "Racun",
                columns: new[] { "ID", "CijenaServisa", "DatumPreuzimanja", "Garancija", "Napomena", "SifraRacuna" },
                values: new object[] { 1, 210f, new DateTime(2024, 5, 7, 17, 12, 32, 547, DateTimeKind.Local).AddTicks(2639), "30 Dana", "", "sifraracuna1" });

            migrationBuilder.InsertData(
                table: "ServisniNalog",
                columns: new[] { "ID", "DatumPredaje", "DatumZaprimanja", "Napomena", "Problem", "SifraNaloga" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 5, 9, 17, 12, 32, 547, DateTimeKind.Local).AddTicks(3313), new DateTime(2024, 5, 7, 17, 12, 32, 547, DateTimeKind.Local).AddTicks(3308), "Ocistiti prednju kameru", "Zamjena LCDa", "sifraservisa1" },
                    { 2, new DateTime(2024, 5, 9, 17, 12, 32, 547, DateTimeKind.Local).AddTicks(3322), new DateTime(2024, 5, 7, 17, 12, 32, 547, DateTimeKind.Local).AddTicks(3320), "", "zakljucan google acc", "sifraservisa2" },
                    { 3, new DateTime(2024, 5, 9, 17, 12, 32, 547, DateTimeKind.Local).AddTicks(3326), new DateTime(2024, 5, 7, 17, 12, 32, 547, DateTimeKind.Local).AddTicks(3325), "bitini podatci", "Spor", "sifraservisa3" },
                    { 4, new DateTime(2024, 5, 9, 17, 12, 32, 547, DateTimeKind.Local).AddTicks(3331), new DateTime(2024, 5, 7, 17, 12, 32, 547, DateTimeKind.Local).AddTicks(3329), "", "Nema slike", "sifraservisa4" },
                    { 5, new DateTime(2024, 5, 9, 17, 12, 32, 547, DateTimeKind.Local).AddTicks(3335), new DateTime(2024, 5, 7, 17, 12, 32, 547, DateTimeKind.Local).AddTicks(3333), "", "Ne radi brzo punjenje!", "sifraservisa5" }
                });

            migrationBuilder.InsertData(
                table: "Spol",
                columns: new[] { "ID", "Naziv" },
                values: new object[,]
                {
                    { 1, "Muški" },
                    { 2, "Ženski" }
                });

            migrationBuilder.InsertData(
                table: "VrstaDio",
                columns: new[] { "ID", "Naziv" },
                values: new object[,]
                {
                    { 1, "LCD" },
                    { 2, "Baterija" },
                    { 3, "Pločica punjenja" }
                });

            migrationBuilder.InsertData(
                table: "Admin",
                columns: new[] { "ID", "GradID", "SpolID" },
                values: new object[,]
                {
                    { 1, 22, 1 },
                    { 6, 1, 1 }
                });

            migrationBuilder.InsertData(
                table: "Prodavac",
                columns: new[] { "ID", "GradID", "SpolID" },
                values: new object[,]
                {
                    { 4, 4, 2 },
                    { 5, 4, 1 }
                });

            migrationBuilder.InsertData(
                table: "Serviser",
                columns: new[] { "ID", "GradID", "SpolID" },
                values: new object[,]
                {
                    { 2, 1, 1 },
                    { 3, 1, 1 }
                });

            migrationBuilder.InsertData(
                table: "ServisniDio",
                columns: new[] { "ID", "Cijena", "Naziv", "ProizvodjacID", "VrstaDioID" },
                values: new object[,]
                {
                    { 1, 100f, "Sasmung Galaxy A71", 1, 1 },
                    { 2, 50f, "Sasmung Galaxy A71", 1, 2 },
                    { 3, 220f, "Iphone 11 pro max 1klasa", 2, 1 },
                    { 4, 50f, "Sasmung Galaxy A71", 1, 3 }
                });

            migrationBuilder.InsertData(
                table: "Uredjaj",
                columns: new[] { "ID", "KategorijaID", "Naziv" },
                values: new object[,]
                {
                    { 1, 1, "Samsung Galaxy A71" },
                    { 2, 2, "Samsung Galaxy Tab A lite" },
                    { 3, 3, "Lenovo IdeaPad" },
                    { 4, 4, "Gaming računar" },
                    { 5, 1, "Samsung Galaxy S21" }
                });

            migrationBuilder.InsertData(
                table: "Prodavac_Uredjaj",
                columns: new[] { "ProdavacID", "ServisniNalogID", "UredjajID", "RacunID" },
                values: new object[,]
                {
                    { 4, 1, 1, 1 },
                    { 4, 2, 2, null },
                    { 4, 3, 3, null },
                    { 5, 4, 4, null },
                    { 5, 5, 5, null }
                });

            migrationBuilder.InsertData(
                table: "Serviser_Kategorija",
                columns: new[] { "KategorijaID", "ServiserID" },
                values: new object[,]
                {
                    { 1, 2 },
                    { 2, 2 },
                    { 3, 3 },
                    { 4, 3 }
                });

            migrationBuilder.InsertData(
                table: "Serviser_ServisniDio",
                columns: new[] { "Datum", "ServiserID", "ServisniDioID", "Kolicina" },
                values: new object[,]
                {
                    { new DateTime(2024, 5, 7, 17, 12, 32, 547, DateTimeKind.Local).AddTicks(2994), 2, 1, 3 },
                    { new DateTime(2024, 5, 7, 17, 12, 32, 547, DateTimeKind.Local).AddTicks(3001), 2, 2, 3 },
                    { new DateTime(2024, 5, 7, 17, 12, 32, 547, DateTimeKind.Local).AddTicks(3004), 2, 3, 2 },
                    { new DateTime(2024, 5, 7, 17, 12, 32, 547, DateTimeKind.Local).AddTicks(3007), 2, 4, 1 }
                });

            migrationBuilder.InsertData(
                table: "Serviser_Uredjaj",
                columns: new[] { "ServiserID", "UredjajID", "ID", "Popravljeno", "Status" },
                values: new object[,]
                {
                    { 2, 1, 1, true, "Završen uredja" },
                    { 2, 2, 2, false, "Radi se" },
                    { 2, 4, 5, false, "Analiza" },
                    { 2, 5, 3, false, "Ceka dio" },
                    { 3, 3, 4, false, "Radi se sistem..." }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Admin_GradID",
                table: "Admin",
                column: "GradID");

            migrationBuilder.CreateIndex(
                name: "IX_Admin_SpolID",
                table: "Admin",
                column: "SpolID");

            migrationBuilder.CreateIndex(
                name: "IX_AutenfitikacijaToken_KorisnickiNalogID",
                table: "AutenfitikacijaToken",
                column: "KorisnickiNalogID");

            migrationBuilder.CreateIndex(
                name: "IX_LogKretanjePoSistemu_KorisnikID",
                table: "LogKretanjePoSistemu",
                column: "KorisnikID");

            migrationBuilder.CreateIndex(
                name: "IX_Prodavac_GradID",
                table: "Prodavac",
                column: "GradID");

            migrationBuilder.CreateIndex(
                name: "IX_Prodavac_SpolID",
                table: "Prodavac",
                column: "SpolID");

            migrationBuilder.CreateIndex(
                name: "IX_Prodavac_Uredjaj_RacunID",
                table: "Prodavac_Uredjaj",
                column: "RacunID");

            migrationBuilder.CreateIndex(
                name: "IX_Prodavac_Uredjaj_ServisniNalogID",
                table: "Prodavac_Uredjaj",
                column: "ServisniNalogID");

            migrationBuilder.CreateIndex(
                name: "IX_Prodavac_Uredjaj_UredjajID",
                table: "Prodavac_Uredjaj",
                column: "UredjajID");

            migrationBuilder.CreateIndex(
                name: "IX_Serviser_GradID",
                table: "Serviser",
                column: "GradID");

            migrationBuilder.CreateIndex(
                name: "IX_Serviser_SpolID",
                table: "Serviser",
                column: "SpolID");

            migrationBuilder.CreateIndex(
                name: "IX_Serviser_Kategorija_KategorijaID",
                table: "Serviser_Kategorija",
                column: "KategorijaID");

            migrationBuilder.CreateIndex(
                name: "IX_Serviser_ServisniDio_ServisniDioID",
                table: "Serviser_ServisniDio",
                column: "ServisniDioID");

            migrationBuilder.CreateIndex(
                name: "IX_Serviser_Uredjaj_UredjajID",
                table: "Serviser_Uredjaj",
                column: "UredjajID");

            migrationBuilder.CreateIndex(
                name: "IX_ServisniDio_ProizvodjacID",
                table: "ServisniDio",
                column: "ProizvodjacID");

            migrationBuilder.CreateIndex(
                name: "IX_ServisniDio_VrstaDioID",
                table: "ServisniDio",
                column: "VrstaDioID");

            migrationBuilder.CreateIndex(
                name: "IX_Uredjaj_KategorijaID",
                table: "Uredjaj",
                column: "KategorijaID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropTable(
                name: "AutenfitikacijaToken");

            migrationBuilder.DropTable(
                name: "FAQ");

            migrationBuilder.DropTable(
                name: "LogKretanjePoSistemu");

            migrationBuilder.DropTable(
                name: "Prodavac_Uredjaj");

            migrationBuilder.DropTable(
                name: "Serviser_Kategorija");

            migrationBuilder.DropTable(
                name: "Serviser_ServisniDio");

            migrationBuilder.DropTable(
                name: "Serviser_Uredjaj");

            migrationBuilder.DropTable(
                name: "Prodavac");

            migrationBuilder.DropTable(
                name: "Racun");

            migrationBuilder.DropTable(
                name: "ServisniNalog");

            migrationBuilder.DropTable(
                name: "ServisniDio");

            migrationBuilder.DropTable(
                name: "Serviser");

            migrationBuilder.DropTable(
                name: "Uredjaj");

            migrationBuilder.DropTable(
                name: "Proizvodjac");

            migrationBuilder.DropTable(
                name: "VrstaDio");

            migrationBuilder.DropTable(
                name: "Grad");

            migrationBuilder.DropTable(
                name: "KorsnickiNalog");

            migrationBuilder.DropTable(
                name: "Spol");

            migrationBuilder.DropTable(
                name: "Kategorija");
        }
    }
}
