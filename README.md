# API_ShopBridge

To run the API locally, you can follow these steps:

Install the .NET 6 SDK on your machine. You can download it here: https://dotnet.microsoft.com/download/dotnet/6.0

Clone the project repository on your local machine. Make sure you have an up-to-date copy of the source code.

Open a terminal or command prompt in the project's root folder.

Run the following command to restore project dependencies:

dotnet restore

Then run the command below to compile the project:


dotnet construction

If the build is successful, you can run an API using the following command:


dotnet run --project <path to project>

Be sure to replace "<path to project>" with the relative or absolute path to your API project file.

The API will now be running locally on your computer. You can access it in your browser or an API testing tool using the address: http://localhost:5000.

To stop the API from running, just press Ctrl + C in the terminal or command prompt where the API is running.
You will need to add a connectionstring and set password and login to generate Jwt Token.

  To test the API online at the following link: https://shopbridgeapi.azurewebsites.net/swagger , you can ask the API developer for login and password.
  
  Diagram:
  ![alt text](https://github.com/ArielLopes888/API_ShopBridge/blob/master/Diagram%20Flow.jpeg)
