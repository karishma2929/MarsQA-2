using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsQA_2.Utilities
{
    public static class ExcelOperation
    {
       
        private static DataTable ExcelToDataTable(string filename)
        {
         FileStream stream = File.Open(filename, FileMode.Open, FileAccess.Read);
         IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream); //connection between program and excel

            DataSet result = excelReader.AsDataSet(new ExcelDataSetConfiguration() // To use first ro
            {
                ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                {
                    UseHeaderRow = true
                }
            });
         DataTableCollection table = result.Tables;
         DataTable resultTable =table["MyTable"];
            return resultTable;
        }
        public class Datacollection
        {
            public int rowNumber { get; set; }       
            public string colName { get; set; }
            public string colValue { get; set; }
        }

        static List<Datacollection> dataCol = new List<Datacollection>();
        public static void PopulateInCollection(string filename)
        {
          DataTable table = ExcelToDataTable(filename);

            for(int row =1; row<=table.Rows.Count; row++) // row is not 0 becoz that is our header
            {
                for (int col =0; col< table.Rows.Count;col++)
                {
                    Datacollection dttable = new Datacollection()
                    {
                        rowNumber = row,
                        colName = table.Columns[col].ColumnName,
                        colValue = table.Rows[row - 1][col].ToString()
                    };
                    dataCol.Add(dttable);
                }
            }
        }
        public static string ReadData(int rowNumber,string coloumnName)
        {
            try
            {
                string data = (from colData in dataCol 
                               where colData.colName == coloumnName && colData.rowNumber== rowNumber 
                               select colData.colValue).SingleOrDefault();
                return data.ToString();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
