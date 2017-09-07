﻿using Raven.Client;
using Raven.Client.Document;
using System;

namespace StoryGenerator.Persistance
{
    public static class DocumentStoreHolder
    {
        private static readonly Lazy<IDocumentStore> LazyStore =
            new Lazy<IDocumentStore>(() =>
            {
                var store = new DocumentStore
                {
                    Url = "http://localhost:8080",
                    DefaultDatabase = "GrailWarDb"
                };
                return store.Initialize();
            });

        public static IDocumentStore Store => LazyStore.Value;
    }
}
