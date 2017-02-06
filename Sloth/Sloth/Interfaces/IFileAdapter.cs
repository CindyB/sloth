namespace Sloth.Interfaces
{

    public interface IFileAdapter
    {

        void AppendToFile(string filePath, string line);

        string[] ReadAllLines(string filePath);

    }

}
