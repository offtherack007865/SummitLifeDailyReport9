using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using EmailWebApiLand9.Data.Models;
using summitlifedailyreport9.CallWebApiLand;
using summitlifedailyreport9.Data.Models;

namespace summitlifedailyreport9.ConsoleApp
{
    public class DailyReportsMainOps
    {
        public DailyReportsMainOps
        (
            Data.Models.ConfigOptions inputFileConfigOptions
            , qy_GetDailyReportConfigOutputColumns inputqy_GetDailyReportConfigOutputColumns 
        )
        {
            MyFileConfigOptions = inputFileConfigOptions;
            Myqy_GetDailyReportConfigOutputColumns = inputqy_GetDailyReportConfigOutputColumns;
        }

        public Data.Models.ConfigOptions MyFileConfigOptions { get; set; }
        public qy_GetDailyReportConfigOutputColumns Myqy_GetDailyReportConfigOutputColumns { get; set; }
        public DailyReportsMainOpsOutput MainOps()
        {
            DailyReportsMainOpsOutput
                returnOutput =
                    new DailyReportsMainOpsOutput();

            // Populate all reports
            PopulateReports(returnOutput);
            if (!returnOutput.IsOk)
            {
                return returnOutput;
            }

            // Populate Excel
            PopulateExcel(returnOutput);
            if (!returnOutput.IsOk)
            {
                return returnOutput;
            }

            return returnOutput;
        }
        public void PopulateReports(DailyReportsMainOpsOutput returnOutput)
        {
            // 001 - Populate Missing Bios
            di_PopulateDailyReportMissingBiosOutput
                mydi_PopulateDailyReportMissingBiosOutput =
                    PopulateMissingBios();
            if (!mydi_PopulateDailyReportMissingBiosOutput.IsOk)
            {
                returnOutput.IsOk = false;
                returnOutput.ErrorMessage =
                    mydi_PopulateDailyReportMissingBiosOutput.ErrorMessage;
                return;
            }

            // 002 - Populate Missing Labs
            di_PopulateDailyReportMissingLabsOutput
                mydi_PopulateDailyReportMissingLabsOutput =
                    PopulateMissingLabs();
            if (!mydi_PopulateDailyReportMissingLabsOutput.IsOk)
            {
                returnOutput.IsOk = false;
                returnOutput.ErrorMessage =
                    mydi_PopulateDailyReportMissingLabsOutput.ErrorMessage;
                return;
            }

            // 003 - Populate Missing Patient IDs
            di_PopulateDailyReportMissingPatientIDsInLabsOutput
                mydi_PopulateDailyReportMissingPatientIDsInLabsOutput =
                    PopulateMissingPatientIDsInLabs();
            if (!mydi_PopulateDailyReportMissingPatientIDsInLabsOutput.IsOk)
            {
                returnOutput.IsOk = false;
                returnOutput.ErrorMessage =
                    mydi_PopulateDailyReportMissingPatientIDsInLabsOutput.ErrorMessage;
                return;
            }

            // 004 - Populate Missing Bios for Scheduled Entries.
            di_PopulateDailyReportPastApptScheduleEntriesWithNoBiometricsOutput
                mydi_PopulateDailyReportPastApptScheduleEntriesWithNoBiometricsOutput =
                    PopulatePastApptScheduleEntriesWithNoBios();
            if (!mydi_PopulateDailyReportPastApptScheduleEntriesWithNoBiometricsOutput.IsOk)
            {
                returnOutput.IsOk = false;
                returnOutput.ErrorMessage =
                    mydi_PopulateDailyReportPastApptScheduleEntriesWithNoBiometricsOutput.ErrorMessage;
                return;
            }

            // 005 -  Populate Missing Labs AND Bios for Scheduled Entries
            di_PopulateDailyReportPastApptScheduleEntriesWithNoBiosAndNoLabsOutput
                mydi_PopulateDailyReportPastApptScheduleEntriesWithNoBiosAndNoLabsOutput =
                    PopulatePastApptScheduleEntriesWithNoBiosAndNoLabs();
            if (!mydi_PopulateDailyReportPastApptScheduleEntriesWithNoBiosAndNoLabsOutput.IsOk)
            {
                returnOutput.IsOk = false;
                returnOutput.ErrorMessage =
                    mydi_PopulateDailyReportPastApptScheduleEntriesWithNoBiosAndNoLabsOutput.ErrorMessage;
                return;
            }

            // 006 -  Populate Missing Labs for Scheduled Entries
            di_PopulateDailyReportPastApptScheduleEntriesWithNoLabsOutput
                mydi_PopulateDailyReportPastApptScheduleEntriesWithNoLabsOutput =
                    PopulatePastApptScheduleEntriesWithNoLabs();
            if (!mydi_PopulateDailyReportPastApptScheduleEntriesWithNoLabsOutput.IsOk)
            {
                returnOutput.IsOk = false;
                returnOutput.ErrorMessage =
                    mydi_PopulateDailyReportPastApptScheduleEntriesWithNoLabsOutput.ErrorMessage;
                return;
            }

            // 007 -  Populate Physician Forms
            di_PopulateDailyReportPhysicianFormsOutput
                mydi_PopulateDailyReportPhysicianFormsOutput =
                    PopulatePhysicianForms();
            if (!mydi_PopulateDailyReportPastApptScheduleEntriesWithNoLabsOutput.IsOk)
            {
                returnOutput.IsOk = false;
                returnOutput.ErrorMessage =
                    mydi_PopulateDailyReportPastApptScheduleEntriesWithNoLabsOutput.ErrorMessage;
                return;
            }

            // 008 - Employees In Asset Files This Year
            di_PopulateDailyReportEmployeesInAssetFilesThisYearOutput
                mydi_PopulateDailyReportEmployeesInAssetFilesThisYearOutput =
                    PopulateEmployeesInAssetFilesThisYear();
            if (!mydi_PopulateDailyReportEmployeesInAssetFilesThisYearOutput.IsOk)
            {
                returnOutput.IsOk = false;
                returnOutput.ErrorMessage =
                    mydi_PopulateDailyReportEmployeesInAssetFilesThisYearOutput.ErrorMessage;
                return;
            }

            // 009 - Populate Employees In Asset File This Week So Far
            di_PopulateDailyReportEmployeesInAssetFileThisWeekSoFarOutput
                mydi_PopulateDailyReportEmployeesInAssetFileThisWeekSoFarOutput =
                    PopulateEmployeesInAssetFileThisWeekSoFar();
            if (!mydi_PopulateDailyReportEmployeesInAssetFileThisWeekSoFarOutput.IsOk)
            {
                returnOutput.IsOk = false;
                returnOutput.ErrorMessage =
                    mydi_PopulateDailyReportEmployeesInAssetFileThisWeekSoFarOutput.ErrorMessage;
                return;
            }

            // 010 - Dup Emp Nbr Ssn Combos
            di_PopulateDailyReportDupEmpNbrSsnCombosOutput
                mydi_PopulateDailyReportDupEmpNbrSsnCombosOutput =
                    PopulateDupEmpNbrSsnCombos();
            if (!mydi_PopulateDailyReportDupEmpNbrSsnCombosOutput.IsOk)
            {
                returnOutput.IsOk = false;
                returnOutput.ErrorMessage =
                    mydi_PopulateDailyReportDupEmpNbrSsnCombosOutput.ErrorMessage;
                return;
            }

            // 011 -  Ssn Name Dob Differences
            di_PopulateDailyReportSsnNameDobDifferencesOutput
                mydi_PopulateDailyReportSsnNameDobDifferencesOutput =
                    PopulateSsnNameDobDifferences();
            if (!mydi_PopulateDailyReportPastApptScheduleEntriesWithNoLabsOutput.IsOk)
            {
                returnOutput.IsOk = false;
                returnOutput.ErrorMessage =
                    mydi_PopulateDailyReportPastApptScheduleEntriesWithNoLabsOutput.ErrorMessage;
                return;
            }

            // 012 - Ssns Not Listed In All Employees List
            di_PopulateDailyReportSsnsNotListedInAllEmployeesListOutput
                mydi_PopulateDailyReportSsnsNotListedInAllEmployeesListOutput =
                    PopulateSsnsNotListedInAllEmployeesList();
            if (!mydi_PopulateDailyReportPastApptScheduleEntriesWithNoLabsOutput.IsOk)
            {
                returnOutput.IsOk = false;
                returnOutput.ErrorMessage =
                    mydi_PopulateDailyReportPastApptScheduleEntriesWithNoLabsOutput.ErrorMessage;
                return;
            }
        }

