using log4net;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using summitlifedailyreport9.Data.Models;

namespace summitlifedailyreport9.WebApiLand.Controllers
{
    [EnableCors("MyPolicy")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OpsController : ControllerBase
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(OpsController));

        public OpsController(DsSummitLifeContext inputDsSummitLifeContext)
        {
            MyContext = inputDsSummitLifeContext;

            log.Info($"Start of OpsController Connection String:  {MyContext.MyConnectionString}");

        }
        public DsSummitLifeContext MyContext { get; set; }

        // GET /api/Ops/di_PopulateDailyReportDupEmpNbrSsnCombos
        [HttpGet]
        public di_PopulateDailyReportDupEmpNbrSsnCombosOutput
                    di_PopulateDailyReportDupEmpNbrSsnCombos
                    (
                    )
        {
            di_PopulateDailyReportDupEmpNbrSsnCombosOutput
                returnOutput =
                    new di_PopulateDailyReportDupEmpNbrSsnCombosOutput();
                              
            string sql = $"sl.di_PopulateDailyReportDupEmpNbrSsnCombos";

            List<SqlParameter> parms = new List<SqlParameter>();

            try
            {
                returnOutput.di_PopulateDailyReportDupEmpNbrSsnCombosOutputColumnsList =
                    MyContext
                    .di_PopulateDailyReportDupEmpNbrSsnCombosOutputColumnsList
                    .FromSqlRaw<di_PopulateDailyReportDupEmpNbrSsnCombosOutputColumns>
                    (
                          sql
                        , parms.ToArray()
                    )
                    .ToList();
            }
            catch (Exception ex)
            {
                returnOutput.IsOk = false;

                string myErrorMessage = ex.Message;
                if (ex.InnerException != null)
                {
                    myErrorMessage = $"{myErrorMessage}.  InnerException:  {ex.InnerException.Message}";
                }
                returnOutput.ErrorMessage = myErrorMessage;
                return returnOutput;
            }
            return returnOutput;
        }

        // GET /api/Ops/di_PopulateDailyReportEmployeesInAssetFilesThisYear
        [HttpGet]
        public di_PopulateDailyReportEmployeesInAssetFilesThisYearOutput
                    di_PopulateDailyReportEmployeesInAssetFilesThisYear
                    (
                    )
        {
            di_PopulateDailyReportEmployeesInAssetFilesThisYearOutput
                returnOutput =
                    new di_PopulateDailyReportEmployeesInAssetFilesThisYearOutput();

            string sql = $"sl.di_PopulateDailyReportEmployeesInAssetFilesThisYear";

            List<SqlParameter> parms = new List<SqlParameter>();

            try
            {
                returnOutput.di_PopulateDailyReportEmployeesInAssetFilesThisYearOutputColumnsList =
                    MyContext
                    .di_PopulateDailyReportEmployeesInAssetFilesThisYearOutputColumnsList
                    .FromSqlRaw<di_PopulateDailyReportEmployeesInAssetFilesThisYearOutputColumns>
                    (
                          sql
                        , parms.ToArray()
                    )
                    .ToList();
            }
            catch (Exception ex)
            {
                returnOutput.IsOk = false;

                string myErrorMessage = ex.Message;
                if (ex.InnerException != null)
                {
                    myErrorMessage = $"{myErrorMessage}.  InnerException:  {ex.InnerException.Message}";
                }
                returnOutput.ErrorMessage = myErrorMessage;
                return returnOutput;
            }
            return returnOutput;
        }

        // GET /api/Ops/di_PopulateDailyReportEmployeesInAssetFileThisWeekSoFar
        [HttpGet]
        public di_PopulateDailyReportEmployeesInAssetFileThisWeekSoFarOutput
                    di_PopulateDailyReportEmployeesInAssetFileThisWeekSoFar
                    (
                    )
        {
            di_PopulateDailyReportEmployeesInAssetFileThisWeekSoFarOutput
                returnOutput =
                    new di_PopulateDailyReportEmployeesInAssetFileThisWeekSoFarOutput();

            string sql = $"sl.di_PopulateDailyReportEmployeesInAssetFileThisWeekSoFar";

            List<SqlParameter> parms = new List<SqlParameter>();

            try
            {
                returnOutput.di_PopulateDailyReportEmployeesInAssetFileThisWeekSoFarOutputColumnsList =
                    MyContext
                    .di_PopulateDailyReportEmployeesInAssetFileThisWeekSoFarOutputColumnsList
                    .FromSqlRaw<di_PopulateDailyReportEmployeesInAssetFileThisWeekSoFarOutputColumns>
                    (
                          sql
                        , parms.ToArray()
                    )
                    .ToList();
            }
            catch (Exception ex)
            {
                returnOutput.IsOk = false;

                string myErrorMessage = ex.Message;
                if (ex.InnerException != null)
                {
                    myErrorMessage = $"{myErrorMessage}.  InnerException:  {ex.InnerException.Message}";
                }
                returnOutput.ErrorMessage = myErrorMessage;
                return returnOutput;
            }
            return returnOutput;
        }


