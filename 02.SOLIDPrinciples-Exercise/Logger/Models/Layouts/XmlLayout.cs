using System;
using System.Text;

internal class XmlLayout : ILayout
{
    public override string ToString()
    {
        StringBuilder builder = new StringBuilder();

        builder.AppendLine("<log>");
        builder.AppendLine("    <date>{0}</date>");
        builder.AppendLine("    <level>{1}</level>");
        builder.AppendLine("    <message>{2}</message>");
        builder.AppendLine("</log>");

        return builder.ToString().TrimEnd();
    }
}