        // 001 - Populate Missing Bios
        public di_PopulateDailyReportMissingBiosOutput PopulateMissingBios()
        {
            di_PopulateDailyReportMissingBiosOutput returnOutput =
                new di_PopulateDailyReportMissingBiosOutput();

            CallWebApiLandClass myCallWebApiLandClass =
                new CallWebApiLandClass(this.MyFileConfigOptions.BaseWebUrl);
            returnOutput =
                myCallWebApiLandClass
                .di_PopulateDailyReportMissingBios();
            if (!returnOutput.IsOk)
            {
                returnOutput.IsOk = false;
                returnOutput.ErrorMessage =
                    returnOutput.ErrorMessage;
                return returnOutput;
            }
            return returnOutput;
        }

        // 002 - Populate Missing Labs
        public di_PopulateDailyReportMissingLabsOutput PopulateMissingLabs()
        {
            di_PopulateDailyReportMissingLabsOutput returnOutput =
                new di_PopulateDailyReportMissingLabsOutput();

            CallWebApiLandClass myCallWebApiLandClass =
                new CallWebApiLandClass(this.MyFileConfigOptions.BaseWebUrl);
            returnOutput =
                myCallWebApiLandClass
                .di_PopulateDailyReportMissingLabs();
            if (!returnOutput.IsOk)
            {
                returnOutput.IsOk = false;
                returnOutput.ErrorMessage =
                    returnOutput.ErrorMessage;
                return returnOutput;
            }
            return returnOutput;
        }

        // 003 - Populate Missing Patient IDs
        public di_PopulateDailyReportMissingPatientIDsInLabsOutput PopulateMissingPatientIDsInLabs()
        {
            di_PopulateDailyReportMissingPatientIDsInLabsOutput returnOutput =
                new di_PopulateDailyReportMissingPatientIDsInLabsOutput();

            CallWebApiLandClass myCallWebApiLandClass =
                new CallWebApiLandClass(this.MyFileConfigOptions.BaseWebUrl);
            returnOutput =
                myCallWebApiLandClass
                .di_PopulateDailyReportMissingPatientIDsInLabs();
            if (!returnOutput.IsOk)
            {
                returnOutput.IsOk = false;
                returnOutput.ErrorMessage =
                    returnOutput.ErrorMessage;
                return returnOutput;
            }
            return returnOutput;
        }

        // 004 - Populate Missing Bios for Scheduled Entries.
        public di_PopulateDailyReportPastApptScheduleEntriesWithNoBiometricsOutput PopulatePastApptScheduleEntriesWithNoBios()
        {
            di_PopulateDailyReportPastApptScheduleEntriesWithNoBiometricsOutput returnOutput =
                new di_PopulateDailyReportPastApptScheduleEntriesWithNoBiometricsOutput();

            CallWebApiLandClass myCallWebApiLandClass =
                new CallWebApiLandClass(this.MyFileConfigOptions.BaseWebUrl);
            returnOutput =
                myCallWebApiLandClass
                .di_PopulateDailyReportPastApptScheduleEntriesWithNoBiometrics();
            if (!returnOutput.IsOk)
            {
                returnOutput.IsOk = false;
                returnOutput.ErrorMessage =
                    returnOutput.ErrorMessage;
                return returnOutput;
            }
            return returnOutput;
        }


