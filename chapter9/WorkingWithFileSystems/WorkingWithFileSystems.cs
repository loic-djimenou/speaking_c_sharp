using System.IO;
using System.Xml;
using static System.Console;
using static System.IO.Directory;
using static System.IO.Path;
using static System.Environment;
using System.IO.Compression;

namespace Working.With.Fille.Systems;
public static class WorkingWithFileSystems
{
    public static void Run()
    {
        //WorkingWithFiles();
        //WorkWithDrives();
        //WorkWithDirectories();
        //WorkWithFilesMore();
        //WorkWithText();
        WorkWithXml();
    }
    static void WorkingWithFiles()
    {
        WriteLine("{0,-33} {1}", "Path.PathSeparator", PathSeparator);

        WriteLine("{0,-33} {1}", "Path.DirectorySeparatorChar", DirectorySeparatorChar);

        WriteLine("{0,-33} {1}", "Directory.GetCurrentDirectory()", GetCurrentDirectory());

        WriteLine("{0,-33} {1}", "Environment.CurrentDirectory", CurrentDirectory);

        WriteLine("{0,-33} {1}", "Environment.SystemDirectory", SystemDirectory);

        WriteLine("{0,-33} {1}", "Path.GetTempPath()", GetTempPath());

        WriteLine("GetFolderPath(SpecialFolder");

        WriteLine("{0,-33} {1}", " .System)", GetFolderPath(SpecialFolder.System));

        WriteLine("{0,-33} {1}", " .ApplicationData)", GetFolderPath(SpecialFolder.ApplicationData));

        WriteLine("{0,-33} {1}", " .MyDocuments)", GetFolderPath(SpecialFolder.MyDocuments));

        WriteLine("{0,-33} {1}", " .Personal)", GetFolderPath(SpecialFolder.Personal));
    }

    static void WorkWithDrives()
    {
        WriteLine("{0,-30} | {1,-10} | {2,-7} | {3,18} | {4,18}", "NAME", "TYPE", "FORMAT", "SIZE (BYTES)", "FREE SPACE");
        foreach (DriveInfo drive in DriveInfo.GetDrives())
        {
            if (drive.IsReady)
            {
                WriteLine("{0,-30} | {1,-10} | {2,-7} | {3,18:N0} | {4,18:N0}", drive.Name, drive.DriveType, drive.DriveFormat, drive.TotalSize, drive.AvailableFreeSpace);
            }
            else
            {
                WriteLine("{0,-30} | {1,-10}", drive.Name, drive.DriveType);
            }
        }
    }
    static void WorkWithDirectories()
    {
        // define a directory path for a new folder
        // starting in the user's folder
        var newFolder = Combine(GetFolderPath(SpecialFolder.Personal), "Projects", "github", "speaking_c_sharp", "chapter9", "NewFolder");
        WriteLine($"Working with: {newFolder}");
        // check if it exists
        WriteLine($"Does it exist? {Exists(newFolder)}");
        // create directory
        WriteLine("Creating it...");
        CreateDirectory(newFolder);
        WriteLine($"Does it exist? {Exists(newFolder)}");
        Write("Confirm the directory exists, and then press ENTER: ");
        ReadLine();
        // delete directory
        WriteLine("Deleting it...");
        Delete(newFolder, recursive: true);
        WriteLine($"Does it exist? {Exists(newFolder)}");
    }

    static void WorkWithFilesMore()

