﻿using AngularConsumer1.Models;
using FRED.Api.Core.ApiFacades;
using System.Collections.Generic;

namespace AngularConsumer1.Controllers
{
	public class ControllerBase : Microsoft.AspNetCore.Mvc.ControllerBase
	{
		#region constructors

		public ControllerBase()
		{
		}

		#endregion

		#region protected methods

		/// <summary>
		/// Sets api values in a result object. 
		/// </summary>
		/// <param name="api">The object containing api values.</param>
		/// <param name="result">The object in which the values are set.</param>
		protected void SetApiValues(IApiBase api, ApiData result)
		{
			var validationErrors = api.GetArguments().ValidationErrors;
			if (validationErrors != null)
			{
				result.ArgumentValidationErrors = new List<KeyValuePair<string, string>>();
				foreach (var error in validationErrors)
				{
					result.ArgumentValidationErrors.Add(new KeyValuePair<string, string>(error.Key, error.Value));
				}
			}
			result.FetchMessage = api.FetchMessage;
			result.Url = api.Url;
		}

		#endregion

	}
}
