using System.IO;

namespace Exception_handling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StreamReader streamReader = null;

            try
            {
                streamReader = new StreamReader(@"C:\Users\sparr\OneDrive\Documents\exception1.txt");
                Console.WriteLine(streamReader.ReadToEnd());
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("Please check if the file {0} exists", ex.FileName);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (streamReader != null)
            { 
                streamReader.Close();
            }
                Console.WriteLine("Finally block");
            }
            
        }
    }
}
