using RtfPipe;

public static class RtfHelper
{
    public static string? ConvertRtfToHtml(string rtfText)
    {
        if (rtfText[0] == '{')
        {
            return Rtf.ToHtml(rtfText);
        }
        else return null;
    }
}