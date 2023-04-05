using System.Text;

namespace WordSquare.File.Internal;
internal class FileReader : IFileReader
{
    public string ReadJsonFile(string path)
    {
        StringBuilder contents = new StringBuilder();

        try
        {
            // Open the file using a stream reader.
            using (StreamReader sr = new StreamReader(path))
            {
                // Read the stream line by line.
                string? line;
                while ((line = sr?.ReadLine()) != null)
                {
                    contents.AppendLine(line);
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("The file could not be read:");
            Console.WriteLine(e.Message);
        }

        return contents.ToString();
    }
}
