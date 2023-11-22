﻿' <auto-generated/>

Imports System.Reflection


Namespace Global.TestProject
    Friend Partial Class Resources
        Private Sub New
        End Sub
        
        Private Shared s_resourceManager As Global.System.Resources.ResourceManager
        Public Shared ReadOnly Property ResourceManager As Global.System.Resources.ResourceManager
            Get
                If s_resourceManager Is Nothing Then
                    s_resourceManager = New Global.System.Resources.ResourceManager(GetType(Resources))
                End If
                Return s_resourceManager
            End Get
        End Property
        Public Shared Property Culture As Global.System.Globalization.CultureInfo
        <Global.System.Runtime.CompilerServices.MethodImpl(Global.System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)>
        Friend Shared Function GetResourceString(ByVal resourceKey As String, Optional ByVal defaultValue As String = Nothing) As String
            Return ResourceManager.GetString(resourceKey, Culture)
        End Function
        ''' <summary>value</summary>
        Public Const [Name] As String = "Name"

    End Class
End Namespace