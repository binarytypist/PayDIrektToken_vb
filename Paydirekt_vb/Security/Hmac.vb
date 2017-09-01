Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Security.Cryptography

Namespace Paydirekt_vb.Security
    Public Class Hmac

        'Valid time stamp generation
        Private Const dateFormat As String = "yyyyMMddHHmmss"

        'string-to-sign :: requestID: timestamp:apiky:nonce concatenation with separation by means of :
        Public Shared Function addSignature(requestId As String, timestamp As String, apiKey As String, nonce As String) As String
            Dim addTimestamp As String = DateTime.UtcNow.ToString(dateFormat).Replace(":", "")
            'merchant is in possession of the API Secrets and is allowed to send valid inquiries
            Dim stringToSign As String = String.Format("{0}:{1}:{2}:{3}", requestId, addTimestamp, apiKey, nonce)
            Return stringToSign
        End Function

        'request signature is formed by function HmacSha256 RFC[2104]
        'for detail:(visit weburl) >> tools.ietf.org/html/rfc2104
        Private Shared Function HmacSha256(key As Byte(), data As String) As Byte()
            Using hmac = New HMACSHA256(key)
                Return hmac.ComputeHash(Encoding.UTF8.GetBytes(data))
            End Using
        End Function

        '
        ' Generate the HMAC signature. The strong SHA-256 algorithm is used.
        ' @param stringToSign The string to sign which authenticates the message integrity.
        ' @param apiSecret The confidential API secret as provided with the API key.
        ' @return HMAC signature to be used in the header field <code>X-Auth-Code</code> in the token obtain endpoint.
        '     
        Public Shared Function getSignature(stringToSign As String, apiSecret As String) As String

            apiSecret = apiSecret.Replace("-"c, "+"c).Replace("_"c, "/"c).PadRight(apiSecret.Length + (4 - apiSecret.Length Mod 4) Mod 4, "="c)
            Dim secretBase64Decoded = Convert.FromBase64String(apiSecret)
            Dim hmac = Convert.ToBase64String(HmacSha256(secretBase64Decoded, stringToSign))
            Dim signature = hmac.Replace("+"c, "-"c).Replace("/"c, "_"c)
            Return signature

        End Function
    End Class

End Namespace




