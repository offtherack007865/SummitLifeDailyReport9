using log4net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Newtonsoft.Json;
using summitlifedailyreport9.Data;
using summitlifedailyreport9.Data.Models;

namespace summitlifedailyreport9.CallWebApiLand
{
    public class CallWebApiLandClass
    {
            private static readonly ILog log = LogManager.GetLogger(typeof(CallWebApiLandClass));

            public CallWebApiLandClass
            (
                string inputBaseWebApiUrl
            )
            {
                MyBaseWebApiUrl = inputBaseWebApiUrl;
            }
            public string MyBaseWebApiUrl { get; set; }

        // GET /api/Ops/di_PopulateDailyReportDupEmpNbrSsnCombos
        public di_PopulateDailyReportDupEmpNbrSsnCombosOutput
                        di_PopulateDailyReportDupEmpNbrSsnCombos
                        ()
        {
            di_PopulateDailyReportDupEmpNbrSsnCombosOutput
                returnOutput =
                        di_PopulateDailyReportDupEmpNbrSsnCombosAsync()
                        .Result;

            return returnOutput;
        }
        public async Task<di_PopulateDailyReportDupEmpNbrSsnCombosOutput>
                        di_PopulateDailyReportDupEmpNbrSsnCombosAsync()
        {
            di_PopulateDailyReportDupEmpNbrSsnCombosOutput
                returnOutput =
                        new di_PopulateDailyReportDupEmpNbrSsnCombosOutput();

            string myCompleteUrl = $"{MyBaseWebApiUrl}/api/Ops/di_PopulateDailyReportDupEmpNbrSsnCombos";
            try
            {
                using (var client = new HttpClient())
                {
                    client.Timeout = TimeSpan.FromHours(1);

                    var result = await client.GetAsync(myCompleteUrl);
                    var response = await result.Content.ReadAsStringAsync();
                    returnOutput = JsonConvert.DeserializeObject<di_PopulateDailyReportDupEmpNbrSsnCombosOutput>(response);
                }
            }
            catch (Exception ex)
            {
                returnOutput.IsOk = false;
                string myErrorMessage = ex.Message;
                if (ex.InnerException != null)
                {
                    myErrorMessage = $"{myErrorMessage}.  Inner Exception:  {ex.InnerException.Message}";
                }
                return returnOutput;
            }

            return returnOutput;
        }


        // GET /api/Ops/di_PopulateDailyReportEmployeesInAssetFilesThisYear
        public di_PopulateDailyReportEmployeesInAssetFilesThisYearOutput
                        di_PopulateDailyReportEmployeesInAssetFilesThisYear
                        ()
        {
            di_PopulateDailyReportEmployeesInAssetFilesThisYearOutput
                returnOutput =
                        di_PopulateDailyReportEmployeesInAssetFilesThisYearAsync()
                        .Result;

            return returnOutput;
        }
        public async Task<di_PopulateDailyReportEmployeesInAssetFilesThisYearOutput>
                        di_PopulateDailyReportEmployeesInAssetFilesThisYearAsync()
        {
            di_PopulateDailyReportEmployeesInAssetFilesThisYearOutput
                returnOutput =
                        new di_PopulateDailyReportEmployeesInAssetFilesThisYearOutput();

            string myCompleteUrl = $"{MyBaseWebApiUrl}/api/Ops/di_PopulateDailyReportEmployeesInAssetFilesThisYear";
            try
            {
                using (var client = new HttpClient())
                {
                    client.Timeout = TimeSpan.FromHours(1);

                    var result = await client.GetAsync(myCompleteUrl);
                    var response = await result.Content.ReadAsStringAsync();
                    returnOutput = JsonConvert.DeserializeObject<di_PopulateDailyReportEmployeesInAssetFilesThisYearOutput>(response);
                }
            }
            catch (Exception ex)
            {
                returnOutput.IsOk = false;
                string myErrorMessage = ex.Message;
                if (ex.InnerException != null)
                {
                    myErrorMessage = $"{myErrorMessage}.  Inner Exception:  {ex.InnerException.Message}";
                }
                return returnOutput;
            }

            return returnOutput;
        }

        // GET /api/Ops/di_PopulateDailyReportEmployeesInAssetFileThisWeekSoFar
        public di_PopulateDailyReportEmployeesInAssetFileThisWeekSoFarOutput
                        di_PopulateDailyReportEmployeesInAssetFileThisWeekSoFar
                        ()
        {
            di_PopulateDailyReportEmployeesInAssetFileThisWeekSoFarOutput
                returnOutput =
                        di_PopulateDailyReportEmployeesInAssetFileThisWeekSoFarAsync()
                        .Result;

            return returnOutput;
        }
        public async Task<di_PopulateDailyReportEmployeesInAssetFileThisWeekSoFarOutput>
                        di_PopulateDailyReportEmployeesInAssetFileThisWeekSoFarAsync()
        {
            di_PopulateDailyReportEmployeesInAssetFileThisWeekSoFarOutput
                returnOutput =
                        new di_PopulateDailyReportEmployeesInAssetFileThisWeekSoFarOutput();

            string myCompleteUrl = $"{MyBaseWebApiUrl}/api/Ops/di_PopulateDailyReportEmployeesInAssetFileThisWeekSoFar";
            try
            {
                using (var client = new HttpClient())
                {
                    client.Timeout = TimeSpan.FromHours(1);

                    var result = await client.GetAsync(myCompleteUrl);
                    var response = await result.Content.ReadAsStringAsync();
                    returnOutput = JsonConvert.DeserializeObject<di_PopulateDailyReportEmployeesInAssetFileThisWeekSoFarOutput>(response);
                }
            }
            catch (Exception ex)
            {
                returnOutput.IsOk = false;
                string myErrorMessage = ex.Message;
                if (ex.InnerException != null)
                {
                    myErrorMessage = $"{myErrorMessage}.  Inner Exception:  {ex.InnerException.Message}";
                }
                return returnOutput;
            }

            return returnOutput;
        }

