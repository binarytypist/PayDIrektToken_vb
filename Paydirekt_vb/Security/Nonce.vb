Imports System.Collections.Concurrent
Imports System.Security.Cryptography
Imports System.Text

Namespace Paydirekt_vb.Security
    '
    '/**
    '* A nonce Is a random arbitrary character sequence that may only be used once.
    '*/
    '
    Public Class Nonce
        Public Shared Function RandomString(length As Integer) As String
            Const valid As String = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890"
            Dim res As New StringBuilder()
            Using rng As New RNGCryptoServiceProvider()
                Dim uintBuffer As Byte() = New Byte(4 - 1) {}

                While System.Math.Max(System.Threading.Interlocked.Decrement(length), length + 1) > 0
                    rng.GetBytes(uintBuffer)
                    Dim num As UInteger = BitConverter.ToUInt32(uintBuffer, 0)
                    res.Append(valid(CInt(num Mod CUInt(valid.Length))))
                End While
            End Using
            Return res.ToString()
        End Function
    End Class
End Namespace
