namespace MusicHub.DataProcessor
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using Data;
    using MusicHub.DataProcessor.ExportDtos;
    using Newtonsoft.Json;

    public class Serializer
    {
        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            var albums = context.Albums
                                .Where(a => a.ProducerId == producerId)
                                .OrderByDescending(a => a.Songs.Sum(s => s.Price))
                                .Select(a => new
                                {
                                    AlbumName = a.Name,
                                    ReleaseDate = a.ReleaseDate.ToString("MM/dd/yyyy"),
                                    ProducerName = a.Producer.Name,
                                    Songs = a.Songs
                                             .OrderByDescending(s => s.Name)
                                             .ThenBy(s => s.Writer.Name)
                                             .Select(s => new
                                             {
                                                 SongName = s.Name,
                                                 Price = s.Price.ToString("F2"),
                                                 Writer = s.Writer.Name
                                             }),
                                    AlbumPrice = a.Songs.Sum(s => s.Price).ToString("F2")
                                })
                                .ToArray();

            return JsonConvert.SerializeObject(albums, Resolver());
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            var tsDuration = TimeSpan.FromSeconds(duration);

            var songs = context.Songs
                               .Where(s => TimeSpan.Compare(s.Duration, tsDuration) == 1)
                               .OrderBy(s => s.Name)
                               .ThenBy(s => s.Writer.Name)
                               .ThenBy(s => s.SongPerformers.Select(sp => $"{sp.Performer.FirstName} {sp.Performer.LastName}"))
                               .Select(s => new ExportSongDto()
                               {
                                   SongName = s.Name,
                                   Writer = s.Writer.Name,
                                   Performer = s.SongPerformers
                                                .Select(sp => $"{sp.Performer.FirstName} {sp.Performer.LastName}")
                                                .FirstOrDefault(),
                                   AlbumProducer = s.Album.Producer.Name,
                                   Duration = s.Duration.ToString("c")
                               })
                               .ToArray();

            return ResultFormater<ExportSongDto[]>(songs, "Songs");
        }

        //Helper method
        private static JsonSerializerSettings Resolver()
        {
            return new JsonSerializerSettings
            {
                Formatting = Newtonsoft.Json.Formatting.Indented
            };
        }


        // Helper method
        private static string ResultFormater<T>(T selection, string rootAttributeName)
        {

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T), new XmlRootAttribute(rootAttributeName));

            var sb = new StringBuilder();

            var namespaces = new XmlSerializerNamespaces(new[]
            {
                new XmlQualifiedName("","")
            });

            xmlSerializer.Serialize(new StringWriter(sb), selection, namespaces);

            return sb.ToString().Trim();
        }
    }
}