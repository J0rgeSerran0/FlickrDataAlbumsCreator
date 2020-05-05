# FlickrDataAlbumsCreator
This tool creates the Flickr's Albums structure from the Flickr Data information recovered in the Flickr Account settings section.

## **Introduction**
Is possible to download all your images from Flickr easily.

When you do this, you will be able to download your Account data and your Photos and videos.

It sound great, but the problem is that you will get your photos and videos all in the same directory (the same directory for all your photos), and the albums won't appear here.

However, in your Account data there is a JSON file with the Albums structure.

This project try to create that structure from this JSON file, copying the photos from the Photos and videos directory to their own album paths.


## **Get your Flickr Data**
To get your Flickr Data, you will have to go to your **Account settings**.

There, you will find the **Your Flickr Data** section.

![screenshot](https://raw.githubusercontent.com/J0rgeSerran0/FlickrDataAlbumsCreator/master/images/FlickrData_01.png)

Click in the **Request my Flickr data** button to get the information.

After some minutes or hours, you will see here the links to download your Flickr Data information.

![screenshot](https://raw.githubusercontent.com/J0rgeSerran0/FlickrDataAlbumsCreator/master/images/FlickrData_02.png)

You will download these files and uncompress them into your computer.

> The paths of your Flickr Data and Photos are important for this tool.


## **Development Tools**
For this project I have used C# as programming language and .NET Core 3.1 as programming technology.


## **How do this**
The project is very easy to understand.

These are the steps:

- Read the JSON Album file.
- Create the Album structure.
- Copy the Photos from the Photos directory to the Album directory.

There is a file named [**appsettings.json**](https://raw.githubusercontent.com/J0rgeSerran0/FlickrDataAlbumsCreator/master/src/FlickrDataAlbumsCreator/appsettings.json) that you will have to modify.
The information of this file is:

- **albumsPath** The Albums Path where the tool will create the albums structure
- **jsonAlbums** The name of the Albums JSON file (normally **albums.json**)
- **jsonDataPath** The JSON Data path where the Albums JSON file is found
- **photosPath** The Photos path where all photos are found

