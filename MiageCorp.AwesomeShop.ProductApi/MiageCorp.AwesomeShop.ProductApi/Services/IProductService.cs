using MiageCorp.AwesomeShop.ProductApi.Models;

namespace MiageCorp.AwesomeShop.ProductApi.Services;

public interface IProductService
{
    /**
     * Get a product by its id
     * @param id the id of the product
     * @return the product
     * @throws NotFoundException if the product is not found
     */
    ProductDTO Get(string Id);
    /**
     * Get all products
     * @return the list of products
     */
    IEnumerable<ProductDTO> GetAll();
    /**
     * Add a product
     * @param product the product to add
     * @return the product added
     * @throws AlreadyExistsException if the product already exists
     */
    ProductDTO Add(ProductDTO product);
    /**
     * Update a product
     * @param id the id of the product to update
     * @param product the product to update
     * @return the product updated
     * @throws NotFoundException if the product is not found
     * @throws AlreadyExistsException if the product already exists
     */
    ProductDTO Update(string id, ProductDTO product);
    /**
     * Delete a product
     * @param id the id of the product to delete
     * @throws NotFoundException if the product is not found
     */
    void Delete(string id);
}