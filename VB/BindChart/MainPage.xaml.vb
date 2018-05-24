Imports System
Imports Windows.UI.Xaml.Controls

Namespace BindChart
    Public NotInheritable Partial Class MainPage
        Inherits Page

        Public Sub New()
            Me.InitializeComponent()
            DataContext = New ViewModel() With { _
                .Start = 10000, _
                .Count = 50000, _
                .Step = TimeSpan.FromHours(3) _
            }
        End Sub
    End Class
End Namespace