        // GET /api/Ops/di_PopulateDailyReportMissingBios
        public di_PopulateDailyReportMissingBiosOutput
                        di_PopulateDailyReportMissingBios
                        ()
        {
                di_PopulateDailyReportMissingBiosOutput
                    returnOutput =
                            di_PopulateDailyReportMissingBiosAsync()
                            .Result;

                return returnOutput;
        }
        public async Task<di_PopulateDailyReportMissingBiosOutput>
                        di_PopulateDailyReportMissingBiosAsync()
        {
            di_PopulateDailyReportMissingBiosOutput
                returnOutput =
                        new di_PopulateDailyReportMissingBiosOutput();

            string myCompleteUrl = $"{MyBaseWebApiUrl}/api/Ops/di_PopulateDailyReportMissingBios";
            try
            {
                using (var client = new HttpClient())
                {
                    client.Timeout = TimeSpan.FromHours(1);

                    var result = await client.GetAsync(myCompleteUrl);
                    var response = await result.Content.ReadAsStringAsync();
                    returnOutput = JsonConvert.DeserializeObject<di_PopulateDailyReportMissingBiosOutput>(response);
                }
            }
            catch (Exception ex)
            {
                returnOutput.IsOk = false;
                string myErrorMessage = ex.Message;
                if (ex.InnerException != null)
                {
                    myErrorMessage = $"{myErrorMessage}.  Inner Exception:  {ex.InnerException.Message}";
                }
                return returnOutput;
            }

            return returnOutput;
        }

        // GET /api/Ops/di_PopulateDailyReportMissingLabs
        public di_PopulateDailyReportMissingLabsOutput
                        di_PopulateDailyReportMissingLabs
                        ()
        {
            di_PopulateDailyReportMissingLabsOutput
                returnOutput =
                        di_PopulateDailyReportMissingLabsAsync()
                        .Result;

            return returnOutput;
        }
        public async Task<di_PopulateDailyReportMissingLabsOutput>
                        di_PopulateDailyReportMissingLabsAsync()
        {
            di_PopulateDailyReportMissingLabsOutput
                returnOutput =
                        new di_PopulateDailyReportMissingLabsOutput();

            string myCompleteUrl = $"{MyBaseWebApiUrl}/api/Ops/di_PopulateDailyReportMissingLabs";
            try
            {
                using (var client = new HttpClient())
                {
                    client.Timeout = TimeSpan.FromHours(1);

                    var result = await client.GetAsync(myCompleteUrl);
                    var response = await result.Content.ReadAsStringAsync();
                    returnOutput = JsonConvert.DeserializeObject<di_PopulateDailyReportMissingLabsOutput>(response);
                }
            }
            catch (Exception ex)
            {
                returnOutput.IsOk = false;
                string myErrorMessage = ex.Message;
                if (ex.InnerException != null)
                {
                    myErrorMessage = $"{myErrorMessage}.  Inner Exception:  {ex.InnerException.Message}";
                }
                return returnOutput;
            }

            return returnOutput;
        }

        // GET /api/Ops/PopulateDailyReportMissingPatientIDsInLabs
        public di_PopulateDailyReportMissingPatientIDsInLabsOutput
                        di_PopulateDailyReportMissingPatientIDsInLabs
                        ()
        {
            di_PopulateDailyReportMissingPatientIDsInLabsOutput
                returnOutput =
                        di_PopulateDailyReportMissingPatientIDsInLabsAsync()
                        .Result;

            return returnOutput;
        }

        public async Task<di_PopulateDailyReportMissingPatientIDsInLabsOutput>
                            di_PopulateDailyReportMissingPatientIDsInLabsAsync()
            {
                di_PopulateDailyReportMissingPatientIDsInLabsOutput
                    returnOutput =
                            new di_PopulateDailyReportMissingPatientIDsInLabsOutput();

                string myCompleteUrl = $"{MyBaseWebApiUrl}/api/Ops/di_PopulateDailyReportMissingPatientIDsInLabs";
                try
                {
                    using (var client = new HttpClient())
                    {
                        client.Timeout = TimeSpan.FromHours(1);

                        var result = await client.GetAsync(myCompleteUrl);
                        var response = await result.Content.ReadAsStringAsync();
                        returnOutput = JsonConvert.DeserializeObject<di_PopulateDailyReportMissingPatientIDsInLabsOutput>(response);
                    }
                }
                catch (Exception ex)
                {
                    returnOutput.IsOk = false;
                    string myErrorMessage = ex.Message;
                    if (ex.InnerException != null)
                    {
                        myErrorMessage = $"{myErrorMessage}.  Inner Exception:  {ex.InnerException.Message}";
                    }
                    return returnOutput;
                }

                return returnOutput;
            }

