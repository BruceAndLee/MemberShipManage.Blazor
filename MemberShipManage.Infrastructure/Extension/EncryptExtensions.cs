using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MemberShipManage.Infrastructure.Extension
{
    public static class EncryptExtensions
    {
        #region Base64

        /// <summary>}
        /// 将字符串使用base64算法编码 
        /// </summary>
        /// <param name="encodingName">编码类型（编码名称）</param>
        /// <param name="source">待加密的字符串</param>
        /// <returns>加密后的字符串</returns> 
        public static string EncodeBase64String(this string source, string encodingName = "UTF-8")
        {
            if (string.IsNullOrEmpty(source))
                return string.Empty;

            var bytes = Encoding.GetEncoding(encodingName).GetBytes(source);
            return Convert.ToBase64String(bytes);
        }

        /// <summary> 
        /// 将字符串使用base64算法解码
        /// </summary> 
        /// <param name="encodingName">编码类型</param> 
        /// <param name="base64String">已用base64算法加密的字符串</param> 
        /// <returns>解密后的字符串</returns> 
        public static string DecodeBase64String(this string base64String, string encodingName = "UTF-8")
        {
            if (string.IsNullOrEmpty(base64String))
                return string.Empty;

            var bytes = Convert.FromBase64String(base64String);
            return Encoding.GetEncoding(encodingName).GetString(bytes);
        }

        #endregion

        #region Md5

        /// <summary>
        /// 将字符串使用MD5算法加密
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string EncodeMd5String(this string source)
        {
            if (source.IsNullOrEmpty())
                return source;

            using var md5 = MD5.Create();
            var result = md5.ComputeHash(Encoding.Default.GetBytes(source));
            return BitConverter.ToString(result).Replace("-", "");
        }

        #endregion

        #region SHA

        /// <summary>
        /// 将字符串使用SHA1算法加密
        /// </summary>
        /// <param name="source">明文</param>
        /// <returns></returns>
        public static string EncodeSha1String(this string source)
        {
            if (string.IsNullOrEmpty(source))
                return string.Empty;

            using var sha1 = SHA1.Create();
            var buffer = Encoding.UTF8.GetBytes(source);
            var byteArr = sha1.ComputeHash(buffer);
            return BitConverter.ToString(byteArr).Replace("-", "").ToLower();
        }

        /// <summary>
        /// 将字符串使用SHA256算法加密
        /// </summary>
        /// <param name="source">明文</param>
        /// <returns></returns>
        public static string EncodeSha256String(this string source)
        {
            if (string.IsNullOrEmpty(source))
                return string.Empty;

            using var sha256 = SHA256.Create();
            var buffer = Encoding.UTF8.GetBytes(source);
            var byteArr = sha256.ComputeHash(buffer);
            return BitConverter.ToString(byteArr).Replace("-", "").ToLower();
        }

        /// <summary>
        /// 将字符串使用SHA384算法加密
        /// </summary>
        /// <param name="source">明文</param>
        /// <returns></returns>
        public static string EncodeSha384String(this string source)
        {
            if (string.IsNullOrEmpty(source))
                return string.Empty;

            using var sha384 = SHA384.Create();
            var buffer = Encoding.UTF8.GetBytes(source);
            var byteArr = sha384.ComputeHash(buffer);
            return BitConverter.ToString(byteArr).Replace("-", "").ToLower();
        }

        /// <summary>
        /// 将字符串使用SHA512算法加密
        /// </summary>
        /// <param name="source">明文</param>
        /// <returns></returns>
        public static string EncodeSha512String(this string source)
        {
            if (string.IsNullOrEmpty(source))
                return string.Empty;

            using var sha512 = SHA512.Create();
            var buffer = Encoding.UTF8.GetBytes(source);
            var byteArr = sha512.ComputeHash(buffer);
            return BitConverter.ToString(byteArr).Replace("-", "").ToLower();
        }

        #endregion
    }
}