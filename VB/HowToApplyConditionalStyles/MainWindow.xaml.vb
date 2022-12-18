Imports System.Windows
Imports HowToBindToMDB.NwindDataSetTableAdapters
Imports System.Windows.Markup
Imports System.Windows.Data
Imports System
Imports System.Windows.Media

Namespace HowToBindToMDB

    ''' <summary>
    ''' Interaction logic for MainWindow.xaml
    ''' </summary>
    Public Partial Class MainWindow
        Inherits Window

        Private salesPersonDataTable As NwindDataSet.SalesPersonDataTable = New NwindDataSet.SalesPersonDataTable()

        Private salesPersonDataAdapter As SalesPersonTableAdapter = New SalesPersonTableAdapter()

        Public Sub New()
            Me.InitializeComponent()
            Me.pivotGridControl1.DataSource = salesPersonDataTable
        End Sub

        Private Sub Window_Loaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
            salesPersonDataAdapter.Fill(salesPersonDataTable)
        End Sub
    End Class

    Public Class ValueToColorConverter
        Inherits MarkupExtension
        Implements IValueConverter

'#Region "IValueConverter Members"
        Public Function Convert(ByVal value As Object, ByVal targetType As Type, ByVal parameter As Object, ByVal culture As Globalization.CultureInfo) As Object Implements IValueConverter.Convert
            If System.Convert.ToDecimal(value) < 10000 Then
                Return Brushes.Yellow
            Else
                Return Brushes.Transparent
            End If
        End Function

        Public Function ConvertBack(ByVal value As Object, ByVal targetType As Type, ByVal parameter As Object, ByVal culture As Globalization.CultureInfo) As Object Implements IValueConverter.ConvertBack
            Throw New NotImplementedException()
        End Function

'#End Region
        Public Overrides Function ProvideValue(ByVal serviceProvider As IServiceProvider) As Object
            Return Me
        End Function
    End Class
End Namespace
