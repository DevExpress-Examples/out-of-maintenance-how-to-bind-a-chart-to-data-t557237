Imports System
Imports System.Collections
Imports System.Collections.Generic

Namespace BindChart

    Public Class DateTimeDataPoint
        Public Property PointArgument() As Date
        Public Property PointValue() As Double
    End Class

    Public Class ViewModel

        Private start_Renamed As New Date(2000, 1, 1)

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

        Protected Function CreateItemsSource(ByVal count As Integer) As IEnumerable
            Dim points = New List(Of DateTimeDataPoint)()

            Dim value As Double = GenerateStartValue(random)
            points.Add(New DateTimeDataPoint() With { _
                .PointArgument = start_Renamed, _
                .PointValue = value _
            })
            For i As Integer = 1 To count - 1
                value += GenerateAddition(random)
                start_Renamed = start_Renamed.Add([Step])
                points.Add(New DateTimeDataPoint() With { _
                    .PointArgument = start_Renamed, _
                    .PointValue = value _
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
