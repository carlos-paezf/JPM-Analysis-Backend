
using System.ComponentModel.DataAnnotations;
using BackendJPMAnalysis.Models;

namespace BackendJPMAnalysis.DTO
{
    public abstract class ProductDTO : BaseDTO
    {
        [Key]
        public string Id { get; set; } = null!;

        [Required(ErrorMessage = "La propiedad `productName` es requerida")]
        public string ProductName { get; set; } = null!;

        public string? SubProduct { get; set; }
    }


    public class ProductSimpleDTO : ProductDTO
    {
        public ProductSimpleDTO(Product product)
        {
            Id = product.Id;
            ProductName = product.ProductName;
            SubProduct = product.SubProduct;
        }
    }


    public class ProductEagerDTO : ProductDTO
    {
        public ICollection<ClientSimpleDTO> Clients { get; set; }
        public ICollection<UserEntitlementSimpleDTO> UserEntitlements { get; set; }

        public ProductEagerDTO(Product product, ICollection<ClientSimpleDTO> clientDTOs, ICollection<UserEntitlementSimpleDTO> userEntitlementDTOs)
        {
            Id = product.Id;
            ProductName = product.ProductName;
            SubProduct = product.SubProduct;
            Clients = clientDTOs;
            UserEntitlements = userEntitlementDTOs;
        }
    }
}