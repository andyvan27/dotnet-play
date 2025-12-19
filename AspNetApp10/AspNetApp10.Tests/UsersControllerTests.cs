using Xunit;
using AspNetApp10.Controllers;
using AspNetApp10.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

public class UsersControllerTests
{
    public UsersControllerTests()
    { // Clear static state before each test 
        UsersController.Users.Clear();
    }
    [Fact]
    public void GetUsers_ReturnsOkResult_WithList()
    {
        // Arrange
        var controller = new UsersController();

        // Act
        var result = controller.GetUsers() as OkObjectResult;

        // Assert
        Assert.NotNull(result);
        var users = Assert.IsType<List<UserDto>>(result.Value);
        Assert.Empty(users); // initially empty
    }

    [Fact]
    public void CreateUser_ReturnsCreatedResult()
    {
        // Arrange
        var controller = new UsersController();
        var newUser = new UserDto { Name = "Alice", Email = "alice@example.com" };

        // Act
        var result = controller.CreateUser(newUser) as CreatedAtActionResult;

        // Assert
        Assert.NotNull(result);
        var user = Assert.IsType<UserDto>(result.Value);
        Assert.Equal("Alice", user.Name);
        Assert.Equal("alice@example.com", user.Email);
        Assert.True(user.Id > 0);
    }

    [Fact]
    public void GetUser_ReturnsNotFound_WhenMissing()
    {
        // Arrange
        var controller = new UsersController();

        // Act
        var result = controller.GetUser(99);

        // Assert
        Assert.IsType<NotFoundResult>(result);
    }

    [Fact]
    public void UpdateUser_ReturnsOk_WhenExists()
    {
        // Arrange
        var controller = new UsersController();
        var newUser = new UserDto { Name = "Bob", Email = "bob@example.com" };
        controller.CreateUser(newUser);

        var updated = new UserDto { Name = "Bob Updated", Email = "bob.updated@example.com" };

        // Act
        var result = controller.UpdateUser(1, updated) as OkObjectResult;

        // Assert
        Assert.NotNull(result);
        var user = Assert.IsType<UserDto>(result.Value);
        Assert.Equal("Bob Updated", user.Name);
    }

    [Fact]
    public void DeleteUser_ReturnsNoContent_WhenExists()
    {
        // Arrange
        var controller = new UsersController();
        var newUser = new UserDto { Name = "Charlie", Email = "charlie@example.com" };
        controller.CreateUser(newUser);

        // Act
        var result = controller.DeleteUser(1);

        // Assert
        Assert.IsType<NoContentResult>(result);
    }
}
