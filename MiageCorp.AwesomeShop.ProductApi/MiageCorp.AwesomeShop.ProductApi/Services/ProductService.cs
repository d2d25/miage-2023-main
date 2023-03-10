using System.Globalization;
using AutoMapper;
using MiageCorp.AwesomeShop.ProductApi.Config;
using MiageCorp.AwesomeShop.ProductApi.Models;
using MiageCorp.AwesomeShop.ProductApi.Services.Exception;

namespace MiageCorp.AwesomeShop.ProductApi.Services;

public class ProductService : IProductService
{
    private Mapper _mapper = MapperConfig.InitializeAutoMapper();
    
    private static List<Product> _products = new List<Product>()
    {
        new Product() { Id = Guid.NewGuid().ToString(), Label = "Produit 1",
            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit", Price = 20d },
        new Product() { Id = Guid.NewGuid().ToString(), Label = "Produit 2",
            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit", Price = 12d },
        new Product() { Id = Guid.NewGuid().ToString(), Label = "Produit 3",
            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit", Price = 99.99d },
        new Product() { Id = Guid.NewGuid().ToString(), Label = "Produit 4",
            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit", Price = 5d },
        new Product() { Id = Guid.NewGuid().ToString(), Label = "Produit 5",
            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit", Price = 55.55d }
    };

    /**
     * Get a product by its Id
     * @param Id
     * @return ProductDTO
     * @throws NotFoundException
     */
    public ProductDTO Get(string Id)
    {
        var product = _products.SingleOrDefault(p => p.Id == Id);
        if (product == null)
            throw new NotFoundException("Product with Id "+Id+" notfound");

        return _mapper.Map<ProductDTO>(product);

    }

    /**
     * Get all products
     * @return IEnumerable<ProductDTO>
     */
    public IEnumerable<ProductDTO> GetAll()
    {
        return _mapper.Map<IEnumerable<ProductDTO>>(_products);
    }

    /**
     * Add a product
     * @param productDto
     * @return ProductDTO
     * @throws AlreadyExistsException
     */
    public ProductDTO Add(ProductDTO productDto)
    {
        Product product = _mapper.Map<Product>(productDto);
        if (_products.Contains(product))
        {
            throw new AlreadyExistsException("Product with Id "+product.Id+" already exists");
        }
        product.Id = Guid.NewGuid().ToString();
        _products.Add(product);
        return _mapper.Map<ProductDTO>(product);
    }

    /**
     * Update a product
     * @param Id
     * @param productDto
     * @return ProductDTO
     * @throws NotFoundException
     * @throws AlreadyExistsException
     */
    public ProductDTO Update(string id, ProductDTO productDto)
    {
        var productToUpdate = _products.SingleOrDefault(p => p.Id == id);
        if (productToUpdate == null)
            throw new NotFoundException("Product with Id "+id+" notfound");
        Product product = _mapper.Map<Product>(productDto);
        if (_products.Contains(product))
        {
            throw new AlreadyExistsException("Product with Id "+product.Id+" already exists");
        }

        productToUpdate.Label = product.Label;
        productToUpdate.Description = product.Description;
        productToUpdate.Price = product.Price;

        return _mapper.Map<ProductDTO>(productToUpdate);
    }

    /**
     * Delete a product
     * @param Id
     * @throws NotFoundException
     */
    public void Delete(string id)
    {
        var productToDelete = _products.SingleOrDefault(p => p.Id == id);
        if (productToDelete == null)
            throw new NotFoundException("Product with Id "+id+" notfound");

        _products.Remove(productToDelete);
    }
}