        // GET /api/Ops/di_PopulateDailyReportMissingBios
        [HttpGet]
        public di_PopulateDailyReportMissingBiosOutput
                    di_PopulateDailyReportMissingBios
                    (
                    )
        {
            di_PopulateDailyReportMissingBiosOutput
                returnOutput =
                    new di_PopulateDailyReportMissingBiosOutput();

            string sql = $"sl.di_PopulateDailyReportMissingBios";

            List<SqlParameter> parms = new List<SqlParameter>();

            try
            {
                returnOutput.di_PopulateDailyReportMissingBiosOutputColumnsList =
                    MyContext
                    .di_PopulateDailyReportMissingBiosOutputColumnsList
                    .FromSqlRaw<di_PopulateDailyReportMissingBiosOutputColumns>
                    (
                          sql
                        , parms.ToArray()
                    )
                    .ToList();
            }
            catch (Exception ex)
            {
                returnOutput.IsOk = false;

                string myErrorMessage = ex.Message;
                if (ex.InnerException != null)
                {
                    myErrorMessage = $"{myErrorMessage}.  InnerException:  {ex.InnerException.Message}";
                }
                returnOutput.ErrorMessage = myErrorMessage;
                return returnOutput;
            }
            return returnOutput;
        }

        // GET /api/Ops/di_PopulateDailyReportMissingLabs
        [HttpGet]
        public di_PopulateDailyReportMissingLabsOutput
                    di_PopulateDailyReportMissingLabs
                    (
                    )
        {
            di_PopulateDailyReportMissingLabsOutput
                returnOutput =
                    new di_PopulateDailyReportMissingLabsOutput();

            string sql = $"sl.di_PopulateDailyReportMissingLabs";

            List<SqlParameter> parms = new List<SqlParameter>();

            try
            {
                returnOutput.di_PopulateDailyReportMissingLabsOutputColumnsList =
                    MyContext
                    .di_PopulateDailyReportMissingLabsOutputColumnsList
                    .FromSqlRaw<di_PopulateDailyReportMissingLabsOutputColumns>
                    (
                          sql
                        , parms.ToArray()
                    )
                    .ToList();
            }
            catch (Exception ex)
            {
                returnOutput.IsOk = false;

                string myErrorMessage = ex.Message;
                if (ex.InnerException != null)
                {
                    myErrorMessage = $"{myErrorMessage}.  InnerException:  {ex.InnerException.Message}";
                }
                returnOutput.ErrorMessage = myErrorMessage;
                return returnOutput;
            }
            return returnOutput;
        }


        // GET /api/Ops/di_PopulateDailyReportPastApptScheduleEntriesWithNoBiometrics
        [HttpGet]
        public di_PopulateDailyReportPastApptScheduleEntriesWithNoBiometricsOutput
                    di_PopulateDailyReportPastApptScheduleEntriesWithNoBiometrics
                    (
                    )
        {
            di_PopulateDailyReportPastApptScheduleEntriesWithNoBiometricsOutput
                returnOutput =
                    new di_PopulateDailyReportPastApptScheduleEntriesWithNoBiometricsOutput();

            string sql = $"sl.di_PopulateDailyReportPastApptScheduleEntriesWithNoBiometrics";

            List<SqlParameter> parms = new List<SqlParameter>();

            try
            {
                returnOutput.di_PopulateDailyReportPastApptScheduleEntriesWithNoBiometricsOutputColumnsList =
                    MyContext
                    .di_PopulateDailyReportPastApptScheduleEntriesWithNoBiometricsOutputColumnsList
                    .FromSqlRaw<di_PopulateDailyReportPastApptScheduleEntriesWithNoBiometricsOutputColumns>
                    (
                          sql
                        , parms.ToArray()
                    )
                    .ToList();
            }
            catch (Exception ex)
            {
                returnOutput.IsOk = false;

                string myErrorMessage = ex.Message;
                if (ex.InnerException != null)
                {
                    myErrorMessage = $"{myErrorMessage}.  InnerException:  {ex.InnerException.Message}";
                }
                returnOutput.ErrorMessage = myErrorMessage;
                return returnOutput;
            }
            return returnOutput;
        }

