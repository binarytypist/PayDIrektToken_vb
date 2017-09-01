
Imports Newtonsoft.Json
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.Linq
Imports System.Web

'author:Sammit neupane
'Date: 28.08.2017

Namespace Paydirekt_vb.Domain

    '/**
    '* An OAuth2 access token as defined in
    '* <a href="https://tools.ietf.org/html/rfc6749#section-1.4">RFC 6749 Section 1.4</a>.
    '* <p>
    '* For all requests to the paydirekt system a valid access token Is required to authenticate your shop.
    ''* <p>
    '* The response from the service supplies some more fields, as defined by OAuth2 standard,
    '* which are Not relevant in our context.
    '*/

    Public Class AccessToken
        'Adding the commom properties'
        <JsonProperty("secretkey")>
        Public Shared _AuthCode As String
        <JsonProperty("base64secret")>
        Public Shared _AuthKey As String
        <JsonProperty("requestid")>
        Public Shared _RequestID As String
        <JsonProperty("currentdate")>
        Public Shared _Currentdate As String
        <JsonProperty("randomNonce")>
        Public Shared _RandomNonce As String

        'property for accessing the token'
        <JsonProperty("accessToken")>
        Public Shared _accessToken As String
        <JsonProperty("timesStamp")>
        Public Shared _timeStamp As String
        <JsonProperty("expires_in")>
        Public Shared expires_in As Long
        <JsonProperty("refresh_token")>
        Public Shared _refreshtoken As String

        Public Property AuthKey() As String
            Get
                Return _AuthKey
            End Get
            Set(ByVal Value As String)
                _AuthKey = Value
            End Set
        End Property

        Public Property AuthCode() As String
            Get
                Return _AuthCode
            End Get
            Set(ByVal Value As String)
                _AuthCode = Value
            End Set
        End Property


        Public Property RequestID() As String
            Get
                Return _RequestID
            End Get
            Set(ByVal Value As String)
                _RequestID = Value
            End Set
        End Property


        Public Property Currentdate() As String
            Get
                Return _Currentdate
            End Get
            Set(ByVal Value As String)
                _Currentdate = Value
            End Set
        End Property

        Public Property RandomNonce() As String
            Get
                Return _randomNonce
            End Get
            Set(ByVal Value As String)
                _randomNonce = Value
            End Set
        End Property

        ' *
        ' * The actual OAuth2 access token that must be provided as Bearer in the Authorization header in any subsequent
        ' * requests to the paydirekt system. The token can And should be used for multiple requests to the system.
        ' *
        ' *

        Public Property Accesstoken() As String
            Get
                Return _accessToken
            End Get
            Set(ByVal Value As String)
                _accessToken = Value
            End Set
        End Property

        Public Property TimeStamp() As String
            Get
                Return _timeStamp
            End Get
            Set(ByVal Value As String)
                _timeStamp = Value
            End Set
        End Property

        Public Property Expires() As Long
            Get
                Return expires_in
            End Get
            Set(ByVal Value As Long)
                expires_in = Value
            End Set
        End Property

        Public Property RefreshToken() As String
            Get
                Return _refreshtoken
            End Get
            Set
                _refreshtoken = Value
            End Set
        End Property

    End Class
End Namespace






