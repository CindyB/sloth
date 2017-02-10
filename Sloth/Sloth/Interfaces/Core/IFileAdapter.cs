namespace Sloth.Interfaces.Core
{

    public interface IFileAdapter
    {

        void AppendToFile(string filePath, string line);

        string[] ReadAllLines(string filePath);

    }

}
