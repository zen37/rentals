using rentals.Data.Models;
using rentals.Data.ModelsDTO;
using rentals.Services.IRepo;

using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace rentals.Services.Repo
{
    public class ProductRepo : IProduct
    {
        private readonly Data.ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public ProductRepo(Data.ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<ProductDTO> Create(ProductDTO objDTO)
        {
            var dt = DateTime.Now;
            var obj = _mapper.Map<ProductDTO, Product>(objDTO);

            var addedObj = _db.Products.Add(obj);
            await _db.SaveChangesAsync();

            return _mapper.Map<Product, ProductDTO>(addedObj.Entity);
        }

        public Task<int> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ProductDTO> Get(int id)
        {
            var obj = await _db.Products.FirstOrDefaultAsync(u => u.Id == id);
            if (obj != null)
            {
                return _mapper.Map<Product, ProductDTO>(obj);
            }
            return new ProductDTO();
        }

        public async Task<IEnumerable<ProductDTO>> GetAll(string userId)
        {
            if (userId != null && userId != "")
            {
                return _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDTO>>
                (_db.Products.Where(x => x.UserId == userId));
            }
            else { throw new NotImplementedException(); }
        }

        public async Task<ProductDTO> Update(ProductDTO objDTO)
        {
            var objFromDb = await _db.Products.FirstOrDefaultAsync(u => u.Id == objDTO.Id);
            if (objFromDb != null)
            {
                objFromDb.Name = objDTO.Name;

                _db.Products.Update(objFromDb);
                await _db.SaveChangesAsync();

                return _mapper.Map<Product, ProductDTO>(objFromDb);
            }
            return objDTO;
        }
    }
}
