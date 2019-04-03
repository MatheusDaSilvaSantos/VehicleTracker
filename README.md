# SimpleBlog

What is the SimpleBlog Project?
=====================
this is an app for CRUD operations sample using .NET Core, DDD, CQRS pattern, layered architecture ,SignalR and MVC front end

## How to run these porject
to run these project, simply open the solution file you have to open by VS2017 and .Net Core SDK v2.2
then urn Update-Database in SimpleBlog.Infra.Data project and you have to start both projects SimpleBlog.UI.Web and SimpleBlog.Services.Api
it will run the api in this port
 ```sh
http://localhost:11937
```

also you can try the documentaion of api throw swagger 
 ```sh
http://localhost:11937/swagger
```
 and the UI web for add a new record and see the  notification after adding a post will run in this post 
 then you have to go to 
 ```sh
http://localhost:14491
```
finally, for real-time notification test, you can open the web UI into two different browser tabs