        // 005 -  Populate Missing Labs AND Bios for Scheduled Entries
        public di_PopulateDailyReportPastApptScheduleEntriesWithNoBiosAndNoLabsOutput PopulatePastApptScheduleEntriesWithNoBiosAndNoLabs()
        {
            di_PopulateDailyReportPastApptScheduleEntriesWithNoBiosAndNoLabsOutput returnOutput =
                new di_PopulateDailyReportPastApptScheduleEntriesWithNoBiosAndNoLabsOutput();

            CallWebApiLandClass myCallWebApiLandClass =
                new CallWebApiLandClass(this.MyFileConfigOptions.BaseWebUrl);
            returnOutput =
                myCallWebApiLandClass
                .di_PopulateDailyReportPastApptScheduleEntriesWithNoBiosAndNoLabs();
            if (!returnOutput.IsOk)
            {
                returnOutput.IsOk = false;
                returnOutput.ErrorMessage =
                    returnOutput.ErrorMessage;
                return returnOutput;
            }
            return returnOutput;
        }

        // 006 -  Populate Missing Labs for Scheduled Entries
        public di_PopulateDailyReportPastApptScheduleEntriesWithNoLabsOutput PopulatePastApptScheduleEntriesWithNoLabs()
        {
            di_PopulateDailyReportPastApptScheduleEntriesWithNoLabsOutput returnOutput =
                new di_PopulateDailyReportPastApptScheduleEntriesWithNoLabsOutput();

            CallWebApiLandClass myCallWebApiLandClass =
                new CallWebApiLandClass(this.MyFileConfigOptions.BaseWebUrl);
            returnOutput =
                myCallWebApiLandClass
                .di_PopulateDailyReportPastApptScheduleEntriesWithNoLabs();
            if (!returnOutput.IsOk)
            {
                returnOutput.IsOk = false;
                returnOutput.ErrorMessage =
                    returnOutput.ErrorMessage;
                return returnOutput;
            }
            return returnOutput;
        }

        // 007 -  Populate Physician Forms
        public di_PopulateDailyReportPhysicianFormsOutput PopulatePhysicianForms()
        {
            di_PopulateDailyReportPhysicianFormsOutput returnOutput =
                new di_PopulateDailyReportPhysicianFormsOutput();

            CallWebApiLandClass myCallWebApiLandClass =
                new CallWebApiLandClass(this.MyFileConfigOptions.BaseWebUrl);
            returnOutput =
                myCallWebApiLandClass
                .di_PopulateDailyReportPhysicianForms();
            if (!returnOutput.IsOk)
            {
                returnOutput.IsOk = false;
                returnOutput.ErrorMessage =
                    returnOutput.ErrorMessage;
                return returnOutput;
            }
            return returnOutput;
        }

        // 008 - Populate Employees In Asset Files This Year
        public di_PopulateDailyReportEmployeesInAssetFilesThisYearOutput PopulateEmployeesInAssetFilesThisYear()
        {
            di_PopulateDailyReportEmployeesInAssetFilesThisYearOutput returnOutput =
                new di_PopulateDailyReportEmployeesInAssetFilesThisYearOutput();

            CallWebApiLandClass myCallWebApiLandClass =
                new CallWebApiLandClass(this.MyFileConfigOptions.BaseWebUrl);
            returnOutput =
                myCallWebApiLandClass
                .di_PopulateDailyReportEmployeesInAssetFilesThisYear();
            if (!returnOutput.IsOk)
            {
                returnOutput.IsOk = false;
                returnOutput.ErrorMessage =
                    returnOutput.ErrorMessage;
                return returnOutput;
            }
            return returnOutput;
        }


        // 009 - Populate Employees In Asset File This Week So Far
        public di_PopulateDailyReportEmployeesInAssetFileThisWeekSoFarOutput PopulateEmployeesInAssetFileThisWeekSoFar()
        {
            di_PopulateDailyReportEmployeesInAssetFileThisWeekSoFarOutput returnOutput =
                new di_PopulateDailyReportEmployeesInAssetFileThisWeekSoFarOutput();

            CallWebApiLandClass myCallWebApiLandClass =
                new CallWebApiLandClass(this.MyFileConfigOptions.BaseWebUrl);
            returnOutput =
                myCallWebApiLandClass
                .di_PopulateDailyReportEmployeesInAssetFileThisWeekSoFar();
            if (!returnOutput.IsOk)
            {
                returnOutput.IsOk = false;
                returnOutput.ErrorMessage =
                    returnOutput.ErrorMessage;
                return returnOutput;
            }
            return returnOutput;
        }

        // 010 - Populate Dup Emp Nbr Ssn Combos
        public di_PopulateDailyReportDupEmpNbrSsnCombosOutput PopulateDupEmpNbrSsnCombos()
        {
            di_PopulateDailyReportDupEmpNbrSsnCombosOutput returnOutput =
                new di_PopulateDailyReportDupEmpNbrSsnCombosOutput();

            CallWebApiLandClass myCallWebApiLandClass =
                new CallWebApiLandClass(this.MyFileConfigOptions.BaseWebUrl);
            returnOutput =
                myCallWebApiLandClass
                .di_PopulateDailyReportDupEmpNbrSsnCombos();
            if (!returnOutput.IsOk)
            {
                returnOutput.IsOk = false;
                returnOutput.ErrorMessage =
                    returnOutput.ErrorMessage;
                return returnOutput;
            }
            return returnOutput;
        }



        // 011 -  Populate Ssn Name Dob Differences
        public di_PopulateDailyReportSsnNameDobDifferencesOutput PopulateSsnNameDobDifferences()
        {
            di_PopulateDailyReportSsnNameDobDifferencesOutput returnOutput =
                new di_PopulateDailyReportSsnNameDobDifferencesOutput();

            CallWebApiLandClass myCallWebApiLandClass =
                new CallWebApiLandClass(this.MyFileConfigOptions.BaseWebUrl);
            returnOutput =
                myCallWebApiLandClass
                .di_PopulateDailyReportSsnNameDobDifferences();
            if (!returnOutput.IsOk)
            {
                returnOutput.IsOk = false;
                returnOutput.ErrorMessage =
                    returnOutput.ErrorMessage;
                return returnOutput;
            }
            return returnOutput;
        }

