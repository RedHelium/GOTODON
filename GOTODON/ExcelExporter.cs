using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Controls;

namespace GOTODON
{
    //TODO Make abstract class and create factory in main class
    public sealed class ExcelExporter
    {
        public void Export(List<Task> tasks)
        {
            
            HSSFWorkbook workbook = new HSSFWorkbook();
            ISheet Sheet = workbook.CreateSheet("Sheet 1");
            IRow HeaderRow = Sheet.CreateRow(0);
            CreateCell(HeaderRow, 0, "TODO");
            CreateCell(HeaderRow, 1, "In Progress");
            CreateCell(HeaderRow, 2, "Complete");
            int rowCounts = 0;

            Task[] todoTasks = tasks.FindAll(x => x.Type.Equals(TaskType.TODO)).ToArray();
            Task[] inProgressTasks = tasks.FindAll(x => x.Type.Equals(TaskType.InProgress)).ToArray();
            Task[] completeTasks = tasks.FindAll(x => x.Type.Equals(TaskType.Complete)).ToArray();

            //TODO generate path + insert created date
            using (var fileData = new FileStream("result.xls", FileMode.Create))
            {
                workbook.Write(fileData);
            }
        }

        private void CreateCell(IRow CurrentRow, int CellIndex, string Value)
        {
            ICell Cell = CurrentRow.CreateCell(CellIndex);
            Cell.SetCellValue(Value);
        }
    }
}
