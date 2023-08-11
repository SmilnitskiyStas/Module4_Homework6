using AllMaterialsIn4Module.Entities;
using AllMaterialsIn4Module.Models;

namespace AllMaterialsIn4Module
{
    internal class Starter
    {
        public static void Run()
        {
            QueryToDB();
        }

        public static void QueryToDB()
        {
            // 1. Вывести название песни, имя исполнителя, название жанра песни. Вывести только песни у которых есть жанр и которые поет существующий исполнитель.
            using (ApplicationContext applicationContext = new ApplicationContext())
            {
                var songs = applicationContext.ArtistSongs.Join(
                    applicationContext.Songs,
                    ar => ar.SongId,
                    s => s.SongId,
                    (ar, s) => new
                    {
                        SongName = s.Title,
                        ArtistSongsId = ar.ArtistId,
                        GenreId = s.Genre
                    }).Join(
                    applicationContext.Artists,
                    ar => ar.ArtistSongsId,
                    a => a.ArtistId,
                    (ar, a) => new
                    {
                        SongName = ar.SongName,
                        ArtistName = a.Name,
                        Genre = ar.GenreId.Title
                    }).Where(g => g.Genre != null && g.ArtistName != null);
            }

            // 2. Вывести кол-во песен в каждом жанре.
            using (ApplicationContext applicationContext = new ApplicationContext())
            {
                var songsCount = applicationContext.Songs.GroupBy(s => s.Genre.Title).Select(g => new
                {
                    Key = g.Key,
                    Count = g.Count()
                });
            }

            // 3. Вывести песни, которые были написаны (ReleasedDate) до рождения самого молодого исполнителя.
            using (ApplicationContext applicationContext = new ApplicationContext())
            {
                var songToBD = applicationContext.ArtistSongs.Join(
                    applicationContext.Artists,
                    ar => ar.ArtistId,
                    a => a.ArtistId,
                    (ar, a) => new
                    {
                        Name = a.Name,
                        BirthDate = a.DateOfBirth,
                        SongId = ar.SongId
                    }).Join(
                    applicationContext.Songs,
                    a => a.SongId,
                    s => s.SongId,
                    (a, s) => new
                    {
                        Song = s.Title,
                        ReleasedDate = s.ReleasedDate,
                        Birth = a.BirthDate
                    }).Where(s => s.ReleasedDate < s.Birth);
            }
        }

        public static void SeedDB()
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                Genre genre1 = new Genre { Title = "Pop" };
                Genre genre2 = new Genre { Title = "Jazz" };
                Genre genre3 = new Genre { Title = "Rock " };
                Genre genre4 = new Genre { Title = "Hip hop" };
                Genre genre5 = new Genre { Title = "Lyrics" };

                context.Genres.Add(genre1);
                context.Genres.Add(genre2);
                context.Genres.Add(genre3);
                context.Genres.Add(genre4);
                context.Genres.Add(genre5);

                Song song1 = new Song { Title = "Душа", Duration = 2.19m, ReleasedDate = new DateTime(2011, 09, 14), Genre = genre5 };
                Song song2 = new Song { Title = "Коли мине війна", Duration = 3.01m, ReleasedDate = new DateTime(2022, 08, 05), Genre = genre1 };
                Song song3 = new Song { Title = "Василина", Duration = 3.21m, ReleasedDate = new DateTime(2014, 08, 19), Genre = genre1 };
                Song song4 = new Song { Title = "Kherson", Duration = 2.06m, ReleasedDate = new DateTime(2022, 12, 03), Genre = genre1 };
                Song song5 = new Song { Title = "Ну ж бо", Duration = 2.17m, ReleasedDate = new DateTime(2023, 03, 27), Genre = genre1 };

                context.Songs.Add(song1);
                context.Songs.Add(song2);
                context.Songs.Add(song3);
                context.Songs.Add(song4);
                context.Songs.Add(song5);

                Artist artist1 = new Artist { Name = "MamaRika", DateOfBirth = new DateTime(2016, 04, 08), Email = "mamarika@gmail.com", Phone = "+380978393123", InstagramUrl = @"https://www.instagram.com/mamarika_official/" };
                Artist artist2 = new Artist { Name = "NK", DateOfBirth = new DateTime(2017, 10, 24), Email = "nk@gmail.com", Phone = "+3806797867", InstagramUrl = @"https://www.instagram.com/kamenskux/" };
                Artist artist3 = new Artist { Name = "Dzidzio", DateOfBirth = new DateTime(2009, 04, 21), Email = "dzidzio@gmail.com", Phone = "+3805525875", InstagramUrl = @"https://www.instagram.com/dzidzio/" };
                Artist artist4 = new Artist { Name = "Kozak_System", DateOfBirth = new DateTime(2012, 07, 12), Email = "kozaksystem@gmail.com", Phone = "+380667707773", InstagramUrl = @"https://www.instagram.com/kozak_system/?hl=uk" };
                Artist artist5 = new Artist { Name = "Kozak Siromaha", DateOfBirth = new DateTime(2022, 12, 15), Email = "kozaksiromaha@gmail.com", Phone = "+380668858258", InstagramUrl = @"https://www.instagram.com/kozak.siromaha/" };

                context.Artists.Add(artist1);
                context.Artists.Add(artist2);
                context.Artists.Add(artist3);
                context.Artists.Add(artist4);
                context.Artists.Add(artist5);

                ArtistSong artistSong1 = new ArtistSong { Artist = artist1, Song = song1 };
                ArtistSong artistSong2 = new ArtistSong { Artist = artist2, Song = song2 };
                ArtistSong artistSong3 = new ArtistSong { Artist = artist3, Song = song3 };
                ArtistSong artistSong4 = new ArtistSong { Artist = artist4, Song = song4 };
                ArtistSong artistSong5 = new ArtistSong { Artist = artist5, Song = song5 };

                context.ArtistSongs.Add(artistSong1);
                context.ArtistSongs.Add(artistSong2);
                context.ArtistSongs.Add(artistSong3);
                context.ArtistSongs.Add(artistSong4);
                context.ArtistSongs.Add(artistSong5);

                context.SaveChanges();
            }
        }
    }
}
