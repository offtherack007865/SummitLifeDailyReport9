-- SQL Server Instance:  smg-sql01

USE [Utilities];

IF (@@SERVERNAME <> 'smg-sql01')
BEGIN
PRINT 'Invalid SQL Server Connection'
RETURN
END

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('sl.di_DailyReportAssetIncentiveStatusErrorForOneEmployee'))
   DROP PROC [sl].[di_DailyReportAssetIncentiveStatusErrorForOneEmployee]
GO
CREATE PROCEDURE [sl].[di_DailyReportAssetIncentiveStatusErrorForOneEmployee]
(
  @inputEmployeeNumber [nvarchar] (10)
  ,@inputEmployeeLastName [nvarchar] (50)
  ,@inputEmployeeFirstName [nvarchar] (50)
  ,@inputEmployeeDob [datetime]
)

/* -----------------------------------------------------------------------------------------------------------
   Procedure Name  :  sl.di_DailyReportAssetIncentiveStatusErrorForOneEmployee
   Business Analyis:
   Project/Process :   
   Description     :  Populate the DailyReportAssetIncentiveStatusError table for one Employee.
	  
   Author          :  Philip Morrison 
   Create Date     :  08/25/2025

   ***********************************************************************************************************
   **         Change History                                                                                **
   ***********************************************************************************************************

   Date       Version    Author             Description
   --------   --------   -----------        ------------
   08/25/2025 1.01.001   Philip Morrison    Created

*/ -----------------------------------------------------------------------------------------------------------                                   

AS
BEGIN

-- This Instance Declarations
DECLARE @currentTimestamp [datetime] = null;
SET @currentTimestamp = getdate();

DECLARE @CurrentYear           [int] = 0;
SET @CurrentYear = DATEPART(year, getdate());

DECLARE @CharCtr [int] = 0;
DECLARE @inputEmployeeNumberStrippedOfLeadingZeroes [nvarchar] (10) = ''
SET @inputEmployeeNumberStrippedOfLeadingZeroes = @inputEmployeeNumber;
SET @CharCtr = 1;
WHILE (@CharCtr <= LEN(@inputEmployeeNumber)) BEGIN
  IF (SUBSTRING(@inputEmployeeNumber, @CharCtr, 1) <> '0') BEGIN
     SET @inputEmployeeNumberStrippedOfLeadingZeroes = SUBSTRING(@inputEmployeeNumber, @CharCtr, LEN(@inputEmployeeNumber) - @CharCtr + 1);
     BREAK;
  END
  SET @CharCtr = @CharCtr + 1;
END

DECLARE @ExistsEmployeeID [nvarchar] (30) = '';
DECLARE @BaseLevelChecksAllPassed [bit] = 1;
DECLARE @NonCategoryGroupLevelChecksPassed [bit] = 1;
DECLARE @CategoryGroupLevelChecksPassed [bit] = 1;

DECLARE @HealthAssessmentPoints [int] = 0;
DECLARE @BiometricSubmittedPoints [int] = 0;
DECLARE @BloodPressurePoints [int] = 0;
DECLARE @WaistCircumferencePoints [int] = 0;
DECLARE @CholesterolRatioPoints [int] = 0;
DECLARE @TriglyceridePoints [int] = 0;
DECLARE @Hba1cPoints [int] = 0;
DECLARE @TobaccoFreePoints [int] = 0;
DECLARE @PreventativePoints [int] = 0;
DECLARE @CoursePoints [int] = 0;
DECLARE @CoachingCallPoints [int] = 0;
DECLARE @PhysicalActivityTrackingPoints [int] = 0;
DECLARE @AssetHealthChallengePoints [int] = 0;
DECLARE @SummitChallengePoints [int] = 0;
DECLARE @VirtaHealthPoints [int] = 0;
DECLARE @EventsPoints [int] = 0;
DECLARE @HingePoints [int] = 0;
DECLARE @HeadspacePoints [int] = 0;
DECLARE @SupportLincEapPoints [int] = 0;
DECLARE @HealthyLifestylePoints [int] = 0;
DECLARE @TotalHealthyTargetPoints [int] = 0;
DECLARE @PointTotal [int] = 0;
DECLARE @HealthyMeasuresAndLifestyleTargetsCategoryPoints  [int] = 0;
DECLARE @PortalActivitiesCategoryPoints [int] = 0;
DECLARE @WellnessChallengesCategoryPoints [int] = 0;
DECLARE @SummitHealthPlanEnrolleeOfferingsCategoryPoints [int] = 0;
DECLARE @EmotionalHealthActivitiesCategoryPoints [int] = 0;
DECLARE @SumOfHealthyLifestylePoints [int] = 0; 
DECLARE @SumOfAllCategoriesPoints [int] = 0; 

DECLARE @Gender [nvarchar] (30) = '';
DECLARE @SystolicBloodPressure [decimal] (10,4) = 0
DECLARE @DiastolicBloodPressure [decimal] (10,4) = 0
DECLARE @WaistInches [decimal] (10,4) = 0
DECLARE @TcOverHdl [decimal] (10,4) = 0
DECLARE @Triglycerides [decimal] (10,4) = 0
DECLARE @HemoglobinA1C [decimal] (10,4) = 0
DECLARE @BloodPressurePointsShouldHaveBeenEarned [bit] = 0;
DECLARE @WaistCircumferencePointsShouldHaveBeenEarned [bit] = 0;
DECLARE @CholesterolRatioPointsShouldHaveBeenEarned [bit] = 0;
DECLARE @TriglyceridePointsShouldHaveBeenEarned [bit] = 0;
DECLARE @A1cPointsShouldHaveBeenEarned [bit] = 0;



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

    SET @BatchDetailDescription = '010/340:  Get base-level field values from AssetIncentivePointsStatus'
    EXEC Admin.Utilities.logs.di_Batch @BatchOutID OUTPUT,  @BatchOutID, 'DetailStart', @BatchDetailDescription
	
    
	  SELECT @AnticipatedRecordCount = 1;
	  
      -- Get base-level field values from AssetIncentivePointsStatus
      SELECT 
         @HealthAssessmentPoints = [HealthAssessmentPoints]
         ,@BiometricSubmittedPoints = [BiometricSubmittedPoints]
         ,@BloodPressurePoints = [BloodPressurePoints]
         ,@WaistCircumferencePoints = [WaistCircumferencePoints]
         ,@CholesterolRatioPoints = [CholesterolRatioPoints]
         ,@TriglyceridePoints = [TriglyceridePoints]
         ,@Hba1cPoints = [Hba1cPoints]
         ,@TobaccoFreePoints = [TobaccoFreePoints]
         ,@PreventativePoints = [PreventativePoints]
         ,@CoursePoints = [CoursePoints]
         ,@CoachingCallPoints = [CoachingCallPoints]
         ,@PhysicalActivityTrackingPoints = [PhysicalActivityTrackingPoints]
         ,@AssetHealthChallengePoints = [AssetHealthChallengePoints]
         ,@SummitChallengePoints = [SummitChallengePoints]
         ,@VirtaHealthPoints = [VirtaHealthPoints]
         ,@EventsPoints = [EventsPoints]
         ,@HingePoints = [HingePoints]
         ,@HeadspacePoints = [HeadspacePoints]
         ,@SupportLincEapPoints = [SupportLincEapPoints]
         ,@HealthyLifestylePoints = [HealthyLifestylePoints]
         ,@TotalHealthyTargetPoints = [TotalHealthyTargetPoints]
         ,@PointTotal = [PointTotal]
      FROM [DS_SummitLife].[dbo].[AssetIncentivePointsStatus]
      WHERE [EmployeeID] = @inputEmployeeNumberStrippedOfLeadingZeroes;
      
    SET @ActualRecordCount = @@ROWCOUNT
    EXEC Admin.Utilities.logs.di_Batch @BatchOutID OUTPUT,  @BatchOutID, 'DetailEnd', NULL, NULL, NULL, @AnticipatedRecordCount, @ActualRecordCount
----------------------------------------------------------------------------------------------------------------------------------------------------
    SET @BatchDetailDescription = '020/340:  Base-Level Check:  HealthAssessmentPoints - 0 or 100'
    EXEC Admin.Utilities.logs.di_Batch @BatchOutID OUTPUT,  @BatchOutID, 'DetailStart', @BatchDetailDescription
	
    -- Base-Level Check:  HealthAssessmentPoints - 0 or 100
    IF (@HealthAssessmentPoints <> 0 AND @HealthAssessmentPoints <> 100) BEGIN
    
      SELECT @AnticipatedRecordCount = 1;
      
      INSERT INTO [DS_SummitLife].[dbo].[DailyReportAssetIncentiveStatusError]
      (
        [EmployeeNumber]
        ,[EmployeeLastName]
        ,[EmployeeFirstName]
        ,[EmployeeDob]
        ,[ErrorMessage]
        ,[DataGatheredOnTimestamp]
      )
      VALUES
      (
        @inputEmployeeNumber
        ,@inputEmployeeLastName
        ,@inputEmployeeFirstName
        ,@inputEmployeeDob
        ,'HealthAssessmentPoints has an invalid value, ' + CONVERT([nvarchar] (10), @HealthAssessmentPoints) + '.  HealthAssessmentPoints must be either 0 or 100.'
        ,CONVERT([nvarchar] (50), @currentTimestamp, 121)
      );
      
      -- BaseLevel Check Failure
      SET @BaseLevelChecksAllPassed = 0;
      
    END
	
    SET @ActualRecordCount = @@ROWCOUNT
    EXEC Admin.Utilities.logs.di_Batch @BatchOutID OUTPUT,  @BatchOutID, 'DetailEnd', NULL, NULL, NULL, @AnticipatedRecordCount, @ActualRecordCount
----------------------------------------------------------------------------------------------------------------------------------------------------
    SET @BatchDetailDescription = '030/340:  Base-Level Check:  BiometricSubmittedPoints - 0 or 100'
    EXEC Admin.Utilities.logs.di_Batch @BatchOutID OUTPUT,  @BatchOutID, 'DetailStart', @BatchDetailDescription
	
    -- Base-Level Check:  BiometricSubmittedPoints - 0 or 100
    IF (@BiometricSubmittedPoints <> 0 AND @BiometricSubmittedPoints <> 100) BEGIN
    
      SELECT @AnticipatedRecordCount = 1;
      
      INSERT INTO [DS_SummitLife].[dbo].[DailyReportAssetIncentiveStatusError]
      (
        [EmployeeNumber]
        ,[EmployeeLastName]
        ,[EmployeeFirstName]
        ,[EmployeeDob]
        ,[ErrorMessage]
        ,[DataGatheredOnTimestamp]
      )
      VALUES
      (
        @inputEmployeeNumber
        ,@inputEmployeeLastName
        ,@inputEmployeeFirstName
        ,@inputEmployeeDob
        ,'BiometricSubmittedPoints has an invalid value, ' + CONVERT([nvarchar] (10), @BiometricSubmittedPoints) + '.  BiometricSubmittedPoints must be either 0 or 100.'
        ,CONVERT([nvarchar] (50), @currentTimestamp, 121)
      );

      -- BaseLevel Check Failure
      SET @BaseLevelChecksAllPassed = 0;
      
    END
	
    SET @ActualRecordCount = @@ROWCOUNT
    EXEC Admin.Utilities.logs.di_Batch @BatchOutID OUTPUT,  @BatchOutID, 'DetailEnd', NULL, NULL, NULL, @AnticipatedRecordCount, @ActualRecordCount
----------------------------------------------------------------------------------------------------------------------------------------------------
    SET @BatchDetailDescription = '040/340:  Base-Level Check:  BloodPressurePoints - 0 or 25'
    EXEC Admin.Utilities.logs.di_Batch @BatchOutID OUTPUT,  @BatchOutID, 'DetailStart', @BatchDetailDescription
	
    -- Base-Level Check:  BloodPressurePoints - 0 or 25
    IF (@BloodPressurePoints <> 0 AND @BloodPressurePoints <> 25) BEGIN
    
      SELECT @AnticipatedRecordCount = 1;
      
      INSERT INTO [DS_SummitLife].[dbo].[DailyReportAssetIncentiveStatusError]
      (
        [EmployeeNumber]
        ,[EmployeeLastName]
        ,[EmployeeFirstName]
        ,[EmployeeDob]
        ,[ErrorMessage]
        ,[DataGatheredOnTimestamp]
      )
      VALUES
      (
        @inputEmployeeNumber
        ,@inputEmployeeLastName
        ,@inputEmployeeFirstName
        ,@inputEmployeeDob
        ,'BloodPressurePoints has an invalid value, ' + CONVERT([nvarchar] (10), @BloodPressurePoints) + '.  BloodPressurePoints must be either 0 or 25.'
        ,CONVERT([nvarchar] (50), @currentTimestamp, 121)
      );

      -- BaseLevel Check Failure
      SET @BaseLevelChecksAllPassed = 0;
      
    END
	
    SET @ActualRecordCount = @@ROWCOUNT
    EXEC Admin.Utilities.logs.di_Batch @BatchOutID OUTPUT,  @BatchOutID, 'DetailEnd', NULL, NULL, NULL, @AnticipatedRecordCount, @ActualRecordCount
