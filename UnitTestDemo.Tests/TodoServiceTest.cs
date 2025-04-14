using System;
using Xunit;
using Moq;
using UnitTestDemoApplication.Services;
using UnitTestDemoApplication.Interfaces;
using Microsoft.AspNetCore.Identity;
using UnitTestDemoApplication.Models;
namespace UnitTestDemo.Tests;

public class TodoServiceTest
{
    // We nned to mock the actual database
    private readonly Mock<ITodoRepository> _mockRepo;
    private readonly TodoService _service;
    public TodoServiceTest()
    {
         // THis mimics my todorepostiory - database functionality that I want to mock.
        _mockRepo = new Mock<ITodoRepository>();
       // Using the mock repository in our servicesm file that we are testing
        _service = new TodoService(_mockRepo.Object);
    }
    //Getting Item

    //Adding Item
    [Fact]
public async Task AddTodoAsync_AddsItem()
{
    //Arrange
    //Setting up values
    TodoItem newItem = new() { Title  = "Test Adding", IsCompleted = false};
    // setting up our mock repository to return the new item
    _mockRepo.Setup(x => x.AddAsync(It.IsAny<TodoItem>())).ReturnsAsync(newItem);
    //Act
    // calll adding functionality
    var result = await _service.AddTodoAsync("Test Adding");
    //Assert
    Assert.Equal(newItem, result);
    Assert.Equal("Test Adding",result.Title);
    Assert.False(result.IsCompleted);
    Assert.NotNull(result);
}
    //Add an item, that it actually got added successfully
}
