using System.IO;
using System.Linq;

internal class FileAppender : Appender
{
    private int fileSize;

    public FileAppender(ILayout layout) : base(layout)
    {
        this.fileSize = 0;
    }

    public override void Append(string datetime, string message)
    {
        string result = string.Format(this.layout.ToString(), datetime, this.Report, message);

        this.fileSize += result.ToCharArray().Where(c => char.IsLetter(c)).Sum(c => c);

        File.AppendAllText("log.txt.", result);
    }

    public override string ToString()
    {
        return base.ToString() + $", File Size: {this.fileSize}";
    }
}