----------------------------------------------------------------------------------------------------------------------------------------------------
    SET @BatchDetailDescription = '050/340:  Base-Level Check:  WaistCircumferencePoints - 0 or 25'
    EXEC Admin.Utilities.logs.di_Batch @BatchOutID OUTPUT,  @BatchOutID, 'DetailStart', @BatchDetailDescription
	
    -- Base-Level Check:  WaistCircumferencePoints - 0 or 25
    IF (@WaistCircumferencePoints <> 0 AND @WaistCircumferencePoints <> 25) BEGIN
    
      SELECT @AnticipatedRecordCount = 1;
      
      INSERT INTO [DS_SummitLife].[dbo].[DailyReportAssetIncentiveStatusError]
      (
        [EmployeeNumber]
        ,[EmployeeLastName]
        ,[EmployeeFirstName]
        ,[EmployeeDob]
        ,[ErrorMessage]
        ,[DataGatheredOnTimestamp]
      )
      VALUES
      (
        @inputEmployeeNumber
        ,@inputEmployeeLastName
        ,@inputEmployeeFirstName
        ,@inputEmployeeDob
        ,'WaistCircumferencePoints has an invalid value, ' + CONVERT([nvarchar] (10), @WaistCircumferencePoints) + '.  WaistCircumferencePoints must be either 0 or 25.'
        ,CONVERT([nvarchar] (50), @currentTimestamp, 121)
      );

      -- BaseLevel Check Failure
      SET @BaseLevelChecksAllPassed = 0;
      
    END
	
    SET @ActualRecordCount = @@ROWCOUNT
    EXEC Admin.Utilities.logs.di_Batch @BatchOutID OUTPUT,  @BatchOutID, 'DetailEnd', NULL, NULL, NULL, @AnticipatedRecordCount, @ActualRecordCount
----------------------------------------------------------------------------------------------------------------------------------------------------
    SET @BatchDetailDescription = '060/340:  Base-Level Check:  CholesterolRatioPoints - 0 or 25'
    EXEC Admin.Utilities.logs.di_Batch @BatchOutID OUTPUT,  @BatchOutID, 'DetailStart', @BatchDetailDescription
	
    -- Base-Level Check:  CholesterolRatioPoints - 0 or 25
    IF (@CholesterolRatioPoints <> 0 AND @CholesterolRatioPoints <> 25) BEGIN
    
      SELECT @AnticipatedRecordCount = 1;
      
      INSERT INTO [DS_SummitLife].[dbo].[DailyReportAssetIncentiveStatusError]
      (
        [EmployeeNumber]
        ,[EmployeeLastName]
        ,[EmployeeFirstName]
        ,[EmployeeDob]
        ,[ErrorMessage]
        ,[DataGatheredOnTimestamp]
      )
      VALUES
      (
        @inputEmployeeNumber
        ,@inputEmployeeLastName
        ,@inputEmployeeFirstName
        ,@inputEmployeeDob
        ,'CholesterolRatioPoints has an invalid value, ' + CONVERT([nvarchar] (10), @CholesterolRatioPoints) + '.  CholesterolRatioPoints must be either 0 or 25.'
        ,CONVERT([nvarchar] (50), @currentTimestamp, 121)
      );

      -- BaseLevel Check Failure
      SET @BaseLevelChecksAllPassed = 0;
      
    END
	
    SET @ActualRecordCount = @@ROWCOUNT
    EXEC Admin.Utilities.logs.di_Batch @BatchOutID OUTPUT,  @BatchOutID, 'DetailEnd', NULL, NULL, NULL, @AnticipatedRecordCount, @ActualRecordCount
----------------------------------------------------------------------------------------------------------------------------------------------------
    SET @BatchDetailDescription = '070/340:  Base-Level Check:  TriglyceridePoints - 0 or 25'
    EXEC Admin.Utilities.logs.di_Batch @BatchOutID OUTPUT,  @BatchOutID, 'DetailStart', @BatchDetailDescription
	
    -- Base-Level Check:  TriglyceridePoints - 0 or 25
    IF (@TriglyceridePoints <> 0 AND @TriglyceridePoints <> 25) BEGIN
    
      SELECT @AnticipatedRecordCount = 1;
      
      INSERT INTO [DS_SummitLife].[dbo].[DailyReportAssetIncentiveStatusError]
      (
        [EmployeeNumber]
        ,[EmployeeLastName]
        ,[EmployeeFirstName]
        ,[EmployeeDob]
        ,[ErrorMessage]
        ,[DataGatheredOnTimestamp]
      )
      VALUES
      (
        @inputEmployeeNumber
        ,@inputEmployeeLastName
        ,@inputEmployeeFirstName
        ,@inputEmployeeDob
        ,'TriglyceridePoints has an invalid value, ' + CONVERT([nvarchar] (10), @TriglyceridePoints) + '.  TriglyceridePoints must be either 0 or 25.'
        ,CONVERT([nvarchar] (50), @currentTimestamp, 121)
      );

      -- BaseLevel Check Failure
      SET @BaseLevelChecksAllPassed = 0;
      
    END
	
    SET @ActualRecordCount = @@ROWCOUNT
    EXEC Admin.Utilities.logs.di_Batch @BatchOutID OUTPUT,  @BatchOutID, 'DetailEnd', NULL, NULL, NULL, @AnticipatedRecordCount, @ActualRecordCount
----------------------------------------------------------------------------------------------------------------------------------------------------
    SET @BatchDetailDescription = '080/340:  Base-Level Check: Hba1cPoints - 0 or 25'
    EXEC Admin.Utilities.logs.di_Batch @BatchOutID OUTPUT,  @BatchOutID, 'DetailStart', @BatchDetailDescription
	
    -- Base-Level Check:  Hba1cPoints - 0 or 25
    IF (@Hba1cPoints <> 0 AND @Hba1cPoints <> 25) BEGIN
    
      SELECT @AnticipatedRecordCount = 1;
      
      INSERT INTO [DS_SummitLife].[dbo].[DailyReportAssetIncentiveStatusError]
      (
        [EmployeeNumber]
        ,[EmployeeLastName]
        ,[EmployeeFirstName]
        ,[EmployeeDob]
        ,[ErrorMessage]
        ,[DataGatheredOnTimestamp]
      )
      VALUES
      (
        @inputEmployeeNumber
        ,@inputEmployeeLastName
        ,@inputEmployeeFirstName
        ,@inputEmployeeDob
        ,'Hba1cPoints has an invalid value, ' + CONVERT([nvarchar] (10), @Hba1cPoints) + '.  Hba1cPoints must be either 0 or 25.'
        ,CONVERT([nvarchar] (50), @currentTimestamp, 121)
      );
      
      -- BaseLevel Check Failure
      SET @BaseLevelChecksAllPassed = 0;
      
    END
	
    SET @ActualRecordCount = @@ROWCOUNT
    EXEC Admin.Utilities.logs.di_Batch @BatchOutID OUTPUT,  @BatchOutID, 'DetailEnd', NULL, NULL, NULL, @AnticipatedRecordCount, @ActualRecordCount
----------------------------------------------------------------------------------------------------------------------------------------------------
    SET @BatchDetailDescription = '090/340:  Base-Level Check: TobaccoFreePoints - 0 or 25'
    EXEC Admin.Utilities.logs.di_Batch @BatchOutID OUTPUT,  @BatchOutID, 'DetailStart', @BatchDetailDescription
	
    -- Base-Level Check: TobaccoFreePoints - 0 or 25
    IF (@TobaccoFreePoints <> 0 AND @TobaccoFreePoints <> 25) BEGIN
    
      SELECT @AnticipatedRecordCount = 1;
      
      INSERT INTO [DS_SummitLife].[dbo].[DailyReportAssetIncentiveStatusError]
      (
        [EmployeeNumber]
        ,[EmployeeLastName]
        ,[EmployeeFirstName]
        ,[EmployeeDob]
        ,[ErrorMessage]
        ,[DataGatheredOnTimestamp]
      )
      VALUES
      (
        @inputEmployeeNumber
        ,@inputEmployeeLastName
        ,@inputEmployeeFirstName
        ,@inputEmployeeDob
        ,'TobaccoFreePoints has an invalid value, ' + CONVERT([nvarchar] (10), @TobaccoFreePoints) + '.  TobaccoFreePoints must be either 0 or 25.'
        ,CONVERT([nvarchar] (50), @currentTimestamp, 121)
      );

      -- BaseLevel Check Failure
      SET @BaseLevelChecksAllPassed = 0;
      
    END
	
    SET @ActualRecordCount = @@ROWCOUNT
    EXEC Admin.Utilities.logs.di_Batch @BatchOutID OUTPUT,  @BatchOutID, 'DetailEnd', NULL, NULL, NULL, @AnticipatedRecordCount, @ActualRecordCount
----------------------------------------------------------------------------------------------------------------------------------------------------
    SET @BatchDetailDescription = '100/340:  Base-Level Check PreventativePoints - multiple of 25, max of 150'
    EXEC Admin.Utilities.logs.di_Batch @BatchOutID OUTPUT,  @BatchOutID, 'DetailStart', @BatchDetailDescription
	
    -- Base-Level Check PreventativePoints - multiple of 25, max of 150
    IF (@PreventativePoints > 150) BEGIN
    
         SELECT @AnticipatedRecordCount = 1;
      
         INSERT INTO [DS_SummitLife].[dbo].[DailyReportAssetIncentiveStatusError]
         (
           [EmployeeNumber]
           ,[EmployeeLastName]
           ,[EmployeeFirstName]
           ,[EmployeeDob]
           ,[ErrorMessage]
           ,[DataGatheredOnTimestamp]
         )
         VALUES
         (
            @inputEmployeeNumber
            ,@inputEmployeeLastName
            ,@inputEmployeeFirstName
            ,@inputEmployeeDob
            ,'PreventativePoints value, ' + CONVERT([nvarchar] (10), @PreventativePoints) + ',  exceeds the maximum of 150.'
            ,CONVERT([nvarchar] (50), @currentTimestamp, 121)
         );


      -- BaseLevel Check Failure
      SET @BaseLevelChecksAllPassed = 0;

    END
    ELSE BEGIN
       IF ((@PreventativePoints % 25) <> 0) BEGIN
    
         SELECT @AnticipatedRecordCount = 1;
      
         INSERT INTO [DS_SummitLife].[dbo].[DailyReportAssetIncentiveStatusError]
         (
           [EmployeeNumber]
           ,[EmployeeLastName]
           ,[EmployeeFirstName]
           ,[EmployeeDob]
           ,[ErrorMessage]
           ,[DataGatheredOnTimestamp]
         )
         VALUES
         (
            @inputEmployeeNumber
            ,@inputEmployeeLastName
            ,@inputEmployeeFirstName
            ,@inputEmployeeDob
            ,'PreventativePoints has an invalid value, ' + CONVERT([nvarchar] (10), @PreventativePoints) + '.  PreventativePoints must be a multiple of 25.'
            ,CONVERT([nvarchar] (50), @currentTimestamp, 121)
         );
      

         -- BaseLevel Check Failure
         SET @BaseLevelChecksAllPassed = 0;
      
       END
	END
    SET @ActualRecordCount = @@ROWCOUNT
    EXEC Admin.Utilities.logs.di_Batch @BatchOutID OUTPUT,  @BatchOutID, 'DetailEnd', NULL, NULL, NULL, @AnticipatedRecordCount, @ActualRecordCount
