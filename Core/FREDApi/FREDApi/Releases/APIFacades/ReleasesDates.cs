﻿using FRED.Api.Releases.Arguments;
using FRED.Api.Releases.Data;
using FRED.Api.Core.ApiFacades;
using FRED.Api.Core.Requests;
using Newtonsoft.Json;
using System.Threading.Tasks;
using FRED.Api.Core.Arguments;

namespace FRED.Api.Releases.ApiFacades
{
	/// <summary>
	/// Provides a facade for consuming the fred/releases/dates API endpoint. Results are returned in a ReleasesDateContainer instance.
	/// </summary>
	public class ReleasesDates : ApiBase, IReleasesDates
	{
		#region properties

		/// <summary>
		/// Argument values used in a fetch. Argument names match those in the FRED API.
		/// </summary>
		public ReleaseDatesArguments Arguments { get; set; } = new ReleaseDatesArguments();

		#endregion

		#region constructors

		public ReleasesDates(IRequest request = null) : base(request)
		{
		}

		#endregion

		#region public methods

		/// <summary>
		/// Fetches data from a FRED service endpoint.
		/// </summary>
		/// <returns>
		/// A <see cref="ReleasesDateContainer"/> containing FRED data. 
		/// An abnormal fetch returns null and a message is available in the <see cref="FetchMessage"/> property.
		/// </returns>
		public new ReleasesDateContainer Fetch()
		{
			string json = base.Fetch();
			var result = JsonConvert.DeserializeObject<ReleasesDateContainer>(json);

			return result;
		}

		/// <summary>
		/// Fetches data from a FRED service endpoint asynchronously.
		/// </summary>
		/// <returns>
		/// A <see cref="ReleasesDateContainer"/> containing FRED data.
		/// An abnormal fetch returns null and a message is available in the <see cref="FetchMessage"/> property.
		/// </returns>
		public new async Task<ReleasesDateContainer> FetchAsync()
		{
			string json = await base.FetchAsync();
			var result = JsonConvert.DeserializeObject<ReleasesDateContainer>(json);

			return result;
		}

		#endregion

		#region protected methods

		protected override ArgumentsBase GetArguments()
		{
			return Arguments;
		}

		#endregion

	}

	/// <summary>
	/// Defines the interface for ReleasesDates types.
	/// </summary>
	public interface IReleasesDates : IApiBase
	{
		#region properties

		ReleaseDatesArguments Arguments { get; set; }

		#endregion

		#region public methods

		ReleasesDateContainer Fetch();

		Task<ReleasesDateContainer> FetchAsync();

		#endregion

	}

}
