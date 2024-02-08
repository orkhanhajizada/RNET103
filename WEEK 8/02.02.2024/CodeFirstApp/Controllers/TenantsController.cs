using System.Security.Cryptography;
using System.Text;
using CodeFirstApp.Cryptography;
using CodeFirstApp.Data;
using CodeFirstApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace CodeFirstApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TenantsController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public TenantsController(ApplicationDbContext context)
    {
        _context = context;
    }


    [HttpPost]
    public async Task<IActionResult> Post(Tenant tenant)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var _tenant = _context.Tenants.FirstOrDefault(x => x.TenancyName == tenant.TenancyName);
        if (_tenant != null)
            return BadRequest("Tenant already exists");

        if (!string.IsNullOrWhiteSpace(tenant.ConnectionString))
        {
            string connectionString = tenant.ConnectionString;
            string key = "6A7B8C9D0E1F2G3H4I5J6K7L8M9N0O1P";
            string iv = $"{tenant.TenancyName}6A7B8C9D0E1F2G3H4I5J6K7L8M9N0O1P";

            byte[] keyBytes = new byte[32];
            byte[] ivBytes = new byte[16];

            Array.Copy(new SHA256Managed().ComputeHash(Encoding.ASCII.GetBytes(key)), keyBytes, keyBytes.Length);
            Array.Copy(new MD5CryptoServiceProvider().ComputeHash(Encoding.ASCII.GetBytes(key)), ivBytes,
                ivBytes.Length);

            using (var aes = Aes.Create())
            {
                aes.Key = keyBytes;
                aes.IV = ivBytes;
                var encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
                var decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                tenant.ConnectionString =
                    Convert.ToBase64String(CryptographyHelper.Encrypt(connectionString, encryptor));

                string decrypted =
                    CryptographyHelper.Decrypt(Convert.FromBase64String(tenant.ConnectionString), decryptor);
            }
        }


        _context.Tenants.Add(tenant);
        await _context.SaveChangesAsync();
        return Ok(tenant);
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var tenants = await _context.Tenants.ToListAsync();
        return Ok(tenants);
    }
}