﻿using Newtonsoft.Json;
using Raven.Client.Documents;
using Raven.Client.Documents.Indexes;
using Raven.Client.Server;
using Raven.Client.Server.Operations;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Raven4CustomSerialization
{
	public static class RavenFactory
	{
		public static IDocumentStore Store => LazyStore.Value;

		private static readonly Lazy<IDocumentStore> LazyStore =
			new Lazy<IDocumentStore>(() =>
			{
				var store = CreateStore();
				IndexCreation.CreateIndexes(Assembly.GetEntryAssembly(), store);
				return store;
			});

		private static IDocumentStore CreateStore()
		{
			var store = new DocumentStore
			{
				Url = "http://localhost:8080",
				DefaultDatabase = "ProofOfConcept",
			};

			/*
			var doc = MultiDatabase.CreateDatabaseDocument("ProofOfConcept");
			var cdo = new CreateDatabaseOperation(doc);
			store.Admin.Server.SendAsync(cdo).Wait();
			*/

			store.Conventions.CustomizeJsonSerializer += serializer => serializer.Converters.Add(new JsonNodaMoneyConverter());

			store.Initialize();

			return store;
		}
	}
}
