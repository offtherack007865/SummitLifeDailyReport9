-- SQL Server Instance: smg-sql01
USE [DS_SummitLife];

-- Delete Duplicate Form Submission for KAREN HAYNES

  SELECT *
  FROM [DS_SummitLife].[dbo].[SummitLifeBiometricScreeningFormSubmission]
  WHERE [Pk] = 5084;
  -- 1 record 

BEGIN TRAN
  DELETE [DS_SummitLife].[dbo].[SummitLifeBiometricScreeningFormSubmission]
  WHERE [Pk] = 5084;
  -- 
-- COMMIT
-- ROLLBACK
-----------------------------------------------------------------------------------------------



-- UPDATE SSN for KAREN HAYNES to '412-27-3003' and EmployeeId to '000004786'

 SELECT SSN, [EmployeeId] 
 FROM [DS_SummitLife].[dbo].[SummitLifeBiometricScreeningFormSubmission]
 WHERE [Pk] = 5871;
 -- 1 record

BEGIN TRAN
  UPDATE [DS_SummitLife].[dbo].[SummitLifeBiometricScreeningFormSubmission]
  SET [Ssn] = '412-27-3003'
      ,[EmployeeId] = '000004786'
  WHERE [Pk] = 5871;

-- COMMIT
-- ROLLBACK 
----------------------------------------------------------------------------------

-- Delete Duplicate Form Submission for ANTHONY	MORTON

SELECT *
FROM [DS_SummitLife].[dbo].[SummitLifeBiometricScreeningFormSubmission]
WHERE [Pk] = 5453;
-- 1 record

BEGIN TRAN 
    DELETE [DS_SummitLife].[dbo].[SummitLifeBiometricScreeningFormSubmission]
    WHERE [Pk] = 5453;
-- COMMIT
-- ROLLBACK
---------------------------------------------------------------------------------

-- Delete Duplicate Form Submission for SARAH BROWN

SELECT *
FROM [DS_SummitLife].[dbo].[SummitLifeBiometricScreeningFormSubmission]
WHERE [Pk] = 5388;
-- 1 record
BEGIN TRAN 
    DELETE [DS_SummitLife].[dbo].[SummitLifeBiometricScreeningFormSubmission]
    WHERE [Pk] = 5388;
-- COMMIT
-- ROLLBACK
------------------------------------------------------------------------------




-- Delete Duplicate Form Submission for ERRIKA DOANE
SELECT *
FROM   [DS_SummitLife].[dbo].[SummitLifeBiometricScreeningFormSubmission]
WHERE [Pk] = 4981;
-- 1 records

BEGIN TRAN
      DELETE [DS_SummitLife].[dbo].[SummitLifeBiometricScreeningFormSubmission]
      WHERE [Pk] = 4981;
-- COMMIT
-- ROLLBACK
