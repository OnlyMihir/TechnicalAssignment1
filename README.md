# VoingTechChallenge

Approach taken:
Created a new Solution named "VoingTechChallenge" and created a new .NET Core 6 Web API project insided named as "E-CommerceAPI".
Created Dtos folder for taking items checkout controller request in json(ItemsCheckoutRequestDto) and send back response as a Dto(ItemsCheckoutResponseDto).
Created Models folder which contains Product and Product Discount Offer Model.
Created Interfaces, ICheckout interface contains all the methods that the CheckoutController would implement and IProductInfo interface contains methods to get all products and product discount offers data.
Created Services folder which contains ProductInfoService, which contains the implementation of IProductInfo Interface.
Created CheckoutController that inherits from ICheckout interface and thus implements all of it's methods. CheckoutController also creates an IProductInfo object for fetching all products and product discount offers data.
In Program.cs file, we add IProductInfo Service. Ex-"builder.Services.AddTransient<IProductInfo, ProductInfoService>();"


How to run this application:
Download the code from this repo as a zip file or clone it using git cli.
Open the "VoingTechChallenge.sln" solution file in Visual Studio. Make sure you have .NET 6 SDK support in your Visual Studio installtion.
Start the applciation in debug mode from VS and it will open up Swagger page from where you can test the API or call the URL "https://localhost:xxxx/Checkout" which is a HttpPost method type API from Postman or any such similar application.

Dummy Json Request Body:
{
  "itemIdList": [
    1,1,1,2,3,4
  ]
}


Improvements for future:
Implement logging functionality into the applciation. We can use any modern framework like Serilog for this.
Work on better exception handling. Currently there are some cases where exception handling is missing like let's say the item id passed is invalid or the length of item id array passed as json body to the API is empty.


Assumptions:
There could only be one Discount offer for a give Product/Item.
