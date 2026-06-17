# How to disable specific rows based on row data in .NET MAUI SfDataGrid?
This demo shows how to disable specific rows based on row data in [.NET MAUI DataGrid](https://help.syncfusion.com/maui/datagrid/overview)(SfDataGrid). 
It demonstrates how to apply conditional styling to visually indicate disabled rows and use DataGrid events to restrict selection and editing based on a property value in the underlying data.

## Xaml
```
     <ContentPage.BindingContext>
        <local:OrderInfoRepository x:Name="viewModel"/>
    </ContentPage.BindingContext>

    <ContentPage.Resources>
        <ResourceDictionary>
            <converters:RowDisableConverter x:Key="rowDisableConverter"/>
            <Style TargetType="syncfusion:DataGridRow">
                <Setter Property="Opacity" Value="{Binding Converter={StaticResource rowDisableConverter}}"/>
            </Style>
        </ResourceDictionary>
    </ContentPage.Resources>

    <ContentPage.Content>
        <syncfusion:SfDataGrid x:Name="dataGrid" NavigationMode="Cell" SelectionMode="Single" 
                          AllowEditing="True"
                          ColumnWidthMode="Auto"
                          GridLinesVisibility="Both" 
                          HeaderGridLinesVisibility="Both"
                          AutoGenerateColumnsMode="None"
                          ItemsSource="{Binding OrderInfoCollection}">
            <syncfusion:SfDataGrid.Columns>
                <syncfusion:DataGridTextColumn MappingName="OrderID" 
                                             HeaderText="Order ID" />
                <syncfusion:DataGridTextColumn MappingName="CustomerID" 
                                          HeaderText="Customer ID" />
                <syncfusion:DataGridTextColumn MappingName="ShipCountry" 
                                          HeaderText="Ship Country"/>
            </syncfusion:SfDataGrid.Columns>
        </syncfusion:SfDataGrid>
    </ContentPage.Content>

```
## Xaml.cs
```
 public partial class MainPage : ContentPage
 {
     public MainPage()
     {
         InitializeComponent();
         this.dataGrid.SelectionChanging += DataGrid_SelectionChanging;
         this.dataGrid.CurrentCellBeginEdit += DataGrid_CurrentCellBeginEdit;
     }

     private void DataGrid_CurrentCellBeginEdit(object? sender, Syncfusion.Maui.DataGrid.DataGridCurrentCellBeginEditEventArgs e)
     {
         var dataGrid = sender as SfDataGrid;

         if (dataGrid == null)
             return;

         var rowIndex = e.RowColumnIndex.RowIndex;

         if (rowIndex < dataGrid.GetHeaderIndex())
             return;

         var record = dataGrid.GetRecordAtRowIndex(rowIndex) as OrderInfo;

         if (record?.IsExternal == true)
         {
             e.Cancel = true; 
         }

     }

     private void DataGrid_SelectionChanging(object? sender, Syncfusion.Maui.DataGrid.DataGridSelectionChangingEventArgs e)
     {
         if (e.AddedRows.Any(item => ((OrderInfo)item).IsExternal))
         {
             e.Cancel = true;
         }
     }
 }

```

## RowDisableConverter.cs
```
  public class RowDisableConverter : IValueConverter
  {
      public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
      {
          if (value is OrderInfo orderInfo)
          {
              // Return a lighter opacity/grayed-out appearance for external rows
              if (orderInfo.IsExternal)
              {
                  return 0.5; // 50% opacity for disabled rows
              }
          }
          return 1.0; // Full opacity for enabled rows
      }

      public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
      {
          throw new NotImplementedException();
      }
  }
```
## Requirements to run the demo

To run the demo, refer to [System Requirements for .NET MAUI](https://help.syncfusion.com/maui/system-requirements)

## Troubleshooting:
### Path too long exception

If you are facing path too long exception when building this example project, close Visual Studio and rename the repository to short and build the project.

## License

Syncfusion� has no liability for any damage or consequence that may arise from using or viewing the samples. The samples are for demonstrative purposes. If you choose to use or access the samples, you agree to not hold Syncfusion� liable, in any form, for any damage related to use, for accessing, or viewing the samples. By accessing, viewing, or seeing the samples, you acknowledge and agree Syncfusion�'s samples will not allow you seek injunctive relief in any form for any claim related to the sample. If you do not agree to this, do not view, access, utilize, or otherwise do anything with Syncfusion�'s samples.