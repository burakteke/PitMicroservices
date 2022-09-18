using AutoMapper;
using FreeCourses.Services.Catalog.Dtos;
using FreeCourses.Services.Catalog.Models;
using FreeCourses.Services.Catalog.Settings;
using FreeCourses.Shared.Dtos;
using MongoDB.Driver;
using System.Net;

namespace FreeCourses.Services.Catalog.Services
{
    internal class CategoryService: ICategoryService
    {
        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly IMapper _mapper;

        public CategoryService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _categoryCollection = database.GetCollection<Category>(databaseSettings.CategoryCollectionName);
            _mapper = mapper;
        }

        public async Task<Response<List<CategoryDto>>> GetAllAsync()
        {
            var categories = await _categoryCollection.Find(category => true).ToListAsync();
            return Response<List<CategoryDto>>.Success(_mapper.Map<List<CategoryDto>>(categories), (int)HttpStatusCode.OK);
        }

        public async Task<Response<CategoryDto>> CreateAsync(Category category)
        {
            await _categoryCollection.InsertOneAsync(category);
            return Response<CategoryDto>.Success(_mapper.Map<CategoryDto>(category), (int)HttpStatusCode.OK);
        }

        public async Task<Response<CategoryDto>> GetByIdAsync(string id)
        {
            var category = await _categoryCollection.Find<Category>(x => x.Id == id).FirstOrDefaultAsync();
            if(category == null) return Response<CategoryDto>.Fail("Category not found!", (int)HttpStatusCode.NotFound);

            return Response<CategoryDto>.Success(_mapper.Map<CategoryDto>(category), (int)HttpStatusCode.OK);
        }
    }
}
