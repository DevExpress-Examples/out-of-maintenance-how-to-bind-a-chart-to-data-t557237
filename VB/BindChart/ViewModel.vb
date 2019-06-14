Imports System
Imports System.Collections
Imports System.Collections.Generic

Namespace BindChart

	Public Class DateTimeDataPoint
		Public Property PointArgument() As DateTime
		Public Property PointValue() As Double
	End Class

	Public Class ViewModel
'INSTANT VB NOTE: The field start was renamed since Visual Basic does not allow fields to have the same name as other class members:
		Private start_Renamed As New DateTime(2000, 1, 1)
'INSTANT VB NOTE: The field itemsSource was renamed since Visual Basic does not allow fields to have the same name as other class members:
		Private itemsSource_Renamed As IEnumerable
		Private ReadOnly random As New Random()


		Public Property [Step]() As TimeSpan
		Public Property Count() As Integer
		Public Property Start() As Double
		Public ReadOnly Property ItemsSource() As IEnumerable
			Get
				If itemsSource_Renamed IsNot Nothing Then
					Return itemsSource_Renamed
				Else
					itemsSource_Renamed = CreateItemsSource(Count)
					Return itemsSource_Renamed
				End If
			End Get
		End Property

'INSTANT VB NOTE: The variable count was renamed since Visual Basic does not handle local variables named the same as class members well:
		Protected Function CreateItemsSource(ByVal count_Renamed As Integer) As IEnumerable
			Dim points = New List(Of DateTimeDataPoint)()

			Dim value As Double = GenerateStartValue(random)
			points.Add(New DateTimeDataPoint() With {
				.PointArgument = start_Renamed,
				.PointValue = value
			})
			For i As Integer = 1 To count_Renamed - 1
				value += GenerateAddition(random)
				start_Renamed = start_Renamed.Add([Step])
				points.Add(New DateTimeDataPoint() With {
					.PointArgument = start_Renamed,
					.PointValue = value
				})
			Next i
			Return points
		End Function

		Protected Function GenerateStartValue(ByVal random As Random) As Double
			Return Start + random.NextDouble() * 100
		End Function

		Protected Function GenerateAddition(ByVal random As Random) As Double
			Dim factor As Double = random.NextDouble()
			If factor = 1 Then
				factor = 50
			ElseIf factor = 0 Then
				factor = -50
			End If
			Return (factor - 0.5) * 50
		End Function
	End Class
End Namespace
