Imports System.IO
Imports System.Net
Imports System.Net.Security
Imports System.Security.Cryptography.X509Certificates
Imports Newtonsoft.Json
Imports System.Web.Script.Serialization
Imports System.Security.Cryptography
Imports System.Net.Http
Imports System.Threading.Tasks
Imports System.Net.Http.Headers
Imports System.Drawing
Imports Paydirekt_vb.Paydirekt_vb.Domain
Imports Paydirekt_vb.Paydirekt_vb.Common


Public Class indexpage
    Inherits System.Web.UI.Page
    'SANDBOX DETAIL
    Const _TOKEN_OBTAIN_ENDPOINT = "https://"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        getAccesstoken()
    End Sub

    Protected Sub btnAccesstoken_Click(sender As Object, e As EventArgs) Handles btnAccesstoken.Click
        getAccesstoken()

    End Sub

    '*
    '* Methods Accesstoken
    '*
    Public Sub getAccesstoken()

        SecurityClient()
        Dim txtResults As String = String.Empty
        Dim obj As AccessToken = New AccessToken()
        Dim requestID = obj.RequestID
        Dim requestAuthKey = obj.AuthKey
        Dim requestDate = obj.Currentdate
        Dim Signature = obj.AuthCode
        Dim randomNonce = obj.RandomNonce

        Try

            Dim httpWebRequest = DirectCast(WebRequest.Create(_TOKEN_OBTAIN_ENDPOINT), HttpWebRequest)
            Dim byteData() As Byte

            'ReQuired HTTP POST Header'
            httpWebRequest.Method = "POST"
            httpWebRequest.Accept = "application/hal+json"
            httpWebRequest.ContentType = "application/hal+json;charset=utf-8"

            'ReQuired PayDirekt POST Header'
            httpWebRequest.Headers.Add("X-Request-ID", requestID)
            httpWebRequest.Headers.Add("X-Auth-Key", requestAuthKey)
            httpWebRequest.Headers.Add("X-Auth-Code", Signature)
            httpWebRequest.Headers.Add("X-Date", requestDate)

            'Set the content length in the request headers  
            Using streamWriter = New StreamWriter(httpWebRequest.GetRequestStream())
                'Request Body <JSON>  Part from Paydirekt Request 
                Dim json As String = "{" + """grantType"":""api_key"" ," + """randomNonce"":""" + randomNonce + """}"
                streamWriter.Write(json)
            End Using

            Dim token = getAuthenitcation(requestAuthKey, Signature, requestDate, requestDate, randomNonce)
            'Includes all HTTP Request for Outh2 security
            'Detail on paydirekt.de/haendler/merchant-api.html
            httpWebRequest.Headers.Add("Authorization", token)
            ' Create a byte array of the data to send  
            byteData = UTF8Encoding.UTF8.GetBytes(token.ToString())

            'Get:: (Resource) ( Access _token (Json Format)
            Dim httpResponse = DirectCast(httpWebRequest.GetResponse(), HttpWebResponse)
            'reading for specified stream.
            Using streamReader = New StreamReader(httpResponse.GetResponseStream())
                Dim responseText = streamReader.ReadToEnd()
                lblresult.Text = responseText
            End Using

        Catch ex As WebException
            'error exeption 
            Dim err As HttpWebResponse = TryCast(ex.Response, HttpWebResponse)
            If err IsNot Nothing Then
                Dim htmlResponse As String = New StreamReader(err.GetResponseStream()).ReadToEnd()
                txtResults = String.Format("{0} {1}", err.StatusDescription, htmlResponse)
                lblresult.Text = txtResults
            End If
        End Try
    End Sub

End Class

