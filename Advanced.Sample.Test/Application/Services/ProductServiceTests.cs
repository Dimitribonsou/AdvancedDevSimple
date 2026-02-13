
using AdvancedDevSample.Application.Services;
using AdvancedDevSample.Domain.Entities;
using AdvancedDevSample.Domain.Interfaces.Products;
using Moq;
using Xunit;
namespace AdvancedDevSample.Test.Application.Services
{

    public class ProductServiceTests
    {
        private readonly Mock<IProductRepository> _repositoryMock;
        private readonly ProductService _service;

        public ProductServiceTests()
        {
            _repositoryMock = new Mock<IProductRepository>();
            _service = new ProductService(_repositoryMock.Object);
        }

        [Fact]
        public void ChangePrice_Should_Update_Product_Price()
        {
            // Arrange
            var productId = Guid.NewGuid();
            var product = new Product(productId, "Test", 100, true);

            _repositoryMock
                .Setup(r => r.GetProductById(productId))
                .Returns(product);

            // Act
            _service.ChangeProductPrice(productId, 200);

            // Assert
            Assert.Equal(200, product.Price);

            _repositoryMock.Verify(r => r.Update(product), Times.Once);
        }

        [Fact]
        public void ChangePrice_Should_Throw_When_Product_Not_Found()
        {
            // Arrange
            var productId = Guid.NewGuid();

            _repositoryMock
                .Setup(r => r.GetProductById(productId))
                .Returns((Product?)null);

            // Act & Assert
            Assert.Throws<Exception>(() => _service.ChangeProductPrice(productId, 200));
        }

        [Fact]
        public void Create_Should_Add_Product_To_Repository()
        {
            // Arrange
            string name = "New Product";
            decimal price = 150;
            bool isActive = true;

            // Act
            var id = _service.Create(name, price, isActive);

            // Assert
            _repositoryMock.Verify(r => r.Save(It.Is<Product>(p =>
                p.Name == name &&
                p.Price == price &&
                p.IsActive == isActive
            )), Times.Once);
        }

        [Fact]
        public void Delete_Should_Call_Delete_On_Repository()
        {
            // Arrange
            var productId = Guid.NewGuid();

            // Act
            _service.Delete(productId);

            // Assert
            _repositoryMock.Verify(r => r.Delete(productId), Times.Once);
        }
        [Fact]
        public void GetAll_Should_Return_All_Products()
        {
            // Arrange
            var products = new List<Product>
                {
                    new Product(Guid.NewGuid(), "P1", 100, true),
                    new Product(Guid.NewGuid(), "P2", 200, true)
                };

            _repositoryMock
                .Setup(r => r.GetAll())
                .Returns(products);

            // Act
            var result = _service.GetAll();

            // Assert
            Assert.Equal(2, result.Count());
            Assert.Contains(result, p => p.Name == "P1");
            Assert.Contains(result, p => p.Name == "P2");
        }
        [Fact]
        public void Update_Should_Modify_Product_And_Call_Repository()
        {
            // Arrange
            var productId = Guid.NewGuid();
            var product = new Product(productId, "OldName", 100, true);

            _repositoryMock
                .Setup(r => r.GetProductById(productId))
                .Returns(product);

            // Act
            _service.Update(productId, "NewName", 150, true);

            // Assert
            Assert.Equal("NewName", product.Name);
            Assert.Equal(150, product.Price);

            _repositoryMock.Verify(r => r.Update(product), Times.Once);
        }
        [Fact]
        public void GetById_Should_Return_Product_When_Found()
        {
            // Arrange
            var productId = Guid.NewGuid();
            var product = new Product(productId, "Test", 100, true);

            _repositoryMock
                .Setup(r => r.GetProductById(productId))
                .Returns(product);

            // Act
            var result = _service.GetById(productId);

            // Assert
            Assert.Equal(productId, result.Id);
        }
        [Fact]
        public void GetById_Should_Throw_When_Product_Not_Found()
        {
            // Arrange
            var productId = Guid.NewGuid();

            _repositoryMock
                .Setup(r => r.GetProductById(productId))
                .Returns((Product?)null);

            // Act & Assert
            Assert.Throws<Exception>(() => _service.GetById(productId));
        }


    }

}
