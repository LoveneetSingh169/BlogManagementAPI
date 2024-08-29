# BlogManagementAPI

This project is a full-stack application for managing blog posts. It includes an ASP.NET Core API that handles the backend operations and an Angular frontend for user interaction. The application uses a JSON file (BlogData.Json) as a mock database for storing blog data.

## Features

## Backend API: Provides CRUD operations for blog posts.

* GET /api/BlogPost/Get: Retrieve all blogs.
* GET /api/BlogPost/{id}: Retrieve a specific blog by its ID.
* POST /api/BlogPost: Create a new blog.
* PUT /api/BlogPost/{id}: Update an existing blog.
* DELETE /api/BlogPost/{id}: Delete a blog.
## Frontend Application: Consumes the API and provides a user-friendly interface for managing blog posts.

* Create: Add new blog posts.
* Read: View all or specific blog posts.
* Update: Edit existing blog posts.
* Delete: Remove blog posts.

## Technologies Used

## Backend
  
- ASP.NET Core (.Net Core 8)
- RESTful API development
- Dependency Injection
- JSON file as a data store (BlogData.Json)
- AutoMapper: For mapping ViewModel/DTOs and models.
- NUnit: For unit testing.
  
## Frontend
* Angular 15
* Reactive Forms for handling form inputs.
* @Input and @Output directives for component communication.
* HttpClient for making HTTP requests to the backend API.

## Project Setup
## Prerequisites
* .NET SDK: .NET Core 8 SDK
* Node.js: Node.js (version 14.x or higher)
* Angular CLI: Install globally using npm install -g @angular/cli

## Backend Setup : BlogManagementAPI Project

* Clone the repository:

https://github.com/LoveneetSingh169/BlogManagementAPI.git

## Frontend Setup : BlogManagementUI (Angular project)

https://github.com/LoveneetSingh169/Blog.Management.UI.git

## Usage
 * View All Blogs: Navigate to the home page to see a list of all blog posts. (http://localhost:4200/blog/blog-list)
* Create a Blog: Use the "Add New Blog" button to open the form and submit a new blog.
* Edit a Blog: Click on a blog from the list to edit its content.
* Delete a Blog: Use the delete button next to a blog to remove it from the list.

## API Documentation
* GET /api/BlogPost: Returns a list of all blogs.
* GET /api/BlogPost/{id}: Returns a single blog by ID.
* POST /api/BlogPost: Adds a new blog. Requires a Username, DateCreated, and Text in the request body.
* PUT /api/BlogPost/{id}: Updates an existing blog. Requires Username, DateCreated, and Text.
* DELETE /api/BlogPost/{id}: Deletes a blog by ID.
