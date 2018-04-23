Public Class DateTimeDataPoint

    Private privatePointArgument As DateTime
    Private privatePointValue As Double

    Public Property PointArgument() As DateTime
        Get
            Return privatePointArgument
        End Get
        Set(ByVal value As DateTime)
            privatePointArgument = value
        End Set
    End Property

    Public Property PointValue() As Double
        Get
            Return privatePointValue
        End Get
        Set(ByVal value As Double)
            privatePointValue = value
        End Set
    End Property

End Class

Public Class ViewModel
    Private startDate As New DateTime(2000, 1, 1)
    Private ReadOnly random1 As New Random()

    Private privateIncrement As TimeSpan
    Public Property Increment() As TimeSpan
        Get
            Return privateIncrement
        End Get
        Set(ByVal value As TimeSpan)
            privateIncrement = value
        End Set
    End Property

    Private privateCount As Integer
    Public Property Count() As Integer
        Get
            Return privateCount
        End Get
        Set(ByVal value As Integer)
            privateCount = value
        End Set
    End Property

    Private privateStart As Double
    Public Property Start() As Double
        Get
            Return privateStart
        End Get
        Set(ByVal value As Double)
            privateStart = value
        End Set
    End Property

    Private privateItemsSource As IEnumerable
    Public ReadOnly Property ItemsSource() As IEnumerable
        Get
            If privateItemsSource IsNot Nothing Then
                Return privateItemsSource
            Else
                privateItemsSource = CreateItemsSource(Count)
                Return privateItemsSource
            End If
        End Get
    End Property

    Protected Function CreateItemsSource(ByVal count As Integer) As IEnumerable
        Dim points = New List(Of DateTimeDataPoint)()

        Dim value As Double = GenerateStartValue(random1)
        points.Add(New DateTimeDataPoint() With {.PointArgument = startDate, .PointValue = value})
        For i As Integer = 1 To count - 1
            value += GenerateAddition(random1)
            startDate = startDate + Increment
            points.Add(New DateTimeDataPoint() With {.PointArgument = startDate, .PointValue = value})
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