        // GET /api/Ops/di_PopulateDailyReportPastApptScheduleEntriesWithNoBiosAndNoLabs
        public di_PopulateDailyReportPastApptScheduleEntriesWithNoBiosAndNoLabsOutput
                        di_PopulateDailyReportPastApptScheduleEntriesWithNoBiosAndNoLabs
                        ()
        {
            di_PopulateDailyReportPastApptScheduleEntriesWithNoBiosAndNoLabsOutput
                returnOutput =
                        di_PopulateDailyReportPastApptScheduleEntriesWithNoBiosAndNoLabsAsync()
                        .Result;

            return returnOutput;
        }

        public async Task<di_PopulateDailyReportPastApptScheduleEntriesWithNoBiosAndNoLabsOutput>
                            di_PopulateDailyReportPastApptScheduleEntriesWithNoBiosAndNoLabsAsync()
        {
            di_PopulateDailyReportPastApptScheduleEntriesWithNoBiosAndNoLabsOutput
                returnOutput =
                        new di_PopulateDailyReportPastApptScheduleEntriesWithNoBiosAndNoLabsOutput();

            string myCompleteUrl = $"{MyBaseWebApiUrl}/api/Ops/di_PopulateDailyReportPastApptScheduleEntriesWithNoBiosAndNoLabs";
            try
            {
                using (var client = new HttpClient())
                {
                    client.Timeout = TimeSpan.FromHours(1);

                    var result = await client.GetAsync(myCompleteUrl);
                    var response = await result.Content.ReadAsStringAsync();
                    returnOutput = JsonConvert.DeserializeObject<di_PopulateDailyReportPastApptScheduleEntriesWithNoBiosAndNoLabsOutput>(response);
                }
            }
            catch (Exception ex)
            {
                returnOutput.IsOk = false;
                string myErrorMessage = ex.Message;
                if (ex.InnerException != null)
                {
                    myErrorMessage = $"{myErrorMessage}.  Inner Exception:  {ex.InnerException.Message}";
                }
                return returnOutput;
            }

            return returnOutput;
        }

        // GET /api/Ops/di_PopulateDailyReportPastApptScheduleEntriesWithNoBiometrics
        public di_PopulateDailyReportPastApptScheduleEntriesWithNoBiometricsOutput
                        di_PopulateDailyReportPastApptScheduleEntriesWithNoBiometrics
                        ()
        {
            di_PopulateDailyReportPastApptScheduleEntriesWithNoBiometricsOutput
                returnOutput =
                        di_PopulateDailyReportPastApptScheduleEntriesWithNoBiometricsAsync()
                        .Result;

            return returnOutput;
        }

        public async Task<di_PopulateDailyReportPastApptScheduleEntriesWithNoBiometricsOutput>
                            di_PopulateDailyReportPastApptScheduleEntriesWithNoBiometricsAsync()
        {
            di_PopulateDailyReportPastApptScheduleEntriesWithNoBiometricsOutput
                returnOutput =
                        new di_PopulateDailyReportPastApptScheduleEntriesWithNoBiometricsOutput();

            string myCompleteUrl = $"{MyBaseWebApiUrl}/api/Ops/di_PopulateDailyReportPastApptScheduleEntriesWithNoBiometrics";
            try
            {
                using (var client = new HttpClient())
                {
                    client.Timeout = TimeSpan.FromHours(1);

                    var result = await client.GetAsync(myCompleteUrl);
                    var response = await result.Content.ReadAsStringAsync();
                    returnOutput = JsonConvert.DeserializeObject<di_PopulateDailyReportPastApptScheduleEntriesWithNoBiometricsOutput>(response);
                }
            }
            catch (Exception ex)
            {
                returnOutput.IsOk = false;
                string myErrorMessage = ex.Message;
                if (ex.InnerException != null)
                {
                    myErrorMessage = $"{myErrorMessage}.  Inner Exception:  {ex.InnerException.Message}";
                }
                return returnOutput;
            }

            return returnOutput;
        }

        // GET /api/Ops/di_PopulateDailyReportPastApptScheduleEntriesWithNoLabs
        public di_PopulateDailyReportPastApptScheduleEntriesWithNoLabsOutput
                        di_PopulateDailyReportPastApptScheduleEntriesWithNoLabs
                        ()
        {
            di_PopulateDailyReportPastApptScheduleEntriesWithNoLabsOutput
               returnOutput =
                         di_PopulateDailyReportPastApptScheduleEntriesWithNoLabsAsync()
                        .Result;

            return returnOutput;
        }

        public async Task<di_PopulateDailyReportPastApptScheduleEntriesWithNoLabsOutput>
                             di_PopulateDailyReportPastApptScheduleEntriesWithNoLabsAsync()
        {
            di_PopulateDailyReportPastApptScheduleEntriesWithNoLabsOutput
               returnOutput =
                        new di_PopulateDailyReportPastApptScheduleEntriesWithNoLabsOutput();

            string myCompleteUrl = $"{MyBaseWebApiUrl}/api/Ops/di_PopulateDailyReportPastApptScheduleEntriesWithNoLabs";
            try
            {
                using (var client = new HttpClient())
                {
                    client.Timeout = TimeSpan.FromHours(1);

                    var result = await client.GetAsync(myCompleteUrl);
                    var response = await result.Content.ReadAsStringAsync();
                    returnOutput = JsonConvert.DeserializeObject<di_PopulateDailyReportPastApptScheduleEntriesWithNoLabsOutput>(response);
                }
            }
            catch (Exception ex)
            {
                returnOutput.IsOk = false;
                string myErrorMessage = ex.Message;
                if (ex.InnerException != null)
                {
                    myErrorMessage = $"{myErrorMessage}.  Inner Exception:  {ex.InnerException.Message}";
                }
                return returnOutput;
            }

            return returnOutput;
        }