        // GET /api/Ops/di_PopulateDailyReportPastApptScheduleEntriesWithNoBiosAndNoLabs
        [HttpGet]
        public di_PopulateDailyReportPastApptScheduleEntriesWithNoBiosAndNoLabsOutput
                    di_PopulateDailyReportPastApptScheduleEntriesWithNoBiosAndNoLabs
                    (
                    )
        {
            di_PopulateDailyReportPastApptScheduleEntriesWithNoBiosAndNoLabsOutput
                returnOutput =
                    new di_PopulateDailyReportPastApptScheduleEntriesWithNoBiosAndNoLabsOutput();

            string sql = $"sl.di_PopulateDailyReportPastApptScheduleEntriesWithNoBiosAndNoLabs";

            List<SqlParameter> parms = new List<SqlParameter>();

            try
            {
                returnOutput.di_PopulateDailyReportPastApptScheduleEntriesWithNoBiosAndNoLabsOutputColumnsList =
                    MyContext
                    .di_PopulateDailyReportPastApptScheduleEntriesWithNoBiosAndNoLabsOutputColumnsList
                    .FromSqlRaw<di_PopulateDailyReportPastApptScheduleEntriesWithNoBiosAndNoLabsOutputColumns>
                    (
                          sql
                        , parms.ToArray()
                    )
                    .ToList();
            }
            catch (Exception ex)
            {
                returnOutput.IsOk = false;

                string myErrorMessage = ex.Message;
                if (ex.InnerException != null)
                {
                    myErrorMessage = $"{myErrorMessage}.  InnerException:  {ex.InnerException.Message}";
                }
                returnOutput.ErrorMessage = myErrorMessage;
                return returnOutput;
            }
            return returnOutput;
        }


        // GET /api/Ops/di_PopulateDailyReportPastApptScheduleEntriesWithNoLabs
        [HttpGet]
        public di_PopulateDailyReportPastApptScheduleEntriesWithNoLabsOutput
                    di_PopulateDailyReportPastApptScheduleEntriesWithNoLabs
                    (
                    )
        {
            di_PopulateDailyReportPastApptScheduleEntriesWithNoLabsOutput
                returnOutput =
                    new di_PopulateDailyReportPastApptScheduleEntriesWithNoLabsOutput();

            string sql = $"sl.di_PopulateDailyReportPastApptScheduleEntriesWithNoLabs";

            List<SqlParameter> parms = new List<SqlParameter>();

            try
            {
                returnOutput.di_PopulateDailyReportPastApptScheduleEntriesWithNoLabsOutputColumnsList =
                    MyContext
                    .di_PopulateDailyReportPastApptScheduleEntriesWithNoLabsOutputColumnsList
                    .FromSqlRaw<di_PopulateDailyReportPastApptScheduleEntriesWithNoLabsOutputColumns>
                    (
                          sql
                        , parms.ToArray()
                    )
                    .ToList();
            }
            catch (Exception ex)
            {
                returnOutput.IsOk = false;

                string myErrorMessage = ex.Message;
                if (ex.InnerException != null)
                {
                    myErrorMessage = $"{myErrorMessage}.  InnerException:  {ex.InnerException.Message}";
                }
                returnOutput.ErrorMessage = myErrorMessage;
                return returnOutput;
            }
            return returnOutput;
        }


        // GET /api/Ops/di_PopulateDailyReportMissingPatientIDsInLabs
        [HttpGet]
        public di_PopulateDailyReportMissingPatientIDsInLabsOutput
                    di_PopulateDailyReportMissingPatientIDsInLabs
                    (
                    )
        {
            di_PopulateDailyReportMissingPatientIDsInLabsOutput
                returnOutput =
                    new di_PopulateDailyReportMissingPatientIDsInLabsOutput();

            string sql = $"sl.di_PopulateDailyReportMissingPatientIDsInLabs";

            List<SqlParameter> parms = new List<SqlParameter>();

            try
            {
                returnOutput.di_PopulateDailyReportMissingPatientIDsInLabsOutputColumnsList =
                    MyContext
                    .di_PopulateDailyReportMissingPatientIDsInLabsOutputColumnsList
                    .FromSqlRaw<di_PopulateDailyReportMissingPatientIDsInLabsOutputColumns>
                    (
                          sql
                        , parms.ToArray()
                    )
                    .ToList();
            }
            catch (Exception ex)
            {
                returnOutput.IsOk = false;

                string myErrorMessage = ex.Message;
                if (ex.InnerException != null)
                {
                    myErrorMessage = $"{myErrorMessage}.  InnerException:  {ex.InnerException.Message}";
                }
                returnOutput.ErrorMessage = myErrorMessage;
                return returnOutput;
            }
            return returnOutput;
        }

