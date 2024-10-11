namespace dms_webapi.Services;

public interface IEncryptionService
{
    public string Encrypt(string plainText);
    public bool Verify(string hash, string plainText);
}