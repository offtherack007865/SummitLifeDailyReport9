-- SQL Server Instance: smg-sql01
IF (@@SERVERNAME <> 'smg-sql01')
BEGIN
PRINT 'Invalid SQL Server Connection'
RETURN
END

USE [BulkInsert8];

-- STEP 1 OF 6
-- Change ELIZABETH BUMBY's FormSubmission SSN from 000-00-0000 to 415-47-6097
SELECT COUNT(*)
FROM [DS_SummitLife].[dbo].[SummitLifeBiometricScreeningFormSubmission]
WHERE [Pk] = 5923;

--BEGIN TRAN
UPDATE [DS_SummitLife].[dbo].[SummitLifeBiometricScreeningFormSubmission]
SET [SSN] = '415-47-6097'
WHERE [Pk] = 5923;


-- COMMIT TRAN
-- ROLLBACK TRAN
-----------------------------------------------------------------------------------------------
-- STEP 2 OF 6
-- Change CAROLINE PAYSON's FormSubmission LastName from ADAMS to PAYSON
SELECT COUNT(*)
FROM [DS_SummitLife].[dbo].[SummitLifeBiometricScreeningFormSubmission]
WHERE [Pk] = 5689;

--BEGIN TRAN
UPDATE [DS_SummitLife].[dbo].[SummitLifeBiometricScreeningFormSubmission]
SET [LastName] = 'PAYSON'
WHERE [Pk] = 5689;


-- COMMIT TRAN
-- ROLLBACK TRAN
-----------------------------------------------------------------------------------------------
-- STEP 3 OF 6
-- Change MOLLIE HOOK's FormSubmission LastName from DOWLAND to HOOKS
SELECT COUNT(*)
FROM [DS_SummitLife].[dbo].[SummitLifeBiometricScreeningFormSubmission]
WHERE [Pk] = 5581;

--BEGIN TRAN
UPDATE [DS_SummitLife].[dbo].[SummitLifeBiometricScreeningFormSubmission]
SET [LastName] = 'HOOKS'
WHERE [Pk] = 5581;


-- COMMIT TRAN
-- ROLLBACK TRAN
-----------------------------------------------------------------------------------------------
-- STEP 4 OF 6
-- Change STEPHANIE WASSUM's FormSubmission LastName from HELTON to WASSUM
SELECT COUNT(*)
FROM [DS_SummitLife].[dbo].[SummitLifeBiometricScreeningFormSubmission]
WHERE [Pk] = 3866;

--BEGIN TRAN
UPDATE [DS_SummitLife].[dbo].[SummitLifeBiometricScreeningFormSubmission]
SET [LastName] = 'WASSUM'
WHERE [Pk] = 3866;


-- COMMIT TRAN
-- ROLLBACK TRAN
-----------------------------------------------------------------------------------------------
-- STEP 5 OF 6
-- Change LISA BAUGHMAN's FormSubmission LastName from WEAVER to BAUGHMAN
SELECT COUNT(*)
FROM [DS_SummitLife].[dbo].[SummitLifeBiometricScreeningFormSubmission]
WHERE [Pk] = 2691;

--BEGIN TRAN
UPDATE [DS_SummitLife].[dbo].[SummitLifeBiometricScreeningFormSubmission]
SET [LastName] = 'BAUGHMAN'
WHERE [Pk] = 2691;


-- COMMIT TRAN
-- ROLLBACK TRAN
-----------------------------------------------------------------------------------------------
-- STEP 6 OF 6
-- Delete older record for JANE HUTTON's 2025 FormSubmission
SELECT COUNT(*)
FROM [DS_SummitLife].[dbo].[SummitLifeBiometricScreeningFormSubmission]
WHERE [Pk] = 5895;

--BEGIN TRAN
DELETE [DS_SummitLife].[dbo].[SummitLifeBiometricScreeningFormSubmission]
WHERE [Pk] = 5895;


-- COMMIT TRAN
-- ROLLBACK TRAN
-----------------------------------------------------------------------------------------------