        // GET /api/Ops/di_PopulateDailyReportPhysicianForms
        [HttpGet]
        public di_PopulateDailyReportPhysicianFormsOutput
                    di_PopulateDailyReportPhysicianForms
                    (
                    )
        {
            di_PopulateDailyReportPhysicianFormsOutput
                returnOutput =
                    new di_PopulateDailyReportPhysicianFormsOutput();

            string sql = $"sl.di_PopulateDailyReportPhysicianForms";

            List<SqlParameter> parms = new List<SqlParameter>();

            try
            {
                returnOutput.di_PopulateDailyReportPhysicianFormsOutputColumnsList =
                    MyContext
                    .di_PopulateDailyReportPhysicianFormsOutputColumnsList
                    .FromSqlRaw<di_PopulateDailyReportPhysicianFormsOutputColumns>
                    (
                          sql
                        , parms.ToArray()
                    )
                    .ToList();
            }
            catch (Exception ex)
            {
                returnOutput.IsOk = false;

                string myErrorMessage = ex.Message;
                if (ex.InnerException != null)
                {
                    myErrorMessage = $"{myErrorMessage}.  InnerException:  {ex.InnerException.Message}";
                }
                returnOutput.ErrorMessage = myErrorMessage;
                return returnOutput;
            }
            return returnOutput;
        }

        // GET /api/Ops/di_PopulateDailyReportSsnNameDobDifferences
        [HttpGet]
        public di_PopulateDailyReportSsnNameDobDifferencesOutput
                    di_PopulateDailyReportSsnNameDobDifferences
                    (
                    )
        {
            di_PopulateDailyReportSsnNameDobDifferencesOutput
                returnOutput =
                    new di_PopulateDailyReportSsnNameDobDifferencesOutput();

            string sql = $"sl.di_PopulateDailyReportSsnNameDobDifferences";

            List<SqlParameter> parms = new List<SqlParameter>();

            try
            {
                returnOutput.di_PopulateDailyReportSsnNameDobDifferencesOutputColumnsList =
                    MyContext
                    .di_PopulateDailyReportSsnNameDobDifferencesOutputColumnsList
                    .FromSqlRaw<di_PopulateDailyReportSsnNameDobDifferencesOutputColumns>
                    (
                          sql
                        , parms.ToArray()
                    )
                    .ToList();
            }
            catch (Exception ex)
            {
                returnOutput.IsOk = false;

                string myErrorMessage = ex.Message;
                if (ex.InnerException != null)
                {
                    myErrorMessage = $"{myErrorMessage}.  InnerException:  {ex.InnerException.Message}";
                }
                returnOutput.ErrorMessage = myErrorMessage;
                return returnOutput;
            }
            return returnOutput;
        }

        // GET /api/Ops/di_PopulateDailyReportSsnsNotListedInAllEmployeesList
        [HttpGet]
        public di_PopulateDailyReportSsnsNotListedInAllEmployeesListOutput
                    di_PopulateDailyReportSsnsNotListedInAllEmployeesList
                    (
                    )
        {
            di_PopulateDailyReportSsnsNotListedInAllEmployeesListOutput
                returnOutput =
                    new di_PopulateDailyReportSsnsNotListedInAllEmployeesListOutput();

            string sql = $"sl.di_PopulateDailyReportSsnsNotListedInAllEmployeesList";

            List<SqlParameter> parms = new List<SqlParameter>();

            try
            {
                returnOutput.di_PopulateDailyReportSsnsNotListedInAllEmployeesListOutputColumnsList =
                    MyContext
                    .di_PopulateDailyReportSsnsNotListedInAllEmployeesListOutputColumnsList
                    .FromSqlRaw<di_PopulateDailyReportSsnsNotListedInAllEmployeesListOutputColumns>
                    (
                          sql
                        , parms.ToArray()
                    )
                    .ToList();
            }
            catch (Exception ex)
            {
                returnOutput.IsOk = false;

                string myErrorMessage = ex.Message;
                if (ex.InnerException != null)
                {
                    myErrorMessage = $"{myErrorMessage}.  InnerException:  {ex.InnerException.Message}";
                }
                returnOutput.ErrorMessage = myErrorMessage;
                return returnOutput;
            }
            return returnOutput;
        }

        // GET /api/Ops/di_DailyReportAssetIncentiveStatusErrorForAllEmployees
        [HttpGet]
        public di_DailyReportAssetIncentiveStatusErrorForAllEmployeesOutput
                    di_DailyReportAssetIncentiveStatusErrorForAllEmployees
                    (
                    )
        {
            di_DailyReportAssetIncentiveStatusErrorForAllEmployeesOutput
                returnOutput =
                    new di_DailyReportAssetIncentiveStatusErrorForAllEmployeesOutput();

            string sql = $"sl.di_DailyReportAssetIncentiveStatusErrorForAllEmployees";

            List<SqlParameter> parms = new List<SqlParameter>();

            try
            {
                returnOutput.di_DailyReportAssetIncentiveStatusErrorForAllEmployeesOutputColumnsList =
                    MyContext
                    .di_DailyReportAssetIncentiveStatusErrorForAllEmployeesOutputColumnsList
                    .FromSqlRaw<di_DailyReportAssetIncentiveStatusErrorForAllEmployeesOutputColumns>
                    (
                          sql
                        , parms.ToArray()
                    )
                    .ToList();
            }
            catch (Exception ex)
            {
                returnOutput.IsOk = false;

                string myErrorMessage = ex.Message;
                if (ex.InnerException != null)
                {
                    myErrorMessage = $"{myErrorMessage}.  InnerException:  {ex.InnerException.Message}";
                }
                returnOutput.ErrorMessage = myErrorMessage;
                return returnOutput;
            }
            return returnOutput;
        }

