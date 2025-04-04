using lnkchngr.Models;

namespace lnkchngr.Services
{
	public interface IUrlGenerationStrategy
	{
		UrlGenerationStrategyModel GenerateUniqueUrlMap(Uri uri);
	}

	public class HashUrlGenerationStrategy : IUrlGenerationStrategy
	{
		private readonly IHasher _hasher;

		public HashUrlGenerationStrategy(IHasher hasher)
		{
			_hasher = hasher;
		}

		public UrlGenerationStrategyModel GenerateUniqueUrlMap(Uri uri)
		{
			if (uri == null)
			{
				throw new ArgumentNullException(nameof(uri), "A valid Uri must be provided.");
			}

			var model = new UrlGenerationStrategyModel
			{
				InputUrl = uri
			};

			var hashCode = _hasher.HashMe(uri.AbsoluteUri);

			model.SourceUrlHash = hashCode;
			model.UrlMap = hashCode.ToString();
			model.UrlMapHash = _hasher.HashMe(hashCode.ToString());

			return model;
		}
	}
}
