using Core.Entites;

namespace Core.Specification
{
    public class GetProductsWithBrandsAndTypes:BaseSpecification<Product>
    {
        public GetProductsWithBrandsAndTypes(ProductSpecParams productSpecParams)
            :base( x => (string.IsNullOrEmpty(productSpecParams.Search) || x.Name.ToLower().Contains(productSpecParams.Search)
                         && (!productSpecParams.BrandId.HasValue || x.ProductBrandId == productSpecParams.BrandId )
                         && (!productSpecParams.TypeId.HasValue || x.ProductTypeId == productSpecParams.TypeId) ))
        {
            AddInclude(p => p.ProductBrand);
            AddInclude(p => p.ProductType);

            AddOrderBy(p => p.Name);
        
            ApplyPaging(productSpecParams.PageSize, productSpecParams.PageSize*(productSpecParams.PageIndex -1), true);

            switch (productSpecParams.Sort)
            {
                case "priceAsc":
                    AddOrderBy(p => p.Price);
                    break;
                case "priceDesc":
                    AddOrderByDesc(p => p.Price);
                    break;
                default:
                    AddOrderBy(p => p.Name);
                    break;
            }
        }

        public GetProductsWithBrandsAndTypes(int id):
            base(p => p.Id == id)
        {
            AddInclude(p => p.ProductBrand);
            AddInclude(p => p.ProductType);
        }
    }
}