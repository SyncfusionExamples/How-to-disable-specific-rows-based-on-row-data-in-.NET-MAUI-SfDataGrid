using Syncfusion.Maui.DataGrid;
using Syncfusion.Maui.DataGrid.Helper;

namespace SfDataGridSample
{
    public partial class MainPage : ContentPage
    {
        /// <summary>
        /// Rows with IsExternal = true are visually disabled using conditional styling (Opacity converter).
        /// This sample demonstrates how to disable rows using conditional row styling approach.
        /// </summary>
        public MainPage()
        {
            InitializeComponent();
            this.dataGrid.SelectionChanging += DataGrid_SelectionChanging;
            this.dataGrid.CurrentCellBeginEdit += DataGrid_CurrentCellBeginEdit;
        }

        /// <summary>
        /// Prevents editing of cells in rows where IsExternal is true.
        /// This complements the visual styling to fully disable external rows.
        /// </summary>
        private void DataGrid_CurrentCellBeginEdit(object? sender, DataGridCurrentCellBeginEditEventArgs e)
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

        /// <summary>
        /// Prevents selection of rows where IsExternal is true.
        /// This complements the visual styling to fully disable external rows.
        /// </summary>
        private void DataGrid_SelectionChanging(object? sender, DataGridSelectionChangingEventArgs e)
        {
            if (e.AddedRows.Any(item => ((OrderInfo)item).IsExternal))
            {
                e.Cancel = true;
            }
        }
    }
}
