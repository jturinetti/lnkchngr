using lnkchngr.Models;

namespace lnkchngr.Services
{
	public interface IUrlEngine
	{
		UrlEngineResponseModel GenerateUrl(Uri url);

		UrlEngineResponseModel LookupUrl(string map);
	}

	public class UrlEngine : IUrlEngine
	{
		private readonly IUrlGenerationStrategy _strategy;
		private readonly IHttpContextAccessor _httpContextProvider;
		private readonly IHasher _hasher;
		// private readonly LinkChangerContext _context;

		public UrlEngine(IUrlGenerationStrategy strategy, IHttpContextAccessor httpContextProvider, IHasher hasher) //, LinkChangerContext context)
		{
			_strategy = strategy;
			_httpContextProvider = httpContextProvider;
			_hasher = hasher;
			// _context = context;            
		}

		public UrlEngineResponseModel GenerateUrl(Uri uri)
		{
			/*if (uri == null)
            {
                throw new ArgumentNullException(nameof(uri));
            }

            // generate unique url mapping
            var generatedUrlModel = _strategy.GenerateUniqueUrlMap(uri);

            // see if url already exists in database based on generated hash
            var existingRecord = _context.UrlMaps.FirstOrDefault(u => u.SourceUrlMapHash == generatedUrlModel.SourceUrlHash);
            if (existingRecord == null)
            {
                _context.UrlMaps.Add(new Data.Entities.UrlMap
                {
                    SourceUrl = generatedUrlModel.InputUrl.AbsoluteUri,
                    SourceUrlMapHash = generatedUrlModel.SourceUrlHash,
                    TargetUrlMap = generatedUrlModel.UrlMap,
                    TargetUrlMapHash = generatedUrlModel.UrlMapHash,
                    Created = DateTime.UtcNow
                });                
            }
            else
            {
                existingRecord.LastAccessed = DateTime.UtcNow;
            }            

            _context.SaveChanges();

            // build target url
            var uriBuilder = new UriBuilder(_httpContextProvider.HttpContext.Request.Scheme,
                    _httpContextProvider.HttpContext.Request.Host.Host,
                    (_httpContextProvider.HttpContext.Request.Host.Port.HasValue ? _httpContextProvider.HttpContext.Request.Host.Port.Value : 80),
                    generatedUrlModel.UrlMap);

            return new UrlEngineResponseModel
            {
                Url = uriBuilder.Uri
            };*/
			return null;    // TEMP
		}

		public UrlEngineResponseModel LookupUrl(string url)
		{
			/* if (url == null)
			 {
				 throw new ArgumentNullException(nameof(url));
			 }

			 if (url == string.Empty)
			 {
				 throw new ArgumentException("A URL must be provided.", nameof(url));
			 }

			 var mapHash = _hasher.HashMe(url);

			 var model = new UrlEngineResponseModel();
			 var result = _context.UrlMaps.FirstOrDefault(u => u.TargetUrlMapHash == mapHash);

			 if (result == null)
			 {
				 model.ErrorMessage = "No matching URL found.";
				 return model;
			 }

			 result.LastAccessed = DateTime.UtcNow;
			 _context.SaveChanges();

			 model.Url = new Uri(result.SourceUrl);
			 return model;*/
			return null;    // TEMP
		}
	}
}