----------------------------------------------------------------------------------------------------------------------------------------------------
    SET @BatchDetailDescription = '110/340:  Base-Level Check CoursePoints - multiple of 10, max of 150'
    EXEC Admin.Utilities.logs.di_Batch @BatchOutID OUTPUT,  @BatchOutID, 'DetailStart', @BatchDetailDescription
	
    -- Base-Level Check CoursePoints - multiple of 10, max of 150
    IF (@CoursePoints > 150) BEGIN
       SELECT @AnticipatedRecordCount = 1;
      
       INSERT INTO [DS_SummitLife].[dbo].[DailyReportAssetIncentiveStatusError]
       (
           [EmployeeNumber]
           ,[EmployeeLastName]
           ,[EmployeeFirstName]
           ,[EmployeeDob]
           ,[ErrorMessage]
           ,[DataGatheredOnTimestamp]
       )
       VALUES
       (
          @inputEmployeeNumber
         ,@inputEmployeeLastName
         ,@inputEmployeeFirstName
         ,@inputEmployeeDob
         ,'CoursePoints value, ' + CONVERT([nvarchar] (10), @CoursePoints) + ',  exceeds the maximum of 150.'
         ,CONVERT([nvarchar] (50), @currentTimestamp, 121)
       );

       -- BaseLevel Check Failure
       SET @BaseLevelChecksAllPassed = 0;
      
    END
    ELSE BEGIN
       IF ((@CoursePoints % 10) <> 0) BEGIN
    
         SELECT @AnticipatedRecordCount = 1;
      
         INSERT INTO [DS_SummitLife].[dbo].[DailyReportAssetIncentiveStatusError]
         (
           [EmployeeNumber]
           ,[EmployeeLastName]
           ,[EmployeeFirstName]
           ,[EmployeeDob]
           ,[ErrorMessage]
           ,[DataGatheredOnTimestamp]
         )
         VALUES
         (
            @inputEmployeeNumber
           ,@inputEmployeeLastName
           ,@inputEmployeeFirstName
           ,@inputEmployeeDob
           ,'CoursePoints has an invalid value, ' + CONVERT([nvarchar] (10), @CoursePoints) + '.  CoursePoints must be a multiple of 10.'
           ,CONVERT([nvarchar] (50), @currentTimestamp, 121)
         );

         -- BaseLevel Check Failure
         SET @BaseLevelChecksAllPassed = 0;
       END
	END
    
    
    SET @ActualRecordCount = @@ROWCOUNT
    EXEC Admin.Utilities.logs.di_Batch @BatchOutID OUTPUT,  @BatchOutID, 'DetailEnd', NULL, NULL, NULL, @AnticipatedRecordCount, @ActualRecordCount
----------------------------------------------------------------------------------------------------------------------------------------------------
    SET @BatchDetailDescription = '120/340:  Base-Level CoachingCallPoints - 0 or 50 '
    EXEC Admin.Utilities.logs.di_Batch @BatchOutID OUTPUT,  @BatchOutID, 'DetailStart', @BatchDetailDescription
	
    -- Base-Level Check CoachingCallPoints - 0 or 50 
    IF (@CoachingCallPoints <> 0 AND @CoachingCallPoints <> 50) BEGIN
        SELECT @AnticipatedRecordCount = 1;
      
         INSERT INTO [DS_SummitLife].[dbo].[DailyReportAssetIncentiveStatusError]
         (
           [EmployeeNumber]
           ,[EmployeeLastName]
           ,[EmployeeFirstName]
           ,[EmployeeDob]
           ,[ErrorMessage]
           ,[DataGatheredOnTimestamp]
         )
         VALUES
         (
            @inputEmployeeNumber
            ,@inputEmployeeLastName
            ,@inputEmployeeFirstName
            ,@inputEmployeeDob
            ,'CoachingCallPoints value, ' + CONVERT([nvarchar] (10), @CoachingCallPoints) + ',  CoachingCallPoints must be 0 or 50.'
            ,CONVERT([nvarchar] (50), @currentTimestamp, 121)
         );

       -- BaseLevel Check Failure
       SET @BaseLevelChecksAllPassed = 0;

    END
    
    SET @ActualRecordCount = @@ROWCOUNT
    EXEC Admin.Utilities.logs.di_Batch @BatchOutID OUTPUT,  @BatchOutID, 'DetailEnd', NULL, NULL, NULL, @AnticipatedRecordCount, @ActualRecordCount
----------------------------------------------------------------------------------------------------------------------------------------------------
    SET @BatchDetailDescription = '130/340:  Base-Level PhysicalActivityTrackingPoints - multiple of 100, max of 200'
    EXEC Admin.Utilities.logs.di_Batch @BatchOutID OUTPUT,  @BatchOutID, 'DetailStart', @BatchDetailDescription
	
   -- Base-Level Check PhysicalActivityTrackingPoints - multiple of 100, max of 200
    IF (@PhysicalActivityTrackingPoints > 200) BEGIN
       SELECT @AnticipatedRecordCount = 1;
      
       INSERT INTO [DS_SummitLife].[dbo].[DailyReportAssetIncentiveStatusError]
       (
           [EmployeeNumber]
           ,[EmployeeLastName]
           ,[EmployeeFirstName]
           ,[EmployeeDob]
           ,[ErrorMessage]
           ,[DataGatheredOnTimestamp]
       )
       VALUES
       (
         @inputEmployeeNumber
         ,@inputEmployeeLastName
         ,@inputEmployeeFirstName
         ,@inputEmployeeDob
         ,'PhysicalActivityTrackingPoints value, ' + CONVERT([nvarchar] (10), @PhysicalActivityTrackingPoints) + ',  exceeds the maximum of 200.'
         ,CONVERT([nvarchar] (50), @currentTimestamp, 121)
       );

       -- BaseLevel Check Failure
       SET @BaseLevelChecksAllPassed = 0;

    END
    ELSE BEGIN
       IF ((@PhysicalActivityTrackingPoints % 100) <> 0) BEGIN
    
         SELECT @AnticipatedRecordCount = 1;
      
         INSERT INTO [DS_SummitLife].[dbo].[DailyReportAssetIncentiveStatusError]
         (
           [EmployeeNumber]
           ,[EmployeeLastName]
           ,[EmployeeFirstName]
           ,[EmployeeDob]
           ,[ErrorMessage]
           ,[DataGatheredOnTimestamp]
         )
         VALUES
         (
             @inputEmployeeNumber
            ,@inputEmployeeLastName
            ,@inputEmployeeFirstName
            ,@inputEmployeeDob
            ,'PhysicalActivityTrackingPoints has an invalid value, ' + CONVERT([nvarchar] (10), @PhysicalActivityTrackingPoints) + '.  PhysicalActivityTrackingPoints must be a multiple of 100.'
            ,CONVERT([nvarchar] (50), @currentTimestamp, 121)
         );

         -- BaseLevel Check Failure
         SET @BaseLevelChecksAllPassed = 0;
      
       END
	END
    
    SET @ActualRecordCount = @@ROWCOUNT
    EXEC Admin.Utilities.logs.di_Batch @BatchOutID OUTPUT,  @BatchOutID, 'DetailEnd', NULL, NULL, NULL, @AnticipatedRecordCount, @ActualRecordCount
----------------------------------------------------------------------------------------------------------------------------------------------------
    SET @BatchDetailDescription = '140/340:  Base-Level AssetHealthChallengePoints - multiple of 20, max of 100'
    EXEC Admin.Utilities.logs.di_Batch @BatchOutID OUTPUT,  @BatchOutID, 'DetailStart', @BatchDetailDescription
	
   -- Base-Level Check AssetHealthChallengePoints - multiple of 20, max of 100
    IF (@AssetHealthChallengePoints > 100) BEGIN
       SELECT @AnticipatedRecordCount = 1;
      
       INSERT INTO [DS_SummitLife].[dbo].[DailyReportAssetIncentiveStatusError]
       (
           [EmployeeNumber]
           ,[EmployeeLastName]
           ,[EmployeeFirstName]
           ,[EmployeeDob]
           ,[ErrorMessage]
           ,[DataGatheredOnTimestamp]
       )
       VALUES
       (
         @inputEmployeeNumber
         ,@inputEmployeeLastName
         ,@inputEmployeeFirstName
         ,@inputEmployeeDob
         ,'AssetHealthChallengePoints value, ' + CONVERT([nvarchar] (10), @AssetHealthChallengePoints) + ',  exceeds the maximum of 100.'
         ,CONVERT([nvarchar] (50), @currentTimestamp, 121)
       );

       -- BaseLevel Check Failure
       SET @BaseLevelChecksAllPassed = 0;

    END
    ELSE BEGIN
       IF ((@AssetHealthChallengePoints % 20) <> 0) BEGIN
    
         SELECT @AnticipatedRecordCount = 1;
      
         INSERT INTO [DS_SummitLife].[dbo].[DailyReportAssetIncentiveStatusError]
         (
           [EmployeeNumber]
           ,[EmployeeLastName]
           ,[EmployeeFirstName]
           ,[EmployeeDob]
           ,[ErrorMessage]
           ,[DataGatheredOnTimestamp]
         )
         VALUES
         (
            @inputEmployeeNumber
            ,@inputEmployeeLastName
            ,@inputEmployeeFirstName
            ,@inputEmployeeDob
            ,'AssetHealthChallengePoints has an invalid value, ' + CONVERT([nvarchar] (10), @AssetHealthChallengePoints) + '.  AssetHealthChallengePoints must be a multiple of 20.'
            ,CONVERT([nvarchar] (50), @currentTimestamp, 121)
         );

         -- BaseLevel Check Failure
         SET @BaseLevelChecksAllPassed = 0;
      
       END
	END
    
    SET @ActualRecordCount = @@ROWCOUNT
    EXEC Admin.Utilities.logs.di_Batch @BatchOutID OUTPUT,  @BatchOutID, 'DetailEnd', NULL, NULL, NULL, @AnticipatedRecordCount, @ActualRecordCount
----------------------------------------------------------------------------------------------------------------------------------------------------
    SET @BatchDetailDescription = '150/340:  Base-Level Check SummitChallengePoints - multiple of 20, max of 100'
    EXEC Admin.Utilities.logs.di_Batch @BatchOutID OUTPUT,  @BatchOutID, 'DetailStart', @BatchDetailDescription
	
   -- Base-Level Check SummitChallengePoints - multiple of 20, max of 100
    IF (@SummitChallengePoints > 100) BEGIN
       SELECT @AnticipatedRecordCount = 1;
      
       INSERT INTO [DS_SummitLife].[dbo].[DailyReportAssetIncentiveStatusError]
       (
           [EmployeeNumber]
           ,[EmployeeLastName]
           ,[EmployeeFirstName]
           ,[EmployeeDob]
           ,[ErrorMessage]
           ,[DataGatheredOnTimestamp]
       )
       VALUES
       (
          @inputEmployeeNumber
         ,@inputEmployeeLastName
         ,@inputEmployeeFirstName
         ,@inputEmployeeDob
         ,'SummitChallengePoints value, ' + CONVERT([nvarchar] (10), @SummitChallengePoints) + ',  exceeds the maximum of 100.'
         ,CONVERT([nvarchar] (50), @currentTimestamp, 121)
       );

       -- BaseLevel Check Failure
       SET @BaseLevelChecksAllPassed = 0;

    END
    ELSE BEGIN
       IF ((@SummitChallengePoints % 20) <> 0) BEGIN
    
         SELECT @AnticipatedRecordCount = 1;
      
         INSERT INTO [DS_SummitLife].[dbo].[DailyReportAssetIncentiveStatusError]
         (
           [EmployeeNumber]
           ,[EmployeeLastName]
           ,[EmployeeFirstName]
           ,[EmployeeDob]
           ,[ErrorMessage]
           ,[DataGatheredOnTimestamp]
         )
         VALUES
         (
             @inputEmployeeNumber
            ,@inputEmployeeLastName
            ,@inputEmployeeFirstName
            ,@inputEmployeeDob
            ,'SummitChallengePoints has an invalid value, ' + CONVERT([nvarchar] (10), @SummitChallengePoints) + '.  SummitChallengePoints must be a multiple of 20.'
            ,CONVERT([nvarchar] (50), @currentTimestamp, 121)
         );

         -- BaseLevel Check Failure
         SET @BaseLevelChecksAllPassed = 0;
       END
	END
    
    SET @ActualRecordCount = @@ROWCOUNT
    EXEC Admin.Utilities.logs.di_Batch @BatchOutID OUTPUT,  @BatchOutID, 'DetailEnd', NULL, NULL, NULL, @AnticipatedRecordCount, @ActualRecordCount