        // 012 -  Populate Ssns Not Listed In All Employees List
        public di_PopulateDailyReportSsnsNotListedInAllEmployeesListOutput PopulateSsnsNotListedInAllEmployeesList()
        {
            di_PopulateDailyReportSsnsNotListedInAllEmployeesListOutput returnOutput =
                new di_PopulateDailyReportSsnsNotListedInAllEmployeesListOutput();

            CallWebApiLandClass myCallWebApiLandClass =
                new CallWebApiLandClass(this.MyFileConfigOptions.BaseWebUrl);
            returnOutput =
                myCallWebApiLandClass
                .di_PopulateDailyReportSsnsNotListedInAllEmployeesList();
            if (!returnOutput.IsOk)
            {
                returnOutput.IsOk = false;
                returnOutput.ErrorMessage =
                    returnOutput.ErrorMessage;
                return returnOutput;
            }
            return returnOutput;
        }


        public void PopulateExcel(DailyReportsMainOpsOutput returnOutput)
        {
            // 000 DeleteCurrentWorkbook
            string
                myErrorMessageForDeleteCurrentWorkbook =
                    DeleteCurrentWorkbook();
            if (myErrorMessageForDeleteCurrentWorkbook.Length > 0)
            {
                returnOutput.IsOk = false;
                returnOutput.ErrorMessage = myErrorMessageForDeleteCurrentWorkbook;
                return;
            }

            // 001 - Populate Missing Bios Excel
            qy_GetDailyReportMissingBiosOutput
                myqy_GetDailyReportMissingBiosOutput =
                    PopulateMissingBiosExcel();
            if (!myqy_GetDailyReportMissingBiosOutput.IsOk)
            {
                returnOutput.IsOk = false;
                returnOutput.ErrorMessage =
                    myqy_GetDailyReportMissingBiosOutput.ErrorMessage;
                return;
            }

            // 002 - Populate Missing Labs Excel
            qy_GetDailyReportMissingLabsOutput
                myqy_GetDailyReportMissingLabsOutput =
                    PopulateMissingLabsExcel();
            if (!myqy_GetDailyReportMissingLabsOutput.IsOk)
            {
                returnOutput.IsOk = false;
                returnOutput.ErrorMessage =
                    myqy_GetDailyReportMissingLabsOutput.ErrorMessage;
                return;
            }

            // 003 - Populate Missing Patient IDs Excel
            qy_GetDailyReportMissingPatientIDsInLabsOutput
                myqy_GetDailyReportMissingPatientIDsInLabsOutput =
                    PopulateMissingPatientIDsInLabsExcel();
            if (!myqy_GetDailyReportMissingPatientIDsInLabsOutput.IsOk)
            {
                returnOutput.IsOk = false;
                returnOutput.ErrorMessage =
                    myqy_GetDailyReportMissingPatientIDsInLabsOutput.ErrorMessage;
                return;
            }

            // 004 - Populate Missing Bios for Scheduled Entries Excel.
            qy_GetDailyReportPastApptScheduleEntriesWithNoBiometricsOutput
                myqy_GetDailyReportPastApptScheduleEntriesWithNoBiometricsOutput =
                    PopulatePastApptScheduleEntriesWithNoBiosExcel();
            if (!myqy_GetDailyReportPastApptScheduleEntriesWithNoBiometricsOutput.IsOk)
            {
                returnOutput.IsOk = false;
                returnOutput.ErrorMessage =
                    myqy_GetDailyReportPastApptScheduleEntriesWithNoBiometricsOutput.ErrorMessage;
                return;
            }

            // 005 -  Populate Missing Labs AND Bios for Scheduled Entries Excel
            qy_GetDailyReportPastApptScheduleEntriesWithNoBiosAndNoLabsOutput
                 myqy_GetDailyReportPastApptScheduleEntriesWithNoBiosAndNoLabsOutput =
                    PopulatePastApptScheduleEntriesWithNoBiosAndNoLabsExcel();
            if (!myqy_GetDailyReportPastApptScheduleEntriesWithNoBiosAndNoLabsOutput.IsOk)
            {
                returnOutput.IsOk = false;
                returnOutput.ErrorMessage =
                    myqy_GetDailyReportPastApptScheduleEntriesWithNoBiosAndNoLabsOutput.ErrorMessage;
                return;
            }

            // 006 -  Populate Missing Labs for Scheduled Entries Excel
            qy_GetDailyReportPastApptScheduleEntriesWithNoLabsOutput
                mqy_GetDailyReportPastApptScheduleEntriesWithNoLabsOutput =
                    PopulatePastApptScheduleEntriesWithNoLabsExcel();
            if (!mqy_GetDailyReportPastApptScheduleEntriesWithNoLabsOutput.IsOk)
            {
                returnOutput.IsOk = false;
                returnOutput.ErrorMessage =
                    mqy_GetDailyReportPastApptScheduleEntriesWithNoLabsOutput.ErrorMessage;
                return;
            }

            // 007 -  Populate Physician Forms Excel
            qy_GetDailyReportPhysicianFormsOutput
                myqy_GetDailyReportPhysicianFormsOutput =
                    PopulatePhysicianFormsExcel();
            if (!myqy_GetDailyReportPhysicianFormsOutput.IsOk)
            {
                returnOutput.IsOk = false;
                returnOutput.ErrorMessage =
                    myqy_GetDailyReportPhysicianFormsOutput.ErrorMessage;
                return;
            }

            // 008 - Employees In Asset Files This Year Excel
            qy_GetDailyReportEmployeesInAssetFilesThisYearOutput
                myqy_GetDailyReportEmployeesInAssetFilesThisYearOutput =
                    PopulateEmployeesInAssetFilesThisYearExcel();
            if (!myqy_GetDailyReportEmployeesInAssetFilesThisYearOutput.IsOk)
            {
                returnOutput.IsOk = false;
                returnOutput.ErrorMessage =
                    myqy_GetDailyReportEmployeesInAssetFilesThisYearOutput.ErrorMessage;
                return;
            }

            // 009 - Employees In Asset File This Week So Far Excel
            qy_GetDailyReportEmployeesInAssetFileThisWeekSoFarOutput
                myqy_GetDailyReportEmployeesInAssetFileThisWeekSoFarOutput =
                    PopulateEmployeesInAssetFileThisWeekSoFarExcel();
            if (!myqy_GetDailyReportEmployeesInAssetFileThisWeekSoFarOutput.IsOk)
            {
                returnOutput.IsOk = false;
                returnOutput.ErrorMessage =
                    myqy_GetDailyReportEmployeesInAssetFileThisWeekSoFarOutput.ErrorMessage;
                return;
            }

            // 010 - Dup Emp Nbr Ssn Combos Excel
            qy_GetDailyReportDupEmpNbrSsnCombosOutput
                myqy_GetDailyReportDupEmpNbrSsnCombosOutput =
                    PopulateDupEmpNbrSsnCombosExcel();
            if (!myqy_GetDailyReportDupEmpNbrSsnCombosOutput.IsOk)
            {
                returnOutput.IsOk = false;
                returnOutput.ErrorMessage =
                    myqy_GetDailyReportDupEmpNbrSsnCombosOutput.ErrorMessage;
                return;
            }

            // 011 -  Ssn Name Dob Differences Excel
            qy_GetDailyReportSsnNameDobDifferencesOutput
                myqy_GetDailyReportSsnNameDobDifferencesOutput =
                    PopulateSsnNameDobDifferencesExcel();
            if (!myqy_GetDailyReportSsnNameDobDifferencesOutput.IsOk)
            {
                returnOutput.IsOk = false;
                returnOutput.ErrorMessage =
                    myqy_GetDailyReportSsnNameDobDifferencesOutput.ErrorMessage;
                return;
            }

            // 012 -  Populate Ssns Not Listed In All Employees List Excel
            qy_GetDailyReportSsnsNotListedInAllEmployeesListOutput
                myqy_GetDailyReportSsnsNotListedInAllEmployeesListOutput =
                    PopulateSsnsNotListedInAllEmployeesListExcel();
            if (!myqy_GetDailyReportSsnsNotListedInAllEmployeesListOutput.IsOk)
            {
                returnOutput.IsOk = false;
                returnOutput.ErrorMessage =
                    myqy_GetDailyReportSsnsNotListedInAllEmployeesListOutput.ErrorMessage;
                return;
            }

            // Get the Current Excel workbook full filename.
            string myWorkbookFullFilename = string.Empty;
            string sourceFullFilename = string.Empty;
            sourceFullFilename =
                Myqy_GetDailyReportConfigOutputColumns.ExcelTemplateFullFilename;
            FileInfo sourceFi = new FileInfo(sourceFullFilename);
            string destinationFilename =
                sourceFi.Name.Replace("Template", "");
            myWorkbookFullFilename =
                Path.Combine(Myqy_GetDailyReportConfigOutputColumns.WriteDirectory, destinationFilename);

            string emailBodyLine =
                $"Successfully created Dailty Reports Excel Document at <br><br>{myWorkbookFullFilename}";
            returnOutput.MailBodyLineList.Add(emailBodyLine);

            // Copy the Current Excel workbook (as a dated file) to the archive 
            string archiveFilename = string.Empty;
            DateTime currentDateTime = DateTime.Now;
            archiveFilename = sourceFi.Name.Replace("Template", "");
            archiveFilename = archiveFilename.Substring(0, archiveFilename.Length - sourceFi.Extension.Length);
            archiveFilename = archiveFilename + $"_{currentDateTime.Year.ToString()}{currentDateTime.Month.ToString().PadLeft(2, '0')}{currentDateTime.Day.ToString().PadLeft(2, '0')}{sourceFi.Extension}";
            string fullArchiveFilename =
                Path.Combine(Myqy_GetDailyReportConfigOutputColumns.ArchiveDirectory, archiveFilename);
            if (File.Exists(fullArchiveFilename))
            {
                File.Delete(fullArchiveFilename);
            }
            File.Copy(myWorkbookFullFilename, fullArchiveFilename);


        }

