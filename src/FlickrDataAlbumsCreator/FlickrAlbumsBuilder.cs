using FlickrDataAlbumsCreator.Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace FlickrDataAlbumsCreator
{
    public class FlickrAlbumsBuilder
    {
        private const string SETTINGS_FILE = "appsettings.json";

        private const string CONFIG_SECTION_ALBUMS_PATH = "albumsPath";
        private const string CONFIG_SECTION_JSON_ALBUMS = "jsonAlbums";
        private const string CONFIG_SECTION_JSON_DATA_PATH = "jsonDataPath";
        private const string CONFIG_SECTION_PHOTOS_PATH = "photosPath";

        private string _albumsPath = String.Empty;
        private string _jsonAlbums = String.Empty;
        private string _jsonDataPath = String.Empty;
        private string _photosPath = String.Empty;

        private List<string> _errors = new List<string>();

        public FlickrAlbumsBuilder()
        {
            LoadConfiguration();

            if (_errors.Count > 0)
                throw new ApplicationException($"An error ocurred. Call to {nameof(GetErrorDetails)} for more details.");
        }

        public List<string> GetErrorDetails() => _errors.ToList();

        private void LoadConfiguration()
        {
            try
            {
                var builder = new ConfigurationBuilder().AddJsonFile(SETTINGS_FILE, true, true);
                var configuration = builder.Build();

                _albumsPath = configuration.GetSection(CONFIG_SECTION_ALBUMS_PATH).Value;
                _jsonAlbums = configuration.GetSection(CONFIG_SECTION_JSON_ALBUMS).Value;
                _jsonDataPath = configuration.GetSection(CONFIG_SECTION_JSON_DATA_PATH).Value;
                _photosPath = configuration.GetSection(CONFIG_SECTION_PHOTOS_PATH).Value;
            }
            catch (Exception ex)
            {
                _errors.Add($"An error ocurred: {ex.Message}");
            }
        }

        public bool Create()
        {
            _errors = new List<string>();

            try
            {
                var albums = GetFlickrAlbums().albums;
                CreateFlickrAlbums(albums);
            }
            catch (Exception ex)
            {
                _errors.Add($"An error ocurred: {ex.Message}");
            }
        
            return _errors.Count() > 0;
        }

        private FlickrAlbums GetFlickrAlbums()
        {
            var json = File.ReadAllText(Path.Combine(_jsonDataPath, _jsonAlbums));

            return JsonSerializer.Deserialize<FlickrAlbums>(json);
        }

        private void CreateFlickrAlbums(FlickrAlbums.Album[] albums)
        {
            if (!Directory.Exists(_albumsPath)) Directory.CreateDirectory(_albumsPath);

            foreach (var album in albums)
            {
                var directory = Path.Combine(_albumsPath, album.title);

                if (!Directory.Exists(directory)) Directory.CreateDirectory(directory);

                foreach (var photo in album.photos)
                {
                    if (photo != "0")
                    {
                        var images = Directory.GetFiles(_photosPath, $"*{photo}*");

                        if (images.Count() == 1)
                        {
                            var fileExtension = images[0].Split(".")[1];
                            File.Copy(images[0], Path.Combine(directory, $"{photo}.{fileExtension}"));
                        }
                    }
                }
            }
        }
    }
}