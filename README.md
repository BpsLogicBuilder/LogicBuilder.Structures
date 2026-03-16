# LogicBuilder.Structures

[![CI](https://github.com/BpsLogicBuilder/LogicBuilder.Structures/actions/workflows/ci.yml/badge.svg)](https://github.com/BpsLogicBuilder/LogicBuilder.Structures/actions/workflows/ci.yml)
[![CodeQL](https://github.com/BpsLogicBuilder/LogicBuilder.Structures/actions/workflows/github-code-scanning/codeql/badge.svg)](https://github.com/BpsLogicBuilder/LogicBuilder.Structures/actions/workflows/github-code-scanning/codeql)
[![codecov](https://codecov.io/gh/BpsLogicBuilder/LogicBuilder.Structures/graph/badge.svg?token=UAV0UB5NLC)](https://codecov.io/gh/BpsLogicBuilder/LogicBuilder.Structures)
[![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=BpsLogicBuilder_LogicBuilder.Structures&metric=alert_status)](https://sonarcloud.io/summary/new_code?id=BpsLogicBuilder_LogicBuilder.Structures)
[![NuGet](https://img.shields.io/nuget/v/LogicBuilder.Structures.svg)](https://www.nuget.org/packages/LogicBuilder.Structures)

A comprehensive metadata library for building dynamic LINQ expressions through descriptors. This library provides a rich set of classes that represent expression components, enabling the construction of complex LINQ queries from serializable metadata structures.

## Purpose

LogicBuilder.Structures serves as the metadata foundation for the LogicBuilder.Expressions framework. Instead of writing LINQ expressions directly in code, developers can:

1. **Define expressions as metadata** using descriptor classes
2. **Serialize and store** query definitions independent of code
3. **Dynamically build** LINQ Expression Trees at runtime
4. **Support data-driven** query scenarios where query logic comes from configuration or user input

## Key Features

### Expression Building Blocks

- **Binary Operations**: `EqualsBinaryDescriptor`, `GreaterThanBinaryDescriptor`, `LessThanBinaryDescriptor`, etc.
- **Logical Operations**: `AndBinaryDescriptor`, `OrBinaryDescriptor`, `NotDescriptor`
- **Arithmetic Operations**: `AddBinaryDescriptor`, `SubtractBinaryDescriptor`, `MultiplyBinaryDescriptor`, `DivideBinaryDescriptor`, `ModuloBinaryDescriptor`

### Queryable Operations

- **Filtering**: `WhereDescriptor`, `AnyDescriptor`, `AllDescriptor`
- **Projection**: `SelectDescriptor`, `SelectManyDescriptor`
- **Ordering**: `OrderByDescriptor`, `ThenByDescriptor`
- **Aggregation**: `CountDescriptor`, `SumDescriptor`, `AverageDescriptor`, `MinDescriptor`, `MaxDescriptor`
- **Paging**: `SkipDescriptor`, `TakeDescriptor`
- **Grouping**: `GroupByDescriptor`
- **Element Access**: `FirstDescriptor`, `LastDescriptor`, `SingleDescriptor`, and their `OrDefault` variants

### Collection Operations

- **Set Operations**: `UnionDescriptor`, `ConcatDescriptor`, `ExceptDescriptor`
- **Collection Tests**: `AnyDescriptor`, `AllDescriptor`, `ContainsDescriptor`

### String Functions

- `SubstringDescriptor`, `ContainsDescriptor`, `StartsWithDescriptor`, `EndsWithDescriptor`
- `ToUpperDescriptor`, `ToLowerDescriptor`, `TrimDescriptor`
- `LengthDescriptor`, `IndexOfDescriptor`, `ConcatDescriptor`

### Date/Time Functions

- Component extraction: `YearDescriptor`, `MonthDescriptor`, `DayDescriptor`, `HourDescriptor`, `MinuteDescriptor`, `SecondDescriptor`
- Conversions: `ConvertToNumericDateDescriptor`, `ConvertToNumericTimeDescriptor`
- Fractional seconds: `FractionalSecondsDescriptor`

### Math Functions

- `FloorDescriptor`, `CeilingDescriptor`, `RoundDescriptor`

### Type Operations

- **Casting**: `CastDescriptor`, `ConvertDescriptor`, `CollectionCastDescriptor`
- **Type Checking**: `IsOfDescriptor`
- **Conversions**: `ConvertToStringDescriptor`, `ConvertToEnumDescriptor`, `ConvertToNullableUnderlyingValueDescriptor`

### Member Access

- `MemberSelectorDescriptor` - Access properties and fields
- `ParameterDescriptor` - Define lambda parameters
- `ConstantDescriptor` - Represent constant values
- `CollectionConstantDescriptor` - Represent collection constants

### Custom Operations

- `CustomMethodDescriptor` - Call custom methods on types
- `MemberInitDescriptor` - Initialize anonymous types or objects


## Integration

Works seamlessly with **LogicBuilder.Expressions.Utils** to:
- Map descriptors to LINQ Expression Trees via AutoMapper
- Execute dynamic queries against Entity Framework, LINQ to Objects, and other LINQ providers
- Build complex filtering, sorting, paging, and aggregation logic from configuration

## Supported Scenarios

- **OData-style filtering** with complex predicates
- **Dynamic reporting queries** with runtime-defined aggregations
- **Configurable business rules** expressed as queryable filters
- **User-defined search criteria** converted to type-safe LINQ expressions
- **Multi-tenant filtering** applied dynamically based on context

## Benefits

1. **Serializable**: All descriptors are POCOs that can be JSON/XML serialized
2. **Type-safe**: Generates strongly-typed LINQ expressions at runtime
3. **Testable**: Expression logic can be unit tested through descriptors
4. **Maintainable**: Query logic separated from code into data structures
5. **Extensible**: Custom descriptors can be added for domain-specific needs

## Related Libraries

- **LogicBuilder.Expressions.Utils**: Descriptors can be converted to their corresponding operators which generate executable LINQ expressions
- **LogicBuilder.EntityFrameworkCore.SqlServer**: Entity Framework integration and testing