        // 000 - Delete Current Workbook
        public string DeleteCurrentWorkbook()
        {
            string returnOutput = string.Empty;
            ExcelOps myExcelOps =
                    new ExcelOps
                        (
                            Myqy_GetDailyReportConfigOutputColumns
                        );
            myExcelOps.DeleteCurrentWorkbook();

            return returnOutput;
        }


        // 001 - Populate Missing Bios Excel
        public qy_GetDailyReportMissingBiosOutput PopulateMissingBiosExcel()
        {
            qy_GetDailyReportMissingBiosOutput returnOutput =
                new qy_GetDailyReportMissingBiosOutput();

            CallWebApiLandClass myCallWebApiLandClass =
                new CallWebApiLandClass(this.MyFileConfigOptions.BaseWebUrl);
            returnOutput =
                myCallWebApiLandClass
                .qy_GetDailyReportMissingBios();
            if (!returnOutput.IsOk)
            {
                returnOutput.IsOk = false;
                returnOutput.ErrorMessage =
                    returnOutput.ErrorMessage;
                return returnOutput;
            }

            if (returnOutput.qy_GetDailyReportMissingBiosOutputColumnsList.Count > 0)
            {
                List<qy_GetDailyReportBaseOutputColumns>
                    myqy_GetDailyReportBaseOutputColumnsList =
                        new List<qy_GetDailyReportBaseOutputColumns>();
                foreach (var loopRecord in returnOutput.qy_GetDailyReportMissingBiosOutputColumnsList)
                {
                    myqy_GetDailyReportBaseOutputColumnsList.Add(loopRecord);
                }
                ExcelOps myExcelOps =
                    new ExcelOps
                        (
                            Myqy_GetDailyReportConfigOutputColumns
                            , myqy_GetDailyReportBaseOutputColumnsList
                        );
                string populateWorksheetError =
                    myExcelOps.PopulateWorksheet();

            }

            return returnOutput;
        }