        // GET /api/Ops/di_PopulateDailyReportPhysicianFormsOutput
        public di_PopulateDailyReportPhysicianFormsOutput
                        di_PopulateDailyReportPhysicianForms
                        ()
        {
            di_PopulateDailyReportPhysicianFormsOutput
                returnOutput =
                        di_PopulateDailyReportPhysicianFormsAsync()
                        .Result;

            return returnOutput;
        }

        public async Task<di_PopulateDailyReportPhysicianFormsOutput>
                            di_PopulateDailyReportPhysicianFormsAsync()
        {
            di_PopulateDailyReportPhysicianFormsOutput
                returnOutput =
                        new di_PopulateDailyReportPhysicianFormsOutput();

            string myCompleteUrl = $"{MyBaseWebApiUrl}/api/Ops/di_PopulateDailyReportPhysicianForms";
            try
            {
                using (var client = new HttpClient())
                {
                    client.Timeout = TimeSpan.FromHours(1);

                    var result = await client.GetAsync(myCompleteUrl);
                    var response = await result.Content.ReadAsStringAsync();
                    returnOutput = JsonConvert.DeserializeObject<di_PopulateDailyReportPhysicianFormsOutput>(response);
                }
            }
            catch (Exception ex)
            {
                returnOutput.IsOk = false;
                string myErrorMessage = ex.Message;
                if (ex.InnerException != null)
                {
                    myErrorMessage = $"{myErrorMessage}.  Inner Exception:  {ex.InnerException.Message}";
                }
                return returnOutput;
            }

            return returnOutput;
        }

        // GET /api/Ops/di_PopulateDailyReportSsnNameDobDifferencesOutput
        public di_PopulateDailyReportSsnNameDobDifferencesOutput
                        di_PopulateDailyReportSsnNameDobDifferences
                        ()
        {
            di_PopulateDailyReportSsnNameDobDifferencesOutput
                returnOutput =
                        di_PopulateDailyReportSsnNameDobDifferencesAsync()
                        .Result;

            return returnOutput;
        }

        public async Task<di_PopulateDailyReportSsnNameDobDifferencesOutput>
                            di_PopulateDailyReportSsnNameDobDifferencesAsync()
        {
            di_PopulateDailyReportSsnNameDobDifferencesOutput
                returnOutput =
                        new di_PopulateDailyReportSsnNameDobDifferencesOutput();

            string myCompleteUrl = $"{MyBaseWebApiUrl}/api/Ops/di_PopulateDailyReportSsnNameDobDifferences";
            try
            {
                using (var client = new HttpClient())
                {
                    client.Timeout = TimeSpan.FromHours(1);

                    var result = await client.GetAsync(myCompleteUrl);
                    var response = await result.Content.ReadAsStringAsync();
                    returnOutput = JsonConvert.DeserializeObject<di_PopulateDailyReportSsnNameDobDifferencesOutput>(response);
                }
            }
            catch (Exception ex)
            {
                returnOutput.IsOk = false;
                string myErrorMessage = ex.Message;
                if (ex.InnerException != null)
                {
                    myErrorMessage = $"{myErrorMessage}.  Inner Exception:  {ex.InnerException.Message}";
                }
                return returnOutput;
            }

            return returnOutput;
        }

        // GET /api/Ops/di_PopulateDailyReportSsnsNotListedInAllEmployeesListOutput
        public di_PopulateDailyReportSsnsNotListedInAllEmployeesListOutput
                        di_PopulateDailyReportSsnsNotListedInAllEmployeesList
                        ()
        {
            di_PopulateDailyReportSsnsNotListedInAllEmployeesListOutput
                returnOutput =
                        di_PopulateDailyReportSsnsNotListedInAllEmployeesListAsync()
                        .Result;

            return returnOutput;
        }

        public async Task<di_PopulateDailyReportSsnsNotListedInAllEmployeesListOutput>
                            di_PopulateDailyReportSsnsNotListedInAllEmployeesListAsync()
        {
            di_PopulateDailyReportSsnsNotListedInAllEmployeesListOutput
                returnOutput =
                        new di_PopulateDailyReportSsnsNotListedInAllEmployeesListOutput();

            string myCompleteUrl = $"{MyBaseWebApiUrl}/api/Ops/di_PopulateDailyReportSsnsNotListedInAllEmployeesList";
            try
            {
                using (var client = new HttpClient())
                {
                    client.Timeout = TimeSpan.FromHours(1);

                    var result = await client.GetAsync(myCompleteUrl);
                    var response = await result.Content.ReadAsStringAsync();
                    returnOutput = JsonConvert.DeserializeObject<di_PopulateDailyReportSsnsNotListedInAllEmployeesListOutput>(response);
                }
            }
            catch (Exception ex)
            {
                returnOutput.IsOk = false;
                string myErrorMessage = ex.Message;
                if (ex.InnerException != null)
                {
                    myErrorMessage = $"{myErrorMessage}.  Inner Exception:  {ex.InnerException.Message}";
                }
                return returnOutput;
            }

            return returnOutput;
        }

















