﻿namespace SGI.Aplicacion;
using System.Security.Cryptography;
using System.Text;

public static class ServicioFuncionHash
{
    public static String FuncionHashSHA256(string password)
    {
        byte[] passwordEnBytes = Encoding.UTF8.GetBytes(password);

        using (SHA256 funcionSHA256 = SHA256.Create())
        {
            byte[] hashBytes = funcionSHA256.ComputeHash(passwordEnBytes);

            string passwordPasadaPorHash = BitConverter.ToString(hashBytes).Replace("-", "").ToLower();

            return passwordPasadaPorHash;
        }
        
    }
}