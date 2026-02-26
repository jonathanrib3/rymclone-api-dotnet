using RymCloneApi.src.Domain.Entities;
using RymCloneApi.src.Persistence.Context.Interfaces;

namespace RymCloneApi.src.Persistence.Repositories.Reviews
{
  public class ReviewsRepository : Repository<Review>, IReviewsRepository
  {
    public ReviewsRepository(IAppDbContext context): base(context) { }
  }
}
