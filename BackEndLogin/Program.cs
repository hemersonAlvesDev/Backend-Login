using Npgsql;
using System.Security.Cryptography;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors();

var app = builder.Build();

app.UseCors(p => p
    .WithOrigins("http://localhost:3000")
    .AllowAnyHeader()
    .AllowAnyMethod());

string conexao =
    "Host=localhost;Port=5432;DataBase=dbLogin;" +
    "Username=postgres;Password=D3VSwcc!";

string GerarHash(string senha)
{
    byte[] salt = RandomNumberGenerator.GetBytes(16);

    byte[] hash = Rfc2898DeriveBytes.Pbkdf2(
        senha, salt, 100000, 
        HashAlgorithmName.SHA256, 32);

    return Convert.ToBase64String(salt) + ":" + 
            Convert.ToBase64String(hash);
}


bool VerificarHash(string senha, string hashArmazenado)
{
    var partes = hashArmazenado.Split(':');
    if (partes.Length !=2)
        return false;

    try
    {
        
    }
}