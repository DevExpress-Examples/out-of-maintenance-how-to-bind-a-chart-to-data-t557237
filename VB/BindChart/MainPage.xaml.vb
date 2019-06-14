Imports System
Imports Windows.UI.Xaml.Controls

Namespace BindChart
	Public NotInheritable Partial Class MainPage
		Inherits Page

		Public Sub New()
			Me.InitializeComponent()
			DataContext = New ViewModel() With {
				.Start = 10000,
				.Count = 50000,
				.Step = TimeSpan.FromHours(3)
			}
		End Sub
	End Class
End Namespace
