// TodoListTests.cs
using Beyond.PruebaTecnica.Abstractions.Repositories;
using Beyond.PruebaTecnica.Abstractions.Services;
using Beyond.PruebaTecnica.Repositories;
using Beyond.PruebaTecnica.Services;
using NUnit.Framework;
using System;
using System.Linq;

namespace TodoApp.Tests
{
    public class TodoListTests
    {
        private ITodoListRepository _repository;
        private ITodoList _service;

        [SetUp]
        public void Setup()
        {
            _repository = new TodoListRepository();
            _service = new TodoListService(_repository);
        }

        [Test]
        public void AddItem_ShouldAddNewItem()
        {
            // Act
            _service.AddItem(1, "Test Item", "Test Description", "Work");

            // Assert
            var item = _repository.GetById(1);
            Assert.NotNull(item);
            Assert.AreEqual("Test Item", item.Title);
            Assert.AreEqual("Test Description", item.Description);
        }

        [Test]
        public void UpdateItem_ShouldUpdateDescription()
        {
            // Arrange
            _service.AddItem(1, "Test Item", "Test Description", "Work");

            // Act
            _service.UpdateItem(1, "Updated Description");

            // Assert
            var item = _repository.GetById(1);
            Assert.AreEqual("Updated Description", item.Description);
        }

        [Test]
        public void RemoveItem_ShouldRemoveItem()
        {
            // Arrange
            _service.AddItem(1, "Test Item", "Test Description", "Work");

            // Act
            _service.RemoveItem(1);

            // Assert
            var item = _repository.GetById(1);
            Assert.IsNull(item);
        }

        [Test]
        public void RegisterProgression_ShouldAddProgression()
        {
            // Arrange
            _service.AddItem(1, "Test Item", "Test Description", "Work");

            // Act
            _service.RegisterProgression(1, DateTime.Now, 50);

            // Assert
            var item = _repository.GetById(1);
            Assert.AreEqual(1, item.Progressions.Count);
            Assert.AreEqual(50, item.Progressions.First().Percent);
        }

        [Test]
        public void PrintItems_ShouldPrintItemsCorrectly()
        {
            // Arrange
            _service.AddItem(1, "Test Item 1", "Description 1", "Work");
            _service.AddItem(2, "Test Item 2", "Description 2", "Personal");

            // Act & Assert
            Assert.DoesNotThrow(() => _service.PrintItems());
        }
    }
}
