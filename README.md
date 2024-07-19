# FizzBuzz API
This is a simple ASP.NET Core Web API that processes an array of values and applies FizzBuzz logic.

Getting Started

Prerequisites

.NET 8 SDK

Visual Studio 2022

Running the Application

Clone the repository:

bash

Copy code

git clone https://github.com/sireesha17-maker/FizzBuzzAppMain/tree/main

Open the solution in Visual Studio.

Press F5 to run the application.

Testing with Postman

Start the application.

Open Postman.

Create a POST request to https://localhost:7040/api/fizzbuzz.

In the body, select raw and JSON and enter the following array:

json

Copy code

["1", "3", "5", "15", ""]

Send the request and verify the response.

Running Unit Tests

Open the Test Explorer in Visual Studio:

Go to Test > Test Explorer.

Run All Tests:

Click on Run All in the Test Explorer.

Testing with Swagger

Navigate to https://localhost:7040/swagger to use the Swagger UI to test the API.

Select the POST endpoint for the FizzBuzz API.

In the Try it out section, provide the following JSON:

json

Copy code

["1", "3", "5", "15", ""]

Click Execute and verify the response.

Authors

Venkata Anu Sireesha

License

This is a Test Project

