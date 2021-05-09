using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Cryptography;
using System.Text;

namespace Catsier.Security {
	public static class Hasher {
		public static string Hash(string hash) {
            using (var hasher = SHA256.Create()) {
                var buffer = hasher.ComputeHash(Encoding.UTF8.GetBytes(hash));
                var sb = new StringBuilder();
                for (var i = 0; i < buffer.Length; i++) {
                    sb.Append(buffer[i].ToString("x2"));
                }
                return sb.ToString();
            }
        }

        public static string Hash(SecureString secureString) {
            return Hash(SecureStringToString(secureString));
		}

        private static string SecureStringToString(SecureString value) {
            IntPtr valuePtr = IntPtr.Zero;
            try {
                valuePtr = Marshal.SecureStringToGlobalAllocUnicode(value);
                return Marshal.PtrToStringUni(valuePtr);
            } finally {
                Marshal.ZeroFreeGlobalAllocUnicode(valuePtr);
            }
        }
    }
}
