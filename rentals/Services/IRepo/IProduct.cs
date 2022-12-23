using rentals.Data.ModelsDTO;

namespace rentals.Services.IRepo
{
    public interface IProduct
    {
        public Task<ProductDTO> Create(ProductDTO objDTO);
        public Task<ProductDTO> Update(ProductDTO objDTO);
        public Task<int> Delete(int id);
        public Task<ProductDTO> Get(int id);
        public Task<IEnumerable<ProductDTO>> GetAll(string userId);
    }
}
