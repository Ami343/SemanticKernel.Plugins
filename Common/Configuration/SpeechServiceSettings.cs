namespace Common.Configuration;

public class SpeechServiceSettings
{
    public static string SectionName = "SpeechService";
    
    public string ApiKey { get; set; }
    public string Region { get; set; }
}