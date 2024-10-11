using System.Diagnostics;
using AutoMapper;
using dms_webapi.Data;
using dms_webapi.Entities;
using dms_webapi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace dms_webapi.Services;

internal class UserServices : IUserServices
{
    private readonly DocumentDbContext _dbContext;
    private readonly UserManager<User> _userManager;
    private readonly IEncryptionService _encryptionService;
    private readonly IMapper _mapper;

    public UserServices(DocumentDbContext dbContext, IEncryptionService encryptionService, IMapper mapper,
        UserManager<User> userManager)
    {
        _dbContext = dbContext;
        _encryptionService = encryptionService;
        _mapper = mapper;
        _userManager = userManager;
    }

    public async Task<User?> RegisterUser(UserRegistrationRequestDto userModel)
    {
        if (await _userManager.FindByEmailAsync(userModel.Email) is not null)
        {
            Console.WriteLine("User already exists");
            return null;
        }

        var encryptedPassword = _encryptionService.Encrypt(userModel.Password);

        var user = _mapper.Map<User>(userModel);
        user.PasswordHash = encryptedPassword;
        user.UserName = userModel.Email;
        user.WorkspaceName = $"{user.FirstName}'s Workspace";
        var isCreated = await _userManager.CreateAsync(user);

        if (isCreated.Succeeded) return user;
        Console.WriteLine("Failed to register user");
        return null;
    }

    public async Task<User?> LoginUser(string email, string password)
    {
        var user = await _userManager.FindByEmailAsync(email);
        if (user is null)
        {
            return null;
        }

        return string.Compare(user.PasswordHash, _encryptionService.Encrypt(password), StringComparison.Ordinal) != 0
            ? null
            : user;
    }

    private async Task<int> SaveChangesAsync()
    {
        return await _dbContext.SaveChangesAsync();
    }
}