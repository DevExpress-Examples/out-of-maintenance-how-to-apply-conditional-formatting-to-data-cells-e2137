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
	''' <summary>
	''' Interaction logic for MainWindow.xaml
	''' </summary>
	Partial Public Class MainWindow
		Inherits Window

'INSTANT VB NOTE: The variable salesPersonDataTable was renamed since it may cause conflicts with calls to static members of the user-defined type with this name:
		Private salesPersonDataTable_Conflict As New NwindDataSet.SalesPersonDataTable()
		Private salesPersonDataAdapter As New SalesPersonTableAdapter()

		Public Sub New()
			InitializeComponent()
			pivotGridControl1.DataSource = salesPersonDataTable_Conflict
		End Sub

		Private Sub Window_Loaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
			salesPersonDataAdapter.Fill(salesPersonDataTable_Conflict)
		End Sub
	End Class

	Public Class ValueToColorConverter
		Inherits MarkupExtension
		Implements IValueConverter

		#Region "IValueConverter Members"
		Public Function Convert(ByVal value As Object, ByVal targetType As System.Type, ByVal parameter As Object, ByVal culture As System.Globalization.CultureInfo) As Object Implements IValueConverter.Convert
				If System.Convert.ToDecimal(value) < 10000 Then
					Return Brushes.Yellow
				Else
					Return Brushes.Transparent
				End If
		End Function

		Public Function ConvertBack(ByVal value As Object, ByVal targetType As System.Type, ByVal parameter As Object, ByVal culture As System.Globalization.CultureInfo) As Object Implements IValueConverter.ConvertBack
			Throw New System.NotImplementedException()
		End Function
		#End Region

		Public Overrides Function ProvideValue(ByVal serviceProvider As System.IServiceProvider) As Object
			Return Me
		End Function
	End Class
End Namespace
