using Core.Entites;

namespace Core.Specification
{
    public class ProductWithFilterForCountSpec : BaseSpecification<Product>
    {
        public ProductWithFilterForCountSpec(ProductSpecParams productSpecParams)
        :base( x => (string.IsNullOrEmpty(productSpecParams.Search) || x.Name.ToLower().Contains(productSpecParams.Search))
                    &&(!productSpecParams.BrandId.HasValue || x.ProductBrandId == productSpecParams.BrandId)
                    && (!productSpecParams.TypeId.HasValue || x.ProductTypeId == productSpecParams.TypeId))
        {
        }
    }
   
}