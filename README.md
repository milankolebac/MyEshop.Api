##  Eshop Web API study project ##

**Eshop Web API** is small project to learn how to use Web API with other supporting technologies for them


### Used technolgies ###

- NET Core Web API
- NET Core Mvc Versioning
- Entity Framework InMemory
- Swashbuckle framework 
- xUnit


### Endpoints ###

API contain one controller with 3 methods, works with **Product** model

 - Get 		- Retrieves all product items
 - Get{id}  - Retrieves a specific product by Id
 - Put{id}	- Update description of specific product

###### Swagger description

	https://../swagger/index.html 


### Prerequisites

Just download solution, open it in Visual Studio and run project MyEshop.Api.

No other settings needed.

 
### Using sample

	GET https://../api/v1/Product/1 - get product with Id = 1
	GET https://../api/v1/Product	- get all products 


### Unit tests

Tests are in MyEshop.ApiTests project.

To run tests with Visual Studion use Test explorer ('go to Test > Test Explorer') and click the Run All.