        // 002 - Populate Missing Labs Excel
        public qy_GetDailyReportMissingLabsOutput PopulateMissingLabsExcel()
        {
            qy_GetDailyReportMissingLabsOutput returnOutput =
                new qy_GetDailyReportMissingLabsOutput();

            CallWebApiLandClass myCallWebApiLandClass =
                new CallWebApiLandClass(this.MyFileConfigOptions.BaseWebUrl);
            returnOutput =
                myCallWebApiLandClass
                .qy_GetDailyReportMissingLabs();
            if (!returnOutput.IsOk)
            {
                returnOutput.IsOk = false;
                returnOutput.ErrorMessage =
                    returnOutput.ErrorMessage;
                return returnOutput;
            }
            if (returnOutput.qy_GetDailyReportMissingLabsOutputColumnsList.Count > 0)
            {
                List<qy_GetDailyReportBaseOutputColumns>
                    myqy_GetDailyReportBaseOutputColumnsList =
                        new List<qy_GetDailyReportBaseOutputColumns>();
                foreach (var loopRecord in returnOutput.qy_GetDailyReportMissingLabsOutputColumnsList)
                {
                    myqy_GetDailyReportBaseOutputColumnsList.Add(loopRecord);
                }
                ExcelOps myExcelOps =
                    new ExcelOps
                        (
                            Myqy_GetDailyReportConfigOutputColumns
                            , myqy_GetDailyReportBaseOutputColumnsList
                        );
                string populateWorksheetError =
                    myExcelOps.PopulateWorksheet();
            }

            return returnOutput;
        }

        // 003 - Populate Missing Patient IDs Excel
        public qy_GetDailyReportMissingPatientIDsInLabsOutput PopulateMissingPatientIDsInLabsExcel()
        {
            qy_GetDailyReportMissingPatientIDsInLabsOutput returnOutput =
                new qy_GetDailyReportMissingPatientIDsInLabsOutput();

            CallWebApiLandClass myCallWebApiLandClass =
                new CallWebApiLandClass(this.MyFileConfigOptions.BaseWebUrl);
            returnOutput =
                myCallWebApiLandClass
                .qy_GetDailyReportMissingPatientIDsInLabs();
            if (!returnOutput.IsOk)
            {
                returnOutput.IsOk = false;
                returnOutput.ErrorMessage =
                    returnOutput.ErrorMessage;
                return returnOutput;
            }
            if (returnOutput.qy_GetDailyReportMissingPatientIDsInLabsOutputColumnsList.Count > 0)
            {
                List<qy_GetDailyReportBaseOutputColumns>
                    myqy_GetDailyReportBaseOutputColumnsList =
                        new List<qy_GetDailyReportBaseOutputColumns>();
                foreach (var loopRecord in returnOutput.qy_GetDailyReportMissingPatientIDsInLabsOutputColumnsList)
                {
                    myqy_GetDailyReportBaseOutputColumnsList.Add(loopRecord);
                }
                ExcelOps myExcelOps =
                    new ExcelOps
                        (
                            Myqy_GetDailyReportConfigOutputColumns
                            , myqy_GetDailyReportBaseOutputColumnsList
                        );
                string populateWorksheetError =
                    myExcelOps.PopulateWorksheet();
            }

            return returnOutput;
        }

        // 004 - Populate Missing Bios for Scheduled Entries Excel.
        public qy_GetDailyReportPastApptScheduleEntriesWithNoBiometricsOutput PopulatePastApptScheduleEntriesWithNoBiosExcel()
        {
            qy_GetDailyReportPastApptScheduleEntriesWithNoBiometricsOutput returnOutput =
                new qy_GetDailyReportPastApptScheduleEntriesWithNoBiometricsOutput();

            CallWebApiLandClass myCallWebApiLandClass =
                new CallWebApiLandClass(this.MyFileConfigOptions.BaseWebUrl);
            returnOutput =
                myCallWebApiLandClass
                .qy_GetDailyReportPastApptScheduleEntriesWithNoBiometrics();
            if (!returnOutput.IsOk)
            {
                returnOutput.IsOk = false;
                returnOutput.ErrorMessage =
                    returnOutput.ErrorMessage;
                return returnOutput;
            }

            if (returnOutput.qy_GetDailyReportPastApptScheduleEntriesWithNoBiometricsOutputColumnsList.Count > 0)
            {
                List<qy_GetDailyReportBaseOutputColumns>
                    myqy_GetDailyReportBaseOutputColumnsList =
                        new List<qy_GetDailyReportBaseOutputColumns>();
                foreach (var loopRecord in returnOutput.qy_GetDailyReportPastApptScheduleEntriesWithNoBiometricsOutputColumnsList)
                {
                    myqy_GetDailyReportBaseOutputColumnsList.Add(loopRecord);
                }
                ExcelOps myExcelOps =
                    new ExcelOps
                        (
                            Myqy_GetDailyReportConfigOutputColumns
                            , myqy_GetDailyReportBaseOutputColumnsList
                        );
                string populateWorksheetError =
                    myExcelOps.PopulateWorksheet();
            }


            return returnOutput;
        }

        // 005 -  Populate Missing Labs AND Bios for Scheduled Entries Excel
        public qy_GetDailyReportPastApptScheduleEntriesWithNoBiosAndNoLabsOutput PopulatePastApptScheduleEntriesWithNoBiosAndNoLabsExcel()
        {
            qy_GetDailyReportPastApptScheduleEntriesWithNoBiosAndNoLabsOutput returnOutput =
                new qy_GetDailyReportPastApptScheduleEntriesWithNoBiosAndNoLabsOutput();

            CallWebApiLandClass myCallWebApiLandClass =
                new CallWebApiLandClass(this.MyFileConfigOptions.BaseWebUrl);
            returnOutput =
                myCallWebApiLandClass
                .qy_GetDailyReportPastApptScheduleEntriesWithNoBiosAndNoLabs();
            if (!returnOutput.IsOk)
            {
                returnOutput.IsOk = false;
                returnOutput.ErrorMessage =
                    returnOutput.ErrorMessage;
                return returnOutput;
            }

            if (returnOutput.qy_GetDailyReportPastApptScheduleEntriesWithNoBiosAndNoLabsOutputColumnsList.Count > 0)
            {
                List<qy_GetDailyReportBaseOutputColumns>
                    myqy_GetDailyReportBaseOutputColumnsList =
                        new List<qy_GetDailyReportBaseOutputColumns>();
                foreach (var loopRecord in returnOutput.qy_GetDailyReportPastApptScheduleEntriesWithNoBiosAndNoLabsOutputColumnsList)
                {
                    myqy_GetDailyReportBaseOutputColumnsList.Add(loopRecord);
                }
                ExcelOps myExcelOps =
                    new ExcelOps
                        (
                            Myqy_GetDailyReportConfigOutputColumns
                            , myqy_GetDailyReportBaseOutputColumnsList
                        );
                string populateWorksheetError =
                    myExcelOps.PopulateWorksheet();
            }


            return returnOutput;
        }


