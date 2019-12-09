namespace MusicHub.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using MusicHub.Data.Models;
    using MusicHub.Data.Models.Enums;
    using MusicHub.DataProcessor.ImportDtos;
    using Newtonsoft.Json;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data";

        private const string SuccessfullyImportedWriter 
            = "Imported {0}";
        private const string SuccessfullyImportedProducerWithPhone 
            = "Imported {0} with phone: {1} produces {2} albums";
        private const string SuccessfullyImportedProducerWithNoPhone
            = "Imported {0} with no phone number produces {1} albums";
        private const string SuccessfullyImportedSong 
            = "Imported {0} ({1} genre) with duration {2}";
        private const string SuccessfullyImportedPerformer
            = "Imported {0} ({1} songs)";

        public static string ImportWriters(MusicHubDbContext context, string jsonString)
        {
            StringBuilder result = new StringBuilder();
            List<Writer> writers = new List<Writer>();

            var writersDto = JsonConvert.DeserializeObject<ImportWriterDto[]>(jsonString);

            foreach (var writerDto in writersDto)
            {
                if (!IsValid(writerDto))
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }

                var writer = new Writer()
                {
                    Name = writerDto.Name,
                    Pseudonym = writerDto.Pseudonym
                };

                writers.Add(writer);

                result.AppendLine(String.Format(SuccessfullyImportedWriter, writer.Name));
            }

            context.Writers.AddRange(writers);
            context.SaveChanges();

            return result.ToString().TrimEnd();
        }

        public static string ImportProducersAlbums(MusicHubDbContext context, string jsonString)
        {
            StringBuilder result = new StringBuilder();
            List<Producer> producers = new List<Producer>();
            List<Album> albums = new List<Album>();

            var producersDto = JsonConvert.DeserializeObject<ImportProducerDto[]>(jsonString);

            foreach (var producerDto in producersDto)
            {
                if (!IsValid(producerDto) || !producerDto.Albums.All(IsValid))
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }

                var producer = new Producer()
                {
                    Name = producerDto.Name,
                    Pseudonym = producerDto.Pseudonym,
                    PhoneNumber = producerDto.PhoneNumber
                };

                foreach (var albumDto in producerDto.Albums)
                {
                    var album = new Album()
                    {
                        Name = albumDto.Name,
                        ReleaseDate = DateTime.ParseExact(albumDto.ReleaseDate, "dd/MM/yyyy", CultureInfo.InvariantCulture)
                    };

                    producer.Albums.Add(album);
                }

                producers.Add(producer);

                string message = producer.PhoneNumber == null
                        ? String.Format(SuccessfullyImportedProducerWithNoPhone, producer.Name, producer.Albums.Count)
                        : String.Format(SuccessfullyImportedProducerWithPhone, producer.Name, producer.PhoneNumber, producer.Albums.Count);

                result.AppendLine(message);
            }

            context.Producers.AddRange(producers);
            context.SaveChanges();

            return result.ToString().TrimEnd();
        }

        public static string ImportSongs(MusicHubDbContext context, string xmlString)
        {
            StringBuilder result = new StringBuilder();
            List<Song> songs = new List<Song>();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportSongDto[]), new XmlRootAttribute("Songs"));
            var songsDto = (ImportSongDto[])xmlSerializer.Deserialize(new StringReader(xmlString));

            foreach (var songDto in songsDto)
            {
                if (!IsValid(songsDto))
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }

                var isGenreValid = Enum.IsDefined(typeof(Genre), songDto.Genre);
                var album = context.Albums.Find(songDto.AlbumId);
                var writer = context.Writers.Find(songDto.WriterId);
                var isSongExits = songs.Any(s => s.Name == songDto.Name);

                if (!isGenreValid || album == null || writer == null)
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }

                var song = new Song()
                {
                    Name = songDto.Name,
                    Duration = TimeSpan.ParseExact(songDto.Duration, @"hh\:mm\:ss", CultureInfo.InvariantCulture),
                    CreatedOn = DateTime.ParseExact(songDto.CreatedOn, @"dd/MM/yyyy", CultureInfo.InvariantCulture).Date,
                    Genre = Enum.Parse<Genre>(songDto.Genre),
                    AlbumId = songDto.AlbumId,
                    WriterId = songDto.WriterId,
                    Price = songDto.Price
                };

                if (!IsValid(song))
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }

                songs.Add(song);

                result.AppendLine(String.Format(SuccessfullyImportedSong, song.Name, song.Genre, song.Duration));
            }

            context.Songs.AddRange(songs);
            context.SaveChanges();

            return result.ToString().TrimEnd();
        }

        public static string ImportSongPerformers(MusicHubDbContext context, string xmlString)
        {
            StringBuilder result = new StringBuilder();
            List<Performer> performers = new List<Performer>();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportPerformerDto[]), new XmlRootAttribute("Performers"));
            var performersDto = (ImportPerformerDto[])xmlSerializer.Deserialize(new StringReader(xmlString));

            foreach (var performerDto in performersDto)
            {
                var performer = new Performer()
                {
                    FirstName = performerDto.FirstName,
                    LastName = performerDto.LastName,
                    Age = performerDto.Age,
                    NetWorth = performerDto.NetWorth
                };

                var validSongsCount = context.Songs.Count(s => performerDto.Songs.Any(ps => ps.Id == s.Id));

                if ((validSongsCount != performerDto.Songs.Length) || performerDto.Songs.Length == 1)
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }

                performer.PerformerSongs = performerDto.Songs
                                                       .Select(s => new SongPerformer()
                                                       {
                                                           SongId = s.Id
                                                       })
                                                       .ToList();

                if (!IsValid(performer))
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }

                performers.Add(performer);

                result.AppendLine(String.Format(SuccessfullyImportedPerformer, performer.FirstName, performer.PerformerSongs.Count));
            }

            context.Performers.AddRange(performers);
            context.SaveChanges();

            return result.ToString().TrimEnd();
        }

        public static bool IsValid(object obj)
        {
            ValidationContext validationContext = new ValidationContext(obj);
            List<ValidationResult> validationResults = new List<ValidationResult>();

            return Validator.TryValidateObject(obj, validationContext, validationResults, true);
        }
    }
}