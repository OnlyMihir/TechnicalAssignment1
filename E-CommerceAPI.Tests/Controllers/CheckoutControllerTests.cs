using E_CommerceAPI.Controllers;
using E_CommerceAPI.Dtos;
using E_CommerceAPI.Interfaces;
using E_CommerceAPI.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceAPI.Tests.Controllers
{
    public class CheckoutControllerTests
    {
        private readonly Mock<IProductInfo> _mockRepo;
        private readonly CheckoutController _controller;
        public CheckoutControllerTests()
        {
            _mockRepo = new Mock<IProductInfo>();
            _controller = new CheckoutController(_mockRepo.Object);
        }

        [Fact]
        public void Test1_ReturnsCalculatedTotalCheckoutPrice()
        {
            _mockRepo.Setup(repo => repo.GetAllProducts())
            .Returns(GetAllProductsMocked());
            _mockRepo.Setup(repo => repo.GetAllProductDiscountOffers())
            .Returns(GetAllProductDiscountOffersMocked());

            ItemsCheckoutRequestDto itemsCheckoutRequestDto = new ItemsCheckoutRequestDto();
            itemsCheckoutRequestDto.ItemIdList = new List<int> { 1, 1, 1 };

            var result = _controller.CalculateTotalCheckoutPrice(itemsCheckoutRequestDto);
            Assert.Equal(300, result.Result.Price);
        }

        [Fact]
        public void Test2_ReturnsCalculatedTotalCheckoutPrice()
        {
            _mockRepo.Setup(repo => repo.GetAllProducts())
            .Returns(GetAllProductsMocked());
            _mockRepo.Setup(repo => repo.GetAllProductDiscountOffers())
            .Returns(GetAllProductDiscountOffersMocked());

            ItemsCheckoutRequestDto itemsCheckoutRequestDto = new ItemsCheckoutRequestDto();
            itemsCheckoutRequestDto.ItemIdList = new List<int> { 2, 2 };

            var result = _controller.CalculateTotalCheckoutPrice(itemsCheckoutRequestDto);
            Assert.Equal(120, result.Result.Price);
        }

        [Fact]
        public void Test3_ReturnsCalculatedTotalCheckoutPrice()
        {
            _mockRepo.Setup(repo => repo.GetAllProducts())
            .Returns(GetAllProductsMocked());
            _mockRepo.Setup(repo => repo.GetAllProductDiscountOffers())
            .Returns(GetAllProductDiscountOffersMocked());

            ItemsCheckoutRequestDto itemsCheckoutRequestDto = new ItemsCheckoutRequestDto();
            itemsCheckoutRequestDto.ItemIdList = new List<int> { 1, 1, 1, 2, 2, 2, 2 };

            var result = _controller.CalculateTotalCheckoutPrice(itemsCheckoutRequestDto);
            Assert.Equal(540, result.Result.Price);
        }

        [Fact]
        public void Test4_ReturnsCalculatedTotalCheckoutPrice()
        {
            _mockRepo.Setup(repo => repo.GetAllProducts())
            .Returns(GetAllProductsMocked());
            _mockRepo.Setup(repo => repo.GetAllProductDiscountOffers())
            .Returns(GetAllProductDiscountOffersMocked());

            ItemsCheckoutRequestDto itemsCheckoutRequestDto = new ItemsCheckoutRequestDto();
            itemsCheckoutRequestDto.ItemIdList = new List<int> { 1, 2, 3, 4 };

            var result = _controller.CalculateTotalCheckoutPrice(itemsCheckoutRequestDto);
            Assert.Equal(360, result.Result.Price);
        }

        public async Task<List<ProductModel>> GetAllProductsMocked()
        {
            List<ProductModel> productModels = new List<ProductModel>();
            productModels.Add(new ProductModel { ProductId = 1, ProductName = "Item1", ProductUnitPrice = 200 });
            productModels.Add(new ProductModel { ProductId = 2, ProductName = "Item2", ProductUnitPrice = 80 });
            productModels.Add(new ProductModel { ProductId = 3, ProductName = "Item3", ProductUnitPrice = 50 });
            productModels.Add(new ProductModel { ProductId = 4, ProductName = "Item4", ProductUnitPrice = 30 });

            return productModels;
        }

        public async Task<List<ProductDiscountOfferModel>> GetAllProductDiscountOffersMocked()
        {
            List<ProductDiscountOfferModel> productDiscountOfferModels = new List<ProductDiscountOfferModel>();
            productDiscountOfferModels.Add(new ProductDiscountOfferModel { DiscountOfferId = 1, ProductId = 1, UnitQuantityToBePurchased = 3, DiscountedProductUnitPrice = 300 });
            productDiscountOfferModels.Add(new ProductDiscountOfferModel { DiscountOfferId = 2, ProductId = 2, UnitQuantityToBePurchased = 2, DiscountedProductUnitPrice = 120 });

            return productDiscountOfferModels;
        }
    }
}
