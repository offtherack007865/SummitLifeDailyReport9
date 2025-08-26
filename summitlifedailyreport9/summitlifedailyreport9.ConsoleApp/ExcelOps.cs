using Microsoft.SqlServer.Server;
using Spire.Xls;

using summitlifedailyreport9.Data;
using summitlifedailyreport9.Data.ExcelTabs;
using summitlifedailyreport9.Data.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace summitlifedailyreport9.ConsoleApp
{
    public class ExcelOps
    {
        // Constructor for the deletion of the workbook containing all the reports.
        public ExcelOps
                (
                    qy_GetDailyReportConfigOutputColumns inputConfigOptions
                )
        {
            MyConfigOptions = inputConfigOptions;
        }

        // Constructor to 
        // Transfer the inputted set of records to the appropriate worksheet
        // in the workbook.
        public ExcelOps
                (
                    qy_GetDailyReportConfigOutputColumns inputConfigOptions
                    , List<qy_GetDailyReportBaseOutputColumns> inputqy_GetDailyReportBaseOutputColumns
                )
        {
            MyConfigOptions = inputConfigOptions;

            DataRecordList =
                inputqy_GetDailyReportBaseOutputColumns;
        }


        public qy_GetDailyReportConfigOutputColumns MyConfigOptions { get; set; }
        public List<qy_GetDailyReportBaseOutputColumns> DataRecordList { get; set; }
        public string ExcelTabName { get; set; }

        public string WorkbookFullFilename { get; set; }

        public Workbook CurrentWorkbook { get; set; }

        public Worksheet CurrentWorksheet { get; set; }

        public Dictionary<string, int> ColumnNameVsColumnNumberDictionary { get; set; }
        public List<Dictionary<string, string>> ClassInstanceVariableNameVsValueDictionaryList { get; set; }
        public void GetTabnamePertainingToReportFields(qy_GetDailyReportBaseOutputColumns inputSampleReportFields)
        {
            ExcelTabName = string.Empty;

            switch (inputSampleReportFields.GetType().Name)
            {
                case "qy_GetDailyReportMissingBiosOutputColumns":
                    ExcelTabName = "001_MissingBios";
                    break;
                case "qy_GetDailyReportMissingLabsOutputColumns":
                    ExcelTabName = "002_MissingLabs";
                    break;
                case "qy_GetDailyReportMissingPatientIDsInLabsOutputColumns":
                    ExcelTabName = "003_MissingPatientIDsInLabs";
                    break;
                case "qy_GetDailyReportPastApptScheduleEntriesWithNoBiometricsOutputColumns":
                    ExcelTabName = "004_ScheduledWithNoBios";
                    break;
                case "qy_GetDailyReportPastApptScheduleEntriesWithNoBiosAndNoLabsOutputColumns":
                    ExcelTabName = "005_ScheduledWithNoBiosNoLabs";
                    break;
                case "qy_GetDailyReportPastApptScheduleEntriesWithNoLabsOutputColumns":
                    ExcelTabName = "006_ScheduledWithNoLabs";
                    break;
                case "qy_GetDailyReportPhysicianFormsOutputColumns":
                    ExcelTabName = "007_PhysicianForms";
                    break;
                case "qy_GetDailyReportEmployeesInAssetFilesThisYearOutputColumns":
                    ExcelTabName = "008_EmpsSentToAssetYTD";
                    break;
                case "qy_GetDailyReportEmployeesInAssetFileThisWeekSoFarOutputColumns":
                    ExcelTabName = "009_EmpsToSendToAssetThisWk";
                    break;
                case "qy_GetDailyReportDupEmpNbrSsnCombosOutputColumns":
                    ExcelTabName = "010_DupEmpNbrSSNCombos";
                    break;
                case "qy_GetDailyReportSsnNameDobDifferencesOutputColumns":
                    ExcelTabName = "011_SsnNameDobDifferences";
                    break;
                case "qy_GetDailyReportSsnsNotListedInAllEmployeesListOutputColumns":
                    ExcelTabName = "012_SsnsNotListedInAllEmployees";
                    break;

            }
        }
        public void ReformatDatabaseRecordsIndexedByFieldNames()
        {
            ClassInstanceVariableNameVsValueDictionaryList
                = new List<Dictionary<string, string>>();

            BindingFlags
                bindingFlags =
                            BindingFlags.Public |
                            BindingFlags.NonPublic |
                            BindingFlags.Instance |
                            BindingFlags.Static;

            List<string> columnNameList = new List<string>();

            var fieldNames =
                DataRecordList[0].GetType().GetFields(bindingFlags)
                .Select(field => field.Name)
                .ToList();
            foreach (var loopFieldName in fieldNames)
            {
                // Extract the column name from the muck that is returned.
                var columnNameRegex = new Regex(@"<(?<columnname>.+)>");
                var columnNameMatch = columnNameRegex.Match(loopFieldName.ToString());
                if (columnNameMatch.Success)
                {
                    string columnName = string.Empty;
                    columnName = columnNameMatch.Groups["columnname"].Value;
                    columnNameList.Add(columnName);
                }
            }

            foreach (qy_GetDailyReportBaseOutputColumns loopRecord in DataRecordList)
            {
                Dictionary<string, string>
                    myClassInstanceVariableNameVsValueDictionary =
                        new Dictionary<string, string>();

                var myValuesList =
                    loopRecord.GetType().GetFields(bindingFlags)
                    .Select(field => field.GetValue(loopRecord))
                    .ToList();
                List<string> myValueStringsList = new List<string>();
                foreach (var loopValue in myValuesList)
                {
                    myValueStringsList.Add(loopValue.ToString());
                }

                for (int fieldCtr = 0; fieldCtr < columnNameList.Count; fieldCtr++)
                {
                    myClassInstanceVariableNameVsValueDictionary[columnNameList[fieldCtr]] =
                        myValueStringsList[fieldCtr];
                }

                ClassInstanceVariableNameVsValueDictionaryList.Add(myClassInstanceVariableNameVsValueDictionary);
            }
        }

        public string GetMyColumnDesignation(int inputColumnNumber)
        {
            switch (inputColumnNumber)
            {
                case 1:
                    return "A";
                case 2:
                    return "B";
                case 3:
                    return "C";
                case 4:
                    return "D";
                case 5:
                    return "E";
                case 6:
                    return "F";
                case 7:
                    return "G";
                case 8:
                    return "H";
                case 9:
                    return "I";
                case 10:
                    return "J";
                case 11:
                    return "K";
                case 12:
                    return "L";
                case 13:
                    return "M";
                case 14:
                    return "N";
                case 15:
                    return "O";
                case 16:
                    return "P";
                case 17:
                    return "Q";
                case 18:
                    return "R";
                case 19:
                    return "S";
                case 20:
                    return "T";
                case 21:
                    return "U";
                case 22:
                    return "V";
                case 23:
                    return "W";
                case 24:
                    return "X";
                case 25:
                    return "Y";
                case 26:
                    return "Z";
                case 27:
                    return "AA";
                case 28:
                    return "AB";
                case 29:
                    return "AC";
                case 30:
                    return "AD";
                case 31:
                    return "AE";
                case 32:
                    return "AF";
                case 33:
                    return "AG";
                case 34:
                    return "AH";
                case 35:
                    return "AI";
                case 36:
                    return "AJ";
                case 37:
                    return "AK";
                case 38:
                    return "AL";
                case 39:
                    return "AM";
                case 40:
                    return "AN";
                case 41:
                    return "AO";
                case 42:
                    return "AP";
                case 43:
                    return "AQ";
                case 44:
                    return "AR";
                case 45:
                    return "AS";
                case 46:
                    return "AT";
                case 47:
                    return "AU";
                case 48:
                    return "AV";
                case 49:
                    return "AW";
                case 50:
                    return "AX";
                case 51:
                    return "AY";
                case 52:
                    return "AZ";
                case 53:
                    return "BA";
                case 54:
                    return "BB";
                case 55:
                    return "BC";
                case 56:
                    return "BD";
                case 57:
                    return "BE";
                case 58:
                    return "BF";
                case 59:
                    return "BG";
                case 60:
                    return "BH";
                case 61:
                    return "BI";
                case 62:
                    return "BJ";
                case 63:
                    return "BK";
                case 64:
                    return "BL";
                case 65:
                    return "BM";
                case 66:
                    return "BN";
                case 67:
                    return "BO";

                default:
                    return string.Empty;
            }
        }

        public string MyCellDesignation(int inputColNumber, int inputRowNumber)
        {
            string columnDesignation =
                GetMyColumnDesignation(inputColNumber);
            if (columnDesignation.Length == 0)
            {
                return string.Empty;
            }
            return $"{columnDesignation}{inputRowNumber.ToString()}";
        }


        public string PopulateWorksheet()
        {
            string returnOutput = string.Empty;

            // Get or Create current workbook
            GetOrCreateAndGetWorkbook();

            // Get current worksheet
            GetCurrentWorksheet();
            if (CurrentWorksheet != null)
            {
                // In the Excel Spreadsheet, get the column number corresponding
                // to the Excel Spreadsheet column number.  The Column Name
                // is the same name for the database column.
                GetExcelSpreadsheetColumnNameVsColumnNumberDictionary();

                // Reformat Database Records indexed by field names.
                ReformatDatabaseRecordsIndexedByFieldNames();

                // Transfer Database Records to Excel Spreadsheet
                TransferDatabaseRecordsToExcelSpreadsheet();
            }
            return returnOutput;
        }

        public void TransferDatabaseRecordsToExcelSpreadsheet()
        {
            for (int dataRowCtr = 0; dataRowCtr < ClassInstanceVariableNameVsValueDictionaryList.Count; dataRowCtr++)
            {
                Dictionary<string, string> myClassInstanceVariableNameVsValueDictionary =
                    ClassInstanceVariableNameVsValueDictionaryList[dataRowCtr];
                foreach (string loopColumnNameString in myClassInstanceVariableNameVsValueDictionary.Keys)
                {
                    int loopExcelRowNumber = dataRowCtr + 2;
                    int loopExcelColumnNumber =
                        ColumnNameVsColumnNumberDictionary[loopColumnNameString];
                    string myExcelCellDesignation =
                        MyCellDesignation(loopExcelColumnNumber, loopExcelRowNumber);
                    CurrentWorksheet.Range[myExcelCellDesignation].Value =
                        myClassInstanceVariableNameVsValueDictionary[loopColumnNameString];
                }
            }
            CurrentWorkbook.Save();
        }

        public void GetExcelSpreadsheetColumnNameVsColumnNumberDictionary()
        {
            ColumnNameVsColumnNumberDictionary = new Dictionary<string, int>();
            int colCtr = 1;
            int rowNumber = 1;
            string cellDesignation = string.Empty;

            cellDesignation =
                MyCellDesignation(colCtr, rowNumber);
            while (cellDesignation.Length > 0)
            {
                if (CurrentWorksheet.Range[cellDesignation] != null &&
                    CurrentWorksheet.Range[cellDesignation].Value != null &&
                    CurrentWorksheet.Range[cellDesignation].Value.ToString().Length > 0)
                {
                    ColumnNameVsColumnNumberDictionary[CurrentWorksheet.Range[cellDesignation].Value.ToString()] = colCtr;
                }
                else
                {
                    return;
                }
                colCtr++;
                cellDesignation =
                    MyCellDesignation(colCtr, rowNumber);
            }
        }

        public void DeleteCurrentWorkbook()
        {
            GetWorkbookFullFilename();
            if (File.Exists(WorkbookFullFilename))
            {
                File.Delete(WorkbookFullFilename);
            }
        }

        public void GetOrCreateAndGetWorkbook()
        {
            CurrentWorkbook = new Workbook();


            if (File.Exists(WorkbookFullFilename))
            {
                CurrentWorkbook.LoadFromFile(WorkbookFullFilename);
            }
            else
            {
                GetWorkbookFullFilename();

                if (File.Exists(WorkbookFullFilename))
                {
                    CurrentWorkbook.LoadFromFile(WorkbookFullFilename);
                }
            }
        }
        public void GetCurrentWorksheet()
        {
            GetTabnamePertainingToReportFields(DataRecordList[0]);

            if (CurrentWorkbook != null && CurrentWorkbook.Worksheets.Count > 0)
            {
                CurrentWorksheet =
                    (Worksheet)
                        CurrentWorkbook.Worksheets.Where(s => s.Name.CompareTo(ExcelTabName) == 0).FirstOrDefault();

            }
        }
        public void GetWorkbookFullFilename()
        {
            WorkbookFullFilename = string.Empty;

            string sourceFullFilename = string.Empty;
            sourceFullFilename =
                MyConfigOptions.ExcelTemplateFullFilename;
            FileInfo sourceFi = new FileInfo(sourceFullFilename);
            string destinationFilename =
                sourceFi.Name.Replace("Template", "");
            WorkbookFullFilename =
                Path.Combine(MyConfigOptions.WriteDirectory, destinationFilename);
            if (!File.Exists(WorkbookFullFilename))
            {
                File.Copy(sourceFullFilename, WorkbookFullFilename);
            }
        }
    }
}
