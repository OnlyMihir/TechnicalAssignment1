# VoingTechChallenge

Approach taken:<br />
Created a new Solution named "VoingTechChallenge" and created a new .NET Core 6 Web API project insided named as "E-CommerceAPI".<br />
Created Dtos folder for taking items checkout controller request in json(ItemsCheckoutRequestDto) and send back response as a Dto(ItemsCheckoutResponseDto).<br />
Created Models folder which contains Product and Product Discount Offer Model.<br />
Created Interfaces, ICheckout interface contains all the methods that the CheckoutController would implement and IProductInfo interface contains methods to get all products and product discount offers data.<br />
Created Services folder which contains ProductInfoService, which contains the implementation of IProductInfo Interface.<br />
Created CheckoutController that inherits from ICheckout interface and thus implements all of it's methods. CheckoutController also creates an IProductInfo object for fetching all products and product discount offers data.<br />
In Program.cs file, we add IProductInfo Service. Ex-"builder.Services.AddTransient<IProductInfo, ProductInfoService>();"<br />
<br />
<br />
How to run this application:<br />
Download the code from this repo as a zip file or clone it using git cli.<br />
Open the "VoingTechChallenge.sln" solution file in Visual Studio. Make sure you have .NET 6 SDK support in your Visual Studio installtion.<br />
Start the applciation in debug mode from VS and it will open up Swagger page from where you can test the API or call the URL "https://localhost:xxxx/Checkout" which is a HttpPost method type API from Postman or any such similar application.<br />
<br />
Dummy Json Request Body:<br />
{<br />
  "itemIdList": [<br />
    1,1,1,2,3,4<br />
  ]<br />
}<br />
<br />
<br />
How to run the xUnit test project:<br />
Open the solution in VS and then from View Menu open Test Explorer. From there we can run the test cases.<br />
<br />
<br />
Improvements for future:<br />
Implement logging functionality into the applciation. We can use any modern framework like Serilog for this.<br />
Work on better exception handling. Currently there are some cases where exception handling is missing like let's say the item id passed is invalid or the length of item id array passed as json body to the API is empty.<br />
Write more test cases.<br />
<br />
<br />
Assumptions:<br />
There could only be one Discount offer for a give Product/Item.<br />
<br />
