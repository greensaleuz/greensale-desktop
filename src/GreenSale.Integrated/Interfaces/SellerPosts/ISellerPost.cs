using GreenSale.Dtos.Dtos.SellerPost;
using GreenSale.ViewModels.Models.SellerPosts;

namespace GreenSale.Integrated.Interfaces.SellerPosts;

public interface ISellerPost
{
    public Task<List<SellerPost>> GetAllAsync();
    public Task<long> CountAsync();
    public Task<SellerGetById> GetByIdAsync(long postId);
    public Task<bool> CreateAsync(SellerPostCreate dto);
    public Task<List<SellerPost>> GetAllUserId(long userId);
    public Task<bool> DeleteAsync(long postId);
    public Task<bool> UpdateAsync(long postId, SellerPostUpdateDto dto);
    public Task<bool> ImageUpdateAsync(long imageId, string dto);
    public Task<SellerPostSearch> SearchAsync(string title);

}
