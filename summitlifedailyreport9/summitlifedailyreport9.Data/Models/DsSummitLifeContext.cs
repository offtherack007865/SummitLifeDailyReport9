using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace summitlifedailyreport9.Data.Models;

public partial class DsSummitLifeContext : DbContext
{
    public DsSummitLifeContext(DbContextOptions<DsSummitLifeContext> options)
        : base(options)
    {
        string projectPath = AppDomain.CurrentDomain.BaseDirectory;
        IConfigurationRoot configuration =
            new ConfigurationBuilder()
                .SetBasePath(projectPath)
        .AddJsonFile(MyConstants.AppSettingsFile)
        .Build();
        Database.SetCommandTimeout(9000);
        MyConnectionString =
            configuration.GetConnectionString(MyConstants.ConnectionString);
    }

    public string MyConnectionString { get; set; }

    public virtual DbSet<di_PopulateDailyReportMissingBiosOutputColumns> di_PopulateDailyReportMissingBiosOutputColumnsList { get; set; }
    public virtual DbSet<di_PopulateDailyReportMissingLabsOutputColumns> di_PopulateDailyReportMissingLabsOutputColumnsList { get; set; }
    public virtual DbSet<di_PopulateDailyReportPastApptScheduleEntriesWithNoBiometricsOutputColumns> di_PopulateDailyReportPastApptScheduleEntriesWithNoBiometricsOutputColumnsList { get; set; }
    public virtual DbSet<di_PopulateDailyReportPastApptScheduleEntriesWithNoBiosAndNoLabsOutputColumns> di_PopulateDailyReportPastApptScheduleEntriesWithNoBiosAndNoLabsOutputColumnsList { get; set; }
    public virtual DbSet<di_PopulateDailyReportPastApptScheduleEntriesWithNoLabsOutputColumns> di_PopulateDailyReportPastApptScheduleEntriesWithNoLabsOutputColumnsList { get; set; }
    public virtual DbSet<di_PopulateDailyReportPhysicianFormsOutputColumns> di_PopulateDailyReportPhysicianFormsOutputColumnsList { get; set; }
    public virtual DbSet<qy_GetDailyReportPhysicianFormsOutputColumns> qy_GetDailyReportPhysicianFormsOutputColumnsList { get; set; }
    public virtual DbSet<qy_GetDailyReportMissingLabsOutputColumns> qy_GetDailyReportMissingLabsOutputColumnsList { get; set; }
    public virtual DbSet<qy_GetDailyReportMissingBiosOutputColumns> qy_GetDailyReportMissingBiosOutputColumnsList { get; set; }
    public virtual DbSet<qy_GetDailyReportPastApptScheduleEntriesWithNoBiometricsOutputColumns> qy_GetDailyReportPastApptScheduleEntriesWithNoBiometricsOutputColumnsList { get; set; }
    public virtual DbSet<qy_GetDailyReportPastApptScheduleEntriesWithNoBiosAndNoLabsOutputColumns> qy_GetDailyReportPastApptScheduleEntriesWithNoBiosAndNoLabsOutputColumnsList { get; set; }
    public virtual DbSet<qy_GetDailyReportPastApptScheduleEntriesWithNoLabsOutputColumns> qy_GetDailyReportPastApptScheduleEntriesWithNoLabsOutputColumnsList { get; set; }
    public virtual DbSet<di_PopulateDailyReportMissingPatientIDsInLabsOutputColumns> di_PopulateDailyReportMissingPatientIDsInLabsOutputColumnsList { get; set;  }
    public virtual DbSet<qy_GetDailyReportConfigOutputColumns> qy_GetDailyReportConfigOutputColumnsList { get; set; }
    public virtual DbSet<di_PopulateDailyReportDupEmpNbrSsnCombosOutputColumns> di_PopulateDailyReportDupEmpNbrSsnCombosOutputColumnsList { get; set; }
    public virtual DbSet<di_PopulateDailyReportEmployeesInAssetFilesThisYearOutputColumns> di_PopulateDailyReportEmployeesInAssetFilesThisYearOutputColumnsList { get; set; }
    public virtual DbSet<di_PopulateDailyReportEmployeesInAssetFileThisWeekSoFarOutputColumns> di_PopulateDailyReportEmployeesInAssetFileThisWeekSoFarOutputColumnsList { get; set; }
    public virtual DbSet<di_PopulateDailyReportSsnNameDobDifferencesOutputColumns> di_PopulateDailyReportSsnNameDobDifferencesOutputColumnsList { get; set;  }
    public virtual DbSet<di_PopulateDailyReportSsnsNotListedInAllEmployeesListOutputColumns> di_PopulateDailyReportSsnsNotListedInAllEmployeesListOutputColumnsList { get; set; }
    public virtual DbSet<qy_GetDailyReportDupEmpNbrSsnCombosOutputColumns> qy_GetDailyReportDupEmpNbrSsnCombosOutputColumnsList { get; set; }
    public virtual DbSet<qy_GetDailyReportEmployeesInAssetFilesThisYearOutputColumns> qy_GetDailyReportEmployeesInAssetFilesThisYearOutputColumnsList { get; set; }
    public virtual DbSet<qy_GetDailyReportEmployeesInAssetFileThisWeekSoFarOutputColumns> qy_GetDailyReportEmployeesInAssetFileThisWeekSoFarOutputColumnsList { get; set; }
    public virtual DbSet<qy_GetDailyReportSsnNameDobDifferencesOutputColumns> qy_GetDailyReportSsnNameDobDifferencesOutputColumnsList { get; set; }
    public virtual DbSet<qy_GetDailyReportSsnsNotListedInAllEmployeesListOutputColumns> qy_GetDailyReportSsnsNotListedInAllEmployeesListOutputColumnsList { get; set; }
    public virtual DbSet<di_DailyReportAssetIncentiveStatusErrorForAllEmployeesOutputColumns> di_DailyReportAssetIncentiveStatusErrorForAllEmployeesOutputColumnsList { get; set; }
    public virtual DbSet<qy_DailyReportAssetIncentiveStatusErrorForAllEmployeesOutputColumns> qy_DailyReportAssetIncentiveStatusErrorForAllEmployeesOutputColumnsList { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<qy_DailyReportAssetIncentiveStatusErrorForAllEmployeesOutputColumns>(entity =>
        {
            entity.HasNoKey();
        });

        modelBuilder.Entity<di_DailyReportAssetIncentiveStatusErrorForAllEmployeesOutputColumns>(entity =>
        {
            entity.HasNoKey();
        });


        modelBuilder.Entity<qy_GetDailyReportSsnsNotListedInAllEmployeesListOutputColumns>(entity =>
        {
            entity.HasNoKey();
        });

        modelBuilder.Entity<qy_GetDailyReportSsnNameDobDifferencesOutputColumns>(entity =>
        {
            entity.HasNoKey();
        });

        modelBuilder.Entity<qy_GetDailyReportEmployeesInAssetFileThisWeekSoFarOutputColumns>(entity =>
        {
            entity.HasNoKey();
        });

        modelBuilder.Entity<qy_GetDailyReportEmployeesInAssetFilesThisYearOutputColumns>(entity =>
        {
            entity.HasNoKey();
        });

        modelBuilder.Entity<qy_GetDailyReportDupEmpNbrSsnCombosOutputColumns>(entity =>
        {
            entity.HasNoKey();
        });

        modelBuilder.Entity<di_PopulateDailyReportSsnsNotListedInAllEmployeesListOutputColumns>(entity =>
        {
            entity.HasNoKey();
        });

        modelBuilder.Entity<di_PopulateDailyReportSsnNameDobDifferencesOutputColumns>(entity =>
        {
            entity.HasNoKey();
        });

        modelBuilder.Entity<di_PopulateDailyReportEmployeesInAssetFileThisWeekSoFarOutputColumns>(entity =>
        {
            entity.HasNoKey();
        });

        modelBuilder.Entity<di_PopulateDailyReportEmployeesInAssetFilesThisYearOutputColumns>(entity =>
        {
            entity.HasNoKey();
        });

        modelBuilder.Entity<di_PopulateDailyReportDupEmpNbrSsnCombosOutputColumns>(entity =>
        {
            entity.HasNoKey();
        });

        modelBuilder.Entity<qy_GetDailyReportConfigOutputColumns>(entity =>
        {
            entity.HasNoKey();
        });

        modelBuilder.Entity<di_PopulateDailyReportMissingPatientIDsInLabsOutputColumns>(entity =>
        {
            entity.HasNoKey();
        });

        modelBuilder.Entity<qy_GetDailyReportPastApptScheduleEntriesWithNoLabsOutputColumns>(entity =>
        {
            entity.HasNoKey();
        });

        modelBuilder.Entity<qy_GetDailyReportPastApptScheduleEntriesWithNoBiosAndNoLabsOutputColumns>(entity =>
        {
            entity.HasNoKey();
        });
        modelBuilder.Entity<qy_GetDailyReportPastApptScheduleEntriesWithNoBiometricsOutputColumns>(entity =>
        {
            entity.HasNoKey();
        });

        modelBuilder.Entity<qy_GetDailyReportMissingBiosOutputColumns>(entity =>
        {
            entity.HasNoKey();
        });

        modelBuilder.Entity<qy_GetDailyReportMissingLabsOutputColumns>(entity =>
        {
            entity.HasNoKey();
        });

        modelBuilder.Entity<qy_GetDailyReportPhysicianFormsOutputColumns>(entity =>
        {
            entity.HasNoKey();
        });

        modelBuilder.Entity<di_PopulateDailyReportPhysicianFormsOutputColumns>(entity =>
        {
            entity.HasNoKey();
        });

        modelBuilder.Entity<di_PopulateDailyReportPastApptScheduleEntriesWithNoLabsOutputColumns>(entity =>
        {
            entity.HasNoKey();
        });

        modelBuilder.Entity<di_PopulateDailyReportPastApptScheduleEntriesWithNoBiosAndNoLabsOutputColumns>(entity =>
        {
            entity.HasNoKey();
        });

        modelBuilder.Entity<di_PopulateDailyReportPastApptScheduleEntriesWithNoBiometricsOutputColumns>(entity =>
        {
            entity.HasNoKey();
        });

        modelBuilder.Entity<di_PopulateDailyReportMissingLabsOutputColumns>(entity =>
        {
            entity.HasNoKey();
        });

        modelBuilder.Entity<di_PopulateDailyReportMissingBiosOutputColumns>(entity =>
        {
            entity.HasNoKey();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
