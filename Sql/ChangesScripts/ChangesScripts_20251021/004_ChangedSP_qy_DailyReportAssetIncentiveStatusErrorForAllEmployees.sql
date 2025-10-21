-- SQL Server Instance:  smg-sql01

USE [Utilities];

IF (@@SERVERNAME <> 'smg-sql01')
BEGIN
PRINT 'Invalid SQL Server Connection'
RETURN
END
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('sl.qy_DailyReportAssetIncentiveStatusErrorForAllEmployees'))
   DROP PROC [sl].[qy_DailyReportAssetIncentiveStatusErrorForAllEmployees]
GO
CREATE PROCEDURE [sl].[qy_DailyReportAssetIncentiveStatusErrorForAllEmployees]

/* -----------------------------------------------------------------------------------------------------------
   Procedure Name  :  sl.qy_DailyReportAssetIncentiveStatusErrorForAllEmployees
   Business Analyis:
   Project/Process :   
   Description     :  Get the DailyReportAssetIncentiveStatusError table for all Employees.
	  
   Author          :  Philip Morrison 
   Create Date     :  10/18/2025

   ***********************************************************************************************************
   **         Change History                                                                                **
   ***********************************************************************************************************

   Date       Version    Author             Description
   --------   --------   -----------        ------------
   10/18/2025 1.01.001   Philip Morrison    Created

*/ -----------------------------------------------------------------------------------------------------------                                   

AS
BEGIN

-- This Instance Declarations

-- Template Declarations
DECLARE @Application            varchar(128) = 'Summit Life' 
DECLARE @Version                varchar(25)  = '1.01.001'

DECLARE @ProcessID              int          = 212
DECLARE @Process                varchar(128) = 'DailyReports'

DECLARE @BatchOutID             int
DECLARE @BatchDescription       varchar(1000) = @@ServerName + '  - ' + @Version
DECLARE @BatchDetailDescription varchar(1000)
DECLARE @BatchMessage           varchar(MAX)
DECLARE @User                   varchar(128) = SUSER_NAME()

DECLARE @AnticipatedRecordCount int 
DECLARE @ActualRecordCount      int


SET NOCOUNT ON

BEGIN TRY

--  Initialize Batch
    EXEC Admin.Utilities.logs.di_Batch @BatchOutID OUTPUT,  NULL, 'BatchStart', @BatchDescription, @ProcessID, @Process
    
----------------------------------------------------------------------------------------------------------------------------------------------------

    SET @BatchDetailDescription = '010/010:  Get the Asset Incentive Status Points Error Report for All Employees'
    EXEC Admin.Utilities.logs.di_Batch @BatchOutID OUTPUT,  @BatchOutID, 'DetailStart', @BatchDetailDescription
	
	  SELECT @AnticipatedRecordCount = COUNT(*)
	                                   FROM [DS_SummitLife].[dbo].[DailyReportAssetIncentiveStatusError];
	  
      -- Truncate DailyReportAssetIncentiveStatusError
      SELECT
           [EmployeeNumber]
           ,[EmployeeLastName]
           ,[EmployeeFirstName]
           ,CONVERT([nvarchar] (10), [EmployeeDob], 101) AS [EmployeeDob]
           ,[ErrorMessage]
           ,CONVERT([nvarchar] (50), [DataGatheredOnTimestamp], 121) AS [DataGatheredOnTimestamp]
      FROM [DS_SummitLife].[dbo].[DailyReportAssetIncentiveStatusError]
      WHERE [ErrorMessage] <> 'Employee Number not found on either the "Sent to Asset" or the "Physicians Form" table.';
	
    SET @ActualRecordCount = @@ROWCOUNT
    EXEC Admin.Utilities.logs.di_Batch @BatchOutID OUTPUT,  @BatchOutID, 'DetailEnd', NULL, NULL, NULL, @AnticipatedRecordCount, @ActualRecordCount
----------------------------------------------------------------------------------------------------------------------------------------------------

--  Close batch
    EXEC Admin.Utilities.logs.di_batch @BatchOutID OUTPUT, @BatchOutID, 'BatchEnd'
    
END TRY

BEGIN CATCH
DECLARE @Err              int
     ,  @ErrorMessage     varchar(Max)
     ,  @ErrorLine        varchar(128)
     ,  @Workstation      varchar(128) = @Application
     ,  @Procedure        VARCHAR(500)

    IF ERROR_NUMBER() IS NULL 
      SET @Err =0;
    ELSE
      SET @Err = ERROR_NUMBER();

    SET @ErrorMessage = ERROR_MESSAGE()
    SET @ErrorLine    = 'SP Line Number: ' + CAST(ERROR_LINE() as varchar(10)) 
    
	SET @Workstation  = HOST_NAME()
	
    SET @Procedure    = @@SERVERNAME + '.' + DB_NAME() + '.' + OBJECT_SCHEMA_NAME(@@ProcID) + '.' + OBJECT_NAME(@@ProcID) + ' - ' + @ErrorLine + ' - ' + LEFT(@BatchDetailDescription, 7)
    EXEC Admin.Utilities.administration.di_ErrorLog  @Application ,@Process, @Version ,0, @ErrorMessage, @Procedure,  @User , @Workstation

    SET @BatchMessage = 'Process Failed:  ' +  @ErrorMessage
    EXEC Admin.Utilities.logs.di_batch @BatchOutID OUTPUT, @BatchOutID, 'BatchEnd', @BatchMessage
	
    RAISERROR(@ErrorMessage, 16,1)

END CATCH


END