# ASP.NET CORE API with JWT (JSON web token) and Master Detail - Employee registration API


## Description

This project is built using ASP.NET MVC, a popular framework for building web applications using the Model-View-Controller design pattern. It provides a structured way to build web applications, making it easier to manage complexity and keep code organized.
The system uses JWT (JSON Web Tokens) for authentication. JWT is a compact, URL-safe means of representing claims to be transferred between two parties. In the context of this project, when a user logs in with their credentials, the server generates a JWT that contains the user’s information and permissions, and sends it back to the client. The client then includes this token in the header of subsequent requests to authenticate themselves. This token-based system is stateless, meaning the server does not need to keep a record of past tokens, making it scalable and efficient.
The primary function of this system is employee registration. Users can create new employee records, which might include details such as name, position, department, and contact information. This could be used by businesses to keep track of their employees, or by HR departments to manage hiring and onboarding processes.
The system likely includes features for adding, viewing, updating, and deleting employee records, following the CRUD (Create, Read, Update, Delete) paradigm common in web applications. It may also include search and filter functionality to easily find specific employees based on various criteria.
Overall, this project represents a secure, efficient, and user-friendly way to manage employee data. It showcases the power of ASP.NET CORE API and JWT authentication in building robust web applications.
In this project, I've created a hypothetical scenario about a software where you can:

- Using JWT token based authentication system.
- Save Employee information.
- Add multiple Experiences that the employee had.
- Submit data using ASP.NET CORE API.
- Passing Image file/ Picture throught api.
- Using every data type to demonstrate REST api.
- Handle master-details relationships.


This project is intended to showcase the features and capabilities of ASP.NET CORE API with JWT token based authentication. Feel free to explore the code and provide any feedback or contributions.

## Installation
To install and run this project, follow these steps:
### Prerequisite
- You need **Postman** or other 3rd party software to test the api.
- You can download post man from https://www.postman.com/downloads/
- You nees Visual Studio (2019 or later).
- DOT NET 8.0 or later.