        // GET /api/Ops/qy_GetDailyReportDupEmpNbrSsnCombos
        public qy_GetDailyReportDupEmpNbrSsnCombosOutput
                        qy_GetDailyReportDupEmpNbrSsnCombos
                        ()
        {
            qy_GetDailyReportDupEmpNbrSsnCombosOutput
                returnOutput =
                        qy_GetDailyReportDupEmpNbrSsnCombosAsync()
                        .Result;

            return returnOutput;
        }
        public async Task<qy_GetDailyReportDupEmpNbrSsnCombosOutput>
                        qy_GetDailyReportDupEmpNbrSsnCombosAsync()
        {
            qy_GetDailyReportDupEmpNbrSsnCombosOutput
                returnOutput =
                        new qy_GetDailyReportDupEmpNbrSsnCombosOutput();

            string myCompleteUrl = $"{MyBaseWebApiUrl}/api/Ops/qy_GetDailyReportDupEmpNbrSsnCombos";
            try
            {
                using (var client = new HttpClient())
                {
                    client.Timeout = TimeSpan.FromHours(1);

                    var result = await client.GetAsync(myCompleteUrl);
                    var response = await result.Content.ReadAsStringAsync();
                    returnOutput = JsonConvert.DeserializeObject<qy_GetDailyReportDupEmpNbrSsnCombosOutput>(response);
                }
            }
            catch (Exception ex)
            {
                returnOutput.IsOk = false;
                string myErrorMessage = ex.Message;
                if (ex.InnerException != null)
                {
                    myErrorMessage = $"{myErrorMessage}.  Inner Exception:  {ex.InnerException.Message}";
                }
                return returnOutput;
            }

            return returnOutput;
        }

        // GET /api/Ops/qy_GetDailyReportEmployeesInAssetFilesThisYear
        public qy_GetDailyReportEmployeesInAssetFilesThisYearOutput
                        qy_GetDailyReportEmployeesInAssetFilesThisYear
                        ()
        {
            qy_GetDailyReportEmployeesInAssetFilesThisYearOutput
                returnOutput =
                        qy_GetDailyReportEmployeesInAssetFilesThisYearAsync()
                        .Result;

            return returnOutput;
        }
        public async Task<qy_GetDailyReportEmployeesInAssetFilesThisYearOutput>
                        qy_GetDailyReportEmployeesInAssetFilesThisYearAsync()
        {
            qy_GetDailyReportEmployeesInAssetFilesThisYearOutput
                returnOutput =
                        new qy_GetDailyReportEmployeesInAssetFilesThisYearOutput();

            string myCompleteUrl = $"{MyBaseWebApiUrl}/api/Ops/qy_GetDailyReportEmployeesInAssetFilesThisYear";
            try
            {
                using (var client = new HttpClient())
                {
                    client.Timeout = TimeSpan.FromHours(1);

                    var result = await client.GetAsync(myCompleteUrl);
                    var response = await result.Content.ReadAsStringAsync();
                    returnOutput = JsonConvert.DeserializeObject<qy_GetDailyReportEmployeesInAssetFilesThisYearOutput>(response);
                }
            }
            catch (Exception ex)
            {
                returnOutput.IsOk = false;
                string myErrorMessage = ex.Message;
                if (ex.InnerException != null)
                {
                    myErrorMessage = $"{myErrorMessage}.  Inner Exception:  {ex.InnerException.Message}";
                }
                return returnOutput;
            }

            return returnOutput;
        }

        // GET /api/Ops/qy_GetDailyReportEmployeesInAssetFileThisWeekSoFar
        public qy_GetDailyReportEmployeesInAssetFileThisWeekSoFarOutput
                        qy_GetDailyReportEmployeesInAssetFileThisWeekSoFar
                        ()
        {
            qy_GetDailyReportEmployeesInAssetFileThisWeekSoFarOutput
                returnOutput =
                        qy_GetDailyReportEmployeesInAssetFileThisWeekSoFarAsync()
                        .Result;

            return returnOutput;
        }
        public async Task<qy_GetDailyReportEmployeesInAssetFileThisWeekSoFarOutput>
                        qy_GetDailyReportEmployeesInAssetFileThisWeekSoFarAsync()
        {
            qy_GetDailyReportEmployeesInAssetFileThisWeekSoFarOutput
                returnOutput =
                        new qy_GetDailyReportEmployeesInAssetFileThisWeekSoFarOutput();

            string myCompleteUrl = $"{MyBaseWebApiUrl}/api/Ops/qy_GetDailyReportEmployeesInAssetFileThisWeekSoFar";
            try
            {
                using (var client = new HttpClient())
                {
                    client.Timeout = TimeSpan.FromHours(1);

                    var result = await client.GetAsync(myCompleteUrl);
                    var response = await result.Content.ReadAsStringAsync();
                    returnOutput = JsonConvert.DeserializeObject<qy_GetDailyReportEmployeesInAssetFileThisWeekSoFarOutput>(response);
                }
            }
            catch (Exception ex)
            {
                returnOutput.IsOk = false;
                string myErrorMessage = ex.Message;
                if (ex.InnerException != null)
                {
                    myErrorMessage = $"{myErrorMessage}.  Inner Exception:  {ex.InnerException.Message}";
                }
                return returnOutput;
            }

            return returnOutput;
        }






