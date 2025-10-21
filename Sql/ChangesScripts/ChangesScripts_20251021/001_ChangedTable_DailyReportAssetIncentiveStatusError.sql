-- SQL Instance Name:  smg-sql01
USE [DS_SummitLife];

if (@@SERVERNAME != 'smg-sql01')
begin
print 'Invalid SQL Server Connection'
return
end

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'DailyReportAssetIncentiveStatusError' AND TABLE_SCHEMA = 'dbo')
   DROP TABLE [dbo].[DailyReportAssetIncentiveStatusError];
GO
/* -----------------------------------------------------------------------------------------------------------
   Table Name  :  dbo.DailyReportAssetIncentiveStatusError
   Business Analyis:
   Project/Process :   
   Description     :  Daily Report:   Errors detected in the Asset Incentive Status Report
                        
   Author          :   Philip Morrison
   Create Date     :   08/25/2025 

   ***********************************************************************************************************
   **         Change History                                                                                **
   ***********************************************************************************************************

   Date       Version    Author             Description
   --------   --------   -----------        ------------
   08/25/2025 1.01.001   Philip Morrison    Created
*/ -----------------------------------------------------------------------------------------------------------                                   


CREATE TABLE [dbo].[DailyReportAssetIncentiveStatusError](
	[DailyReportAssetIncentiveStatusErrorID] [int] IDENTITY(1,1) NOT NULL
    ,[EmployeeNumber] [nvarchar] (10) NOT NULL
    ,[EmployeeLastName] [nvarchar] (50) NOT NULL
    ,[EmployeeFirstName] [nvarchar] (50) NOT NULL
    ,[EmployeeDob] [datetime] NOT NULL
	,[ErrorMessage] [nvarchar](1000) NOT NULL    
	,[DataGatheredOnTimestamp] [nvarchar](100) NOT NULL
 CONSTRAINT [pk_dboDailyReportAssetIncentiveStatusError] PRIMARY KEY CLUSTERED 
(
	[DailyReportAssetIncentiveStatusErrorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


