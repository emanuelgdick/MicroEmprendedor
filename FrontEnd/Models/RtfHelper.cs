using RtfPipe;

public static class RtfHelper
{
    public static string ConvertRtfToHtml(string rtfText)
    {
        return Rtf.ToHtml(rtfText);
    }
}