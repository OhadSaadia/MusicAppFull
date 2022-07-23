using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MusicApp.Entities.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Coutries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coutries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Publishers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DayOfFounding = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publishers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Artists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StageName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CoutryId = table.Column<int>(type: "int", nullable: true),
                    ImageSrc = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Artists_Coutries_CoutryId",
                        column: x => x.CoutryId,
                        principalTable: "Coutries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Albums",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AlbumName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ArtistId = table.Column<int>(type: "int", nullable: false),
                    DatePublished = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ImageSrc = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Albums", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Albums_Artists_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Artists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ArtistsUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArtistId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtistsUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArtistsUsers_Artists_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Artists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArtistsUsers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Songs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ArtistId = table.Column<int>(type: "int", nullable: false),
                    Watched = table.Column<int>(type: "int", nullable: false),
                    Duration = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DatePublished = table.Column<DateTime>(type: "datetime2", nullable: false),
                    YouTubeSrc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageSrc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PublisherId = table.Column<int>(type: "int", nullable: true),
                    AlbumId = table.Column<int>(type: "int", nullable: true),
                    GenreId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Songs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Songs_Albums_AlbumId",
                        column: x => x.AlbumId,
                        principalTable: "Albums",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Songs_Artists_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Artists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Songs_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Songs_Publishers_PublisherId",
                        column: x => x.PublisherId,
                        principalTable: "Publishers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SongPlayedLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TimePlayed = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SongId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SongPlayedLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SongPlayedLogs_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SongPlayedLogs_Songs_SongId",
                        column: x => x.SongId,
                        principalTable: "Songs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SongsUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SongId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SongsUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SongsUsers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SongsUsers_Songs_SongId",
                        column: x => x.SongId,
                        principalTable: "Songs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });


            migrationBuilder.InsertData(
                table: "Coutries",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Israel" },
                    { 2, "Use" },
                    { 3, "Spain" },
                    { 4, "Japan" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Pop" },
                    { 2, "Trance" },
                    { 3, "Rock" },
                    { 4, "Rap" },

                });

            migrationBuilder.InsertData(
                table: "Publishers",
                columns: new[] { "Id", "CompanyName", "DayOfFounding" },
                values: new object[,]
                {
                    { 1, "Nano Records", new DateTime(1990, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "ACD", new DateTime(1977, 7, 28, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "RRE", new DateTime(1955, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Artists",
                columns: new[] { "Id", "CoutryId", "FirstName", "LastName", "StageName" ,"ImageSrc" },
                values: new object[,]
                {
                    { 1, 1, "Erez", "Duvdev", "Infected Mushroom","https://www.tmisrael.co.il/static/images/live/event/eventphotos/MHP01_NEW_16_8_350x290.jpg" },
                    { 2, 1, "Yuval", "Terner", "New Born" , "https://mesibatube.com/wp-content/uploads/2021/07/new-born-goa-trance-1.jpg"},
                    { 3, 2, "Mok", "Row", "Ice Cube" , "https://upload.wikimedia.org/wikipedia/commons/2/2c/Ice-Cube_2014-01-09-Chicago-photoby-Adam-Bielawski.jpg"},
                    { 5, 3, "Enrike", "du", "Enrike" , null },
                    { 4, 4, "Kun", "Jang", "Samorai" , null}
                });

            migrationBuilder.InsertData(
            table: "Albums",
            columns: new[] { "Id", "AlbumName", "ArtistId", "DatePublished", "ImageSrc" },
            values: new object[,]
            {
                    { 1,  "BP Empire", 1, new DateTime(2002,03,03, 0, 0, 0, 0, DateTimeKind.Unspecified),"https://i.ytimg.com/an_webp/STtd1uPh3I4/mqdefault_6s.webp?du=3000&sqp=CO60vJYG&rs=AOn4CLCa-QxorPXfJtMuNpQEQEKjllQ_sw" },
                    { 2, "Nothing But A Title", 2, new DateTime(2015,06,07, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://i.ytimg.com/vi/SEfza8xb4fU/hq720.jpg?sqp=-oaymwEcCOgCEMoBSFXyq4qpAw4IARUAAIhCGAFwAcABBg==&rs=AOn4CLBTc-3ib7eEHh2KUnOdAIN23imVXA" },
                    { 3, "The Predator", 3, new DateTime(2011,08,01, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://i.ytimg.com/vi/LcF2KUJVdLE/hqdefault.jpg?sqp=-oaymwEbCKgBEF5IVfKriqkDDggBFQAAiEIYAXABwAEG&rs=AOn4CLA_VuSPURQ7DCWFuVbfoGJHXtTcTg" },
                    { 4, "Death Certificate", 3, new DateTime(1991,04,04, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://i.discogs.com/4sBPq5_1SYX3SsALpwzr1I5kSxYxFXKj7S3eya_JfKc/rs:fit/g:sm/q:90/h:400/w:400/czM6Ly9kaXNjb2dz/LWRhdGFiYXNlLWlt/YWdlcy9SLTI0Mzc5/Ny0xMTI5Mjc4NjMw/LmpwZWc.jpeg" }
            });

            migrationBuilder.InsertData(
               table: "Songs",
               columns: new[] { "Id", "Name", "ArtistId", "Watched", "Duration", "PublisherId", "DatePublished", "AlbumId", "GenreId", "YouTubeSrc", "ImageSrc" },
               values: new object[,]
               {
                   {1, "Never Ever Land", 1, 243542,new DateTime(1900,01,01,00,07,47,00, DateTimeKind.Unspecified), 1, new DateTime(2002,03,03, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, "https://www.youtube.com/embed/gCAIeeDkUrQ","https://upload.wikimedia.org/wikipedia/he/c/c5/Bp_empire.jpg" },

                   {2, "Ubalanced (Baby Killer Remix)", 1, 192437,new DateTime(1900, 01, 01, 00, 07,15, 00, DateTimeKind.Unspecified), 1,new DateTime(2002,03,03, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, "https://www.youtube.com/embed/9mW7ewtDTmY", "https://upload.wikimedia.org/wikipedia/he/thumb/c/c5/Bp_empire.jpg/250px-Bp_empire.jpg" },

                   {3, "Spaniard (Live Mix)", 1, 303592, new DateTime(1900,01,01,00,08,31, 00, DateTimeKind.Unspecified), 1, new DateTime(2002,03,03, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, "https://www.youtube.com/embed/NJqJidQwoEs", "https://upload.wikimedia.org/wikipedia/he/thumb/c/c5/Bp_empire.jpg/250px-Bp_empire.jpg" },

                   {4, "Trip of the Luna King", 2, 43529,new DateTime(1900,01,01,00,09,07, 00, DateTimeKind.Unspecified), 2, new DateTime(2010,06,07, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2,"https://www.youtube.com/embed/fWeE14O28aQ","https://m.media-amazon.com/images/I/914YMAs2ZhL._SS500_.jpg" },

                   {6, "Universal Bus", 2, 563467, new DateTime(1900,01,01,00,11,12, 00, DateTimeKind.Unspecified), 2, new DateTime(2010,06,07, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2,"https://www.youtube.com/embed/YFenKIvY304","https://m.media-amazon.com/images/I/914YMAs2ZhL._SS500_.jpg" },

                   {7, "a Sleeper''s Guide", 2, 3466,new DateTime(1900,01,01,00,09,41, 00, DateTimeKind.Unspecified), 2, new DateTime(2010,06,07, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2,"https://www.youtube.com/embed/Ov8fYAeX2Xw","https://m.media-amazon.com/images/I/914YMAs2ZhL._SS500_.jpg" },

                   {8, "The Funeral", 3, 5642, new DateTime(1900,01,01,00,01,38, 00, DateTimeKind.Unspecified), 2, new DateTime(1991,04,04, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 4, "https://www.youtube.com/embed/7hPEHrRWCYo", "https://i.discogs.com/4sBPq5_1SYX3SsALpwzr1I5kSxYxFXKj7S3eya_JfKc/rs:fit/g:sm/q:90/h:400/w:400/czM6Ly9kaXNjb2dz/LWRhdGFiYXNlLWlt/YWdlcy9SLTI0Mzc5/Ny0xMTI5Mjc4NjMw/LmpwZWc.jpeg" },

                   {11,"The Wrong Nigga To Fuck Wit", 3, 23423, new DateTime(1900,01,01,00,02,48, 00, DateTimeKind.Unspecified), 2,new DateTime(1991,04,04, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 4, "https://www.youtube.com/embed/xjnqDpzHJ1Y", "https://i.discogs.com/4sBPq5_1SYX3SsALpwzr1I5kSxYxFXKj7S3eya_JfKc/rs:fit/g:sm/q:90/h:400/w:400/czM6Ly9kaXNjb2dz/LWRhdGFiYXNlLWlt/YWdlcy9SLTI0Mzc5/Ny0xMTI5Mjc4NjMw/LmpwZWc.jpeg" },

                   {12,"My Summer Vacation", 3, 2342, new DateTime(1900,01,01,00,03,56, 00, DateTimeKind.Unspecified), 2,new DateTime(1991,04,04, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 4, "https://www.youtube.com/embed/iXZOt1cVUcQ", "https://i.discogs.com/4sBPq5_1SYX3SsALpwzr1I5kSxYxFXKj7S3eya_JfKc/rs:fit/g:sm/q:90/h:400/w:400/czM6Ly9kaXNjb2dz/LWRhdGFiYXNlLWlt/YWdlcy9SLTI0Mzc5/Ny0xMTI5Mjc4NjMw/LmpwZWc.jpeg" },

                   {14,"The First Day Of School (Intro)", 3, 4645, new DateTime(1900,01,01,00,01,19, 00, DateTimeKind.Unspecified), 3, new DateTime(1990,05,05, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 4, "https://www.youtube.com/embed/RqxWEoCThyI", "https://i.pinimg.com/originals/ae/2f/f9/ae2ff9abc70583adb2b89552d6883b1a.jpg"},

                   {15,"When Will They Shoot?", 3, 7544,  new DateTime(1900, 01, 01, 00, 04,36, 00, DateTimeKind.Unspecified), 3, new DateTime(1990,05,05, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 4, "https://www.youtube.com/embed/UTeMWQfFvrQ", null }


               });

            migrationBuilder.CreateIndex(
                name: "IX_Albums_ArtistId",
                table: "Albums",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_Artists_CoutryId",
                table: "Artists",
                column: "CoutryId");

            migrationBuilder.CreateIndex(
                name: "IX_ArtistsUsers_ArtistId",
                table: "ArtistsUsers",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_ArtistsUsers_UserId",
                table: "ArtistsUsers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_SongPlayedLogs_SongId",
                table: "SongPlayedLogs",
                column: "SongId");

            migrationBuilder.CreateIndex(
                name: "IX_SongPlayedLogs_UserId",
                table: "SongPlayedLogs",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Songs_AlbumId",
                table: "Songs",
                column: "AlbumId");

            migrationBuilder.CreateIndex(
                name: "IX_Songs_ArtistId",
                table: "Songs",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_Songs_GenreId",
                table: "Songs",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_Songs_PublisherId",
                table: "Songs",
                column: "PublisherId");

            migrationBuilder.CreateIndex(
                name: "IX_SongsUsers_SongId",
                table: "SongsUsers",
                column: "SongId");

            migrationBuilder.CreateIndex(
                name: "IX_SongsUsers_UserId",
                table: "SongsUsers",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArtistsUsers");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "SongPlayedLogs");

            migrationBuilder.DropTable(
                name: "SongsUsers");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Songs");

            migrationBuilder.DropTable(
                name: "Albums");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "Publishers");

            migrationBuilder.DropTable(
                name: "Artists");

            migrationBuilder.DropTable(
                name: "Coutries");
        }
    }
}