        // GET /api/Ops/qy_GetDailyReportMissingBios
        public qy_GetDailyReportMissingBiosOutput
                        qy_GetDailyReportMissingBios
                        ()
        {
            qy_GetDailyReportMissingBiosOutput
                returnOutput =
                        qy_GetDailyReportMissingBiosAsync()
                        .Result;

            return returnOutput;
        }
        public async Task<qy_GetDailyReportMissingBiosOutput>
                        qy_GetDailyReportMissingBiosAsync()
        {
            qy_GetDailyReportMissingBiosOutput
                returnOutput =
                        new qy_GetDailyReportMissingBiosOutput();

            string myCompleteUrl = $"{MyBaseWebApiUrl}/api/Ops/qy_GetDailyReportMissingBios";
            try
            {
                using (var client = new HttpClient())
                {
                    client.Timeout = TimeSpan.FromHours(1);

                    var result = await client.GetAsync(myCompleteUrl);
                    var response = await result.Content.ReadAsStringAsync();
                    returnOutput = JsonConvert.DeserializeObject<qy_GetDailyReportMissingBiosOutput>(response);
                }
            }
            catch (Exception ex)
            {
                returnOutput.IsOk = false;
                string myErrorMessage = ex.Message;
                if (ex.InnerException != null)
                {
                    myErrorMessage = $"{myErrorMessage}.  Inner Exception:  {ex.InnerException.Message}";
                }
                return returnOutput;
            }

            return returnOutput;
        }




        // GET /api/Ops/qy_GetDailyReportMissingLabs
        public qy_GetDailyReportMissingLabsOutput
                        qy_GetDailyReportMissingLabs
                        ()
        {
            qy_GetDailyReportMissingLabsOutput
                returnOutput =
                        qy_GetDailyReportMissingLabsAsync()
                        .Result;

            return returnOutput;
        }
        public async Task<qy_GetDailyReportMissingLabsOutput>
                        qy_GetDailyReportMissingLabsAsync()
        {
            qy_GetDailyReportMissingLabsOutput
                returnOutput =
                        new qy_GetDailyReportMissingLabsOutput();

            string myCompleteUrl = $"{MyBaseWebApiUrl}/api/Ops/qy_GetDailyReportMissingLabs";
            try
            {
                using (var client = new HttpClient())
                {
                    client.Timeout = TimeSpan.FromHours(1);

                    var result = await client.GetAsync(myCompleteUrl);
                    var response = await result.Content.ReadAsStringAsync();
                    returnOutput = JsonConvert.DeserializeObject<qy_GetDailyReportMissingLabsOutput>(response);
                }
            }
            catch (Exception ex)
            {
                returnOutput.IsOk = false;
                string myErrorMessage = ex.Message;
                if (ex.InnerException != null)
                {
                    myErrorMessage = $"{myErrorMessage}.  Inner Exception:  {ex.InnerException.Message}";
                }
                return returnOutput;
            }

            return returnOutput;
        }













        // GET /api/Ops/PopulateDailyReportMissingPatientIDsInLabs
        public qy_GetDailyReportMissingPatientIDsInLabsOutput
                        qy_GetDailyReportMissingPatientIDsInLabs
                        ()
        {
            qy_GetDailyReportMissingPatientIDsInLabsOutput
                returnOutput =
                        qy_GetDailyReportMissingPatientIDsInLabsAsync()
                        .Result;

            return returnOutput;
        }

        public async Task<qy_GetDailyReportMissingPatientIDsInLabsOutput>
                            qy_GetDailyReportMissingPatientIDsInLabsAsync()
        {
            qy_GetDailyReportMissingPatientIDsInLabsOutput
                returnOutput =
                        new qy_GetDailyReportMissingPatientIDsInLabsOutput();

            string myCompleteUrl = $"{MyBaseWebApiUrl}/api/Ops/qy_GetDailyReportMissingLabs";
            try
            {
                using (var client = new HttpClient())
                {
                    client.Timeout = TimeSpan.FromHours(1);

                    var result = await client.GetAsync(myCompleteUrl);
                    var response = await result.Content.ReadAsStringAsync();
                    returnOutput = JsonConvert.DeserializeObject<qy_GetDailyReportMissingPatientIDsInLabsOutput>(response);
                }
            }
            catch (Exception ex)
            {
                returnOutput.IsOk = false;
                string myErrorMessage = ex.Message;
                if (ex.InnerException != null)
                {
                    myErrorMessage = $"{myErrorMessage}.  Inner Exception:  {ex.InnerException.Message}";
                }
                return returnOutput;
            }

            return returnOutput;
        }


        // GET /api/Ops/qy_GetDailyReportPastApptScheduleEntriesWithNoBiometrics
        public qy_GetDailyReportPastApptScheduleEntriesWithNoBiometricsOutput
                        qy_GetDailyReportPastApptScheduleEntriesWithNoBiometrics
                        ()
        {
            qy_GetDailyReportPastApptScheduleEntriesWithNoBiometricsOutput
                returnOutput =
                        qy_GetDailyReportPastApptScheduleEntriesWithNoBiometricsAsync()
                        .Result;

            return returnOutput;
        }

        public async Task<qy_GetDailyReportPastApptScheduleEntriesWithNoBiometricsOutput>
                            qy_GetDailyReportPastApptScheduleEntriesWithNoBiometricsAsync()
        {
            qy_GetDailyReportPastApptScheduleEntriesWithNoBiometricsOutput
                returnOutput =
                        new qy_GetDailyReportPastApptScheduleEntriesWithNoBiometricsOutput();

            string myCompleteUrl = $"{MyBaseWebApiUrl}/api/Ops/qy_GetDailyReportPastApptScheduleEntriesWithNoBiometrics";
            try
            {
                using (var client = new HttpClient())
                {
                    client.Timeout = TimeSpan.FromHours(1);

                    var result = await client.GetAsync(myCompleteUrl);
                    var response = await result.Content.ReadAsStringAsync();
                    returnOutput = JsonConvert.DeserializeObject<qy_GetDailyReportPastApptScheduleEntriesWithNoBiometricsOutput>(response);
                }
            }
            catch (Exception ex)
            {
                returnOutput.IsOk = false;
                string myErrorMessage = ex.Message;
                if (ex.InnerException != null)
                {
                    myErrorMessage = $"{myErrorMessage}.  Inner Exception:  {ex.InnerException.Message}";
                }
                return returnOutput;
            }

            return returnOutput;
        }