    {

        // define a directory path to output files

        // starting in the user's folder

        var dir = Combine(GetFolderPath(SpecialFolder.Personal), "Projects", "github", "speaking_c_sharp", "chapter9", "OutputFiles");

        CreateDirectory(dir);

        // define file paths

        string textFile = Combine(dir, "Dummy.txt");


        string backupFile = Combine(dir, "Dummy.bak");



        WriteLine($"Working with: {textFile}");

        // check if a file exists

        WriteLine($"Does it exist? {File.Exists(textFile)}");

        // create a new text file and write a line to it

        StreamWriter textWriter = File.CreateText(textFile);

        textWriter.WriteLine("Hello, C#!");

        textWriter.Close(); // close file and release resources

        WriteLine($"Does it exist? {File.Exists(textFile)}");

        // copy the file, and overwrite if it already exists

        File.Copy(sourceFileName: textFile, destFileName: backupFile, overwrite: true);

        WriteLine($"Does {backupFile} exist? {File.Exists(backupFile)}");

        Write("Confirm the files exist, and then press ENTER: ");

        ReadLine();

        // delete file

        File.Delete(textFile);

        WriteLine($"Does it exist? {File.Exists(textFile)}");

        // read from the text file backup

        WriteLine($"Reading contents of {backupFile}:");

        StreamReader textReader = File.OpenText(backupFile);

        WriteLine(textReader.ReadToEnd());

        textReader.Close();

        WriteLine($"Folder Name: {GetDirectoryName(backupFile)}");

        WriteLine($"File Name: {GetFileName(backupFile)}");

        WriteLine("File Name without Extension: {0}", GetFileNameWithoutExtension(backupFile));

        WriteLine($"File Extension: {GetExtension(backupFile)}");

        WriteLine($"Random File Name: {GetRandomFileName()}");

        WriteLine($"Temporary File Name: {GetTempFileName()}");


        var info = new FileInfo(backupFile);

        WriteLine($"{backupFile}:");

        WriteLine($"Contains {info.Length} bytes");

        WriteLine($"Last accessed {info.LastAccessTime}");

        WriteLine($"Has readonly set to {info.IsReadOnly}");

    }


    static string[] callsigns = new string[] { "Husker", "Starbuck", "Apollo", "Boomer", "Bulldog", "Athena", "Helo", "Racetrack" };


    static void WorkWithText()
    {

        // define a file to write to
        string textFile = Combine(CurrentDirectory, "streams.txt");
        // create a text file and return a helper writer
        StreamWriter text = File.CreateText(textFile);
        // enumerate the strings, writing each one
        // to the stream on a separate line
        foreach (string item in callsigns)
        {
            text.WriteLine(item);
        }
        text.Close(); // release resources
                      // output the contents of the file
        WriteLine("{0} contains {1:N0} bytes.", arg0: textFile, arg1: new FileInfo(textFile).Length);
        WriteLine(File.ReadAllText(textFile));

    }


    static void WorkWithXml()
    {
        FileStream? xmlFileStream = null;
        XmlWriter? xml = null;
        try
        {
            // define a file to write to
            string xmlFile = Combine(CurrentDirectory, "streams.xml");
            // create a file stream
            xmlFileStream = File.Create(xmlFile);
            // wrap the file stream in an XML writer helper
            // and automatically indent nested elements
            xml = XmlWriter.Create(xmlFileStream,
            new XmlWriterSettings { Indent = true });
            // write the XML declaration
            xml.WriteStartDocument();
            // write a root element
            xml.WriteStartElement("callsigns");
            // enumerate the strings writing each one to the stream
            foreach (string item in callsigns)
            {
                xml.WriteElementString("callsign", item);
            }

            // write the close root element

            xml.WriteEndElement();

            // close helper and stream

            xml.Close();

            xmlFileStream.Close();

            // output all the contents of the file

            WriteLine($"{0} contains {1:N0} bytes.", arg0: xmlFile, arg1: new FileInfo(xmlFile).Length);

            WriteLine(File.ReadAllText(xmlFile));

        }
        catch (Exception ex)
        {
            // if the path doesn't exist the exception will be caught

            WriteLine($"{ex.GetType()} says {ex.Message}");

        }
        finally
        {

            if (xml != null)
            {
                xml.Dispose();
                WriteLine("The XML writer's unmanaged resources have been disposed.");
            }
            if (xmlFileStream != null)
            {
                xmlFileStream.Dispose();
                WriteLine("The file stream's unmanaged resources have been disposed.");
            }
        }
    }
}