----------------------------------------------------------------------------------------------------------------------------------------------------
    SET @BatchDetailDescription = '160/340:  Base-Level Check VirtaHealthPoints - 0, 50, or 100'
    EXEC Admin.Utilities.logs.di_Batch @BatchOutID OUTPUT,  @BatchOutID, 'DetailStart', @BatchDetailDescription
	
    -- Base-Level Check VirtaHealthPoints - 0, 50, or 100
    IF (@VirtaHealthPoints <> 0 AND @VirtaHealthPoints <> 50 AND @VirtaHealthPoints <> 100) BEGIN
       SELECT @AnticipatedRecordCount = 1;
      
       INSERT INTO [DS_SummitLife].[dbo].[DailyReportAssetIncentiveStatusError]
       (
           [EmployeeNumber]
           ,[EmployeeLastName]
           ,[EmployeeFirstName]
           ,[EmployeeDob]
           ,[ErrorMessage]
           ,[DataGatheredOnTimestamp]
       )
       VALUES
       (
          @inputEmployeeNumber
         ,@inputEmployeeLastName
         ,@inputEmployeeFirstName
         ,@inputEmployeeDob
         ,'VirtaHealthPoints value, ' + CONVERT([nvarchar] (10), @VirtaHealthPoints) + ',  is invalid.  VirtaHealthPoints value must be 0, 50, or 100.'
         ,CONVERT([nvarchar] (50), @currentTimestamp, 121)
       );

       -- BaseLevel Check Failure
       SET @BaseLevelChecksAllPassed = 0;

    END
    
    SET @ActualRecordCount = @@ROWCOUNT
    EXEC Admin.Utilities.logs.di_Batch @BatchOutID OUTPUT,  @BatchOutID, 'DetailEnd', NULL, NULL, NULL, @AnticipatedRecordCount, @ActualRecordCount
----------------------------------------------------------------------------------------------------------------------------------------------------
    SET @BatchDetailDescription = '170/340:  Base-Level Check EventsPoints - multiple of 20, max of 100'
    EXEC Admin.Utilities.logs.di_Batch @BatchOutID OUTPUT,  @BatchOutID, 'DetailStart', @BatchDetailDescription
	
   -- Base-Level Check EventsPoints - multiple of 20, max of 100
    IF (@EventsPoints > 100) BEGIN
       SELECT @AnticipatedRecordCount = 1;
      
       INSERT INTO [DS_SummitLife].[dbo].[DailyReportAssetIncentiveStatusError]
       (
           [EmployeeNumber]
           ,[EmployeeLastName]
           ,[EmployeeFirstName]
           ,[EmployeeDob]
           ,[ErrorMessage]
           ,[DataGatheredOnTimestamp]
       )
       VALUES
       (
          @inputEmployeeNumber
         ,@inputEmployeeLastName
         ,@inputEmployeeFirstName
         ,@inputEmployeeDob
         ,'EventsPoints value, ' + CONVERT([nvarchar] (10), @EventsPoints) + ',  exceeds the maximum of 100.'
         ,CONVERT([nvarchar] (50), @currentTimestamp, 121)
       );

       -- BaseLevel Check Failure
       SET @BaseLevelChecksAllPassed = 0;

    END
    ELSE BEGIN
       IF ((@EventsPoints % 20) <> 0) BEGIN
    
         SELECT @AnticipatedRecordCount = 1;
      
         INSERT INTO [DS_SummitLife].[dbo].[DailyReportAssetIncentiveStatusError]
         (
           [EmployeeNumber]
           ,[EmployeeLastName]
           ,[EmployeeFirstName]
           ,[EmployeeDob]
           ,[ErrorMessage]
           ,[DataGatheredOnTimestamp]
         )
         VALUES
         (
            @inputEmployeeNumber
           ,@inputEmployeeLastName
           ,@inputEmployeeFirstName
           ,@inputEmployeeDob
           ,'EventsPoints has an invalid value, ' + CONVERT([nvarchar] (10), @EventsPoints) + '.  EventsPoints must be a multiple of 20.'
           ,CONVERT([nvarchar] (50), @currentTimestamp, 121)
         );

         -- BaseLevel Check Failure
         SET @BaseLevelChecksAllPassed = 0;
      
       END
	END
    
    SET @ActualRecordCount = @@ROWCOUNT
    EXEC Admin.Utilities.logs.di_Batch @BatchOutID OUTPUT,  @BatchOutID, 'DetailEnd', NULL, NULL, NULL, @AnticipatedRecordCount, @ActualRecordCount
----------------------------------------------------------------------------------------------------------------------------------------------------
    SET @BatchDetailDescription = '180/340:  Base-Level Check HingePoints - 0, 5, 15, 20, 25, or 40'
    EXEC Admin.Utilities.logs.di_Batch @BatchOutID OUTPUT,  @BatchOutID, 'DetailStart', @BatchDetailDescription
	
    -- Base-Level Check HingePoints - 0, 5, 15, 20, 25, or 40
    IF (@HingePoints <> 0 AND @HingePoints <> 5 AND @HingePoints <> 15 AND @HingePoints <> 20 AND @HingePoints <> 25 AND @HingePoints <> 40) BEGIN
       SELECT @AnticipatedRecordCount = 1;
      
       INSERT INTO [DS_SummitLife].[dbo].[DailyReportAssetIncentiveStatusError]
       (
           [EmployeeNumber]
           ,[EmployeeLastName]
           ,[EmployeeFirstName]
           ,[EmployeeDob]
           ,[ErrorMessage]
           ,[DataGatheredOnTimestamp]
       )
       VALUES
       (
          @inputEmployeeNumber
         ,@inputEmployeeLastName
         ,@inputEmployeeFirstName
         ,@inputEmployeeDob
         ,'HingePoints value, ' + CONVERT([nvarchar] (10), @HingePoints) + ',  is invalid.  HingePoints value must be  0, 5, 15, 20, 25, or 40.'
         ,CONVERT([nvarchar] (50), @currentTimestamp, 121)
       );

       -- BaseLevel Check Failure
       SET @BaseLevelChecksAllPassed = 0;

    END
    
    SET @ActualRecordCount = @@ROWCOUNT
    EXEC Admin.Utilities.logs.di_Batch @BatchOutID OUTPUT,  @BatchOutID, 'DetailEnd', NULL, NULL, NULL, @AnticipatedRecordCount, @ActualRecordCount
----------------------------------------------------------------------------------------------------------------------------------------------------
    SET @BatchDetailDescription = '190/340:  Base-Level Check HeadspacePoints - multiple of 5, max 100'
    EXEC Admin.Utilities.logs.di_Batch @BatchOutID OUTPUT,  @BatchOutID, 'DetailStart', @BatchDetailDescription
	
    -- Base-Level Check HeadspacePoints - multiple of 5, max of 100
    IF (@HeadspacePoints > 100) BEGIN
       SELECT @AnticipatedRecordCount = 1;
      
       INSERT INTO [DS_SummitLife].[dbo].[DailyReportAssetIncentiveStatusError]
       (
           [EmployeeNumber]
           ,[EmployeeLastName]
           ,[EmployeeFirstName]
           ,[EmployeeDob]
           ,[ErrorMessage]
           ,[DataGatheredOnTimestamp]
       )
       VALUES
       (
          @inputEmployeeNumber
         ,@inputEmployeeLastName
         ,@inputEmployeeFirstName
         ,@inputEmployeeDob
         ,'HeadspacePoints value, ' + CONVERT([nvarchar] (10), @HeadspacePoints) + ',  exceeds the maximum of 100.'
         ,CONVERT([nvarchar] (50), @currentTimestamp, 121)
       );

       -- BaseLevel Check Failure
       SET @BaseLevelChecksAllPassed = 0;

    END
    ELSE BEGIN
       IF ((@HeadspacePoints % 5) <> 0) BEGIN
    
         SELECT @AnticipatedRecordCount = 1;
      
         INSERT INTO [DS_SummitLife].[dbo].[DailyReportAssetIncentiveStatusError]
         (
           [EmployeeNumber]
           ,[EmployeeLastName]
           ,[EmployeeFirstName]
           ,[EmployeeDob]
           ,[ErrorMessage]
           ,[DataGatheredOnTimestamp]
         )
         VALUES
         (
            @inputEmployeeNumber
           ,@inputEmployeeLastName
           ,@inputEmployeeFirstName
           ,@inputEmployeeDob
           ,'HeadspacePoints has an invalid value, ' + CONVERT([nvarchar] (10), @HeadspacePoints) + '.  HeadspacePoints must be a multiple of 5.'
           ,CONVERT([nvarchar] (50), @currentTimestamp, 121)
         );


         -- BaseLevel Check Failure
         SET @BaseLevelChecksAllPassed = 0;
      
       END
	END
    
    SET @ActualRecordCount = @@ROWCOUNT
    EXEC Admin.Utilities.logs.di_Batch @BatchOutID OUTPUT,  @BatchOutID, 'DetailEnd', NULL, NULL, NULL, @AnticipatedRecordCount, @ActualRecordCount
----------------------------------------------------------------------------------------------------------------------------------------------------
    SET @BatchDetailDescription = '200/340:  SupportLincEapPoints - multiple of 5, max 100'
    EXEC Admin.Utilities.logs.di_Batch @BatchOutID OUTPUT,  @BatchOutID, 'DetailStart', @BatchDetailDescription
	
    -- Base-Level Check SupportLincEapPoints - multiple of 5, max 100
    IF (@SupportLincEapPoints > 100) BEGIN
       SELECT @AnticipatedRecordCount = 1;
      
       INSERT INTO [DS_SummitLife].[dbo].[DailyReportAssetIncentiveStatusError]
       (
           [EmployeeNumber]
           ,[EmployeeLastName]
           ,[EmployeeFirstName]
           ,[EmployeeDob]
           ,[ErrorMessage]
           ,[DataGatheredOnTimestamp]
       )
       VALUES
       (
          @inputEmployeeNumber
         ,@inputEmployeeLastName
         ,@inputEmployeeFirstName
         ,@inputEmployeeDob
         ,'SupportLincEapPoints value, ' + CONVERT([nvarchar] (10), @SupportLincEapPoints) + ',  exceeds the maximum of 100.'
         ,CONVERT([nvarchar] (50), @currentTimestamp, 121)
       );

       -- BaseLevel Check Failure
       SET @BaseLevelChecksAllPassed = 0;

    END
    ELSE BEGIN
       IF ((@SupportLincEapPoints % 5) <> 0) BEGIN
    
         SELECT @AnticipatedRecordCount = 1;
      
         INSERT INTO [DS_SummitLife].[dbo].[DailyReportAssetIncentiveStatusError]
         (
           [EmployeeNumber]
           ,[EmployeeLastName]
           ,[EmployeeFirstName]
           ,[EmployeeDob]
           ,[ErrorMessage]
           ,[DataGatheredOnTimestamp]
         )
         VALUES
         (
            @inputEmployeeNumber
           ,@inputEmployeeLastName
           ,@inputEmployeeFirstName
           ,@inputEmployeeDob
           ,'SupportLincEapPoints has an invalid value, ' + CONVERT([nvarchar] (10), @SupportLincEapPoints) + '.  SupportLincEapPoints must be a multiple of 5.'
           ,CONVERT([nvarchar] (50), @currentTimestamp, 121)
         );

         -- BaseLevel Check Failure
         SET @BaseLevelChecksAllPassed = 0;
      
       END
	END
    
    SET @ActualRecordCount = @@ROWCOUNT
    EXEC Admin.Utilities.logs.di_Batch @BatchOutID OUTPUT,  @BatchOutID, 'DetailEnd', NULL, NULL, NULL, @AnticipatedRecordCount, @ActualRecordCount
----------------------------------------------------------------------------------------------------------------------------------------------------
    SET @BatchDetailDescription = '210/340:  Base-Level Check HealthyLifestylePoints - 0, 25, 50, or 75'
    EXEC Admin.Utilities.logs.di_Batch @BatchOutID OUTPUT,  @BatchOutID, 'DetailStart', @BatchDetailDescription
	
    -- Base-Level Check HealthyLifestylePoints - 0, 25, 50, or 75
    IF (@HealthyLifestylePoints <> 0 AND @HealthyLifestylePoints <> 25 AND @HealthyLifestylePoints <> 50 AND @HealthyLifestylePoints <> 75) BEGIN
       SELECT @AnticipatedRecordCount = 1;
      
       INSERT INTO [DS_SummitLife].[dbo].[DailyReportAssetIncentiveStatusError]
       (
           [EmployeeNumber]
           ,[EmployeeLastName]
           ,[EmployeeFirstName]
           ,[EmployeeDob]
           ,[ErrorMessage]
           ,[DataGatheredOnTimestamp]
       )
       VALUES
       (
          @inputEmployeeNumber
         ,@inputEmployeeLastName
         ,@inputEmployeeFirstName
         ,@inputEmployeeDob
         ,'HealthyLifestylePoints value, ' + CONVERT([nvarchar] (10), @HealthyLifestylePoints) + ', is invalid.  HealthyLifestylePoints must be 0, 25, 50, or 75.'
         ,CONVERT([nvarchar] (50), @currentTimestamp, 121)
       );

       -- BaseLevel Check Failure
       SET @BaseLevelChecksAllPassed = 0;

    END
    
    SET @ActualRecordCount = @@ROWCOUNT
    EXEC Admin.Utilities.logs.di_Batch @BatchOutID OUTPUT,  @BatchOutID, 'DetailEnd', NULL, NULL, NULL, @AnticipatedRecordCount, @ActualRecordCount