        // GET /api/Ops/qy_DailyReportAssetIncentiveStatusErrorForAllEmployees
        [HttpGet]
        public qy_DailyReportAssetIncentiveStatusErrorForAllEmployeesOutput
                    qy_DailyReportAssetIncentiveStatusErrorForAllEmployees
                    (
                    )
        {
            qy_DailyReportAssetIncentiveStatusErrorForAllEmployeesOutput
                returnOutput =
                    new qy_DailyReportAssetIncentiveStatusErrorForAllEmployeesOutput();

            string sql = $"sl.qy_DailyReportAssetIncentiveStatusErrorForAllEmployees";

            List<SqlParameter> parms = new List<SqlParameter>();

            try
            {
                returnOutput.qy_DailyReportAssetIncentiveStatusErrorForAllEmployeesOutputColumnsList =
                    MyContext
                    .qy_DailyReportAssetIncentiveStatusErrorForAllEmployeesOutputColumnsList
                    .FromSqlRaw<qy_DailyReportAssetIncentiveStatusErrorForAllEmployeesOutputColumns>
                    (
                          sql
                        , parms.ToArray()
                    )
                    .ToList();
            }
            catch (Exception ex)
            {
                returnOutput.IsOk = false;

                string myErrorMessage = ex.Message;
                if (ex.InnerException != null)
                {
                    myErrorMessage = $"{myErrorMessage}.  InnerException:  {ex.InnerException.Message}";
                }
                returnOutput.ErrorMessage = myErrorMessage;
                return returnOutput;
            }
            return returnOutput;
        }

        // GET /api/Ops/qy_GetDailyReportDupEmpNbrSsnCombos
        [HttpGet]
        public qy_GetDailyReportDupEmpNbrSsnCombosOutput
                   qy_GetDailyReportDupEmpNbrSsnCombos
                    (
                    )
        {
            qy_GetDailyReportDupEmpNbrSsnCombosOutput
                returnOutput =
                    new qy_GetDailyReportDupEmpNbrSsnCombosOutput();

            string sql = $"sl.qy_GetDailyReportDupEmpNbrSsnCombos";

            List<SqlParameter> parms = new List<SqlParameter>();

            try
            {
                returnOutput.qy_GetDailyReportDupEmpNbrSsnCombosOutputColumnsList =
                    MyContext
                    .qy_GetDailyReportDupEmpNbrSsnCombosOutputColumnsList
                    .FromSqlRaw<qy_GetDailyReportDupEmpNbrSsnCombosOutputColumns>
                    (
                          sql
                        , parms.ToArray()
                    )
                    .ToList();
            }
            catch (Exception ex)
            {
                returnOutput.IsOk = false;

                string myErrorMessage = ex.Message;
                if (ex.InnerException != null)
                {
                    myErrorMessage = $"{myErrorMessage}.  InnerException:  {ex.InnerException.Message}";
                }
                returnOutput.ErrorMessage = myErrorMessage;
                return returnOutput;
            }
            return returnOutput;
        }


        // GET /api/Ops/qy_GetDailyReportEmployeesInAssetFilesThisYear
        [HttpGet]
        public qy_GetDailyReportEmployeesInAssetFilesThisYearOutput
                    qy_GetDailyReportEmployeesInAssetFilesThisYear
                    (
                    )
        {
            qy_GetDailyReportEmployeesInAssetFilesThisYearOutput
                returnOutput =
                    new qy_GetDailyReportEmployeesInAssetFilesThisYearOutput();

            string sql = $"sl.qy_GetDailyReportEmployeesInAssetFilesThisYear";

            List<SqlParameter> parms = new List<SqlParameter>();

            try
            {
                returnOutput.qy_GetDailyReportEmployeesInAssetFilesThisYearOutputColumnsList =
                    MyContext
                    .qy_GetDailyReportEmployeesInAssetFilesThisYearOutputColumnsList
                    .FromSqlRaw<qy_GetDailyReportEmployeesInAssetFilesThisYearOutputColumns>
                    (
                          sql
                        , parms.ToArray()
                    )
                    .ToList();
            }
            catch (Exception ex)
            {
                returnOutput.IsOk = false;

                string myErrorMessage = ex.Message;
                if (ex.InnerException != null)
                {
                    myErrorMessage = $"{myErrorMessage}.  InnerException:  {ex.InnerException.Message}";
                }
                returnOutput.ErrorMessage = myErrorMessage;
                return returnOutput;
            }
            return returnOutput;
        }

