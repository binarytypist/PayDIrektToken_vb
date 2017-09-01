Imports System.Collections.Concurrent
Imports System.Collections.Generic
Imports System.Linq
Imports System.Security.Cryptography
Imports System.Web
Imports Paydirekt_vb.Paydirekt_vb.Domain
Imports Paydirekt_vb.Paydirekt_vb.Security

Imports Newtonsoft.Json

'author:sammit neupane
'date: 28.08.2017

Namespace Paydirekt_vb

    Public NotInheritable Class Common
        Private Sub New()
        End Sub

        '*
        '* (api)
        '* client connects to the security endpoint.
        '* endpoint authenticates a shop.
        '*
        Public Shared AccessTokenList As New ConcurrentDictionary(Of String, AccessToken)()
        Private Const dateFormat As String = "yyyyMMddHHmmss"
        Const SANDBOX_TOKEN_OBTAIN_ENDPOINT = "https://api.paydirekt.de/api/merchantintegration/v1/token/obtain"
        Const API_KEY = "e81d298b-60dd-4f46-9ec9-1dbc72f5b5df"
        Const API_SECRET = "GJlN718sQxN1unxbLWHVlcf0FgXw2kMyfRwD0mgTRME="

        '*
        '* Gather all necessary information to generate HTTP Request
        '* 
        '*
        Public Shared Function SecurityClient() As AccessToken

            Dim Request_ID = "627a2766-079b-4ecd-acb6-74ab77c0a871"
            Dim Current_Date = System.DateTime.Now.ToUniversalTime().ToString("r")
            'Dim Random_Nonce = "_pQ3emiwKvxeJTBgiWKZN3JVGMj73nHtHde2QmD_ytg5atILhlFT2z81k5c8qW1M"
            Dim Random_Nonce = Nonce.RandomString(64)
            Dim TIme_stamp As String = DateTime.UtcNow.ToString(dateFormat).Replace(":", "")

            'StringToSign
            Dim stringtosign As String = Security.Hmac.addSignature(Request_ID, Current_Date, API_KEY, Random_Nonce)

            'This signature is X-Auth-Codespecified in the request header .
            Dim Secret_Signature As String = Security.Hmac.getSignature(stringtosign, API_SECRET)

            'Proceed to Domain class
            Dim addObjectInfo As New AccessToken
            With addObjectInfo
                .AuthCode = Secret_Signature
                .Currentdate = Current_Date
                .RequestID = Request_ID
                .AuthKey = API_KEY
                .RandomNonce = Random_Nonce
                .TimeStamp = TIme_stamp

            End With
            Return addObjectInfo

        End Function

        '*
        '* Access token Oauth2
        '*
        Public Shared Function getAuthenitcation(requestAuthKey As String, signature As String, requestID As String, requestDate As String, randomNonce As String)
            'create AUTHORIZATION the request header
            Dim headerFormat = "X-Auth-Key:""{0}"", X-Auth-Code:""{1}"", " +
                "X-Request-ID:""{2}"", X-Date:""{3}"", Content-Type:""{4}"",Accept:""{5}"",, grantType:""{6}"", randomNonce:""{7}"""
            Dim token = String.Format(headerFormat,
                                     (requestAuthKey), (signature), (requestID), (requestDate), ("application/hal+json;charset=utf-8"), ("application/hal+json"), ("api_key"), (randomNonce))

            Return token
        End Function


    End Class
End Namespace