﻿using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Domain.Tools
{
    public static class Crypto
    {
        public static string ComputeSha256Hash(string input)
        {
            using(var hasher = SHA256.Create())
            {
                byte[] bytes = hasher.ComputeHash(Encoding.UTF8.GetBytes(input));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }

                return builder.ToString();
            }
        }
    }
}
