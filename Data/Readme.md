# Getting database ready for this demo

This demo relies on a database which is set up in SQLEXPRESS (Sql Server).



## Seeded mountain database

Tallest mountains in Norwegian municipialities - data from Kartverket.
The project MountainDataSet.Console contains a simple tool to create a 
json file from a available excel file from Kartverket for all the tallest 
mountains in the municipialites in Norway. 


Ran these commands:

``` bash
dotnet tool install --global dotnet-ef

dotnet ef migrations add InitialCreate
```


### Update database to latest migration for this demo 

Just run this command: 

``` bash
dotnet ef database update 
```
<hr />

Last update 27.12.2020 