----------------------------------------------------------------------------------------------------------------------------------------------------











-- Blood Pressure: less than or equal to 130/85
-- Waist Circumference: Male: less than or equal to 40"; Female: less than or equal to 35"
-- Cholesterol ratio: less than 5.0 
-- Triglycerides: less than 150
-- A1c: less than 5.7      

    SET @BatchDetailDescription = '220/340:  Base-Level Check Get "Healthy Target" Measurements from Bio in order to validate the Asset Points were earned.'
    EXEC Admin.Utilities.logs.di_Batch @BatchOutID OUTPUT,  @BatchOutID, 'DetailStart', @BatchDetailDescription
	
    -- Get Healthy Target Measurements sent to Asset so we can calculate whether the employee's measurement values merit the points Asset
    -- rewards them.
    SELECT @AnticipatedRecordCount = COUNT(*)
    FROM [DS_SummitLife].[dbo].[SummitLifeBiometricsAndLabsSentToAssetMaster]
    WHERE [EmployeeID] = @inputEmployeeNumber;
    
    SET @SystolicBloodPressure = 0;
    SET @DiastolicBloodPressure = 0;
    SET @WaistInches = 0;
    SET @TcOverHdl = 0;
    SET @Triglycerides = 0;
    SET @HemoglobinA1C = 0;
    SET @ExistsEmployeeID = NULL;
    
    SELECT
          @ExistsEmployeeID = [EmployeeID]
         ,@Gender = ISNULL([Gender],'')
	     ,@SystolicBloodPressure = CONVERT([decimal] (10, 4), [SystolicBloodPressure])
	     ,@DiastolicBloodPressure = CONVERT([decimal] (10, 4), [DiastolicBloodPressure])
 	     ,@WaistInches = CONVERT([decimal] (10, 4), [WaistInches])
	     ,@TcOverHdl = CONVERT([decimal] (10, 4), [TcOverHdl])
	     ,@Triglycerides = CONVERT([decimal] (10, 4), [Triglycerides])
         ,@HemoglobinA1C = CONVERT([decimal] (10, 4), [HemoglobinA1C])
    FROM [DS_SummitLife].[dbo].[SummitLifeBiometricsAndLabsSentToAssetMaster]
    WHERE [EmployeeID] = @inputEmployeeNumber;
    
    SET @ActualRecordCount = @@ROWCOUNT
    EXEC Admin.Utilities.logs.di_Batch @BatchOutID OUTPUT,  @BatchOutID, 'DetailEnd', NULL, NULL, NULL, @AnticipatedRecordCount, @ActualRecordCount
----------------------------------------------------------------------------------------------------------------------------------------------------

IF (@ExistsEmployeeID IS NULL) BEGIN
----------------------------------------------------------------------------------------------------------------------------------------------------

    SET @BatchDetailDescription = '220/340:  Get "Healthy Target" values from Physicians form'
    EXEC Admin.Utilities.logs.di_Batch @BatchOutID OUTPUT,  @BatchOutID, 'DetailStart', @BatchDetailDescription
	
    -- Get "Healthy Target" values from Physicians form
    SELECT @AnticipatedRecordCount = COUNT(*)
    FROM  [DS_SummitLIfe].[dbo].[SummitLifePhysicianLabsAndBiometricsMaster]
    WHERE [EmployeeID] = @inputEmployeeNumber;
    
    SET @SystolicBloodPressure = 0;
    SET @DiastolicBloodPressure = 0;
    SET @WaistInches = 0;
    SET @TcOverHdl = 0;
    SET @Triglycerides = 0;
    SET @HemoglobinA1C = 0;
    SET @ExistsEmployeeID = NULL;
    
    SELECT
          @ExistsEmployeeID = [EmployeeID]
         ,@Gender = ISNULL([Gender],'')
	     ,@SystolicBloodPressure = CONVERT([decimal] (10, 4), [SystolicBloodPressure])
	     ,@DiastolicBloodPressure = CONVERT([decimal] (10, 4), [DiastolicBloodPressure])
 	     ,@WaistInches = CONVERT([decimal] (10, 4), [WaistInches])
	     ,@TcOverHdl = CONVERT([decimal] (10, 4), [TcOverHdl])
	     ,@Triglycerides = CONVERT([decimal] (10, 4), [Triglycerides])
         ,@HemoglobinA1C = CONVERT([decimal] (10, 4), [HemoglobinA1C])
    FROM [DS_SummitLIfe].[dbo].[SummitLifePhysicianLabsAndBiometricsMaster]
    WHERE [EmployeeID] = @inputEmployeeNumber;
    
    SET @ActualRecordCount = @@ROWCOUNT
    EXEC Admin.Utilities.logs.di_Batch @BatchOutID OUTPUT,  @BatchOutID, 'DetailEnd', NULL, NULL, NULL, @AnticipatedRecordCount, @ActualRecordCount
----------------------------------------------------------------------------------------------------------------------------------------------------
END

-- If Employee number cannot be found in either the "Sent to Asset" or the "Physicians Form", write error.
IF (@ExistsEmployeeID IS NULL) BEGIN
----------------------------------------------------------------------------------------------------------------------------------------------------
    SET @BatchDetailDescription = '220/340:  Issue Error Message:  Employee Number not found on either "Sent to Asset" or "Physicians Form"'
    EXEC Admin.Utilities.logs.di_Batch @BatchOutID OUTPUT,  @BatchOutID, 'DetailStart', @BatchDetailDescription
	
    -- Issue Error Message:  Employee Number not found on either "Sent to Asset" or "Physicians Form"
       INSERT INTO [DS_SummitLife].[dbo].[DailyReportAssetIncentiveStatusError]
       (
           [EmployeeNumber]
           ,[EmployeeLastName]
           ,[EmployeeFirstName]
           ,[EmployeeDob]
           ,[ErrorMessage]
           ,[DataGatheredOnTimestamp]
       )
       VALUES
       (
          @inputEmployeeNumber
         ,@inputEmployeeLastName
         ,@inputEmployeeFirstName
         ,@inputEmployeeDob
         ,'Employee Number not found on either the "Sent to Asset" or the "Physicians Form" table.'
         ,CONVERT([nvarchar] (50), @currentTimestamp, 121)
       );
    
    SET @ActualRecordCount = @@ROWCOUNT
    EXEC Admin.Utilities.logs.di_Batch @BatchOutID OUTPUT,  @BatchOutID, 'DetailEnd', NULL, NULL, NULL, @AnticipatedRecordCount, @ActualRecordCount
----------------------------------------------------------------------------------------------------------------------------------------------------
  --  Since the employee is on neither "Sent to Asset" or the "Physicians Form" table they should have no blood pressure poinrs
  IF (@BloodPressurePoints > 0) BEGIN
----------------------------------------------------------------------------------------------------------------------------------------------------
       SET @BatchDetailDescription = '220/340:  Issue Error Message:  Employee Number not found on either "Sent to Asset" or "Physicians Form"; Should not have blood pressure points'
       EXEC Admin.Utilities.logs.di_Batch @BatchOutID OUTPUT,  @BatchOutID, 'DetailStart', @BatchDetailDescription
	
       -- Issue Error Message:  Employee Number not found on either "Sent to Asset" or "Physicians Form; they should have no blood pressure poinrs"
       INSERT INTO [DS_SummitLife].[dbo].[DailyReportAssetIncentiveStatusError]
       (
           [EmployeeNumber]
           ,[EmployeeLastName]
           ,[EmployeeFirstName]
           ,[EmployeeDob]
           ,[ErrorMessage]
           ,[DataGatheredOnTimestamp]
       )
       VALUES
       (
          @inputEmployeeNumber
         ,@inputEmployeeLastName
         ,@inputEmployeeFirstName
         ,@inputEmployeeDob
         ,'Employee Number not found on either the "Sent to Asset" or the "Physicians Form" table; The employee should have no blood pressure points.  Employee has ' + CONVERT([nvarchar] (30), @BloodPressurePoints) + ' blood pressure points.'
         ,CONVERT([nvarchar] (50), @currentTimestamp, 121)
       );
    
      SET @ActualRecordCount = @@ROWCOUNT
      EXEC Admin.Utilities.logs.di_Batch @BatchOutID OUTPUT,  @BatchOutID, 'DetailEnd', NULL, NULL, NULL, @AnticipatedRecordCount, @ActualRecordCount
----------------------------------------------------------------------------------------------------------------------------------------------------
  END
  
  --  Since the employee is on neither "Sent to Asset" or the "Physicians Form" table they should have no waist circumference poinrs
  IF (@WaistCircumferencePoints > 0) BEGIN
----------------------------------------------------------------------------------------------------------------------------------------------------
       SET @BatchDetailDescription = '220/340:  Issue Error Message:  Employee Number not found on either "Sent to Asset" or "Physicians Form"; Should not have Waist Circumference points'
       EXEC Admin.Utilities.logs.di_Batch @BatchOutID OUTPUT,  @BatchOutID, 'DetailStart', @BatchDetailDescription
	
       -- Issue Error Message:  Employee Number not found on either "Sent to Asset" or "Physicians Form"; Should not have Waist Circumference points"
       INSERT INTO [DS_SummitLife].[dbo].[DailyReportAssetIncentiveStatusError]
       (
           [EmployeeNumber]
           ,[EmployeeLastName]
           ,[EmployeeFirstName]
           ,[EmployeeDob]
           ,[ErrorMessage]
           ,[DataGatheredOnTimestamp]
       )
       VALUES
       (
          @inputEmployeeNumber
         ,@inputEmployeeLastName
         ,@inputEmployeeFirstName
         ,@inputEmployeeDob
         ,'Employee Number not found on either the "Sent to Asset" or the "Physicians Form" table; The employee should have no waist circumference points.  Employee has ' + CONVERT([nvarchar] (30), @WaistCircumferencePoints) + ' waist circumference points.'
         ,CONVERT([nvarchar] (50), @currentTimestamp, 121)
       );
    
      SET @ActualRecordCount = @@ROWCOUNT
      EXEC Admin.Utilities.logs.di_Batch @BatchOutID OUTPUT,  @BatchOutID, 'DetailEnd', NULL, NULL, NULL, @AnticipatedRecordCount, @ActualRecordCount
----------------------------------------------------------------------------------------------------------------------------------------------------
  END
  
  --  Since the employee is on neither "Sent to Asset" or the "Physicians Form" table they should have no Cholesterol Ratio points
  IF (@WaistCircumferencePoints > 0) BEGIN
----------------------------------------------------------------------------------------------------------------------------------------------------
       SET @BatchDetailDescription = '220/340:  Issue Error Message:  Employee Number not found on either "Sent to Asset" or "Physicians Form"; Should not have Waist Circumference points'
       EXEC Admin.Utilities.logs.di_Batch @BatchOutID OUTPUT,  @BatchOutID, 'DetailStart', @BatchDetailDescription
	
       -- Issue Error Message:  Employee Number not found on either "Sent to Asset" or "Physicians Form"; Should not have Cholesterol Ratio points"
       INSERT INTO [DS_SummitLife].[dbo].[DailyReportAssetIncentiveStatusError]
       (
           [EmployeeNumber]
           ,[EmployeeLastName]
           ,[EmployeeFirstName]
           ,[EmployeeDob]
           ,[ErrorMessage]
           ,[DataGatheredOnTimestamp]
       )
       VALUES
       (
          @inputEmployeeNumber
         ,@inputEmployeeLastName
         ,@inputEmployeeFirstName
         ,@inputEmployeeDob
         ,'Employee Number not found on either the "Sent to Asset" or the "Physicians Form" table; The employee should have no Cholesterol Ratio points.  Employee has ' + CONVERT([nvarchar] (30), @CholesterolRatioPoints) + ' Cholesterol Ratio points.'
         ,CONVERT([nvarchar] (50), @currentTimestamp, 121)
       );
    
      SET @ActualRecordCount = @@ROWCOUNT
      EXEC Admin.Utilities.logs.di_Batch @BatchOutID OUTPUT,  @BatchOutID, 'DetailEnd', NULL, NULL, NULL, @AnticipatedRecordCount, @ActualRecordCount
