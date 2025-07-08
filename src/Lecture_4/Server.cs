namespace Lecture_4;

public class Server
{

    static bool Download(int fileCount)
    {
        for (int i = 0; i <= fileCount; i++)
        {
            Console.WriteLine($"{i + 1}. file downloaded");
        }
        return true;
    }

    static bool Upload(int fileCount)
    {
        for (int i = 0; i <= fileCount; i++)
        {
            Console.WriteLine($"{i + 1}. file uploaded ");
        }
        return true;
    }

    public static bool operator <<(Server server, int fileCount)
    {

        return Download(fileCount);
    }

    public static bool operator >>(Server server, int fileCount)
    {
        return Upload(fileCount);
    }
}