1. **Clone the repository**: Clone the repository to your local machine using the GitHub CLI command:

   ```shell
   gh repo clone Shahariar-Rokon/ASP.NET-CORE-API-with-JWT
   
  Alternatively, you can download the ZIP file from the GitHub repository page: https://github.com/Shahariar-Rokon/ASP.NET-CORE-API-with-JWT.git
  
2. Open the project in Visual Studio 2022: Open Visual Studio 2022 and select “Open a project or solution”. Navigate to the folder where you cloned or downloaded the repository and select the .sln file.
3. Restore the NuGet packages: Right-click on the solution in the Solution Explorer and select “Restore NuGet Packages”. This will install the required dependencies for the project.
4. Update the database connection string: In the appsettings.json file, update the DefaultConnection value with your database connection string. Make sure the database server is running and accessible.
5. Apply the database migrations: In the Package Manager Console, run the following command to apply the code first migrations and create the database schema:
`add-migration` then `Update-Database`.
6. This project is supposed to be moduler so I used localdb for this purpose.
7. **You need to add some data to the database as login information**. Go to View-->SqlObjectExplorer-->(localdb)MSSQLLocalDB-->Databases-->Your Database Name in my case it is CAPIV3DB-->Tables-->dbo.TblUser
![database](https://github.com/Shahariar-Rokon/ASP.NET-CORE-API-with-JWT/assets/116648090/ca3a35b3-087c-4df6-8b49-4635748fb8ea).
8. Add data to the **TblUser** table. In my case, I added Name:a, Email:a@gmail.com, Password: 1234, Date: 1/1/2024 12:00:00 AM and Fullname: a. You need to prepopulate this table for testing the authorization.
![usrname](https://github.com/Shahariar-Rokon/ASP.NET-CORE-API-with-JWT/assets/116648090/0f1a86f5-26b4-46e4-bbc7-68841317453d)
9. Run the project: Press F5 or click the “Run” button to launch the project in your browser.
## Usage

To use this project, follow these steps:

1. **Navigate to the app**: Open your browser and go to the URL where the app is hosted. For example, `https://localhost:44302/`. You can notice that the browser gives the REST apis. But when you go to test them, It will show **Unauthorized**.
2. **Interact with the app**:
   - Now while running the app, open the **Postman** and paste the api url for example `https://localhost:44302/`.
   - Now modify the url and write  `https://localhost:44302/api/Login/PostLoginDetails`. Because this is how I set up the route.
   - In the **Postman** go to **body** and select **x-wwww-form-urlencoded** as shown in the snippet.
     ![LoginJWTp](https://github.com/Shahariar-Rokon/ASP.NET-CORE-API-with-JWT/assets/116648090/e3affd23-d413-4359-8658-528c0409adba)
   - Now fill out the form using key-value pairs. The keys should be **EmailId** ,**FullName** and **password** with corresponding values **a@gmail.com**, **a** and **1234**. Note that the username 
     and password are prepopulated in the database. After completing this step, send a **Post** request in postman. This will result in display a valid token as as shown in the screenshot. 
     ![JWTtoken](https://github.com/Shahariar-Rokon/ASP.NET-CORE-API-with-JWT/assets/116648090/a4c497c5-89d4-48fe-97f1-93e6703b3997)
   - Now copy the token and head to the **Authorization** tab and enter authorization type as **Bearer Token** and paste the token in the token box.
     ![JWTGet](https://github.com/Shahariar-Rokon/ASP.NET-CORE-API-with-JWT/assets/116648090/1efd9276-e9f4-4a36-b0da-230579b87f7f)
   - Now do not click the **Send** button yet, just modify the url and write the api/controller name for example `https://localhost:44302/api/Employees`.
   - Now click the send button. This will authorize you through the JWT to the **GET** and will show some valid data.
   - Now it's time to post data. Head over to body section and select **form-data** tab. Now fill out the valuse as follows: **EmployeeName**, IsActive, JoinDate, ImageName, ImageFile and Experiences  **JSON** object **ImageFIle** which should be file 
     type. Make sure that the content type of all of them except **ImageFile** is application/json.
   - For example Employee should be like this
     ![JWTData](https://github.com/Shahariar-Rokon/ASP.NET-CORE-API-with-JWT/assets/116648090/52bbe1d4-4c6c-4ba5-8bc0-4ecb483b9af7)
   - Also make sure Experiences has data structure like JSON array `[{"Title":"A","Duration":5}]`
   - Select an image file from your desktop and give any name for your image file. If all things filled correctly the **Postman** should look like below. Next step is to post. Select **POST** in the postman and click send.
     ![JWTPost](https://github.com/Shahariar-Rokon/ASP.NET-CORE-API-with-JWT/assets/116648090/f2ce6900-ee7e-419e-a41a-dae6ac2fe1ce) 
   - Now make a **GET** request to test the post.
   - You can also **PUT** a request to update a data. Simply, add the id that you want to update at the end of the url for example, `https://localhost:44302/api/Employees/6` and send the data according to the format that I explained in the **POST** method. Also 
    don't forget to select the **PUT** method in the postman. Now click **SEND**.
    ![JWTPut](https://github.com/Shahariar-Rokon/ASP.NET-CORE-API-with-JWT/assets/116648090/d6ca6493-e2f0-4e9b-a657-5ab451d3f64b)
  - Note that the service is prepopulated and the token has a time limit. If token expires, you need to get another token. 
4. **Explore the code**: You can open the project in Visual Studio 2022 and explore the code. The project consists of **REST** api.

## Contributing

We welcome contributions from anyone who is interested in improving this project. Here are some ways you can contribute:

- Report bugs or suggest features by opening an issue.
- Fix bugs or implement features by submitting a pull request.
- Review pull requests and provide feedback.
- Write or update documentation, tests, or examples.
- Share your experience or feedback with the project.

## License

This project is licensed under the MIT License. See the LICENSE file for details.