----------------------------------------------------------------------------------------------------------------------------------------------------
  END

  --  Since the employee is on neither "Sent to Asset" or the "Physicians Form" table they should have no Triglyceride points
  IF (@TriglyceridePoints > 0) BEGIN
----------------------------------------------------------------------------------------------------------------------------------------------------
       SET @BatchDetailDescription = '220/340:  Issue Error Message:  Employee Number not found on either "Sent to Asset" or "Physicians Form"; Should not have Triglyceride points'
       EXEC Admin.Utilities.logs.di_Batch @BatchOutID OUTPUT,  @BatchOutID, 'DetailStart', @BatchDetailDescription
	
       -- Issue Error Message:  Employee Number not found on either "Sent to Asset" or "Physicians Form"; Should not have Triglyceride points"
       INSERT INTO [DS_SummitLife].[dbo].[DailyReportAssetIncentiveStatusError]
       (
           [EmployeeNumber]
           ,[EmployeeLastName]
           ,[EmployeeFirstName]
           ,[EmployeeDob]
           ,[ErrorMessage]
           ,[DataGatheredOnTimestamp]
       )
       VALUES
       (
          @inputEmployeeNumber
         ,@inputEmployeeLastName
         ,@inputEmployeeFirstName
         ,@inputEmployeeDob
         ,'Employee Number not found on either the "Sent to Asset" or the "Physicians Form" table; The employee should have no Triglyceride points.  Employee has ' + CONVERT([nvarchar] (30), @TriglyceridePoints) + ' Triglyceride points.'
         ,CONVERT([nvarchar] (50), @currentTimestamp, 121)
       );
    
      SET @ActualRecordCount = @@ROWCOUNT
      EXEC Admin.Utilities.logs.di_Batch @BatchOutID OUTPUT,  @BatchOutID, 'DetailEnd', NULL, NULL, NULL, @AnticipatedRecordCount, @ActualRecordCount
----------------------------------------------------------------------------------------------------------------------------------------------------
  END

  --  Since the employee is on neither "Sent to Asset" or the "Physicians Form" table they should have no Hba1c points
  IF (@TriglyceridePoints > 0) BEGIN
----------------------------------------------------------------------------------------------------------------------------------------------------
       SET @BatchDetailDescription = '220/340:  Issue Error Message:  Employee Number not found on either "Sent to Asset" or "Physicians Form"; Should not have Hba1c points'
       EXEC Admin.Utilities.logs.di_Batch @BatchOutID OUTPUT,  @BatchOutID, 'DetailStart', @BatchDetailDescription
	
       -- Issue Error Message:  Employee Number not found on either "Sent to Asset" or "Physicians Form"; Should not have Hba1c points"
       INSERT INTO [DS_SummitLife].[dbo].[DailyReportAssetIncentiveStatusError]
       (
           [EmployeeNumber]
           ,[EmployeeLastName]
           ,[EmployeeFirstName]
           ,[EmployeeDob]
           ,[ErrorMessage]
           ,[DataGatheredOnTimestamp]
       )
       VALUES
       (
          @inputEmployeeNumber
         ,@inputEmployeeLastName
         ,@inputEmployeeFirstName
         ,@inputEmployeeDob
         ,'Employee Number not found on either the "Sent to Asset" or the "Physicians Form" table; The employee should have no Hba1c points.  Employee has ' + CONVERT([nvarchar] (30), @Hba1cPoints) + ' Hba1c points.'
         ,CONVERT([nvarchar] (50), @currentTimestamp, 121)
       );
    
      SET @ActualRecordCount = @@ROWCOUNT
      EXEC Admin.Utilities.logs.di_Batch @BatchOutID OUTPUT,  @BatchOutID, 'DetailEnd', NULL, NULL, NULL, @AnticipatedRecordCount, @ActualRecordCount
----------------------------------------------------------------------------------------------------------------------------------------------------
  END

  
  RETURN;
END
----------------------------------------------------------------------------------------------------------------------------------------------------
  -- Blood Pressure: less than or equal to 130/85

    SET @BatchDetailDescription = '230/340:  Base-Level Check If the Blood Pressure is less than 130/85, the employee deserves the points for Blood Pressure'
    EXEC Admin.Utilities.logs.di_Batch @BatchOutID OUTPUT,  @BatchOutID, 'DetailStart', @BatchDetailDescription
	
    SET @BloodPressurePointsShouldHaveBeenEarned = 0;
    IF (@SystolicBloodPressure <= 130 AND @DiastolicBloodPressure <= 85) BEGIN
      SET @BloodPressurePointsShouldHaveBeenEarned = 1;
    END
    
    IF (@BloodPressurePointsShouldHaveBeenEarned = 0 AND @BloodPressurePoints > 0) BEGIN
    
       SELECT @AnticipatedRecordCount = 1;
      
       INSERT INTO [DS_SummitLife].[dbo].[DailyReportAssetIncentiveStatusError]
       (
           [EmployeeNumber]
           ,[EmployeeLastName]
           ,[EmployeeFirstName]
           ,[EmployeeDob]
           ,[ErrorMessage]
           ,[DataGatheredOnTimestamp]
       )
       VALUES
       (
          @inputEmployeeNumber
         ,@inputEmployeeLastName
         ,@inputEmployeeFirstName
         ,@inputEmployeeDob
         ,'Asset says the employee has earned blood pressure points that the employee should not have earned.  To earn the Blood Pressure Points an employee must have blood pressure <= 130/85.  This Employee has blood pressure of ' + CONVERT([nvarchar] (10), @SystolicBloodPressure) + '/' + CONVERT([nvarchar] (10), @DiastolicBloodPressure) + '.'
         ,CONVERT([nvarchar] (50), @currentTimestamp, 121)
       );
       
       -- BaseLevel Check Failure
       SET @BaseLevelChecksAllPassed = 0;

    END
    ELSE IF (@BloodPressurePointsShouldHaveBeenEarned = 1 AND @BloodPressurePoints = 0) BEGIN
       SELECT @AnticipatedRecordCount = 1;
      
       INSERT INTO [DS_SummitLife].[dbo].[DailyReportAssetIncentiveStatusError]
       (
           [EmployeeNumber]
           ,[EmployeeLastName]
           ,[EmployeeFirstName]
           ,[EmployeeDob]
           ,[ErrorMessage]
           ,[DataGatheredOnTimestamp]
       )
       VALUES
       (
          @inputEmployeeNumber
         ,@inputEmployeeLastName
         ,@inputEmployeeFirstName
         ,@inputEmployeeDob
         ,'Asset says the employee has NOT earned Blood Pressure Points that the Employee should have earned.  To earn the Blood Pressure Points an employee must have blood pressure <= 130/85.  This Employee has blood pressure of ' + CONVERT([nvarchar] (10), @SystolicBloodPressure) + '/' + CONVERT([nvarchar] (10), @DiastolicBloodPressure)
         ,CONVERT([nvarchar] (50), @currentTimestamp, 121)
       );
       
       -- BaseLevel Check Failure
       SET @BaseLevelChecksAllPassed = 0;
    END
    
    
    SET @ActualRecordCount = @@ROWCOUNT
    EXEC Admin.Utilities.logs.di_Batch @BatchOutID OUTPUT,  @BatchOutID, 'DetailEnd', NULL, NULL, NULL, @AnticipatedRecordCount, @ActualRecordCount
----------------------------------------------------------------------------------------------------------------------------------------------------
    -- Waist Circumference: Male: less than or equal to 40"; Female: less than or equal to 35"
    
    SET @BatchDetailDescription = '240/340:  Base-Level Check Waist Circumference: Male: less than or equal to 40 inches; Female: less than or equal to 35 inches'
    EXEC Admin.Utilities.logs.di_Batch @BatchOutID OUTPUT,  @BatchOutID, 'DetailStart', @BatchDetailDescription
	
    SET @WaistCircumferencePointsShouldHaveBeenEarned = 0;
    IF ((@Gender in ('Male', 'M') AND @WaistInches <= 40) OR (@Gender in ('Female', 'F') AND @WaistInches <= 35)) BEGIN
      SET @WaistCircumferencePointsShouldHaveBeenEarned = 1;
    END
    
    IF (@WaistCircumferencePointsShouldHaveBeenEarned = 0 AND @WaistCircumferencePoints > 0) BEGIN
    
       SELECT @AnticipatedRecordCount = 1;
      
       INSERT INTO [DS_SummitLife].[dbo].[DailyReportAssetIncentiveStatusError]
       (
           [EmployeeNumber]
           ,[EmployeeLastName]
           ,[EmployeeFirstName]
           ,[EmployeeDob]
           ,[ErrorMessage]
           ,[DataGatheredOnTimestamp]
       )
       VALUES
       (
          @inputEmployeeNumber
         ,@inputEmployeeLastName
         ,@inputEmployeeFirstName
         ,@inputEmployeeDob
         ,'Asset says the employee has earned Waist Circumference Points that the employee should not have earned.  To earn the Waist Circumference Points a male employee must have a waist circumference of less than or equal to 40 inches and a female employee must have a waist circumference less than or equal to 35 inches.  This Employee is ' +  @Gender + ' and has a waist circumference of ' + CONVERT([nvarchar] (10), @WaistInches) + ' inches.'
         ,CONVERT([nvarchar] (50), @currentTimestamp, 121)
       );
       
       -- BaseLevel Check Failure
       SET @BaseLevelChecksAllPassed = 0;

    END
    ELSE IF (@WaistCircumferencePointsShouldHaveBeenEarned = 1 AND @WaistCircumferencePoints = 0) BEGIN
       SELECT @AnticipatedRecordCount = 1;
      
       INSERT INTO [DS_SummitLife].[dbo].[DailyReportAssetIncentiveStatusError]
       (
           [EmployeeNumber]
           ,[EmployeeLastName]
           ,[EmployeeFirstName]
           ,[EmployeeDob]
           ,[ErrorMessage]
           ,[DataGatheredOnTimestamp]
       )
       VALUES
       (
          @inputEmployeeNumber
         ,@inputEmployeeLastName
         ,@inputEmployeeFirstName
         ,@inputEmployeeDob
         ,'Asset says the employee has NOT earned Waist Circumference Points that the Employee should have earned.  To earn the Waist Circumference Points a male employee must have a waist circumference of less than or equal to 40 inches and a female employee must have a waist circumference less than or equal to 35 inches.  This Employee is ' +  @Gender + ' and has a waist circumference of ' + CONVERT([nvarchar] (10), @WaistInches) + ' inches.'
         ,CONVERT([nvarchar] (50), @currentTimestamp, 121)
       );
       
       -- BaseLevel Check Failure
       SET @BaseLevelChecksAllPassed = 0;

    END
    
    SET @ActualRecordCount = @@ROWCOUNT
    EXEC Admin.Utilities.logs.di_Batch @BatchOutID OUTPUT,  @BatchOutID, 'DetailEnd', NULL, NULL, NULL, @AnticipatedRecordCount, @ActualRecordCount
