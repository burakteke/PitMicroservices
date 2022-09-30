using Dapper;
using FreeCourses.Services.Discount.Models;
using FreeCourses.Shared.Dtos;
using Npgsql;
using System.Data;
using System.Net;

namespace FreeCourses.Services.Discount.Services
{
    public class DiscountService : IDiscountService
    {
        private readonly IConfiguration _configuration;

        private readonly IDbConnection _dbConnection;
        public DiscountService(IConfiguration configuration)
        {
            _configuration = configuration;
            _dbConnection = new NpgsqlConnection(_configuration.GetConnectionString("PostgreSql"));
        }

        public async Task<Response<NoContent>> Delete(int id)
        {
            var status = await _dbConnection.ExecuteAsync("delete from discount where id=@Id", new { Id = id });
            return status > 0 ? Response<NoContent>.Success((int)HttpStatusCode.NoContent) : Response<NoContent>.Fail("Discount not found", (int)HttpStatusCode.NotFound);
        }

        public async Task<Response<List<Models.Discount>>> GetAll()
        {
            var discounts = await _dbConnection.QueryAsync<Models.Discount>("select * from discount");
            return Response<List<Models.Discount>>.Success(discounts.ToList(), (int)HttpStatusCode.OK);
        }

        public async Task<Response<Models.Discount>> GetByCodeAndUserId(string code, string userId)
        {
            var discount = (await _dbConnection.QueryAsync<Models.Discount>("select * from discount where userid = @UserId and code = @Code", 
                new { UserId = userId, Code = code })).FirstOrDefault();
            if (discount == null) return Response<Models.Discount>.Fail("Discount not found", (int)HttpStatusCode.NotFound);
            return Response<Models.Discount>.Success(discount, (int)HttpStatusCode.OK);
        }

        public async Task<Response<Models.Discount>> GetById(int id)
        {
            var discount = (await _dbConnection.QueryAsync<Models.Discount>("select * from discount where id = @Id", new {Id = id})).SingleOrDefault();
            if (discount == null) return Response<Models.Discount>.Fail("Discount not found", (int)HttpStatusCode.NotFound);
            return Response<Models.Discount>.Success(discount, (int)HttpStatusCode.OK);
        }

        public async Task<Response<NoContent>> Save(Models.Discount discount)
        {
            var saveStasus = await _dbConnection.ExecuteAsync("insert into discount(userid, rate, code) values(@UserId, @Rate, @Code)",discount);
            if (saveStasus > 0) return Response<NoContent>.Success((int)HttpStatusCode.NoContent);
            else return Response<NoContent>.Fail("an error occured while adding",(int)HttpStatusCode.InternalServerError);
        }

        public async Task<Response<NoContent>> Update(Models.Discount discount)
        {
            var stasus = await _dbConnection.ExecuteAsync("update discount set userid = @UserId, rate = @Rate, code = @Code where id=@Id", discount);
            if (stasus > 0) return Response<NoContent>.Success((int)HttpStatusCode.NoContent);
            else return Response<NoContent>.Fail("Discount not found", (int)HttpStatusCode.InternalServerError);
        }
    }
}
