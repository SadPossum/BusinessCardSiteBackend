# BusinessCardSiteBackendDemo

BusinessCardSiteBackendDemo is a web application that allows users to write reviews about you. The application has a REST API that provides CRUD (create, read, update, delete) functionality for reviews.

## Prerequisites
Before you begin, make sure you have the following prerequisites installed on your machine:

* [.NET Core SDK](https://dotnet.microsoft.com/download)
* A database management system (e.g. MySQL, PostgreSQL, SQL Server)

## Installation
To install the application, follow these steps:

1. Clone the repository:
```sh
git clone https://github.com/YOUR_USERNAME/BusinessCardSiteBackendDemo.git
```
2. Navigate to the project directory:
```sh
cd BusinessCardSiteBackendDemo
```
3. Create a database and update the connection string in the appsettings.json file:
```JSON
"ConnectionStrings": {
    "DefaultConnection": "YOUR_CONNECTION_STRING"
  }
```
4. Run the following command to apply database migrations:
```sh
dotnet ef database update
```
5. Run the application using the following command:
```sh
dotnet run
```
The application should now be running on http://localhost:5000.

## API Documentation
The API has the following endpoints:

### GET /review
Retrieves all reviews.

Example request:

```HTTP
GET /review
```
Example response:

```HTTP
200 OK
[
  {
    "id": 1,
    "authorName": "John Smith",
    "authorContacts": "john@example.com",
    "authorInformation": "I'm a software developer",
    "subjectDescription": "John is a great software developer",
    "subjectOpinion": "I highly recommend John for any software development projects"
  },
  {
    "id": 2,
    "authorName": "Jane Doe",
    "authorContacts": "jane@example.com",
    "authorInformation": "I'm a project manager",
    "subjectDescription": "John is a reliable and efficient software developer",
    "subjectOpinion": "I had the pleasure of working with John on a recent project and he consistently delivered high quality work on time"
  }
]
```
### GET /review/{id}
Retrieves a specific review by its id.

Example request:

```HTTP
GET /review/1
```
Example response:

```HTTP
200 OK
{
  "id": 1,
  "authorName": "John Smith",
  "authorContacts": "john@example.com",
  "authorInformation": "I'm a software developer",
  "subjectDescription": "John is a great software developer",
  "subjectOpinion": "I highly recommend John for any software development projects"
}
```
If no review with the specified id is found, this action returns a 404 Not Found response.

### POST /review
Creates a new review.

Example request:

```HTTP
POST /review
{
  "authorName": "Jane Doe",
  "authorContacts": "jane@example.com",
  "authorInformation": "I'm a project manager",
  "subjectDescription": "John is a reliable and efficient software developer",
  "subjectOpinion": "I had the pleasure of working with John on a recent project and he consistently delivered high quality work on time"
}
```
Example response:

```HTTP
201 Created
{
  "id": 3
}
```
### PUT /review/{id}
Updates an existing review with the specified id.

Example request:

```HTTP
PUT /review/1
{
  "authorName": "John Smith",
  "authorContacts": "john@gmail.com",
  "authorInformation": "I'm a software developer",
  "subjectDescription": "John is a great software developer",
  "subjectOpinion": "I highly recommend John for any software development projects"
}
```
Example response:

```HTTP
200 OK
```
If no review with the specified id is found, this action returns a 404 Not Found response.

### DELETE /review/{id}
Deletes an existing review with the specified id.

Example request:

```HTTP
DELETE /review/1
```
Example response:

```HTTP
204 No Content
```
If no review with the specified id is found, this action returns a 404 Not Found response.