----------------------------------------------------------------------------------------------------------------------------------------------------
    -- Cholesterol ratio: less than 5.0    
    SET @BatchDetailDescription = '250/340:  Base-Level Check Cholesterol ratio: less than 5.0'
    EXEC Admin.Utilities.logs.di_Batch @BatchOutID OUTPUT,  @BatchOutID, 'DetailStart', @BatchDetailDescription
	
    SET @CholesterolRatioPointsShouldHaveBeenEarned = 0;
    IF (@TcOverHdl < 5) BEGIN
      SET @CholesterolRatioPointsShouldHaveBeenEarned = 1;
    END
    
    IF (@CholesterolRatioPointsShouldHaveBeenEarned = 0 AND @CholesterolRatioPoints > 0) BEGIN
    
       SELECT @AnticipatedRecordCount = 1;
      
       INSERT INTO [DS_SummitLife].[dbo].[DailyReportAssetIncentiveStatusError]
       (
           [EmployeeNumber]
           ,[EmployeeLastName]
           ,[EmployeeFirstName]
           ,[EmployeeDob]
           ,[ErrorMessage]
           ,[DataGatheredOnTimestamp]
       )
       VALUES
       (
          @inputEmployeeNumber
         ,@inputEmployeeLastName
         ,@inputEmployeeFirstName
         ,@inputEmployeeDob
         ,'Asset says the employee has earned cholesterol ratio points that the employee should not have earned.  To earn the cholesterol ratio points an employee must have a cholesterol ratio level of less than 5.0.  This employee has a cholesterol ratio level of ' + CONVERT([nvarchar] (10), @TcOverHdl) + '.'
         ,CONVERT([nvarchar] (50), @currentTimestamp, 121)
       );
       
       -- BaseLevel Check Failure
       SET @BaseLevelChecksAllPassed = 0;

    END
    ELSE IF (@CholesterolRatioPointsShouldHaveBeenEarned = 1 AND @CholesterolRatioPoints = 0) BEGIN
       SELECT @AnticipatedRecordCount = 1;
      
       INSERT INTO [DS_SummitLife].[dbo].[DailyReportAssetIncentiveStatusError]
       (
           [EmployeeNumber]
           ,[EmployeeLastName]
           ,[EmployeeFirstName]
           ,[EmployeeDob]
           ,[ErrorMessage]
           ,[DataGatheredOnTimestamp]
       )
       VALUES
       (
          @inputEmployeeNumber
         ,@inputEmployeeLastName
         ,@inputEmployeeFirstName
         ,@inputEmployeeDob
         ,'Asset says the employee has NOT earned cholesterol ratio points that the employee should have earned.  To earn the cholesterol ratio points an employee must have a cholesterol ratio level of less than 5.0.  This employee has a cholesterol ratio level of ' + CONVERT([nvarchar] (10), @TcOverHdl) + '.'
         ,CONVERT([nvarchar] (50), @currentTimestamp, 121)
       );
       
       -- BaseLevel Check Failure
       SET @BaseLevelChecksAllPassed = 0;

    END
    
    
    SET @ActualRecordCount = @@ROWCOUNT
    EXEC Admin.Utilities.logs.di_Batch @BatchOutID OUTPUT,  @BatchOutID, 'DetailEnd', NULL, NULL, NULL, @AnticipatedRecordCount, @ActualRecordCount
----------------------------------------------------------------------------------------------------------------------------------------------------
    -- Triglycerides: less than 150
    SET @BatchDetailDescription = '260/340:  Base-Level Check Triglycerides: less than 150'
    EXEC Admin.Utilities.logs.di_Batch @BatchOutID OUTPUT,  @BatchOutID, 'DetailStart', @BatchDetailDescription
	
    SET @TriglyceridePointsShouldHaveBeenEarned = 0;
    IF (@Triglycerides < 150) BEGIN
      SET @TriglyceridePointsShouldHaveBeenEarned = 1;
    END
    
    IF (@TriglyceridePointsShouldHaveBeenEarned = 0 AND @TriglyceridePoints > 0) BEGIN
    
       SELECT @AnticipatedRecordCount = 1;
      
       INSERT INTO [DS_SummitLife].[dbo].[DailyReportAssetIncentiveStatusError]
       (
           [EmployeeNumber]
           ,[EmployeeLastName]
           ,[EmployeeFirstName]
           ,[EmployeeDob]
           ,[ErrorMessage]
           ,[DataGatheredOnTimestamp]
       )
       VALUES
       (
          @inputEmployeeNumber
         ,@inputEmployeeLastName
         ,@inputEmployeeFirstName
         ,@inputEmployeeDob
         ,'Asset says the employee has earned triglyceride points that the employee should not have earned.  To earn the Triglyceride Points an Employee must have Triglycerides level less than 150.  This employee has a Triglycerides level of ' + CONVERT([nvarchar] (10), @Triglycerides) + '.'
         ,CONVERT([nvarchar] (50), @currentTimestamp, 121)
       );
       
       -- BaseLevel Check Failure
       SET @BaseLevelChecksAllPassed = 0;

    END
    ELSE IF (@TriglyceridePointsShouldHaveBeenEarned = 1 AND @TriglyceridePoints = 0) BEGIN
       SELECT @AnticipatedRecordCount = 1;
      
       INSERT INTO [DS_SummitLife].[dbo].[DailyReportAssetIncentiveStatusError]
       (
           [EmployeeNumber]
           ,[EmployeeLastName]
           ,[EmployeeFirstName]
           ,[EmployeeDob]
           ,[ErrorMessage]
           ,[DataGatheredOnTimestamp]
       )
       VALUES
       (
          @inputEmployeeNumber
         ,@inputEmployeeLastName
         ,@inputEmployeeFirstName
         ,@inputEmployeeDob
         ,'Asset says the employee has NOT earned triglyceride points that the employee should have earned.  To earn the Triglyceride Points an Employee must have Triglycerides level less than 150.  This employee has a Triglycerides level of ' + CONVERT([nvarchar] (10), @Triglycerides) + '.'
         ,CONVERT([nvarchar] (50), @currentTimestamp, 121)
       );
       
       -- BaseLevel Check Failure
       SET @BaseLevelChecksAllPassed = 0;

    END
    
    SET @ActualRecordCount = @@ROWCOUNT
    EXEC Admin.Utilities.logs.di_Batch @BatchOutID OUTPUT,  @BatchOutID, 'DetailEnd', NULL, NULL, NULL, @AnticipatedRecordCount, @ActualRecordCount
----------------------------------------------------------------------------------------------------------------------------------------------------
    -- A1c: less than 5.7
    SET @BatchDetailDescription = '270/340:  Base-Level Check A1c: less than 5.7'
    EXEC Admin.Utilities.logs.di_Batch @BatchOutID OUTPUT,  @BatchOutID, 'DetailStart', @BatchDetailDescription
	
    SET @A1cPointsShouldHaveBeenEarned = 0;
    IF (@HemoglobinA1C < 5.7) BEGIN
      SET @A1cPointsShouldHaveBeenEarned = 1;
    END
    
    IF (@A1cPointsShouldHaveBeenEarned = 0 AND @Hba1cPoints > 0) BEGIN
    
       SELECT @AnticipatedRecordCount = 1;
      
       INSERT INTO [DS_SummitLife].[dbo].[DailyReportAssetIncentiveStatusError]
       (
           [EmployeeNumber]
           ,[EmployeeLastName]
           ,[EmployeeFirstName]
           ,[EmployeeDob]
           ,[ErrorMessage]
           ,[DataGatheredOnTimestamp]
       )
       VALUES
       (
          @inputEmployeeNumber
         ,@inputEmployeeLastName
         ,@inputEmployeeFirstName
         ,@inputEmployeeDob
         ,'Asset says the employee has earned A1C points that the employee should not have earned.  To earn the A1C Points an Employee must have A1C level less than 5.7.  This employee has a A1C level of ' + CONVERT([nvarchar] (10), @HemoglobinA1C) + '.'
         ,CONVERT([nvarchar] (50), @currentTimestamp, 121)
       );
       
       -- BaseLevel Check Failure
       SET @BaseLevelChecksAllPassed = 0;

    END
    ELSE IF (@A1cPointsShouldHaveBeenEarned = 1 AND @Hba1cPoints = 0) BEGIN
       SELECT @AnticipatedRecordCount = 1;
      
       INSERT INTO [DS_SummitLife].[dbo].[DailyReportAssetIncentiveStatusError]
       (
           [EmployeeNumber]
           ,[EmployeeLastName]
           ,[EmployeeFirstName]
           ,[EmployeeDob]
           ,[ErrorMessage]
           ,[DataGatheredOnTimestamp]
       )
       VALUES
       (
          @inputEmployeeNumber
         ,@inputEmployeeLastName
         ,@inputEmployeeFirstName
         ,@inputEmployeeDob
         ,'Asset says the employee has NOT earned A1C points that the employee should have earned.  To earn the A1C Points an Employee must have A1C level less than 5.7.  This employee has a A1C level of ' + CONVERT([nvarchar] (10), @HemoglobinA1C) + '.'
         ,CONVERT([nvarchar] (50), @currentTimestamp, 121)
       );

       -- BaseLevel Check Failure
       SET @BaseLevelChecksAllPassed = 0;

    END
    
    
    SET @ActualRecordCount = @@ROWCOUNT
    EXEC Admin.Utilities.logs.di_Batch @BatchOutID OUTPUT,  @BatchOutID, 'DetailEnd', NULL, NULL, NULL, @AnticipatedRecordCount, @ActualRecordCount
----------------------------------------------------------------------------------------------------------------------------------------------------


IF (@BaseLevelChecksAllPassed = 1) BEGIN

  SET @NonCategoryGroupLevelChecksPassed = 1;
  SET @SumOfHealthyLifestylePoints = 
     @BloodPressurePoints +
     @WaistCircumferencePoints +
     @CholesterolRatioPoints +
     @TriglyceridePoints +
     @Hba1cPoints;
----------------------------------------------------------------------------------------------------------------------------------------------------
    SET @BatchDetailDescription = '280/340:  NonCategoryGroupLevelCheck @SumOfHealthyLifestylePoints <> @TotalHealthyTargetPoints'
    EXEC Admin.Utilities.logs.di_Batch @BatchOutID OUTPUT,  @BatchOutID, 'DetailStart', @BatchDetailDescription
	
    -- NonCategoryGroupLevelCheck @SumOfHealthyLifestylePoints <> @TotalHealthyTargetPoints'
    IF (@SumOfHealthyLifestylePoints <> @TotalHealthyTargetPoints) BEGIN
       SELECT @AnticipatedRecordCount = 1;
      
       INSERT INTO [DS_SummitLife].[dbo].[DailyReportAssetIncentiveStatusError]
       (
           [EmployeeNumber]
           ,[EmployeeLastName]
           ,[EmployeeFirstName]
           ,[EmployeeDob]
           ,[ErrorMessage]
           ,[DataGatheredOnTimestamp]
       )
       VALUES
       (
          @inputEmployeeNumber
         ,@inputEmployeeLastName
         ,@inputEmployeeFirstName
         ,@inputEmployeeDob
         ,'The sum of BloodPressurePoints, WaistCircumferencePoints, CholesterolRatioPoints, TriglyceridePoints, and Hba1cPoints ' + CONVERT([nvarchar] (10), @SumOfHealthyLifestylePoints) + ' does not equal the TotalHealthyTargetPoints from the Asset Incentive Status Report, ' + CONVERT([nvarchar] (10), @TotalHealthyTargetPoints) 
         ,CONVERT([nvarchar] (50), @currentTimestamp, 121)
       );

       -- Non-Category Group Level Check Failure
       SET @NonCategoryGroupLevelChecksPassed = 0;

    END
    ELSE BEGIN
       IF (@SumOfHealthyLifestylePoints > 125) BEGIN
          SELECT @AnticipatedRecordCount = 1;
      
          INSERT INTO [DS_SummitLife].[dbo].[DailyReportAssetIncentiveStatusError]
          (
            [EmployeeNumber]
            ,[EmployeeLastName]
            ,[EmployeeFirstName]
            ,[EmployeeDob]
            ,[ErrorMessage]
            ,[DataGatheredOnTimestamp]
          )
          VALUES
          (
             @inputEmployeeNumber
            ,@inputEmployeeLastName
            ,@inputEmployeeFirstName
            ,@inputEmployeeDob
            ,'The sum of BloodPressurePoints, WaistCircumferencePoints, CholesterolRatioPoints, TriglyceridePoints, and Hba1cPoints ' + CONVERT([nvarchar] (10), @SumOfHealthyLifestylePoints) + ' exceeds the maximum value of 125.'
            ,CONVERT([nvarchar] (50), @currentTimestamp, 121)
          );

          -- Non-Category Group Level Check Failure
          SET @NonCategoryGroupLevelChecksPassed = 0;
       END
    END
    
    SET @ActualRecordCount = @@ROWCOUNT
    EXEC Admin.Utilities.logs.di_Batch @BatchOutID OUTPUT,  @BatchOutID, 'DetailEnd', NULL, NULL, NULL, @AnticipatedRecordCount, @ActualRecordCount
----------------------------------------------------------------------------------------------------------------------------------------------------

IF (@NonCategoryGroupLevelChecksPassed = 1) BEGIN
  
  SET @CategoryGroupLevelChecksPassed = 1;
  
  SET @HealthyMeasuresAndLifestyleTargetsCategoryPoints = 
       @HealthAssessmentPoints +
       @BiometricSubmittedPoints +
       @BloodPressurePoints +
       @WaistCircumferencePoints +
       @CholesterolRatioPoints +
       @TriglyceridePoints +
       @Hba1cPoints +
       @TobaccoFreePoints;
