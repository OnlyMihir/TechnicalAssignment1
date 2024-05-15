# TechnicalAssignment1

### Problem Statement:
XYZ(**Company name intentionally hidden**) LLP – Backend coding challenge

Welcome to XYZ LLP’s backend coding challenge. Please review this
document and submit your solution.

Your Task:<br />
We would like you to build a simple e-commerce API with a single endpoint that performs a checkout action. The single endpoint should take a list of Items and return the total cost.<br />
Product Catalogue:<br />
Below is the catalog of the four Products and their associated prices.<br /><br />
Id Name Unit price Discount<br />
001 Item1 100 3 for 200<br />
002 Item2 80 2 for 120<br />
003 Item3 50<br />
004 Item4 30<br />

There are a few requirements worth noting here:<br />
1.) The first two products have a possible discount. As an example, if the user attempts to check out three or six item1s then they will receive the discount price once or twice, respectively.<br />
2.) There is no limit to the number of items or combinations of products a user can check out.<br />
3.) There is no limit to the number of times a discount can be used.<br />
4.) Similarly, a user can check out a single item if they wish.<br />

Endpoint reference
As a further guideline here’s an endpoint definition that you can use to design your API endpoint.

Request:<br />
Post: http://localhost:8080/checkout<br />
#Headers<br />
Accept: Application/json<br />
Content-Type: application/json<br />
#Body<br />
[<br />
“001”,<br />
“002”,<br />
“001”,<br />
“004”,<br />
“003”<br />
]<br />

Response:<br />
#Headers<br />
Content-Type: application/json.<br />
#Body<br />
{“Price”: 360}<br />

Our Expectations:<br />
We expect this task to be completed within 1 day but we purposefully don’t specify a hard time limit. This is because we don’t want to impose an unnecessarily stressful deadline. How you approach the problem is more important to us than completing the challenge, therefore we expect you to include the following.<br />
1.) A README that documents how to set up and run the application, how you approached it, and what would you improve.<br />
2.) We expect you to submit your solution via GitHub public repository, which includes your GIT commit history. That provides us with a view of how you break down problems and how you work.<br />
3.) Automated Testing is an important part of how we work here at XYZ LLP and we expect you to include some in your solution.<br />

How we review:<br />
When reviewing your solution we try to make sure we are consistent in our evolution by following five core themes.<br />
1.) Correctness: We don’t expect you to handle all the possible edge cases, but we expect the solution to adhere to the core requirements in this document.<br />
2.) Documentation: For us, this is more about including a clear and concise README and the commit history and less about converting the code base in comments.<br />
3.) Testing: We also evaluate your approach to automated testing and whether there’s a reasonable mix of functional (or integration) tests and unit tests.<br />
4.) Readability: Writing code in a team requires having empathy for how other team members will interpret that code. Here we look for things like duplication, method names, variable names, and consistency.<br />
5.) Application architecture: We look at whether the solution follows a conventional architecture based on the language and framework. We also expect to see some modularization with a few separate components that have clear responsibilities.<br />

Questions we may ask:<br />
1.) What framework(s) did you use to implement the app? Why did you choose them?<br />
2.) What would you add or do differently if you had more time?<br />
3.) Where would you deploy this app and why? Which option do you prefer over others?<br />
4.) What testing did you do and why?<br />

Thank you for reading and thanks for taking part in our interview process. We look forward to receiving your solution.<br />
- The engineering team @XYZ LLP<br />

### Problem Solution:<br />
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
