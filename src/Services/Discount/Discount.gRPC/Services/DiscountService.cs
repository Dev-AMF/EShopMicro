

using Discount.gRPC.Models;
using Microsoft.EntityFrameworkCore;

namespace Discount.gRPC.Services
{
    public class DiscountService(DiscountContext @Db, ILogger<DiscountService> logger) : DiscountProtoService.DiscountProtoServiceBase
    {
        public override async Task<CouponModel> GetDiscount(GetDiscountRequest request, ServerCallContext context)
        {
            var cuponFromDb = await @Db.Coupons.FirstOrDefaultAsync(x => x.ProductName == request.ProductName);

            if (cuponFromDb is null)
                cuponFromDb = new Coupon 

                { ProductName = request.ProductName , 
                  Amount = 0, 
                  Description = "No Discount!!"
                };

            logger.LogInformation("Discount is retrieved for ProductName : {productName}, Amount : {amount}", cuponFromDb.ProductName, cuponFromDb.Amount);

            var cuponToBeReturned = cuponFromDb.Adapt<CouponModel>();

            return cuponToBeReturned;
        }
        public override async Task<CouponModel> CreateDiscount(CreateDiscountRequest request, ServerCallContext context)
        {
            var couponToBeSaved = request.Coupon.Adapt<Coupon>();
            if(couponToBeSaved is null)
                throw new RpcException(new Status(StatusCode.InvalidArgument, "Invalid request object."));

            await Db.AddAsync(couponToBeSaved);
            await Db.SaveChangesAsync();

            logger.LogInformation("Discount is successfully created. ProductName : {ProductName}", couponToBeSaved.ProductName);

            var cuponToBeReturned = couponToBeSaved.Adapt<CouponModel>();
            return cuponToBeReturned;
            
        }
        public override async Task<CouponModel> UpdateDiscount(UpdateDiscountRequest request, ServerCallContext context)
        {
            var couponToBeSaved = request.Coupon.Adapt<Coupon>();
            if (couponToBeSaved is null)
                throw new RpcException(new Status(StatusCode.InvalidArgument, "Invalid request object."));

            Db.Update(couponToBeSaved);
            await Db.SaveChangesAsync();

            logger.LogInformation("Discount is successfully updated. ProductName : {ProductName}", couponToBeSaved.ProductName);

            var cuponToBeReturned = couponToBeSaved.Adapt<CouponModel>();
            return cuponToBeReturned;
        }
        public override async Task<DeleteDiscountResponse> DeleteDiscount(DeleteDiscountRequest request, ServerCallContext context)
        {
            var cuponFromDb = await @Db.Coupons.FirstOrDefaultAsync(x => x.ProductName == request.ProductName);

            if (cuponFromDb is null)
                throw new RpcException(new Status(StatusCode.NotFound, $"Discount with ProductName={request.ProductName} is not found."));

            Db.Coupons.Remove(cuponFromDb);
            await Db.SaveChangesAsync();

            logger.LogInformation("Discount is successfully deleted. ProductName : {ProductName}", request.ProductName);

            return new DeleteDiscountResponse { Success = true };
        }
    }
}
