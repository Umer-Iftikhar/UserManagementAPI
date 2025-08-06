using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations;
using UserManagementAPI.Middleware;
using UserManagementAPI.Models;


var builder = WebApplication.CreateBuilder(args);

// Register services (if needed later)
builder.Services.AddRouting();
builder.Services.AddEndpointsApiExplorer();

builder.Services.Configure<JsonOptions>(options =>
{
    options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
});

var app = builder.Build();


app.UseMiddleware<ErrorHandlingMiddleware>();

app.UseMiddleware<AuthenticationMiddleware>();

app.UseMiddleware<RequestResponseLoggingMiddleware>();


var users = new Dictionary<int, User>
{
    [1] = new User
    {
        Id = 1,
        FirstName = "Test",
        LastName = "User",
        Email = "test.user@example.com",
        Department = "Demo"
    }
};

// Basic health check endpoint
app.MapGet("/", context =>
{
    return context.Response.WriteAsync("User Management API is running.");
});

// GET all users
app.MapGet("/api/users", () =>
{
    return Results.Ok(users.Values);
});

// GET user by ID
app.MapGet("/api/users/{id}", (int id) =>
{
    try
    {
        if (!users.TryGetValue(id, out var user))
            return Results.NotFound($"User with ID {id} not found.");

        return Results.Ok(user);
    }
    catch (Exception ex)
    {
        return Results.Problem($"Unexpected error: {ex.Message}");
    }
});

// POST new user
app.MapPost("/api/users",  (User user) =>
{
    int nextId = users.Keys.DefaultIfEmpty(0).Max() + 1;

    var validationContext = new ValidationContext(user);
    var results = new List<ValidationResult>();
    if (!Validator.TryValidateObject(user, validationContext, results, true))
    {
        return Results.BadRequest(results.Select(r => r.ErrorMessage));
    }

    user.Id = nextId++;
    users[user.Id] = user;
    return Results.Created($"/api/users/{user.Id}", user);
});

// PUT update user
app.MapPut("/api/users/{id}", (int id, User updatedUser) =>
{
    if (updatedUser is null)
    {
        return Results.BadRequest("Updated user data is required.");
    }

    if (!users.TryGetValue(id, out var existingUser))
    {
        return Results.NotFound();
    }

    existingUser.FirstName = updatedUser.FirstName;
    existingUser.LastName = updatedUser.LastName;
    existingUser.Email = updatedUser.Email;
    existingUser.Department = updatedUser.Department;

    return Results.Ok(existingUser);
});

// DELETE user
app.MapDelete("/api/users/{id}", (int id) =>
{
    if (!users.ContainsKey(id))
        return Results.NotFound();

    users.Remove(id);
    return Results.NoContent();
});

app.Run();