        // GET /api/Ops/qy_GetDailyReportPastApptScheduleEntriesWithNoBiosAndNoLabs
        public qy_GetDailyReportPastApptScheduleEntriesWithNoBiosAndNoLabsOutput
                        qy_GetDailyReportPastApptScheduleEntriesWithNoBiosAndNoLabs
                        ()
        {
            qy_GetDailyReportPastApptScheduleEntriesWithNoBiosAndNoLabsOutput
                returnOutput =
                        qy_GetDailyReportPastApptScheduleEntriesWithNoBiosAndNoLabsAsync()
                        .Result;

            return returnOutput;
        }

        public async Task<qy_GetDailyReportPastApptScheduleEntriesWithNoBiosAndNoLabsOutput>
                            qy_GetDailyReportPastApptScheduleEntriesWithNoBiosAndNoLabsAsync()
        {
            qy_GetDailyReportPastApptScheduleEntriesWithNoBiosAndNoLabsOutput
                returnOutput =
                        new qy_GetDailyReportPastApptScheduleEntriesWithNoBiosAndNoLabsOutput();

            string myCompleteUrl = $"{MyBaseWebApiUrl}/api/Ops/qy_GetDailyReportPastApptScheduleEntriesWithNoBiosAndNoLabs";
            try
            {
                using (var client = new HttpClient())
                {
                    client.Timeout = TimeSpan.FromHours(1);

                    var result = await client.GetAsync(myCompleteUrl);
                    var response = await result.Content.ReadAsStringAsync();
                    returnOutput = JsonConvert.DeserializeObject<qy_GetDailyReportPastApptScheduleEntriesWithNoBiosAndNoLabsOutput>(response);
                }
            }
            catch (Exception ex)
            {
                returnOutput.IsOk = false;
                string myErrorMessage = ex.Message;
                if (ex.InnerException != null)
                {
                    myErrorMessage = $"{myErrorMessage}.  Inner Exception:  {ex.InnerException.Message}";
                }
                return returnOutput;
            }

            return returnOutput;
        }






        // GET /api/Ops/qy_GetDailyReportPastApptScheduleEntriesWithNoLabsOutput
        public qy_GetDailyReportPastApptScheduleEntriesWithNoLabsOutput
                        qy_GetDailyReportPastApptScheduleEntriesWithNoNoLabs
                        ()
        {
            qy_GetDailyReportPastApptScheduleEntriesWithNoLabsOutput
                returnOutput =
                        qy_GetDailyReportPastApptScheduleEntriesWithNoNoLabsAsync()
                        .Result;

            return returnOutput;
        }

        public async Task<qy_GetDailyReportPastApptScheduleEntriesWithNoLabsOutput>
                            qy_GetDailyReportPastApptScheduleEntriesWithNoNoLabsAsync()
        {
            qy_GetDailyReportPastApptScheduleEntriesWithNoLabsOutput
                returnOutput =
                        new qy_GetDailyReportPastApptScheduleEntriesWithNoLabsOutput();

            string myCompleteUrl = $"{MyBaseWebApiUrl}/api/Ops/qy_GetDailyReportPastApptScheduleEntriesWithNoLabs";
            try
            {
                using (var client = new HttpClient())
                {
                    client.Timeout = TimeSpan.FromHours(1);

                    var result = await client.GetAsync(myCompleteUrl);
                    var response = await result.Content.ReadAsStringAsync();
                    returnOutput = JsonConvert.DeserializeObject<qy_GetDailyReportPastApptScheduleEntriesWithNoLabsOutput>(response);
                }
            }
            catch (Exception ex)
            {
                returnOutput.IsOk = false;
                string myErrorMessage = ex.Message;
                if (ex.InnerException != null)
                {
                    myErrorMessage = $"{myErrorMessage}.  Inner Exception:  {ex.InnerException.Message}";
                }
                return returnOutput;
            }

            return returnOutput;
        }


        // GET /api/Ops/qy_GetDailyReportPhysicianFormsOutput
        public qy_GetDailyReportPhysicianFormsOutput
                        qy_GetDailyReportPhysicianForms
                        ()
        {
            qy_GetDailyReportPhysicianFormsOutput
                returnOutput =
                        qy_GetDailyReportPhysicianFormsAsync()
                        .Result;

            return returnOutput;
        }

