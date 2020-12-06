![Do some useless stuff](https://github.com/raphaelryazhapov/AdvertisingCompany/workflows/Do%20some%20useless%20stuff/badge.svg?branch=master)

## About

#### This is project of Adevrtising Company - there are several Advertisement block types and companies, which can by this blocks.
#### Advertisement blocks are divided to 3 big categories - TEXT, VOICE, VIDEO and each of them contains 3 subcategories - Small, Standart, Long.
#### Companies are also divided to 3 types - Mass, Affluent and VIP. Company can switch up it's type by buying more expensive blocks.

## The project is divided to 3 parts - SQL, Backend and Fronted.

### SQL
#### contains all definitions and primary filling for all tables, all needed stored procedures, triggers and scripts.
#### Tools - Microsoft SQL Server 2017, T-SQL

### Backend
#### contains all business logic and web REST API endpoints for project.
#### Tools - .Net Core 3.1, C#, ASP.NET Core Web API, Entity Framework Core, NLog, Swagger UI

### Frontend
#### contains all UI of project
#### Tools - JavaScript, Vue.js, Vue router, Vuetify


## Usage
### Run ASP.NET Core Web API Project - dotnet run --project Backend/Backend/Backend.Web.csproj
### Run Vue.js project - cd Frontent/vue.js/ && npm run serve
