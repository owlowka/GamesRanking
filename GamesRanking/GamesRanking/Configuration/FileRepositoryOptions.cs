namespace GamesRanking.Configuration
{
    public class FileRepositoryOptions
    {
        public DirectoryInfo FileDirectory { get; set; }

        public FileRepositoryOptions()
        {
            FileDirectory = Directory.CreateDirectory(Environment.CurrentDirectory);
        }
    }
}