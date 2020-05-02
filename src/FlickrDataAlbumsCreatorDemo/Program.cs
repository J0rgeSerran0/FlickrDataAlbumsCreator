using FlickrDataAlbumsCreator;
using System;

namespace FlickrDataAlbumsCreatorDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Flickr Data Albums Creator");

            var flickrAlbumsBuilder = new FlickrAlbumsBuilder();
            var errors = flickrAlbumsBuilder.Create();

            Console.ForegroundColor = ConsoleColor.Cyan;

            if (errors)
            {
                var errorDetails = flickrAlbumsBuilder.GetErrorDetails();
                Console.ForegroundColor = ConsoleColor.Red;
                foreach (var errorDetail in errorDetails)
                    Console.WriteLine(errorDetail);
            }
            else
                Console.WriteLine($"Albums created correctly!");

            Console.ResetColor();
            Console.WriteLine("Press any key to close...");
            Console.ReadKey();
        }
    }
}