        // 006 -  Populate Missing Labs for Scheduled Entries Excel
        public qy_GetDailyReportPastApptScheduleEntriesWithNoLabsOutput PopulatePastApptScheduleEntriesWithNoLabsExcel()
        {
            qy_GetDailyReportPastApptScheduleEntriesWithNoLabsOutput returnOutput =
                new qy_GetDailyReportPastApptScheduleEntriesWithNoLabsOutput();

            CallWebApiLandClass myCallWebApiLandClass =
                new CallWebApiLandClass(this.MyFileConfigOptions.BaseWebUrl);
            returnOutput =
                myCallWebApiLandClass
                .qy_GetDailyReportPastApptScheduleEntriesWithNoNoLabs();
            if (!returnOutput.IsOk)
            {
                returnOutput.IsOk = false;
                returnOutput.ErrorMessage =
                    returnOutput.ErrorMessage;
                return returnOutput;
            }
            if (returnOutput.qy_GetDailyReportPastApptScheduleEntriesWithNoLabsOutputColumnsList.Count > 0)
            {
                List<qy_GetDailyReportBaseOutputColumns>
                    myqy_GetDailyReportBaseOutputColumnsList =
                        new List<qy_GetDailyReportBaseOutputColumns>();
                foreach (var loopRecord in returnOutput.qy_GetDailyReportPastApptScheduleEntriesWithNoLabsOutputColumnsList)
                {
                    myqy_GetDailyReportBaseOutputColumnsList.Add(loopRecord);
                }
                ExcelOps myExcelOps =
                    new ExcelOps
                        (
                            Myqy_GetDailyReportConfigOutputColumns
                            , myqy_GetDailyReportBaseOutputColumnsList
                        );
                string populateWorksheetError =
                    myExcelOps.PopulateWorksheet();
            }

            return returnOutput;
        }

        // 007 -  Populate Physician Forms Excel
        public qy_GetDailyReportPhysicianFormsOutput PopulatePhysicianFormsExcel()
        {
            qy_GetDailyReportPhysicianFormsOutput returnOutput =
                new qy_GetDailyReportPhysicianFormsOutput();

            CallWebApiLandClass myCallWebApiLandClass =
                new CallWebApiLandClass(this.MyFileConfigOptions.BaseWebUrl);
            returnOutput =
                myCallWebApiLandClass
                .qy_GetDailyReportPhysicianForms();
            if (!returnOutput.IsOk)
            {
                returnOutput.IsOk = false;
                returnOutput.ErrorMessage =
                    returnOutput.ErrorMessage;
                return returnOutput;
            }

            if (returnOutput.qy_GetDailyReportPhysicianFormsOutputColumnsList.Count > 0)
            {
                List<qy_GetDailyReportBaseOutputColumns>
                    myqy_GetDailyReportBaseOutputColumnsList =
                        new List<qy_GetDailyReportBaseOutputColumns>();
                foreach (var loopRecord in returnOutput.qy_GetDailyReportPhysicianFormsOutputColumnsList)
                {
                    myqy_GetDailyReportBaseOutputColumnsList.Add(loopRecord);
                }
                ExcelOps myExcelOps =
                    new ExcelOps
                        (
                            Myqy_GetDailyReportConfigOutputColumns
                            , myqy_GetDailyReportBaseOutputColumnsList
                        );
                string populateWorksheetError =
                    myExcelOps.PopulateWorksheet();
            }

            return returnOutput;
        }

        // 008 - Populate Employees In Asset Files This Year Excel
        public qy_GetDailyReportEmployeesInAssetFilesThisYearOutput PopulateEmployeesInAssetFilesThisYearExcel()
        {
            qy_GetDailyReportEmployeesInAssetFilesThisYearOutput returnOutput =
                new qy_GetDailyReportEmployeesInAssetFilesThisYearOutput();

            CallWebApiLandClass myCallWebApiLandClass =
                new CallWebApiLandClass(this.MyFileConfigOptions.BaseWebUrl);
            returnOutput =
                myCallWebApiLandClass
                .qy_GetDailyReportEmployeesInAssetFilesThisYear();
            if (!returnOutput.IsOk)
            {
                returnOutput.IsOk = false;
                returnOutput.ErrorMessage =
                    returnOutput.ErrorMessage;
                return returnOutput;
            }

            if (returnOutput.qy_GetDailyReportEmployeesInAssetFilesThisYearOutputColumnsList.Count > 0)
            {
                List<qy_GetDailyReportBaseOutputColumns>
                    myqy_GetDailyReportBaseOutputColumnsList =
                        new List<qy_GetDailyReportBaseOutputColumns>();
                foreach (var loopRecord in returnOutput.qy_GetDailyReportEmployeesInAssetFilesThisYearOutputColumnsList)
                {
                    myqy_GetDailyReportBaseOutputColumnsList.Add(loopRecord);
                }
                ExcelOps myExcelOps =
                    new ExcelOps
                        (
                            Myqy_GetDailyReportConfigOutputColumns
                            , myqy_GetDailyReportBaseOutputColumnsList
                        );
                string populateWorksheetError =
                    myExcelOps.PopulateWorksheet();

            }

            return returnOutput;
        }


