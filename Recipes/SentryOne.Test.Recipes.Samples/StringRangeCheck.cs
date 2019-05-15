namespace PragmaticWorks.LegiTest.Recipes.DataQuality
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using Contracts.Core;
    using Contracts.Runtime.Core;
    using Core.Actions;
    using Core.Assertions;
    using Core.Assets;
    using Core.Schema;
    using DataComparison.Validation;
    using Model;
    using Recipes.Fluent;
    using Runtime.Models;

    [Export(typeof(IRecipe))]
    public sealed class StringRangeCheck : Recipe
    {
        private const string RecipeName = "Range Check String";

        public override IIngredients ExpectedIngredients =>
            new Ingredients
            {
                Name = RecipeName,
                TestFramework = TestFrameworkType.NUnit,
                Connections =
                {
                    new
                        ConnectionAsset
                        {
                            Name = "SourceDb",
                            ProviderInvariantName = "System.Data.SqlClient",
                            ConnectionString = "DB Connection string",
                        },
                },
                TransientParameters =
                {
                    new TestSuiteParameter
                    {
                        Name = "InformationalColumnList",
                        Type = typeof(string),
                        Value = "List of columns to include for informational purposes",
                    },
                    new TestSuiteParameter
                    {
                        Name = "ColumnName",
                        Type = typeof(string),
                        Value = "Column to retrieve values to be range checked.",
                    },
                    new TestSuiteParameter
                    {
                        Name = "TableName",
                        Type = typeof(string),
                        Value = "Table to check",
                    },
                    new TestSuiteParameter
                    {
                        Name = "MaximumValue",
                        Type = typeof(string),
                        Value = "The maximum value for the range check.",
                    },
                    new TestSuiteParameter
                    {
                        Name = "MinimumValue",
                        Type = typeof(string),
                        Value = "The minimum value for the range check.",
                    },
                },
            };

        public override string Name => RecipeName;

        public override IRecipe Create()
        {
            return new StringRangeCheck();
        }

        public override bool ValidateIngredients(IIngredients ingredients, out IEnumerable<string> errors)
        {
            if (ingredients == null)
            {
                throw new ArgumentNullException(nameof(ingredients));
            }

            var localErrors = new List<string>();

            localErrors.AddRange(CompareIngredients(ExpectedIngredients, ingredients, false));

            errors = localErrors;
            return localErrors.Count == 0;
        }

        protected override void ProcessGroup(ITestSuite testSuite, ITestGroup testGroup, IIngredients ingredients, TestSuiteParameterSet transientParameters)
        {
            if (transientParameters == null)
            {
                throw new ArgumentNullException(nameof(transientParameters));
            }

            var validationManifest = new ValidationManifestAsset
            {
                Name = "Empty set validation manifest",
                Manifest = new ValidationManifest { EmptySetRequired = true },
            };

            var test = new Test { Name = RecipeName };

            var query = string.IsNullOrWhiteSpace(transientParameters.GetTypedParameter("InformationalColumnList", string.Empty)) ?
                transientParameters.ExpandParametersAndEnvironmentVariables("SELECT {{ColumnName}} FROM {{TableName}} WHERE {{ColumnName}} > '{{MaximumValue}}' OR {{ColumnName}} < '{{MinimumValue}}'") :
                transientParameters.ExpandParametersAndEnvironmentVariables("SELECT {{InformationalColumnList}}, {{ColumnName}} FROM {{TableName}} WHERE {{ColumnName}} > '{{MaximumValue}}' OR {{ColumnName}} < '{{MinimumValue}}'");

            AddAsset(
                test.Assets,
                validationManifest);
            AddAsset(
                test.Assets,
                new QueryAsset
                {
                    Name = "SourceQuery",
                    Query = query,
                });

            var loadGrid = new GridValidationAssertion
            {
                ValidationManifestUniqueId =
                    FindAssetId<ValidationManifestAsset>(ingredients, "Empty Set Validation Manifest"),
                Name = "Validate that the set is empty",
                GridResourceKey = "outOfRangeDataset",
            };

            var executionTrack = new TestExecutionTrack { Name = "Default" };

            executionTrack.AddStep(
                new ExecuteQueryGridAction
                {
                    Name = "Get rows that are out of range",
                    ConnectionAssetUniqueId = FindAssetId<ConnectionAsset>(ingredients, "SourceDb"),
                    QueryAssetUniqueId = FindAssetId<QueryAsset>(ingredients, "SourceQuery"),
                    TargetResourceKey = "outOfRangeDataset",
                });

            test.AddExecutionTrack(executionTrack);
            test.AddAssertion(
                loadGrid);

            validationManifest.GridProviderElementId = loadGrid.UniqueId;
            testGroup.Tests.Add(test);
        }
    }
}