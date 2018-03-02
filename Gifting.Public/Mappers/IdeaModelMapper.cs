using Gifting.Models;
using Gifting.Models.Entities;
using Gifting.Public.ViewModels.Ideas;

namespace Gifting.Public.Mappers
{
	public static class IdeaModelMapper
	{
		public static IdeaResponseViewModel MapToIdeaResponseViewModel(Idea idea)
		{
			return new IdeaResponseViewModel(
				idea.Id,
				idea.Name,
				idea.Description,
				idea.Image,
				idea.WhereToBuy,
				idea.OccasionId,
				idea.GranteeId,
				idea.DateCreated);
		}

		public static Idea BuildIdeaModel(CreateIdeaRequestViewModel viewModel)
		{
			return new Idea
			{
				Name = viewModel.Name,
				Description = viewModel.Description,
				GranteeId = viewModel.GranteeId,
				Image = viewModel.Image,
				OccasionId = viewModel.OccasionId,
				WhereToBuy = viewModel.WhereToBuy
			};
		}

		public static Idea BuildIdeaModel(UpdateIdeaRequestViewModel viewModel)
		{
			return new Idea
			{
				Id = viewModel.Id,
				Name = viewModel.Name,
				Description = viewModel.Description,
				GranteeId = viewModel.GranteeId,
				Image = viewModel.Image,
				OccasionId = viewModel.OccasionId,
				WhereToBuy = viewModel.WhereToBuy
			};
		}
	}
}
