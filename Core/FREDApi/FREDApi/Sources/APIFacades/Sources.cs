﻿using AngularConsumer1.Sources.Arguments;
using AngularConsumer1.Sources.Data;
using AngularConsumer1.Core.ApiFacades;
using AngularConsumer1.Core.Requests;
using System.Threading.Tasks;
using AngularConsumer1.Core.Arguments;
using Newtonsoft.Json;

namespace AngularConsumer1.Sources.ApiFacades
{
	/// <summary>
	/// Provides a facade for consuming the fred/sources API endpoint. Results are returned in a SourcesContainer instance.
	/// </summary>
	public class Sources : ApiBase, ISources
	{
		#region properties

		/// <summary>
		/// Argument values used in a fetch. Argument names match those in the FRED API.
		/// </summary>
		public SourcesArguments Arguments { get; set; } = new SourcesArguments();

		#endregion

		#region constructors

		public Sources(IRequest request = null) : base(request)
		{
		}

		#endregion

		#region public methods

		/// <summary>
		/// Fetches data from a FRED service endpoint.
		/// </summary>
		/// <returns>
		/// A <see cref="SourcesContainer"/> containing FRED data. 
		/// An abnormal fetch returns null and a message is available in the <see cref="FetchMessage"/> property.
		/// </returns>
		public new SourcesContainer Fetch()
		{
			string json = base.Fetch();
			var result = JsonConvert.DeserializeObject<SourcesContainer>(json);

			return result;
		}

		/// <summary>
		/// Fetches data from a FRED service endpoint asynchronously.
		/// </summary>
		/// <returns>
		/// A <see cref="SourcesContainer"/> containing FRED data.
		/// An abnormal fetch returns null and a message is available in the <see cref="FetchMessage"/> property.
		/// </returns>
		public new async Task<SourcesContainer> FetchAsync()
		{
			string json = await base.FetchAsync();
			var result = JsonConvert.DeserializeObject<SourcesContainer>(json);

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
	/// Defines the interface for Sources types.
	/// </summary>
	public interface ISources : IApiBase
	{
		#region properties

		SourcesArguments Arguments { get; set; }

		#endregion

		#region public methods

		SourcesContainer Fetch();

		Task<SourcesContainer> FetchAsync();

		#endregion

	}

}
