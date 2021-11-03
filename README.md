# TaxCalculator

## Problem description
A company is struggling with an internal API that currently has no support and is not up to date. There is a
plan to develop a proper REST API following DDD principles; but, as current API is not providing correct
results, you have been assigned to replace the existing one with correct logic implementation.
The API is simple: a POST request that receives as the body an order with item lines associated. It provides,
as a result, the taxes calculation of the items and the order.
The taxes calculation returned as part of the result are:

Relevant fields for Item Tax calculation:

* PricePerUnit: Cost of a single unit of the product.
* Units: Number of units.
* Type: Item type that indicates the tax percentage that needs to be applied.
* * If the value of is 1 ->Apply 25% Tax
* * If the value of is 2 ->Apply 0% Tax

For each item provided in the request, taxes need to be applied with the logic:
* The result should contain the following calculated fields:
* * Subtotal : Price per unit multiplied by the number of units
* * VATPercentage: Percentage to be applied (for 25% of tax, this field should return25)
* * TotalWithVat: Subtotal + Taxes applied to the item line. (For 25% VAT andsubtotal of 100, TotalWithVat = 125)

The order Total field is the sum of each item applying VAT (TotalWithVat field in the result)

Considerations
* The tax calculation of Items and Order should be unit tested.
* The user’s input should not be trusted. The following rules must be applied:
* Order
* * OrderId : Required. Maximum length of 10
* Item
* * Code : Required. Maximum length of 10
* * Units: Positive Integer. Required
* * PricePerUnit: Numeric with 2 decimal values. Required
* * Type: Optional. Possible values: 1 or 2. If no value is provided, type 1 should be automatically set for the item.
* If any validation rule is violated, return a BadRequest as http status and a generic error message(no need to specify the rule which has been violated)

In the future, this API will be upgraded and extended following DDD principles. It will also save the results
in a database. Input and output might be different in the new API version.
Follow the best practices that you consider that will facilitate this update.

### Sample Input
```sh
{
 "orderId": "NewOrder",
 "items": [
 {
 "code": "ItemA1",
 "units": 6,
 "pricePerUnit": 2.5,
 "type": 1
 },
 {
 "code": "ItemA2",
 "units": 12,
 "pricePerUnit": 5,
 "type": 2
 }
 ]
}
```

### Sample Output
```sh
{
 "orderId": "NewOrder",
 "items": [
 {
 "code": "ItemA1",
 "units": 6,
 "pricePerUnit": 2.5,
 "type": 1,
 "subtotal": 15,
 "vatPercentage": 25,
 "totalWithVat": 18.75
 },
 {
 "code": "ItemA2",
 "units": 12,
 "pricePerUnit": 5,
 "type": 2,
 "subtotal": 60,
 "vatPercentage": 0,
 "totalWithVat": 60
 }
 ],
 "total": 78.75
}
```

## Solution 
The system was designed to provide solution to the problem following the criteria described below:
* Applied MS unit Testing for the models described.
* Used enumerator pattern to limit the choices from the request when sending a type for the item.
* Used Command pattern to reflect the actions requested by the clients. If a new operation should be added to the solution, the coder would only need to create a new class that implements abstract class Command and an Invoker class.
* Used fluentvalidation to perform validations for the models mentioned in the description.
* Created a proposal using sql server (code first) database along with migrations to store the orders process results (at the moment it is only able to read dummy data).
* * Create a database called `TaxCalculator` and/or modify connection strings as needed.

* * Connection strings are located in `appsettings.json > ConnectionStrings`

* * Make sure you have the `dotnet ef` tool for dotnet CLI. If not, install like this:
```sh
dotnet tool install dotnet-ef -g
```
To implement the migration into the data base use the following command in the package manager console
```
Update-Database
```
  
## TODO
* Add configurators to further specify the db tables columns.
* Separate the context from the controller using mediator pattern.
* Apply Guid id for entities.
