Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.OleDb
Imports System.Windows
Imports DevExpress.Xpf.PivotGrid
Imports HowToBindToMDB.NwindDataSetTableAdapters
Imports System.Windows.Markup
Imports System.Windows.Data
Imports System
Imports System.Windows.Media

Namespace HowToBindToMDB
    Partial Public Class MainWindow
        Inherits Window
        Private salesPersonDataTable As New NwindDataSet.SalesPersonDataTable()
        Private salesPersonDataAdapter As New SalesPersonTableAdapter()

        Public Sub New()
            InitializeComponent()
            pivotGridControl1.DataSource = salesPersonDataTable
        End Sub

        Private Sub Window_Loaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
            salesPersonDataAdapter.Fill(salesPersonDataTable)
        End Sub
    End Class

    Public Class ValueToColorConverter
        Inherits MarkupExtension
        Implements IValueConverter
        #Region "IValueConverter Members"
        Public Function Convert(ByVal value As Object, _
								ByVal targetType As System.Type, _
								ByVal parameter As Object, _
								ByVal culture As System.Globalization.CultureInfo) _
								As Object Implements IValueConverter.Convert
                If System.Convert.ToDecimal(value) < 10000 Then
                    Return Brushes.Yellow
                Else
                    Return Brushes.Transparent
                End If
        End Function

        Public Function ConvertBack(ByVal value As Object, _
									ByVal targetType As System.Type, _
									ByVal parameter As Object, _
									ByVal culture As System.Globalization.CultureInfo) _
									As Object Implements IValueConverter.ConvertBack
            Throw New System.NotImplementedException()
        End Function
        #End Region

        Public Overrides Function ProvideValue(ByVal serviceProvider As System.IServiceProvider) As Object
            Return Me
        End Function
    End Class
End Namespace