        // GET /api/Ops/qy_GetDailyReportEmployeesInAssetFileThisWeekSoFar
        [HttpGet]
        public qy_GetDailyReportEmployeesInAssetFileThisWeekSoFarOutput
                    qy_GetDailyReportEmployeesInAssetFileThisWeekSoFar
                    (
                    )
        {
            qy_GetDailyReportEmployeesInAssetFileThisWeekSoFarOutput
                returnOutput =
                    new qy_GetDailyReportEmployeesInAssetFileThisWeekSoFarOutput();

            string sql = $"sl.qy_GetDailyReportEmployeesInAssetFileThisWeekSoFar";

            List<SqlParameter> parms = new List<SqlParameter>();

            try
            {
                returnOutput.qy_GetDailyReportEmployeesInAssetFileThisWeekSoFarOutputColumnsList =
                    MyContext
                    .qy_GetDailyReportEmployeesInAssetFileThisWeekSoFarOutputColumnsList
                    .FromSqlRaw<qy_GetDailyReportEmployeesInAssetFileThisWeekSoFarOutputColumns>
                    (
                          sql
                        , parms.ToArray()
                    )
                    .ToList();
            }
            catch (Exception ex)
            {
                returnOutput.IsOk = false;

                string myErrorMessage = ex.Message;
                if (ex.InnerException != null)
                {
                    myErrorMessage = $"{myErrorMessage}.  InnerException:  {ex.InnerException.Message}";
                }
                returnOutput.ErrorMessage = myErrorMessage;
                return returnOutput;
            }
            return returnOutput;
        }

        // GET /api/Ops/qy_GetDailyReportMissingBios
        [HttpGet]
        public qy_GetDailyReportMissingBiosOutput
                    qy_GetDailyReportMissingBios
                    (
                    )
        {
            qy_GetDailyReportMissingBiosOutput
                returnOutput =
                    new qy_GetDailyReportMissingBiosOutput();

            string sql = $"sl.qy_GetDailyReportMissingBios";

            List<SqlParameter> parms = new List<SqlParameter>();

            try
            {
                returnOutput.qy_GetDailyReportMissingBiosOutputColumnsList =
                    MyContext
                    .qy_GetDailyReportMissingBiosOutputColumnsList
                    .FromSqlRaw<qy_GetDailyReportMissingBiosOutputColumns>
                    (
                          sql
                        , parms.ToArray()
                    )
                    .ToList();
            }
            catch (Exception ex)
            {
                returnOutput.IsOk = false;

                string myErrorMessage = ex.Message;
                if (ex.InnerException != null)
                {
                    myErrorMessage = $"{myErrorMessage}.  InnerException:  {ex.InnerException.Message}";
                }
                returnOutput.ErrorMessage = myErrorMessage;
                return returnOutput;
            }
            return returnOutput;
        }


        // GET /api/Ops/qy_GetDailyReportMissingLabs
        [HttpGet]
        public qy_GetDailyReportMissingLabsOutput
                    qy_GetDailyReportMissingLabs
                    (
                    )
        {
            qy_GetDailyReportMissingLabsOutput
                returnOutput =
                    new qy_GetDailyReportMissingLabsOutput();

            string sql = $"sl.qy_GetDailyReportMissingLabs";

            List<SqlParameter> parms = new List<SqlParameter>();

            try
            {
                returnOutput.qy_GetDailyReportMissingLabsOutputColumnsList =
                    MyContext
                    .qy_GetDailyReportMissingLabsOutputColumnsList
                    .FromSqlRaw<qy_GetDailyReportMissingLabsOutputColumns>
                    (
                          sql
                        , parms.ToArray()
                    )
                    .ToList();
            }
            catch (Exception ex)
            {
                returnOutput.IsOk = false;

                string myErrorMessage = ex.Message;
                if (ex.InnerException != null)
                {
                    myErrorMessage = $"{myErrorMessage}.  InnerException:  {ex.InnerException.Message}";
                }
                returnOutput.ErrorMessage = myErrorMessage;
                return returnOutput;
            }
            return returnOutput;
        }

