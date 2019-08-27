# SentryOne Test
Samples and Examples for the SentryOne Test product

This repository contains sample projects and tests for [SentryOne Test](https://www.sentryone.com/products/sentryone-test).

## Build Status
Please note some builds are expected to fail to demonstrate what test failures look like in SentryOne Test.

| Build Type  |      Purpose      |  Status |
|----------|:-------------|:------|
| GUI Build  | Example GUI definition containing Test failures | [![Build Status](https://dev.azure.com/sentryone-demo/SentryOneTest-Samples/_apis/build/status/SentryOneTest-Samples-CI?branchName=master)](https://dev.azure.com/sentryone-demo/SentryOneTest-Samples/_build/latest?definitionId=1&branchName=master) |
| GUI Build  | Example GUI definition that is passing | [![Build Status](https://dev.azure.com/sentryone-demo/SentryOneTest-Samples/_apis/build/status/SentryOneTest-Samples-CI-no-failures?branchName=master)](https://dev.azure.com/sentryone-demo/SentryOneTest-Samples/_build/latest?definitionId=4&branchName=master) |
| YAML Build | Example YAML definition containing Test failures | [![Build Status](https://dev.azure.com/sentryone-demo/SentryOneTest-Samples/_apis/build/status/sentryone.sentryone-test-yaml?branchName=master)](https://dev.azure.com/sentryone-demo/SentryOneTest-Samples/_build/latest?definitionId=2&branchName=master) |
| YAML Build | Example YAML definition that is passing | [![Build Status](https://dev.azure.com/sentryone-demo/SentryOneTest-Samples/_apis/build/status/sentryone.sentryone-test-yaml-passing?branchName=master)](https://dev.azure.com/sentryone-demo/SentryOneTest-Samples/_build/latest?definitionId=3&branchName=master) |

## What's Included
This is a summary of the examples included in this repository.

| Location | Description |
| -------- | ----------- |
| /Recipes | An example of defining a custom SentryOne Test Recipe that can be used for simpler test creation. |
| /build   | Examples of Azure DevOps build pipelines that run tests from SentryOne Test assemblies. |
| /Samples/SsasTabularSample.Tests | A SQL Server Analysis Services tabular model test example. |
| /Samples/SsisSample.Tests | A SQL Server Integration Services example. |
| /Samples/WideWorldImporters.Tests | Examples of database to database comparison, flat file to database comparions, and data validate test cases using the WideWorldImporters sample databases. | 

## Using the Samples
Here are some requirements for using the samples:
* You will need the SentryOne Test Visual Studio Extension installed to use the samples. You can get a trial version of it from the [Visual Studio Marketplace](https://marketplace.visualstudio.com/items?itemName=sentryone.SentryOneTestClient).
* The samples were developed with Visual Studio 2019, but they should work in Visual Studio 2017 as well. They will work with the Community Editon of Visual Studio, as well as Professional and Enterprise.
* One of the samples uses SQL Server Integration Services. You will need to install the [SSIS extension](https://marketplace.visualstudio.com/items?itemName=SSIS.SqlServerIntegrationServicesProjects) if you are using Visual Studio 2019. If you are using Visual Studio 2017, you will need to install SQL Server Data Tools via the [stand-alone installer](https://docs.microsoft.com/en-us/sql/ssdt/download-sql-server-data-tools-ssdt?view=sql-server-2017#ssdt-for-vs-2017-standalone-installer) and make sure to select Integration Services.
* The [WideWorldImporters and WideWorldImportersDW databases](https://github.com/Microsoft/sql-server-samples/releases/tag/wide-world-importers-v1.0) are used for the relational data samples.
* The [AdventureWorks Internet Sales tabular model](https://github.com/Microsoft/sql-server-samples/releases/tag/adventureworks) are used as data sources for the tests.