----------------------------------------------------------------------------------------------------------------------------------------------------
    SET @BatchDetailDescription = '290/340:  CategoryGroupLevelCheck HealthyMeasuresAndLifestyleTargetsCategoryPoints > 325'
    EXEC Admin.Utilities.logs.di_Batch @BatchOutID OUTPUT,  @BatchOutID, 'DetailStart', @BatchDetailDescription
	
    -- CategoryGroupLevelCheck HealthyMeasuresAndLifestyleTargetsCategoryPoints > 325
    IF (@HealthyMeasuresAndLifestyleTargetsCategoryPoints > 325) BEGIN
       SELECT @AnticipatedRecordCount = 1;
      
       INSERT INTO [DS_SummitLife].[dbo].[DailyReportAssetIncentiveStatusError]
       (
           [EmployeeNumber]
           ,[EmployeeLastName]
           ,[EmployeeFirstName]
           ,[EmployeeDob]
           ,[ErrorMessage]
           ,[DataGatheredOnTimestamp]
       )
       VALUES
       (
          @inputEmployeeNumber
         ,@inputEmployeeLastName
         ,@inputEmployeeFirstName
         ,@inputEmployeeDob
         ,'The HealthyMeasuresAndLifestyleTargetsCategoryPoints, the sum of HealthAssessmentPoints, BiometricSubmittedPoints, BloodPressurePoints, WaistCircumferencePoints, CholesterolRatioPoints, TriglyceridePoints, Hba1cPoints, and TobaccoFreePoints, ' + CONVERT([nvarchar] (10), @HealthyMeasuresAndLifestyleTargetsCategoryPoints) + ', exceeds the maximum of 325.'
         ,CONVERT([nvarchar] (50), @currentTimestamp, 121)
       );

       -- Category Group Level Check Failure
       SET @CategoryGroupLevelChecksPassed = 0;

    END
    
    SET @ActualRecordCount = @@ROWCOUNT
    EXEC Admin.Utilities.logs.di_Batch @BatchOutID OUTPUT,  @BatchOutID, 'DetailEnd', NULL, NULL, NULL, @AnticipatedRecordCount, @ActualRecordCount
----------------------------------------------------------------------------------------------------------------------------------------------------
  
  SET @PortalActivitiesCategoryPoints =
       @CoursePoints +
       @CoachingCallPoints;
       
----------------------------------------------------------------------------------------------------------------------------------------------------
    SET @BatchDetailDescription = '300/340:  CategoryGroupLevelCheck PortalActivitiesCategoryPoints > 150'
    EXEC Admin.Utilities.logs.di_Batch @BatchOutID OUTPUT,  @BatchOutID, 'DetailStart', @BatchDetailDescription
	
    -- CategoryGroupLevelCheck PortalActivitiesCategoryPoints > 150
    IF (@PortalActivitiesCategoryPoints > 150) BEGIN
       SELECT @AnticipatedRecordCount = 1;
      
       INSERT INTO [DS_SummitLife].[dbo].[DailyReportAssetIncentiveStatusError]
       (
           [EmployeeNumber]
           ,[EmployeeLastName]
           ,[EmployeeFirstName]
           ,[EmployeeDob]
           ,[ErrorMessage]
           ,[DataGatheredOnTimestamp]
       )
       VALUES
       (
          @inputEmployeeNumber
         ,@inputEmployeeLastName
         ,@inputEmployeeFirstName
         ,@inputEmployeeDob
         ,'PortalActivitiesCategoryPoints, the sum of CoursePoints and CoachingCallPoints, ' + CONVERT([nvarchar] (10), @PortalActivitiesCategoryPoints) + ', exceeds the maximum of 150.'
         ,CONVERT([nvarchar] (50), @currentTimestamp, 121)
       );

       -- Category Group Level Check Failure
       SET @CategoryGroupLevelChecksPassed = 0;

    END
    
    SET @ActualRecordCount = @@ROWCOUNT
    EXEC Admin.Utilities.logs.di_Batch @BatchOutID OUTPUT,  @BatchOutID, 'DetailEnd', NULL, NULL, NULL, @AnticipatedRecordCount, @ActualRecordCount
----------------------------------------------------------------------------------------------------------------------------------------------------

  SET @WellnessChallengesCategoryPoints =
      @AssetHealthChallengePoints +
      @SummitChallengePoints;

----------------------------------------------------------------------------------------------------------------------------------------------------
    SET @BatchDetailDescription = '310/340:  CategoryGroupLevelCheck WellnessChallengesCategoryPoints > 100'
    EXEC Admin.Utilities.logs.di_Batch @BatchOutID OUTPUT,  @BatchOutID, 'DetailStart', @BatchDetailDescription
	
    -- CategoryGroupLevelCheck WellnessChallengesCategoryPoints > 100
    IF (@WellnessChallengesCategoryPoints > 100) BEGIN
       SELECT @AnticipatedRecordCount = 1;
      
       INSERT INTO [DS_SummitLife].[dbo].[DailyReportAssetIncentiveStatusError]
       (
           [EmployeeNumber]
           ,[EmployeeLastName]
           ,[EmployeeFirstName]
           ,[EmployeeDob]
           ,[ErrorMessage]
           ,[DataGatheredOnTimestamp]
       )
       VALUES
       (
          @inputEmployeeNumber
         ,@inputEmployeeLastName
         ,@inputEmployeeFirstName
         ,@inputEmployeeDob
         ,'The WellnessChallengesCategoryPoints, the sum of AssetHealthChallengePoints and SummitChallengePoints, ' + CONVERT([nvarchar] (10), @WellnessChallengesCategoryPoints) + ', exceeds the maximum of 100.'
         ,CONVERT([nvarchar] (50), @currentTimestamp, 121)
       );

       -- Category Group Level Check Failure
       SET @CategoryGroupLevelChecksPassed = 0;

    END
    
    SET @ActualRecordCount = @@ROWCOUNT
    EXEC Admin.Utilities.logs.di_Batch @BatchOutID OUTPUT,  @BatchOutID, 'DetailEnd', NULL, NULL, NULL, @AnticipatedRecordCount, @ActualRecordCount
----------------------------------------------------------------------------------------------------------------------------------------------------

      
  SET @SummitHealthPlanEnrolleeOfferingsCategoryPoints =
       @VirtaHealthPoints +
       @HingePoints;
----------------------------------------------------------------------------------------------------------------------------------------------------
    SET @BatchDetailDescription = '320/340:  CategoryGroupLevelCheck SummitHealthPlanEnrolleeOfferingsCategoryPoints > 140'
    EXEC Admin.Utilities.logs.di_Batch @BatchOutID OUTPUT,  @BatchOutID, 'DetailStart', @BatchDetailDescription
	
    -- CategoryGroupLevelCheck SummitHealthPlanEnrolleeOfferingsCategoryPoints > 140
    IF (@SummitHealthPlanEnrolleeOfferingsCategoryPoints > 140) BEGIN
       SELECT @AnticipatedRecordCount = 1;
      
       INSERT INTO [DS_SummitLife].[dbo].[DailyReportAssetIncentiveStatusError]
       (
           [EmployeeNumber]
           ,[EmployeeLastName]
           ,[EmployeeFirstName]
           ,[EmployeeDob]
           ,[ErrorMessage]
           ,[DataGatheredOnTimestamp]
       )
       VALUES
       (
          @inputEmployeeNumber
         ,@inputEmployeeLastName
         ,@inputEmployeeFirstName
         ,@inputEmployeeDob
         ,'The SummitHealthPlanEnrolleeOfferingsCategoryPoints, the sum of VirtaHealthPoints and HingePoints, ' + CONVERT([nvarchar] (10), @SummitHealthPlanEnrolleeOfferingsCategoryPoints) + ' exceeds the maximum of 140.'
         ,CONVERT([nvarchar] (50), @currentTimestamp, 121)
       );

       -- Category Group Level Check Failure
       SET @CategoryGroupLevelChecksPassed = 0;

    END
    
    SET @ActualRecordCount = @@ROWCOUNT
    EXEC Admin.Utilities.logs.di_Batch @BatchOutID OUTPUT,  @BatchOutID, 'DetailEnd', NULL, NULL, NULL, @AnticipatedRecordCount, @ActualRecordCount
----------------------------------------------------------------------------------------------------------------------------------------------------
       
  SET @EmotionalHealthActivitiesCategoryPoints =
      @HeadspacePoints +
      @SupportLincEapPoints;    
       
----------------------------------------------------------------------------------------------------------------------------------------------------
    SET @BatchDetailDescription = '330/340:  CategoryGroupLevelCheck EmotionalHealthActivitiesCategoryPoints > 100'
    EXEC Admin.Utilities.logs.di_Batch @BatchOutID OUTPUT,  @BatchOutID, 'DetailStart', @BatchDetailDescription
	
    -- CategoryGroupLevelCheck EmotionalHealthActivitiesCategoryPoints > 100
    IF (@EmotionalHealthActivitiesCategoryPoints > 100) BEGIN
       SELECT @AnticipatedRecordCount = 1;
      
       INSERT INTO [DS_SummitLife].[dbo].[DailyReportAssetIncentiveStatusError]
       (
           [EmployeeNumber]
           ,[EmployeeLastName]
           ,[EmployeeFirstName]
           ,[EmployeeDob]
           ,[ErrorMessage]
           ,[DataGatheredOnTimestamp]
       )
       VALUES
       (
          @inputEmployeeNumber
         ,@inputEmployeeLastName
         ,@inputEmployeeFirstName
         ,@inputEmployeeDob
         ,'The EmotionalHealthActivitiesCategoryPoints, the sum of HeadspacePoints and SupportLincEapPoints, ' + CONVERT([nvarchar] (10), @EmotionalHealthActivitiesCategoryPoints) + ' exceeds the maximum of 100.'
         ,CONVERT([nvarchar] (50), @currentTimestamp, 121)
       );

       -- Category Group Level Check Failure
       SET @CategoryGroupLevelChecksPassed = 0;

    END
    
    SET @ActualRecordCount = @@ROWCOUNT
    EXEC Admin.Utilities.logs.di_Batch @BatchOutID OUTPUT,  @BatchOutID, 'DetailEnd', NULL, NULL, NULL, @AnticipatedRecordCount, @ActualRecordCount
----------------------------------------------------------------------------------------------------------------------------------------------------
    IF (@CategoryGroupLevelChecksPassed = 1) BEGIN
      SET @SumOfAllCategoriesPoints = 
         @HealthyMeasuresAndLifestyleTargetsCategoryPoints +
         @PortalActivitiesCategoryPoints +
         @WellnessChallengesCategoryPoints +
         @SummitHealthPlanEnrolleeOfferingsCategoryPoints +
         @EmotionalHealthActivitiesCategoryPoints;       
----------------------------------------------------------------------------------------------------------------------------------------------------
    SET @BatchDetailDescription = '340/340:  SumOfAllCategoriesPoints <> PointTotal'
    EXEC Admin.Utilities.logs.di_Batch @BatchOutID OUTPUT,  @BatchOutID, 'DetailStart', @BatchDetailDescription
	
    -- CategoryGroupLevelCheck SumOfAllCategoriesPoints <> PointTotal
    IF (@SumOfAllCategoriesPoints <> @PointTotal) BEGIN
       SELECT @AnticipatedRecordCount = 1;
      
       INSERT INTO [DS_SummitLife].[dbo].[DailyReportAssetIncentiveStatusError]
       (
           [EmployeeNumber]
           ,[EmployeeLastName]
           ,[EmployeeFirstName]
           ,[EmployeeDob]
           ,[ErrorMessage]
           ,[DataGatheredOnTimestamp]
       )
       VALUES
       (
          @inputEmployeeNumber
         ,@inputEmployeeLastName
         ,@inputEmployeeFirstName
         ,@inputEmployeeDob
         ,'The sum of all points categories, ' + CONVERT([nvarchar] (10), @SumOfAllCategoriesPoints) + ' does not equal PointTotal from the Asset Incentive Points Status Report, ' + CONVERT([nvarchar] (10), @PointTotal) + '.'
         ,CONVERT([nvarchar] (50), @currentTimestamp, 121)
       );

       -- Category Group Level Check Failure
       SET @CategoryGroupLevelChecksPassed = 0;

    END
    
    SET @ActualRecordCount = @@ROWCOUNT
    EXEC Admin.Utilities.logs.di_Batch @BatchOutID OUTPUT,  @BatchOutID, 'DetailEnd', NULL, NULL, NULL, @AnticipatedRecordCount, @ActualRecordCount
----------------------------------------------------------------------------------------------------------------------------------------------------

    END
END
END

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