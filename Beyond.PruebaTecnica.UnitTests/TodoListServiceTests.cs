using Beyond.PruebaTecnica.Abstractions.Repositories;
using Beyond.PruebaTecnica.Abstractions.Services;
using Beyond.PruebaTecnica.Core.Entities;
using Beyond.PruebaTecnica.Services;
using Moq;
using NUnit.Framework;

[TestFixture]
public class TodoListServiceTests
{
    private Mock<ITodoListRepository> _mockRepository;
    private ITodoList _service;

    [SetUp]
    public void SetUp()
    {
        // Crear el mock para el repositorio
        _mockRepository = new Mock<ITodoListRepository>();
        // Instanciar el servicio pasando el mock como dependencias
        _service = new TodoListService(_mockRepository.Object);
    }

    [Test]
    public void AddItem_ShouldCallAddMethod_Once()
    {
        // Arrange
        var id = 1;
        var title = "Test Todo Item";
        var description = "This is a test item";
        var category = "Work";

        // Act
        _service.AddItem(id, title, description, category);

        // Assert
        _mockRepository.Verify(r => r.GetById(id), Times.Once);
    }

    [Test]
    public void UpdateItem_ShouldCallUpdateMethod_Once()
    {
        // Arrange
        int id = 1;
        var newDescription = "Updated Description";

        // Configura el mock del repositorio para devolver un item cuando se llama a GetById
        var existingItem = new TodoItem(id, "Test Todo Item", "This is a test item", "Work");
        _mockRepository.Setup(r => r.GetById(id)).Returns(existingItem);

        // Act
        _service.UpdateItem(id, newDescription);

        // Assert
        // Verifica que GetById fue llamado exactamente una vez
        _mockRepository.Verify(r => r.GetById(id), Times.Once);


        // Verifica que la descripción del item ha sido actualizada
        Assert.AreEqual(newDescription, existingItem.Description);
    }


}

