
// dto for jwt setting
namespace ClassLibrary1.Authentication;

public class JwtSettings
{
    public const string SectionName = "JwtSetting";
    public string Secret { get; set; } = null;
    public int ExpriryMinutes { get; set; }
    public string Issuer { get; set; }= null;
    public string Audience { get; set; }= null;
}