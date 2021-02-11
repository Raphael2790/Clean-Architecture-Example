using AutoMapper;
using CleanArchExample.Application.DTO;
using CleanArchExample.Application.Interfaces;
using CleanArchExample.Domain.Entities;
using CleanArchExample.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchExample.Application.Services
{
    public class ProductService : IProductService
    {
        private IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public ProductService(IMapper mapper, IProductRepository productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }
        public void Add(ProductDTO product)
        {
            var mapProduct = _mapper.Map<Product>(product);
            _productRepository.Add(mapProduct);
        }

        public async Task<ProductDTO> GetProductById(int? id)
        {
            var product = await _productRepository.GetProductById(id);
            var mapProduct = _mapper.Map<ProductDTO>(product);
            return mapProduct;
        }

        public async Task<IEnumerable<ProductDTO>> GetProducts()
        {
            var products = await _productRepository.GetProducts();
            return _mapper.Map<IEnumerable<ProductDTO>>(products);
        }

        public void Remove(int id)
        {
            _productRepository.Remove(id);
        }

        public void Update(ProductDTO product)
        {
            var mapProduct = _mapper.Map<Product>(product);
            _productRepository.Update(mapProduct);
        }
    }
}
