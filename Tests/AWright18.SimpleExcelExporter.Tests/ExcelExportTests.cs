﻿using System.Collections.Generic;
using AWright18.SimpleExcelExporter;
using Xunit;

namespace SampleExcelExporter.Tests
{
    public class ExcelExportTests
    {
        public class TestRecord
        {
            public TestRecord(string name, string value)
            {
                Name = name;
                Value = value;
            }

            public string Name { get; set; }
            public string Value { get; set; }
        }

        private IEnumerable<TestRecord> GetSampleTestRecords()
        {
            return new TestRecord[]
            {
                new TestRecord("Joe", "is cool"),
                new TestRecord("Suzy", "sells sea shells")
            };
        }

        [Fact]
        public void CanExportRecordsToExcel()
        {
            var testRecords = GetSampleTestRecords();

            ExcelDocumentCreater.SaveRecordsToExcelWorksheet("sample.xlsx", testRecords, (o) =>
            {
                o.WorksheetName = "Blah";
                o.HideColumn("Name");
                o.DoNotWriteColumn("Value");
                o.RenameColumn("Value","Yo");
            });
        }

        [Fact]
        public void CanExportRecordsToExcelUsingExtensionMethods()
        {
            var testRecords = GetSampleTestRecords();

            testRecords.SaveRecordsToExcelWorksheet("sample.xlsx", (o) =>
            {
                o.WorksheetName = "Blah";
                o.HideColumn("Name");
                o.DoNotWriteColumn("Value");
                o.RenameColumn("Value", "Yo");
            });
        }

        [Fact]
        public void CanExportRecordsToSameFile()
        {
            var testRecords = GetSampleTestRecords();

            testRecords.SaveRecordsToExcelWorksheet("sample.xlsx");
            testRecords.SaveRecordsToExcelWorksheet("sample.xlsx");
        }

    }
}
