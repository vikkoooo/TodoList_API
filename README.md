# TodoList_API
[Guide](https://learn.microsoft.com/en-us/aspnet/core/tutorials/first-web-api?view=aspnetcore-8.0&tabs=visual-studio)  
## Assignment
Building a .NET Core Web API for the Todo List

Your task is to build a RESTful API using .NET Core that will serve as
the backend for the Todo list application you previously created in
React. This API will allow you to manage todos through HTTP requests,
enabling the full functionality of creating, reading, updating, and
deleting (CRUD) todos.

**Task** **Overview**

> 1\. **Create** **.NET** **Core** **Web** **API** **Project**
>
> Create a new .NET Core Web API project in Visual Studio
>
> 2\. **Design** **and** **Implement** **the** **Todo** **Model**
>
> Create a Todo Model Class:
>
> • Properties: Id, Title, IsCompleted, Timestamp, Author.
>
> • Use proper data types and annotations (e.g., \[Required\]
>
> 3\. **Create** **the** **Todo** **Controller** **(and** **context)**
>
> Use new Scaffolded Item, API controller with actions using
> EntityFramework
>
> CRUD out of the box
>
> Suggest you try to write the code yourself!!
>
> 4\. **Create** **Database**
>
> Open package manager console (Tools =\> Nuget package manager)
>
> Add-Migration “Migration Name” (Generates script)
>
> Update-DataBase (Runs script)
>
> Go to SQL object explorer and look at the created DB
>
> 5\. **Connect** **the** **API** **to** **Your** **React** **App**
>
> Replace the mock data in your React application with actual data from
> the API.
>
> Use fetchto make HTTP requests to the API.
>
> Ensure that all features from the React app are working with the
> backend API.
>
> 6\. **Implement** **Additional** **Features** **(Extra)**
>
> Add search functionality for finding Todos
>
> Be able to get Todos sorted from the API based on Timestamp or author
>
> Sort Todos according to prioritize level from the API


