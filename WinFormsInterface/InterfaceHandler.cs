using System.Globalization;
using System.Windows.Forms;
using BusinessLogic;

namespace WinFormsInterface
{
    internal static class InterfaceHandler
    {
        public static void RefreshList(DataGridView recordsDataGridView)
        {
            var businessLogic = new Content();
            var records = businessLogic.Get();

            if (recordsDataGridView != null)
            {
                recordsDataGridView.DataSource = records;
            }
        }

        public static void Save(Form form, string content, Content.Record record, string name)
        {
            float contentConverted;
            float? contentValue = null;
            var isSuccess = float.TryParse(content, NumberStyles.Float,CultureInfo.InvariantCulture, out contentConverted);
            if (isSuccess)
            {
                contentValue = contentConverted;
            }

            if (record != null)
            {
                record.ContentValue = contentValue;
                record.Name = name;
            }
            var businessLogic = new Content { ContentRecord = record };
            record = businessLogic.Set();

            var isSetSuccess = false;

            if (record != null)
            {
                isSetSuccess = record.Id.HasValue;
            }

            if (isSetSuccess)
            {
                form?.Close();
            }
            else
            {
                MessageBox.Show(@"Error on save");
            }
        }

        public static void AddRecord()
        {
            var viewForm = new ContentView(null);
            viewForm.Show();
        }

        private static Content.Record GetGridContentRecord( DataGridView dataGridView)
        {
            var selectedCellCount = dataGridView?.SelectedCells.Count;

            DataGridViewCell cellId = null;
            DataGridViewCell cellHierachyId = null;
            DataGridViewCell cellName = null;
            DataGridViewCell cellContentValue = null;
            if (selectedCellCount > 0)
            {
                var cell = dataGridView.SelectedCells[0];
                var selectedRow = cell?.OwningRow;
                if (selectedRow != null)
                {
                    cellId = selectedRow.Cells["Id"];
                    cellHierachyId = selectedRow.Cells["HierachyId"];
                    cellName = selectedRow.Cells["Name"];
                    cellContentValue = selectedRow.Cells["ContentValue"];
                }
            }
            var contentIdString = string.Empty;
            if (cellId?.Value != null)
            {
                contentIdString = cellId.Value.ToString();
            }
            var hierachyIdString = string.Empty;
            if (cellHierachyId?.Value != null)
            {
                hierachyIdString = cellHierachyId.Value.ToString();
            }
            var name = string.Empty;
            if (cellName?.Value != null)
            {
                name = cellName.Value.ToString();
            }
            var contentValueString = string.Empty;
            if (cellContentValue?.Value != null)
            {
                contentValueString = cellContentValue.Value.ToString();
            }

            var conternRecord = new Content.Record { Name = name };

            long contentId;
            var sSuccess = long.TryParse(contentIdString, out contentId);
            if (sSuccess)
            {
                conternRecord.Id = contentId;
            }
            long hierachyId;
            sSuccess = long.TryParse(hierachyIdString, out hierachyId);
            if (sSuccess)
            {
                conternRecord.HierachyId = hierachyId;
            }
            float contentValue;
            sSuccess = float.TryParse(contentValueString, out contentValue);
            if (sSuccess)
            {
                conternRecord.ContentValue = contentValue;
            }
            return conternRecord;
        }
        public static void EditRecord(DataGridView dataGridView)
        {
            var contentRecord = GetGridContentRecord(dataGridView);

            var viewForm = new ContentView(contentRecord);
            viewForm.Show();
        }

        public static void DeleteRecord(DataGridView recordsDataGridView)
        {
            var contentRecord = GetGridContentRecord(recordsDataGridView);
            var handler = new Content { ContentRecord = contentRecord };
            var isSuccess = handler.Delete();
            if (!isSuccess)
            {
                MessageBox.Show(@"Error on delete");
            }
        }
    }
}