        // GET /api/Ops/qy_GetDailyReportPastApptScheduleEntriesWithNoBiometrics
        public qy_GetDailyReportPastApptScheduleEntriesWithNoBiometricsOutput
                    qy_GetDailyReportPastApptScheduleEntriesWithNoBiometrics
                    (
                    )
        {
            qy_GetDailyReportPastApptScheduleEntriesWithNoBiometricsOutput
                returnOutput =
                    new qy_GetDailyReportPastApptScheduleEntriesWithNoBiometricsOutput();

            string sql = $"sl.qy_GetDailyReportPastApptScheduleEntriesWithNoBiometrics";

            List<SqlParameter> parms = new List<SqlParameter>();

            try
            {
                returnOutput.qy_GetDailyReportPastApptScheduleEntriesWithNoBiometricsOutputColumnsList =
                    MyContext
                    .qy_GetDailyReportPastApptScheduleEntriesWithNoBiometricsOutputColumnsList
                    .FromSqlRaw<qy_GetDailyReportPastApptScheduleEntriesWithNoBiometricsOutputColumns>
                    (
                          sql
                        , parms.ToArray()
                    )
                    .ToList();
            }
            catch (Exception ex)
            {
                returnOutput.IsOk = false;

                string myErrorMessage = ex.Message;
                if (ex.InnerException != null)
                {
                    myErrorMessage = $"{myErrorMessage}.  InnerException:  {ex.InnerException.Message}";
                }
                returnOutput.ErrorMessage = myErrorMessage;
                return returnOutput;
            }
            return returnOutput;
        }

        // GET /api/Ops/qy_GetDailyReportPastApptScheduleEntriesWithNoBiosAndNoLabs
        public qy_GetDailyReportPastApptScheduleEntriesWithNoBiosAndNoLabsOutput
                    qy_GetDailyReportPastApptScheduleEntriesWithNoBiosAndNoLabs
                    (
                    )
        {
            qy_GetDailyReportPastApptScheduleEntriesWithNoBiosAndNoLabsOutput
                returnOutput =
                    new qy_GetDailyReportPastApptScheduleEntriesWithNoBiosAndNoLabsOutput();

            string sql = $"sl.qy_GetDailyReportPastApptScheduleEntriesWithNoBiosAndNoLabs";

            List<SqlParameter> parms = new List<SqlParameter>();

            try
            {
                returnOutput.qy_GetDailyReportPastApptScheduleEntriesWithNoBiosAndNoLabsOutputColumnsList =
                    MyContext
                    .qy_GetDailyReportPastApptScheduleEntriesWithNoBiosAndNoLabsOutputColumnsList
                    .FromSqlRaw<qy_GetDailyReportPastApptScheduleEntriesWithNoBiosAndNoLabsOutputColumns>
                    (
                          sql
                        , parms.ToArray()
                    )
                    .ToList();
            }
            catch (Exception ex)
            {
                returnOutput.IsOk = false;

                string myErrorMessage = ex.Message;
                if (ex.InnerException != null)
                {
                    myErrorMessage = $"{myErrorMessage}.  InnerException:  {ex.InnerException.Message}";
                }
                returnOutput.ErrorMessage = myErrorMessage;
                return returnOutput;
            }
            return returnOutput;
        }

        // GET /api/Ops/qy_GetDailyReportPastApptScheduleEntriesWithNoLabs
        public qy_GetDailyReportPastApptScheduleEntriesWithNoLabsOutput
                    qy_GetDailyReportPastApptScheduleEntriesWithNoLabs
                    (
                    )
        {
            qy_GetDailyReportPastApptScheduleEntriesWithNoLabsOutput
                returnOutput =
                    new qy_GetDailyReportPastApptScheduleEntriesWithNoLabsOutput();

            string sql = $"sl.qy_GetDailyReportPastApptScheduleEntriesWithNoLabs";

            List<SqlParameter> parms = new List<SqlParameter>();

            try
            {
                returnOutput.qy_GetDailyReportPastApptScheduleEntriesWithNoLabsOutputColumnsList =
                    MyContext
                    .qy_GetDailyReportPastApptScheduleEntriesWithNoLabsOutputColumnsList
                    .FromSqlRaw<qy_GetDailyReportPastApptScheduleEntriesWithNoLabsOutputColumns>
                    (
                          sql
                        , parms.ToArray()
                    )
                    .ToList();
            }
            catch (Exception ex)
            {
                returnOutput.IsOk = false;

                string myErrorMessage = ex.Message;
                if (ex.InnerException != null)
                {
                    myErrorMessage = $"{myErrorMessage}.  InnerException:  {ex.InnerException.Message}";
                }
                returnOutput.ErrorMessage = myErrorMessage;
                return returnOutput;
            }
            return returnOutput;
        }