        // 009 - Populate Employees In Asset File This Week So Far Excel
        public qy_GetDailyReportEmployeesInAssetFileThisWeekSoFarOutput PopulateEmployeesInAssetFileThisWeekSoFarExcel()
        {
            qy_GetDailyReportEmployeesInAssetFileThisWeekSoFarOutput returnOutput =
                new qy_GetDailyReportEmployeesInAssetFileThisWeekSoFarOutput();

            CallWebApiLandClass myCallWebApiLandClass =
                new CallWebApiLandClass(this.MyFileConfigOptions.BaseWebUrl);
            returnOutput =
                myCallWebApiLandClass
                .qy_GetDailyReportEmployeesInAssetFileThisWeekSoFar();
            if (!returnOutput.IsOk)
            {
                returnOutput.IsOk = false;
                returnOutput.ErrorMessage =
                    returnOutput.ErrorMessage;
                return returnOutput;
            }

            if (returnOutput.qy_GetDailyReportEmployeesInAssetFileThisWeekSoFarOutputColumnsList.Count > 0)
            {
                List<qy_GetDailyReportBaseOutputColumns>
                    myqy_GetDailyReportBaseOutputColumnsList =
                        new List<qy_GetDailyReportBaseOutputColumns>();
                foreach (var loopRecord in returnOutput.qy_GetDailyReportEmployeesInAssetFileThisWeekSoFarOutputColumnsList)
                {
                    myqy_GetDailyReportBaseOutputColumnsList.Add(loopRecord);
                }
                ExcelOps myExcelOps =
                    new ExcelOps
                        (
                            Myqy_GetDailyReportConfigOutputColumns
                            , myqy_GetDailyReportBaseOutputColumnsList
                        );
                string populateWorksheetError =
                    myExcelOps.PopulateWorksheet();

            }

            return returnOutput;
        }

        // 010 - Populate Dup Emp Nbr Ssn Combos Excel
        public qy_GetDailyReportDupEmpNbrSsnCombosOutput PopulateDupEmpNbrSsnCombosExcel()
        {
            qy_GetDailyReportDupEmpNbrSsnCombosOutput returnOutput =
                new qy_GetDailyReportDupEmpNbrSsnCombosOutput();

            CallWebApiLandClass myCallWebApiLandClass =
                new CallWebApiLandClass(this.MyFileConfigOptions.BaseWebUrl);
            returnOutput =
                myCallWebApiLandClass
                .qy_GetDailyReportDupEmpNbrSsnCombos();
            if (!returnOutput.IsOk)
            {
                returnOutput.IsOk = false;
                returnOutput.ErrorMessage =
                    returnOutput.ErrorMessage;
                return returnOutput;
            }

            if (returnOutput.qy_GetDailyReportDupEmpNbrSsnCombosOutputColumnsList.Count > 0)
            {
                List<qy_GetDailyReportBaseOutputColumns>
                    myqy_GetDailyReportBaseOutputColumnsList =
                        new List<qy_GetDailyReportBaseOutputColumns>();
                foreach (var loopRecord in returnOutput.qy_GetDailyReportDupEmpNbrSsnCombosOutputColumnsList)
                {
                    myqy_GetDailyReportBaseOutputColumnsList.Add(loopRecord);
                }
                ExcelOps myExcelOps =
                    new ExcelOps
                        (
                            Myqy_GetDailyReportConfigOutputColumns
                            , myqy_GetDailyReportBaseOutputColumnsList
                        );
                string populateWorksheetError =
                    myExcelOps.PopulateWorksheet();

            }

            return returnOutput;
        }

        // 011 -  Populate Ssn Name Dob Differences Excel
        public qy_GetDailyReportSsnNameDobDifferencesOutput PopulateSsnNameDobDifferencesExcel()
        {
            qy_GetDailyReportSsnNameDobDifferencesOutput returnOutput =
                new qy_GetDailyReportSsnNameDobDifferencesOutput();

            CallWebApiLandClass myCallWebApiLandClass =
                new CallWebApiLandClass(this.MyFileConfigOptions.BaseWebUrl);
            returnOutput =
                myCallWebApiLandClass
                .qy_GetDailyReportSsnNameDobDifferences();
            if (!returnOutput.IsOk)
            {
                returnOutput.IsOk = false;
                returnOutput.ErrorMessage =
                    returnOutput.ErrorMessage;
                return returnOutput;
            }

            if (returnOutput.qy_GetDailyReportSsnNameDobDifferencesOutputColumnsList.Count > 0)
            {
                List<qy_GetDailyReportBaseOutputColumns>
                    myqy_GetDailyReportBaseOutputColumnsList =
                        new List<qy_GetDailyReportBaseOutputColumns>();
                foreach (var loopRecord in returnOutput.qy_GetDailyReportSsnNameDobDifferencesOutputColumnsList)
                {
                    myqy_GetDailyReportBaseOutputColumnsList.Add(loopRecord);
                }
                ExcelOps myExcelOps =
                    new ExcelOps
                        (
                            Myqy_GetDailyReportConfigOutputColumns
                            , myqy_GetDailyReportBaseOutputColumnsList
                        );
                string populateWorksheetError =
                    myExcelOps.PopulateWorksheet();
            }

            return returnOutput;
        }

        // 012 -  Populate Ssns Not Listed In All Employees List Excel
        public qy_GetDailyReportSsnsNotListedInAllEmployeesListOutput PopulateSsnsNotListedInAllEmployeesListExcel()
        {
            qy_GetDailyReportSsnsNotListedInAllEmployeesListOutput returnOutput =
                new qy_GetDailyReportSsnsNotListedInAllEmployeesListOutput();

            CallWebApiLandClass myCallWebApiLandClass =
                new CallWebApiLandClass(this.MyFileConfigOptions.BaseWebUrl);
            returnOutput =
                myCallWebApiLandClass
                .qy_GetDailyReportSsnsNotListedInAllEmployeesList();
            if (!returnOutput.IsOk)
            {
                returnOutput.IsOk = false;
                returnOutput.ErrorMessage =
                    returnOutput.ErrorMessage;
                return returnOutput;
            }

            if (returnOutput.qy_GetDailyReportSsnsNotListedInAllEmployeesListOutputColumnsList.Count > 0)
            {
                List<qy_GetDailyReportBaseOutputColumns>
                    myqy_GetDailyReportBaseOutputColumnsList =
                        new List<qy_GetDailyReportBaseOutputColumns>();
                foreach (var loopRecord in returnOutput.qy_GetDailyReportSsnsNotListedInAllEmployeesListOutputColumnsList)
                {
                    myqy_GetDailyReportBaseOutputColumnsList.Add(loopRecord);
                }
                ExcelOps myExcelOps =
                    new ExcelOps
                        (
                            Myqy_GetDailyReportConfigOutputColumns
                            , myqy_GetDailyReportBaseOutputColumnsList
                        );
                string populateWorksheetError =
                    myExcelOps.PopulateWorksheet();
            }

            return returnOutput;
        }
    }
}