        public async Task<qy_GetDailyReportPhysicianFormsOutput>
                            qy_GetDailyReportPhysicianFormsAsync()
        {
            qy_GetDailyReportPhysicianFormsOutput
                returnOutput =
                        new qy_GetDailyReportPhysicianFormsOutput();

            string myCompleteUrl = $"{MyBaseWebApiUrl}/api/Ops/qy_GetDailyReportPhysicianForms";
            try
            {
                using (var client = new HttpClient())
                {
                    client.Timeout = TimeSpan.FromHours(1);

                    var result = await client.GetAsync(myCompleteUrl);
                    var response = await result.Content.ReadAsStringAsync();
                    returnOutput = JsonConvert.DeserializeObject<qy_GetDailyReportPhysicianFormsOutput>(response);
                }
            }
            catch (Exception ex)
            {
                returnOutput.IsOk = false;
                string myErrorMessage = ex.Message;
                if (ex.InnerException != null)
                {
                    myErrorMessage = $"{myErrorMessage}.  Inner Exception:  {ex.InnerException.Message}";
                }
                return returnOutput;
            }

            return returnOutput;
        }

        // GET /api/Ops/qy_GetDailyReportConfig
        public qy_GetDailyReportConfigOutput
                         qy_GetDailyReportConfig
                         ()
        {
            qy_GetDailyReportConfigOutput
               returnOutput =
                        qy_GetDailyReportConfigAsync()
                       .Result;

            return returnOutput;
        }

        public async Task<qy_GetDailyReportConfigOutput>
                             qy_GetDailyReportConfigAsync()
        {
            qy_GetDailyReportConfigOutput
               returnOutput =
                       new qy_GetDailyReportConfigOutput();

            string myCompleteUrl = $"{MyBaseWebApiUrl}/api/Ops/qy_GetDailyReportConfig";
            try
            {
                using (var client = new HttpClient())
                {
                    client.Timeout = TimeSpan.FromHours(1);

                    var result = await client.GetAsync(myCompleteUrl);
                    var response = await result.Content.ReadAsStringAsync();
                    returnOutput = JsonConvert.DeserializeObject<qy_GetDailyReportConfigOutput>(response);
                }
            }
            catch (Exception ex)
            {
                returnOutput.IsOk = false;
                string myErrorMessage = ex.Message;
                if (ex.InnerException != null)
                {
                    myErrorMessage = $"{myErrorMessage}.  Inner Exception:  {ex.InnerException.Message}";
                }
                return returnOutput;
            }

            return returnOutput;
        }








        // GET /api/Ops/qy_GetDailyReportSsnNameDobDifferences
        public qy_GetDailyReportSsnNameDobDifferencesOutput
                        qy_GetDailyReportSsnNameDobDifferences
                        ()
        {
            qy_GetDailyReportSsnNameDobDifferencesOutput
                returnOutput =
                        qy_GetDailyReportSsnNameDobDifferencesAsync()
                        .Result;

            return returnOutput;
        }
        public async Task<qy_GetDailyReportSsnNameDobDifferencesOutput>
                        qy_GetDailyReportSsnNameDobDifferencesAsync()
        {
            qy_GetDailyReportSsnNameDobDifferencesOutput
                returnOutput =
                        new qy_GetDailyReportSsnNameDobDifferencesOutput();

            string myCompleteUrl = $"{MyBaseWebApiUrl}/api/Ops/qy_GetDailyReportSsnNameDobDifferences";
            try
            {
                using (var client = new HttpClient())
                {
                    client.Timeout = TimeSpan.FromHours(1);

                    var result = await client.GetAsync(myCompleteUrl);
                    var response = await result.Content.ReadAsStringAsync();
                    returnOutput = JsonConvert.DeserializeObject<qy_GetDailyReportSsnNameDobDifferencesOutput>(response);
                }
            }
            catch (Exception ex)
            {
                returnOutput.IsOk = false;
                string myErrorMessage = ex.Message;
                if (ex.InnerException != null)
                {
                    myErrorMessage = $"{myErrorMessage}.  Inner Exception:  {ex.InnerException.Message}";
                }
                return returnOutput;
            }

            return returnOutput;
        }

        // GET /api/Ops/qy_GetDailyReportSsnsNotListedInAllEmployeesList
        public qy_GetDailyReportSsnsNotListedInAllEmployeesListOutput
                        qy_GetDailyReportSsnsNotListedInAllEmployeesList
                        ()
        {
            qy_GetDailyReportSsnsNotListedInAllEmployeesListOutput
                returnOutput =
                        qy_GetDailyReportSsnsNotListedInAllEmployeesListAsync()
                        .Result;

            return returnOutput;
        }
        public async Task<qy_GetDailyReportSsnsNotListedInAllEmployeesListOutput>
                        qy_GetDailyReportSsnsNotListedInAllEmployeesListAsync()
        {
            qy_GetDailyReportSsnsNotListedInAllEmployeesListOutput
                returnOutput =
                        new qy_GetDailyReportSsnsNotListedInAllEmployeesListOutput();
                                                      
            string myCompleteUrl = $"{MyBaseWebApiUrl}/api/Ops/qy_GetDailyReportSsnsNotListedInAllEmployeesList";
            try
            {
                using (var client = new HttpClient())
                {
                    client.Timeout = TimeSpan.FromHours(1);

                    var result = await client.GetAsync(myCompleteUrl);
                    var response = await result.Content.ReadAsStringAsync();
                    returnOutput = JsonConvert.DeserializeObject<qy_GetDailyReportSsnsNotListedInAllEmployeesListOutput>(response);
                }
            }
            catch (Exception ex)
            {
                returnOutput.IsOk = false;
                string myErrorMessage = ex.Message;
                if (ex.InnerException != null)
                {
                    myErrorMessage = $"{myErrorMessage}.  Inner Exception:  {ex.InnerException.Message}";
                }
                return returnOutput;
            }

            return returnOutput;
        }


















    }
}