        // GET /api/Ops/qy_GetDailyReportPhysicianForms
        [HttpGet]
        public qy_GetDailyReportPhysicianFormsOutput
                    qy_GetDailyReportPhysicianForms
                    (
                    )
        {
            qy_GetDailyReportPhysicianFormsOutput
                returnOutput =
                    new qy_GetDailyReportPhysicianFormsOutput();

            string sql = $"sl.qy_GetDailyReportPhysicianForms";

            List<SqlParameter> parms = new List<SqlParameter>();

            try
            {
                returnOutput.qy_GetDailyReportPhysicianFormsOutputColumnsList =
                    MyContext
                    .qy_GetDailyReportPhysicianFormsOutputColumnsList
                    .FromSqlRaw<qy_GetDailyReportPhysicianFormsOutputColumns>
                    (
                          sql
                        , parms.ToArray()
                    )
                    .ToList();
            }
            catch (Exception ex)
            {
                returnOutput.IsOk = false;

                string myErrorMessage = ex.Message;
                if (ex.InnerException != null)
                {
                    myErrorMessage = $"{myErrorMessage}.  InnerException:  {ex.InnerException.Message}";
                }
                returnOutput.ErrorMessage = myErrorMessage;
                return returnOutput;
            }
            return returnOutput;
        }

        // GET /api/Ops/qy_GetDailyReportSsnsNotListedInAllEmployeesList
        [HttpGet]
        public qy_GetDailyReportSsnsNotListedInAllEmployeesListOutput
                    qy_GetDailyReportSsnsNotListedInAllEmployeesList
                    (
                    )
        {
            qy_GetDailyReportSsnsNotListedInAllEmployeesListOutput
                returnOutput =
                    new qy_GetDailyReportSsnsNotListedInAllEmployeesListOutput();

            string sql = $"sl.qy_GetDailyReportSsnsNotListedInAllEmployeesList";

            List<SqlParameter> parms = new List<SqlParameter>();

            try
            {
                returnOutput.qy_GetDailyReportSsnsNotListedInAllEmployeesListOutputColumnsList =
                    MyContext
                    .qy_GetDailyReportSsnsNotListedInAllEmployeesListOutputColumnsList
                    .FromSqlRaw<qy_GetDailyReportSsnsNotListedInAllEmployeesListOutputColumns>
                    (
                          sql
                        , parms.ToArray()
                    )
                    .ToList();
            }
            catch (Exception ex)
            {
                returnOutput.IsOk = false;

                string myErrorMessage = ex.Message;
                if (ex.InnerException != null)
                {
                    myErrorMessage = $"{myErrorMessage}.  InnerException:  {ex.InnerException.Message}";
                }
                returnOutput.ErrorMessage = myErrorMessage;
                return returnOutput;
            }
            return returnOutput;
        }

        // GET /api/Ops/qy_GetDailyReportSsnNameDobDifferences
        [HttpGet]
        public qy_GetDailyReportSsnNameDobDifferencesOutput
                    qy_GetDailyReportSsnNameDobDifferences
                    (
                    )
        {
            qy_GetDailyReportSsnNameDobDifferencesOutput
                returnOutput =
                    new qy_GetDailyReportSsnNameDobDifferencesOutput();

            string sql = $"sl.qy_GetDailyReportSsnNameDobDifferences";

            List<SqlParameter> parms = new List<SqlParameter>();

            try
            {
                returnOutput.qy_GetDailyReportSsnNameDobDifferencesOutputColumnsList =
                    MyContext
                    .qy_GetDailyReportSsnNameDobDifferencesOutputColumnsList
                    .FromSqlRaw<qy_GetDailyReportSsnNameDobDifferencesOutputColumns>
                    (
                          sql
                        , parms.ToArray()
                    )
                    .ToList();
            }
            catch (Exception ex)
            {
                returnOutput.IsOk = false;

                string myErrorMessage = ex.Message;
                if (ex.InnerException != null)
                {
                    myErrorMessage = $"{myErrorMessage}.  InnerException:  {ex.InnerException.Message}";
                }
                returnOutput.ErrorMessage = myErrorMessage;
                return returnOutput;
            }
            return returnOutput;
        }

        // GET /api/Ops/qy_GetDailyReportConfig
        public qy_GetDailyReportConfigOutput
                    qy_GetDailyReportConfig()
        {
            qy_GetDailyReportConfigOutput
                returnOutput =
                    new qy_GetDailyReportConfigOutput();

            string sql = $"sl.qy_GetDailyReportConfig";

            List<SqlParameter> parms = new List<SqlParameter>();

            try
            {
                returnOutput.qy_GetDailyReportConfigOutputColumnsList =
                    MyContext
                    .qy_GetDailyReportConfigOutputColumnsList
                    .FromSqlRaw<qy_GetDailyReportConfigOutputColumns>
                    (
                          sql
                        , parms.ToArray()
                    )
                    .ToList();
            }
            catch (Exception ex)
            {
                returnOutput.IsOk = false;

                string myErrorMessage = ex.Message;
                if (ex.InnerException != null)
                {
                    myErrorMessage = $"{myErrorMessage}.  InnerException:  {ex.InnerException.Message}";
                }
                returnOutput.ErrorMessage = myErrorMessage;
                return returnOutput;
            }
            return returnOutput;
        }
    }
}
