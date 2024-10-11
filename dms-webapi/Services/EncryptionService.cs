namespace dms_webapi.Services;

public class EncryptionService : IEncryptionService
{
    private readonly int _rounds;

    public EncryptionService(IConfiguration configuration)
    {
        _rounds = int.Parse(configuration["Encryption:Rounds"] ??
                            throw new InvalidOperationException("encryption:rounds is missing"));
    }

    public string Encrypt(string plainText)
    {
        var salt = BCrypt.Net.BCrypt.GenerateSalt(_rounds);
        return BCrypt.Net.BCrypt.HashPassword(plainText, salt);
    }

    public bool Verify(string hash, string plainText)
    {
        throw new NotImplementedException();
    }
}